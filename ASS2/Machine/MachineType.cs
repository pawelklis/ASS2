using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace ASS2
{
    public class MachineType : DataBaseStorageHelper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ModbusDriver Driver { get; set; }
        public RoundStatType RoundStat;
        public List<MachineStatusLogType> Logs;

        public DictType dict;
        public SortProgramType CurrentSortProgram;
        public RunType CurrentRun;
        //public List<FeederType> Feeders;
        public List<ParcelType> ParcelsOnRun;
        public TactSensorType TactSensor;
        public StopSensorType StopSensor;
        public SensorStartDetectionType StartDetectionSensor;
        public SensorStartParcelType StartParcelSensor;

        public FeederType Feeder1;

        public bool BeltRunning;

        private Timer StatTimer;
        public DataTable StatTable;
        private int StatParcelscount;

        public event EventHandler OnTacted;
        public event EventHandler OnStartParcelSensorRead;
        public event EventHandler<MachineLogEventArgs> OnLogAdded;

        int tactsensorread;
        int startdetectionsensorread;
        int startparcelread;
        int stopsensorread;

        public class MachineLogEventArgs
        {
            public MachineStatusLogType item;
        }

        public MachineType()
        {

        }

        public void InitMachine(int SortProgramID)
        {
            PerformanceType pc = new PerformanceType();
            pc.StartMeasure("InitMachine");

            try
            {
                this.BeltRunning = false;

                StatTable = new DataTable();
                StatTable.Columns.Add("Czas");
                StatTable.Columns.Add("Liczba przesyłek");
                int x = 30;
                for (int i = 0; i < 31; i++)
                {
                    StatTable.Rows.Add("-" + x, 0);
                    x -= 1;
                }

                StatTimer?.Stop();
                StatTimer = new Timer();
                StatTimer.Interval = 1000 * 60;
                StatTimer.Elapsed += StatTimer_Elapsed;
                StatTimer.Start();

                dict = DictType.Load<DictType>(this.Id);
                if (this.dict == null)
                {
                    if (this.Id == 0)
                        this.Save();
                    this.dict = new DictType();
                    dict.MachineId = this.Id;
                    dict.Save();
                }

                List<RunType> rl = RunType.LoadWhere<RunType>("machineid=" + this.Id + " and endtime='0001-01-01 00:00:00';");
                if (rl != null)
                    if (rl.Count > 0)
                        this.CurrentRun = rl[0];




                Driver = new ModbusDriver();
                Driver.ModbusConnected += Driver_ModbusConnected;
                Driver.ModbusDisconnected += Driver_ModbusDisconnected;
                //Driver.CoilValueChanged += Driver_ValueChanged1;
                Driver.ConnectClient("169.254.52.3", 502); //P153027-9000G8Y

                this.LampTestTurnOffAll();


                this.ParcelsOnRun = new List<ParcelType>();
                //this.Feeders = new List<FeederType>();
                foreach (var rs in this.dict.SerialConfigs)
                {
                    if (rs.Name.ToLower().Contains("skaner"))
                    {
                        Feeder1 = new FeederType(rs, this.dict.Stands, this.Driver, this.dict.FeederStartDetectionSensorTactNumber, ParcelsOnRun, this.dict.ParcelStopRunTactNumber, this);


                    }
                }


                TactSensor = new TactSensorType(this.Id, this.dict.TactsCount) { Address = 2, Id = Guid.NewGuid().ToString(), Name = SensorType.SensorName.tactsensor };
                StopSensor = new StopSensorType() { Address = 3, Id = Guid.NewGuid().ToString(), Name = SensorType.SensorName.stopsensor, TactNumber = this.dict.StopSensorTact };

                TactSensor.ValueChanged += TactSensor_ValueChanged;
                TactSensor.BeltStart += TactSensor_BeltStart;
                TactSensor.BeltStop += TactSensor_BeltStop;
                TactSensor.Counter.OnNewCirle += Counter_OnNewCirle;
                TactSensor.TactMissed += TactSensor_TactMissed;
                Task.Run(() => { TactSensor.Connect(); });
                Driver.TactSensor = TactSensor;
                

                StopSensor.ValueChanged += StopSensor_ValueChanged;
                Driver.StopSensor = StopSensor;

                SetSortProgram(SortProgramID);


                StartDetectionSensor = new SensorStartDetectionType() { Id = Guid.NewGuid().ToString(), Address = 0, Name = SensorType.SensorName.startdetectionsensor, Value = false, FeederIndex = 0 };
                StartParcelSensor = new SensorStartParcelType() { Id = Guid.NewGuid().ToString(), Address = 1, Name = SensorType.SensorName.startparcelsensor, Value = false, FeederIndex = 0 };
                StartDetectionSensor.ValueChanged += StartDetectionSensor_ValueChanged; ;
                StartParcelSensor.OnLenghtReaded += StartParcelSensor_OnLenghtReaded;
                StartParcelSensor.ValueChanged += StartParcelSensor_ValueChanged; ;
                Driver.StartDetectionSensor = StartDetectionSensor;
                Driver.StartParcelSensor = StartParcelSensor;

                //foreach(var d in this.dict.Directions)
                //{
                //    foreach(var it in d.Items)
                //    {
                //        it.ParcelTypes = "LW,LWPR,B,PXN,PP1,PPLUS,UK,P,PPR,BPR,PW,PP,PP2,PWPR,UP";
                //    }
                //}
                //this.dict.Save();

                this.Logs = new List<MachineStatusLogType>();
                Logs.Add(new MachineStatusLogType(MachineStatusLogType.MachineEventsLogs.Start_programu));
                this.RoundStat = new RoundStatType(TactSensor.Counter.CircleNumber, this.Id, this.CurrentSortProgram.Id);
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

            pc.StopMeasure();
            
        }



        public void SetSortProgram(int SortProgramID)
        {
            PerformanceType pc = new PerformanceType();
            pc.StartMeasure("SetSortProgram");
            SortProgramType sp = SortProgramType.Load<SortProgramType>(SortProgramID);
            try
            {
                foreach (var iii in sp.Items)
                {
                    if (iii.Direction != null)
                        iii.Direction = dict.Directions.Find(x => x.Id == iii.Direction.Id);
                }
                sp.Save();
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

            try
            {
                this.CurrentSortProgram = sp;
                if (sp == null)
                    sp = new SortProgramType();

                foreach (var i in sp.Items)
                {
                    i.Color = dict.Colors.Find(x => x.Name == i.Color.Name);
                }


                foreach (var item in sp.Items)
                {
                    this.dict.Stands[item.StandIndex].Items[item.DirectionIndex].Direction = item.Direction;
                    this.dict.Stands[item.StandIndex].Items[item.DirectionIndex].Color = item.Color;
                }

                this.dict.Stands.Last().Name = "Odrzuty";
                this.dict.Stands.Last().Items.Clear();
                this.dict.Stands.Last().Items.Add(new StandItemType() { Direction = new DirectionType() { Name = "Brak skanu" }, Color = dict.Colors[1], Lamp1OnTacts = dict.OdrzutyLamp1Tact });
                this.dict.Stands.Last().Items.Add(new StandItemType() { Direction = new DirectionType() { Name = "Brak danych w ZST" }, Color = dict.Colors[2], Lamp1OnTacts = dict.OdrzutyLamp1Tact });
                this.dict.Stands.Last().Items.Add(new StandItemType() { Direction = new DirectionType() { Name = "Brak w planie sortowania" }, Color = dict.Colors[3], Lamp1OnTacts = dict.OdrzutyLamp1Tact });
                this.dict.Stands.Last().Items.Add(new StandItemType() { Direction = new DirectionType() { Name = "" }, Color = dict.Colors[3], Lamp1OnTacts = dict.OdrzutyLamp1Tact });
                this.dict.Stands.Last().Items.Add(new StandItemType() { Direction = new DirectionType() { Name = "" }, Color = dict.Colors[3], Lamp1OnTacts = dict.OdrzutyLamp1Tact });
                this.dict.Stands.Last().Items.Add(new StandItemType() { Direction = new DirectionType() { Name = "" }, Color = dict.Colors[3], Lamp1OnTacts = dict.OdrzutyLamp1Tact });
                this.dict.Stands.Last().Items.Add(new StandItemType() { Direction = new DirectionType() { Name = "" }, Color = dict.Colors[3], Lamp1OnTacts = dict.OdrzutyLamp1Tact });


                foreach (var s in this.dict.Stands)
                {
                    s.SetLamps(this.dict.Lamps[s.Lamp1Index], this.dict.Lamps[s.Lamp2Index]);
                }

            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

            pc.StopMeasure();
        }

        private void StatTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Task.Run(() =>
            {



                for (int i = 0; i < StatTable.Rows.Count; i++)
                {

                    if (i + 1 < StatTable.Rows.Count)
                    {
                        StatTable.Rows[i][1] = StatTable.Rows[i + 1][1];

                    }

                }
                StatTable.Rows[30][1] = StatParcelscount * 60;



                StatParcelscount = 0;
            });
        }

        public async Task<int> AllSortedAsync()
        {
            return await AllSorted();
        }
        private async Task<int> AllSorted()
        {

            int all = 0;

            await Task.Run(() =>
            {
                try
                {
                    foreach (var s in this.dict.Stands)
                    {
                        foreach (var k in s.Items)
                        {
                            all += k.SortedParcels;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.SaveError(ex);
                }


            });

            return all;
        }
        public async Task<int> AllMissedAsync()
        {
            return await AllMissed();
        }
        private async Task<int> AllMissed()
        {

            int all = 0;

            await Task.Run(() =>
            {

                try
                {
                    foreach (var s in this.dict.Stands)
                    {
                        foreach (var k in s.Items)
                        {
                            all += k.MissedParcels;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.SaveError(ex);
                }


            });

            return all;
        }
        public async Task<DataTable> GetStandStats()
        {

            DataTable dt = new DataTable();
            await Task.Run(new Action(() =>
            {
                try
                {
                    dt.Columns.Add("Stanowisko");
                    dt.Columns.Add("Wysortowane");
                    dt.Columns.Add("Recyrkulacja");
                    dt.Columns.Add("Obciążenie");

                    double sum = 0;
                    foreach (var s in dict.Stands)
                    {
                        foreach (var k in s.Items)
                        {
                            sum += k.SortedParcels + k.MissedParcels;
                        }
                    }


                    foreach (var s in this.dict.Stands)
                    {
                        int sp = 0;
                        int m = 0;

                        foreach (var k in s.Items)
                        {
                            sp += k.SortedParcels;
                            m += k.MissedParcels;


                        }

                        double ob = ((sp + m) / sum);
                        if (double.IsNaN(ob) == true)
                            ob = 0;

                        dt.Rows.Add(s.Name, sp, m, Math.Round(ob, 2));
                    }

                    int sums = 0;
                    int sumr = 0;
                    double sump = 0;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int a = int.Parse(dt.Rows[i][1].ToString());
                        int b = int.Parse(dt.Rows[i][2].ToString());
                        try
                        {
                            double c = double.Parse(dt.Rows[i][3].ToString().Replace("%", ""));
                            sump += c;
                        }
                        catch (Exception)
                        {


                        }


                        sums += a;
                        sumr += b;

                    }



                    //dt.Rows.Add("Suma:", sums, sumr, sump);

                }
                catch (Exception ex)
                {
                    ErrorLog.SaveError(ex);
                }


            }));
            return dt;
        }

        private void Driver_ModbusDisconnected(object sender, EventArgs e)
        {
            Task.Run(new Action(() =>
            {
                try
                {
                    MachineStatusLogType l = new MachineStatusLogType(MachineStatusLogType.MachineEventsLogs.Sterowanie_rozłączono);
                    Logs.Add(l);

                    EventHandler<MachineLogEventArgs> handler = OnLogAdded;
                    MachineLogEventArgs args = new MachineLogEventArgs();
                    args.item = l;
                    handler?.Invoke(this, args);
                }
                catch (Exception ex)
                {
                    ErrorLog.SaveError(ex);
                }



            }));
        }

        private void Driver_ModbusConnected(object sender, EventArgs e)
        {
            Task.Run(new Action(() =>
            {
                try
                {
                    MachineStatusLogType l = new MachineStatusLogType(MachineStatusLogType.MachineEventsLogs.Sterowanie_połączono);
                    Logs.Add(l);

                    EventHandler<MachineLogEventArgs> handler = OnLogAdded;
                    MachineLogEventArgs args = new MachineLogEventArgs();
                    args.item = l;
                    handler?.Invoke(this, args);
                }
                catch (Exception ex)
                {
                    ErrorLog.SaveError(ex);
                }


            }));

        }

        private void Counter_OnNewCirle(object sender, EventArgs e)
        {
            Task.Run(new Action(() =>
            {

                try
                {
                    this.RoundStat.EndCircle(this.Logs);
                    this.RoundStat = new RoundStatType(TactSensor.Counter.CircleNumber, this.Id, this.CurrentSortProgram.Id);
                }
                catch (Exception ex)
                {
                    ErrorLog.SaveError(ex);
                }


            }));
        }

        private void StartParcelSensor_OnLenghtReaded(object sender, SensorStartParcelType.StartSensorEventArgs e)
        {
            //Task.Run(new Action(() => { 
            try
            {
                if (this.ParcelsOnRun.Count > 0)
                    //Task.Run(()=>{
                        ParcelsOnRun.Last().SetLenght((int)e.TimeValue.TotalMilliseconds);
                    //});

                Feeder1.StartParcelSensorEndReading();
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

        }

        private void StartParcelSensor_ValueChanged(object sender, ModbusDriver.ModbusValueEventArgs e)
        {

            try
            {
                SensorStartParcelType s = (SensorStartParcelType)sender;
                if (s.Value == false)
                {
                    StatParcelscount += 1;
                    Feeder1?.Startparcelsensor_ValueChanged(sender, e);
                    Task.Run(new Action(() =>
                    {

                        RoundStat.ParcelsCount += 1;
                        EventHandler handler = OnStartParcelSensorRead;
                        handler?.Invoke(this, null);
                    }));


                }
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

            startparcelread += 1;

        }

        private void StartDetectionSensor_ValueChanged(object sender, ModbusDriver.ModbusValueEventArgs e)
        {
            try
            {
               


                    if (this.CurrentRun == null)
                        this.StartStopRun(1);
                    if (this.CurrentRun.IsWorking() == false)
                        this.StartStopRun(1);
               
        
                SensorStartDetectionType s = (SensorStartDetectionType)sender;
                if (s.Value == false)
                    Feeder1?.Startdetectionsensor_ValueChanged(sender, e);
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

            startdetectionsensorread += 1;

        }

        private void StopSensor_ValueChanged(object sender, ModbusDriver.ModbusValueEventArgs e)
        {
            stopsensorread += 1;
            
            try
            {

                StopSensorType s = (StopSensorType)sender;
                if (s.Value == false)
                {
                    Task.Run(new Action(() => { 
                    foreach (var p in ParcelsOnRun)
                    {
                        if (p.CurrentTactNumber > StopSensor.TactNumber-2 && p.CurrentTactNumber < StopSensor.TactNumber+2)
                        {
                            if (p.DestinationStand.Name != "Odrzuty")// pomijaj odrzuty
                                p.NextRound();
                        }

                    }
                    }));
                }
            }

            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }


        }

        public  DataTable PArcelsAtLineTable()
        {

            DataTable dt = new DataTable();

           Task.Run(new Action(() =>
            {
                try
                {
                    dt.Columns.Add("Numer");
                    dt.Columns.Add("Stanowisko");
                    dt.Columns.Add("Kierunek");
                    dt.Columns.Add("Takt");
                    dt.Columns.Add("Takt docelowy");
                    dt.Columns.Add("Czas");
                    dt.Columns.Add("Długość");

                    foreach (var p in this.ParcelsOnRun)
                    {
                        //if (p.visible == true)
                        //{
                            TimeSpan ts = (p.CreateTime - DateTime.Now);
                            dt.Rows.Add(p.Number,
                                p.DestinationStand.Name,
                                p.DestinationStandItem.Direction.Name,
                                p.CurrentTactNumber,
                                p.DestinationStand.Lamp1.TactOnNumber,
                                Math.Round(ts.TotalMilliseconds, 0),
                                p.Lenght);
                        //}

                    }
                }

                catch (Exception ex)
                {
                    ErrorLog.SaveError(ex);
                }

            }));
            return dt;

        }

        private void TactSensor_TactMissed(object sender, EventArgs e)
        {
            Task.Run(new Action(() =>
            {

                try
                {
                    string description = DateTime.Now + ", Okr.:" + this.TactSensor.Counter.CircleNumber + ", Takt:" + this.TactSensor.Counter.TactNumber;
                    MachineStatusLogType l = new MachineStatusLogType(MachineStatusLogType.MachineEventsLogs.Brak_taktu);
                    Logs.Add(l);

                    EventHandler<MachineLogEventArgs> handler = OnLogAdded;
                    MachineLogEventArgs args = new MachineLogEventArgs();
                    args.item = l;
                    handler?.Invoke(this, args);
                }
                catch (Exception ex)
                {
                    ErrorLog.SaveError(ex);
                }


            }));
        }
        private void TactSensor_BeltStop(object sender, EventArgs e)
        {
            this.BeltRunning = false;
            Task.Run(new Action(() =>
            {

                try
                {
                    if (Logs.Last().Event != MachineStatusLogType.MachineEventsLogs.Przenośnik_zatrzymany.ToString())
                    {
                        string description = DateTime.Now + ", Okr.:" + this.TactSensor.Counter.CircleNumber + ", Takt:" + this.TactSensor.Counter.TactNumber;
                        MachineStatusLogType l = new MachineStatusLogType(MachineStatusLogType.MachineEventsLogs.Przenośnik_zatrzymany);
                        Logs.Add(l);

                        EventHandler<MachineLogEventArgs> handler = OnLogAdded;
                        MachineLogEventArgs args = new MachineLogEventArgs();
                        args.item = l;
                        handler?.Invoke(this, args);
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.SaveError(ex);
                }



            }));
        }

        private void TactSensor_BeltStart(object sender, EventArgs e)
        {
            this.BeltRunning = true;
            Task.Run(new Action(() =>
            {

                try
                {
                    if (Logs.Last().Event != MachineStatusLogType.MachineEventsLogs.Przenośnik_uruchomiony.ToString())
                    {
                        MachineStatusLogType l = new MachineStatusLogType(MachineStatusLogType.MachineEventsLogs.Przenośnik_uruchomiony);
                        Logs.Add(l);

                        EventHandler<MachineLogEventArgs> handler = OnLogAdded;
                        MachineLogEventArgs args = new MachineLogEventArgs();
                        args.item = l;
                        handler?.Invoke(this, args);
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.SaveError(ex);
                }



            }));
        }

        private void TactSensor_ValueChanged(object sender, ModbusDriver.ModbusValueEventArgs e)
        {

            PerformanceType pc = new PerformanceType();
            pc.StartMeasure("tactOn");

            tactsensorread += 1;
            
            try
            {
                TactSensorType s = (TactSensorType)sender;
                if (s.Value == false)
                {
                    TactSensor.Counter.AddTact();

                    try
                    {

                        Task.Run(new Action(() =>
                        {
                            for (int i = 0; i < ParcelsOnRun.Count; i++)
                            {
                                ParcelsOnRun[i].AddTact(dict.TactsCount);
                            }
                        }));
                    }
                    catch (Exception ex)
                    {


                    }
                    //Console.WriteLine("tact" + " | " + TactSensor.ValueChangedTime.ToString() + " | " + TactSensor.TactLenghtTime.TotalMilliseconds.ToString());
                    Tacted();
                    EventHandler handler = OnTacted;
                    handler?.Invoke(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

            pc.StopMeasure();
        }


        private ColorType GetColor(ColorType.ColorsList colorname)
        {
            return dict.Colors.Find(x => x.Name == colorname);
        }


        public void LampTest()
        {
            Task.Run(new Action(() => { }));
            try
            {
                foreach (var s in this.dict.Stands)
                {
                    s.Lamp1.LightOn(this.dict.Colors[7], this.Driver);
                    System.Threading.Thread.Sleep(500);

                    foreach (var c in this.dict.Colors)
                    {
                        if (c.Name != ColorType.ColorsList.Żółty)
                        {
                            s.Lamp2.LightOn(c, this.Driver);
                            System.Threading.Thread.Sleep(500);
                        }
                    }
                }

                foreach (var s in this.dict.Stands)
                {
                    s.Lamp1.LightOff(this.Driver);
                    System.Threading.Thread.Sleep(500);
                    s.Lamp2.LightOff(this.Driver);
                    System.Threading.Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

        }
        public void LampTestSingleOn()
        {
            try
            {
                foreach (var s in this.dict.Stands)
                {
                    s.Lamp1.LightOn(this.dict.Colors[7], this.Driver);
                    System.Threading.Thread.Sleep(500);
                    s.Lamp1.LightOff(this.Driver);
                    foreach (var c in this.dict.Colors)
                    {
                        if (c.Name != ColorType.ColorsList.Żółty)
                        {
                            s.Lamp2.LightOn(c, this.Driver);
                            System.Threading.Thread.Sleep(500);
                            s.Lamp2.LightOff(this.Driver);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }



        }
        public void LampTestTurnOnAll()
        {
            Task.Run(new Action(() => { }));
            try
            {
                List<bool> lv = new List<bool>();
                for (int i = 0; i < 64; i++)
                {
                    lv.Add(true);
                }


                this.Driver.WriteCoils(0, lv.ToArray());
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }



        }
        public void LampTestTurnOffAll()
        {
            try
            {
                List<bool> lv = new List<bool>();
                for (int i = 0; i < 64; i++)
                {
                    lv.Add(false);
                }


                this.Driver.WriteCoils(0, lv.ToArray());
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }




        }

        private async void Tacted()
        {
            await Task.Run(new Action(() =>
             {

                 PerformanceType pc = new PerformanceType();
                 pc.StartMeasure("Tacted");
                 try
                 {
                     foreach (var s in dict.Stands)
                     {

                         foreach (var item in s.Items)
                         {
                             if (item.Lamp1OnTacts > 0)
                             {
                                 item.Lamp1OnTacts -= 1;

                                 if (item.Lamp1IsOn == false)
                                 {
                                     item.Lamp1IsOn = true;
                                     //kod zapalenia lamki
                                     s.Lamp1.LightOn(GetColor(ColorType.ColorsList.Żółty), this.Driver);
                                     //Console.WriteLine("Mryg " + item.Direction.Name + " " + item.Color.Name);
                                 }
                                 else
                                 {
                                     item.Lamp1IsOn = false;
                                     //kod zgaszenia lampki
                                     s.Lamp1.LightOff(this.Driver);
                                 }
                             }
                             else
                             {
                                 if (item.Lamp1IsOn == true)
                                 {
                                     item.Lamp1IsOn = false;
                                     //kod zgaszenia lampki
                                     s.Lamp1.LightOff(this.Driver);
                                 }

                             }
                         }
                     }


                     Task.Run(() =>
                     {
                         if (RoundStat == null)
                             RoundStat = new RoundStatType(this.Driver.TactSensor.Counter.CircleNumber, this.Id, this.CurrentSortProgram.Id);
                         RoundStat.AddItem(TactSensor.Counter.TactNumber, startdetectionsensorread, startparcelread, stopsensorread, tactsensorread, (int)TactSensor.TactLenghtTime.TotalMilliseconds);
                         tactsensorread = 0;
                         startdetectionsensorread = 0;
                         startparcelread = 0;
                         stopsensorread = 0;
                     });
                 }
                 catch (Exception ex)
                 {
                     ErrorLog.SaveError(ex);
                 }

                 //mruganie lampki pierwszej

                 pc.StopMeasure();
             }));
        }



        private void Feeder_OnParcelStartRun(object sender, FeederType.FeederEventArgs e)
        {
            try
            {
                this.ParcelsOnRun.Add(e.parcel);
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

        }

        public void StartStopRun(int SortProgramId)
        {
            try
            {
                if (this.CurrentRun == null)
                {
                    RunType r = new RunType();
                    r.StartTime = DateTime.Now;
                    r.MachineId = this.Id;
                    r.SortProgramId = SortProgramId;
                    r.Save();
                    this.CurrentRun = r;
                    //this.CurrentSortProgram = SortProgramType.Load<SortProgramType>(SortProgramId);
                    SetSortProgram(SortProgramId);
                }
                else
                {
                    if (this.CurrentRun.IsWorking() == true)
                    {
                        this.CurrentRun.EndTime = DateTime.Now;
                        this.CurrentRun.Save();

                        RunStatType RunStat = new RunStatType(this.CurrentRun, this.dict.Stands, this.Id, this.TactSensor.Counter.CircleNumber);

                        this.CurrentRun = null;


                    }
                    else
                    {
                        this.CurrentRun = new RunType();
                        this.CurrentRun.StartTime = DateTime.Now;
                        this.CurrentRun.MachineId = this.Id;
                        this.CurrentRun.SortProgramId = SortProgramId;
                        this.CurrentRun.Save();
                        //this.CurrentSortProgram = SortProgramType.Load<SortProgramType>(SortProgramId);
                        SetSortProgram(SortProgramId);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

        }







        public DataTable PrintSettings()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Stanowisko");
            dt.Columns.Add("Kierunek");
            dt.Columns.Add("Zakres PIN od");
            dt.Columns.Add("Zakres PIN do");
            dt.Columns.Add("Kolor");
            dt.Columns.Add("Sygnał Koloru");


            foreach (var s in this.dict.Stands)
            {
                int i = 0;
                foreach (var item in s.Items)
                {
                    foreach (var c in this.dict.Colors)
                    {
                        dt.Rows.Add(s.Name, i.ToString(), s.Lamp1.Address, s.Lamp2.Address + 5, c.Name.ToString(), c.ValuesString(s.Lamp1.Address));

                    }
                    i++;
                }
            }

            return dt;

        }


        public void StressSimulation(bool tacting)
        {
            try
            {
                List<string> numery;//symulacja
                numery = new List<string>();//symulacja
                numery.Add("EE922075416PL");//symulacja
                numery.Add("EE922177962PL");//symulacja
                numery.Add("EE922182239PL");//symulacja
                numery.Add("EE922170845PL");//symulacja
                numery.Add("EE922180706PL");//symulacja
                numery.Add("EE922060819PL");//symulacja
                numery.Add("EE922102584PL");//symulacja
                numery.Add("EE922204416PL");//symulacja
                numery.Add("EE922050079PL");//symulacja
                numery.Add("EE922135809PL");//symulacja
                numery.Add("EE922062647PL");//symulacja
                numery.Add("EE922051131PL");//symulacja
                numery.Add("EE922093335PL");//symulacja
                numery.Add("EE922181304PL");//symulacja
                numery.Add("EE922173210PL");//symulacja
                numery.Add("EE922074693PL");//symulacja
                numery.Add("EE922106714PL");//symulacja
                numery.Add("EE922169365PL");//symulacja
                numery.Add("EE922218675PL");//symulacja
                numery.Add("EE922148161PL");//symulacja
                numery.Add("EE922057845PL");//symulacja
                numery.Add("EE922121314PL");//symulacja
                numery.Add("EE922054610PL");//symulacja
                numery.Add("EE921783550PL");//symulacja
                numery.Add("EE354118933PL");//symulacja
                numery.Add("EE579107203PL");//symulacja
                numery.Add("EE263547297PL");//symulacja
                numery.Add("EE572467215PL");//symulacja
                numery.Add("EE922227669PL");//symulacja
                numery.Add("EE505167054PL");//symulacja
                numery.Add("EE458662065PL");//symulacja
                numery.Add("EE552383508PL");//symulacja
                numery.Add("EE552383508PL");//symulacja
                numery.Add("EE566046219PL");//symulacja
                numery.Add("EE566046222PL");//symulacja
                numery.Add("EE584722967PL");//symulacja
                numery.Add("EE923041918PL");//symulacja
                numery.Add("EE572019084PL");//symulacja
                numery.Add("EE572467238PL");//symulacja
                numery.Add("EE585124523PL");//symulacja
                numery.Add("EE541280710PL");//symulacja
                numery.Add("EE585072256PL");//symulacja

                if (tacting == true)
                {
                  Timer tm = new Timer();
                        tm.Interval = 500;
                        tm.Elapsed += Tm_Elapsed;
                        tm.Start();
                }
      



                Task.Run(new Action(() =>
                {
                    int numi = 0;
                    for (int i = 0; i < 7790; i++)
                    {
                        System.Threading.Thread.Sleep(500);
                        this.Driver.StartDetectionSensor.Value = true;
                        this.Driver.StartDetectionSensor.Value = false;
                        System.Threading.Thread.Sleep(300);
                        if (this.Feeder1.Parcels.Count > 0)
                        {
                            Feeder1.Scanned(numery[numi]);
                        }

                    //  this.Feeder1.Parcels[0].SetNumber(numery[numi], this.dict.Stands);
                    System.Threading.Thread.Sleep(1000);


                        this.Driver.StartParcelSensor.Value = true;
                        this.Driver.StartParcelSensor.Value = false;


                        var parcel = this.ParcelsOnRun.Find(x => x.DestinationStandItem.Direction.Name == "Brak skanu");
                        if (parcel != null)
                        {
                            if (parcel.CurrentTactNumber == this.dict.StopSensorTact)
                            {
                                this.Driver.StopSensor.Value = true;
                                this.Driver.StopSensor.Value = false;
                            }
                        }




                        if (this.ParcelsOnRun.Count > 0)
                            this.ParcelsOnRun.Last().SetLenght(1200);

                        numi++;
                        if (numi > numery.Count - 1)
                            numi = 0;

                    }
                }));
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

        }

        private void Tm_Elapsed(object sender, ElapsedEventArgs e)
        {
            //Console.WriteLine(this.TactSensor.TactLenghtTime.TotalMilliseconds + " " + this.Feeder1.Parcels.Count + " " + this.ParcelsOnRun.Count);

            this.Driver.TactSensor.Value = true;
            this.Driver.TactSensor.Value = false;

        }
    }
}
