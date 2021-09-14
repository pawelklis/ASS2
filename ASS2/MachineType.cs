using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public class MachineType : DataBaseStorageHelper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ModbusDriver Driver { get; set; }

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

        public event EventHandler OnTacted;
        public MachineType()
        {

        }

        public void InitMachine(int SortProgramID)
        {
            this.BeltRunning = false;

    

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
            //Driver.CoilValueChanged += Driver_ValueChanged1;
            Driver.ConnectClient("169.254.52.3", 502); //P153027-9000G8Y

            this.LampTestTurnOffAll();

            SortProgramType sp = SortProgramType.Load<SortProgramType>(SortProgramID);

            this.CurrentSortProgram = sp;
            if (sp == null)
                sp = new SortProgramType();

            foreach(var i in sp.Items)
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

            this.ParcelsOnRun = new List<ParcelType>();
            //this.Feeders = new List<FeederType>();
            foreach (var rs in this.dict.SerialConfigs)
            {
                if (rs.Name.ToLower().Contains("skaner"))
                {
                    Feeder1 = new FeederType(rs, this.dict.Stands, this.Driver, this.dict.FeederStartDetectionSensorTactNumber, ParcelsOnRun, this.dict.ParcelStopRunTactNumber);
                  

                }
            }


            TactSensor = new TactSensorType(this.Id, this.dict.TactsCount) { Address = 10, Id = Guid.NewGuid().ToString(), Name = SensorType.SensorName.tactsensor };
            StopSensor = new StopSensorType() { Address = 11, Id = Guid.NewGuid().ToString(), Name = SensorType.SensorName.stopsensor, TactNumber=this.dict.StopSensorTact };

            TactSensor.ValueChanged += TactSensor_ValueChanged;
            TactSensor.BeltStart += TactSensor_BeltStart;
            TactSensor.BeltStop += TactSensor_BeltStop;
            Driver.TactSensor = TactSensor;

            StopSensor.ValueChanged += StopSensor_ValueChanged;
            Driver.StopSensor = StopSensor;




            StartDetectionSensor = new SensorStartDetectionType() { Id = Guid.NewGuid().ToString(), Address = 8, Name = SensorType.SensorName.startdetectionsensor, Value = false, FeederIndex=0 };
            StartParcelSensor = new SensorStartParcelType() { Id = Guid.NewGuid().ToString(), Address = 9, Name = SensorType.SensorName.startparcelsensor, Value = false, FeederIndex = 0 };
            StartDetectionSensor.ValueChanged += StartDetectionSensor_ValueChanged; ;
            StartParcelSensor.OnLenghtReaded += StartParcelSensor_OnLenghtReaded;
            StartParcelSensor.ValueChanged += StartParcelSensor_ValueChanged; ;
            Driver.StartDetectionSensor = StartDetectionSensor;
            Driver.StartParcelSensor = StartParcelSensor;


            foreach (var s in this.dict.Stands)
            {
                s.SetLamps(this.dict.Lamps[s.Lamp1Index], this.dict.Lamps[s.Lamp2Index]);
            }
        }

        private void StartParcelSensor_OnLenghtReaded(object sender, SensorStartParcelType.StartSensorEventArgs e)
        {
            //Task.Run(new Action(() => { 
            if (this.ParcelsOnRun.Count > 0)
                ParcelsOnRun.Last().SetLenght((int)e.TimeValue.TotalMilliseconds);//}));
        }

        private void StartParcelSensor_ValueChanged(object sender, ModbusDriver.ModbusValueEventArgs e)
        {
            //Task.Run(new Action(() => { 
            SensorStartParcelType s = (SensorStartParcelType)sender;
            if (s.Value == true)
                Feeder1?.Startparcelsensor_ValueChanged(sender, e);//}));
        }

        private void StartDetectionSensor_ValueChanged(object sender, ModbusDriver.ModbusValueEventArgs e)
        {
            //Task.Run(new Action(() => { 
            SensorStartDetectionType s = (SensorStartDetectionType)sender;
            if (s.Value == false)
                Feeder1?.Startdetectionsensor_ValueChanged(sender, e);//}));
        }

        private void StopSensor_ValueChanged(object sender, ModbusDriver.ModbusValueEventArgs e)
        {
            //Task.Run(new Action(() => { 
            StopSensorType s = (StopSensorType)sender;
            if (s.Value == false)
            {
                foreach (var p in ParcelsOnRun)
                {
                    if (p.CurrentTactNumber == StopSensor.TactNumber)
                    {
                        p.NextRound();
                    }
                }
            }
            //}));
        }

        public async Task<DataTable> PArcelsAtLineTable()
        {
  
            DataTable dt = new DataTable();


            dt.Columns.Add("Numer");
            dt.Columns.Add("Stanowisko");
            dt.Columns.Add("Kierunek");
            dt.Columns.Add("Takt");
            dt.Columns.Add("Takt docelowy");
            dt.Columns.Add("Czas");
            dt.Columns.Add("Długość");

            foreach (var p in this.ParcelsOnRun)
            {
                TimeSpan ts = (p.CreateTime - DateTime.Now);
                dt.Rows.Add(p.Number,
                    p.DestinationStand.Name,
                    p.DestinationStandItem.Direction.Name,
                    p.CurrentTactNumber,
                    p.DestinationStand.Lamp1.TactOnNumber,
                    Math.Round(ts.TotalMilliseconds, 0),
                    p.Lenght);
            }

            return dt;
           
        }
        public async Task<DataTable> StandStatsTable()
        {

            DataTable dt = new DataTable();


            dt.Columns.Add("Stanowisko");           
            dt.Columns.Add("Wysortowane");
            dt.Columns.Add("Recyrkulacja");
            dt.Columns.Add("Obciążenie");

            double sum = 0;
            foreach(var s in dict.Stands)
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

                foreach(var k in s.Items)
                {
                    sp = k.SortedParcels;
                    m = k.MissedParcels;
                }

                    double ob = (sp + m) / sum;

                    dt.Rows.Add(s.Name,  sp, m,Math.Round(ob,2)+"%");
            }

            return dt;

        }
        private void TactSensor_BeltStop(object sender, EventArgs e)
        {
            this.BeltRunning = false;
        }

        private void TactSensor_BeltStart(object sender, EventArgs e)
        {
            this.BeltRunning = true;
        }

        private void TactSensor_ValueChanged(object sender, ModbusDriver.ModbusValueEventArgs e)
        {

            // Task.Run(new Action(() => { 

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
            // 
            //}));
        }


        private ColorType GetColor(ColorType.ColorsList colorname)
        {
            return dict.Colors.Find(x => x.Name == colorname);
        }


        public void LampTest()
        {
            Task.Run(new Action(() => { }));

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
        public void LampTestSingleOn()
        {
            Task.Run(new Action(() => { }));

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
        public void LampTestTurnOnAll()
        {
            Task.Run(new Action(() => { }));

            List<bool> lv = new List<bool>();
            for (int i = 0; i < 64; i++)
            {
                lv.Add(true);
            }


            this.Driver.WriteCoils(0, lv.ToArray());       


        }
        public void LampTestTurnOffAll()
        {
            Task.Run(new Action(() => { }));

            List<bool> lv = new List<bool>();
            for (int i = 0; i < 64; i++)
            {
                lv.Add(false);
            }


            this.Driver.WriteCoils(0, lv.ToArray());


        }

        private async void Tacted()
        {
            await Task.Run(new Action(() =>
             {


                //mruganie lampki pierwszej
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

             }));
        }

        private void Feeder_OnParcelStartRun(object sender, FeederType.FeederEventArgs e)
        {
            this.ParcelsOnRun.Add(e.parcel);
        }

        public void StartStopRun()
        {
            if (this.CurrentRun == null)
            {
                RunType r = new RunType();
                r.StartTime = DateTime.Now;
                r.MachineId = this.Id;
                r.SortProgramId = this.CurrentSortProgram.Id;
                r.Save();
                this.CurrentRun = r;
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
                    this.CurrentRun.SortProgramId = this.CurrentSortProgram.Id;
                    this.CurrentRun.Save();
                }
            }
        }

        private void Driver_DigitalInputValueChanged(object sender, ModbusDriver.ModbusValueEventArgs e)
        {
            // //Console.WriteLine("Zmiana wartości Digital: " + e.Address + ":" + e.OldValue + " na: " + e.NewValue);
            //if (e.NewValue == true)
            //{
            //    if (e.Address == 0)
            //        Feeders[0].Parcels.Add(new ParcelType());

            //    if (e.Address == 3)
            //    {
            //        if (Feeders[0].Parcels.Count > 0)
            //        {
            //            this.ParcelsOnRun.Add(Feeders[0].Parcels[0]);
            //            Feeders[0].Parcels.Clear();
            //        }
            //    }
            //}

        }

        private void Driver_ValueChanged1(object sender, ModbusDriver.ModbusValueEventArgs e)
        {
            // //Console.WriteLine("Zmiana wartości Coil: " + e.Address + ":" + e.OldValue + " na: " + e.NewValue);
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
    }
}
