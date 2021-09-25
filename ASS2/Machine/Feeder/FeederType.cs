using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public class FeederType
    {
        public RS232DeviceType Skaner { get; set; }
        public List<ParcelType> Parcels { get; set; }

        private List<StandType> Stands;

        private ModbusDriver driver;

        private MachineType machine;

        private bool ignition;
        private int White = 61;
        private int Green = 62;
        private int Red = 63;

        public int TactNumber;
        private int parcelstoptactnumber;
        List<ParcelType> ParcelsAtLine;

        private bool ParcelWasScanned;

        public event EventHandler<FeederEventArgs> OnParcelStartRun;

        public FeederType(RS232ConfigType SkanerConfig, List<StandType>stands, ModbusDriver driver, int detectiontactnumber, List<ParcelType> parcelsAtLine, int parcelstoptactnumber,MachineType machine)
        {

            try
            {
            this.machine = machine;
            ignition = true;
            this.driver = driver;
            this.Stands = stands;
            Parcels = new List<ParcelType>();
            Skaner = new RS232DeviceType();
            Skaner.OnDataReceived += Skaner_OnDataReceivedAsync;
                Task.Run(() => { Skaner.Connect(SkanerConfig.PortName, SkanerConfig.Name, SkanerConfig.Speed, SkanerConfig.Delay); });
            this.TactNumber = detectiontactnumber;
            this.ParcelsAtLine = parcelsAtLine;
            this.parcelstoptactnumber = parcelstoptactnumber;
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }



            
        }

        //czerwona - 64, zielona - 63, biała - 62

        public void Startdetectionsensor_ValueChanged(object sender, ModbusDriver.ModbusValueEventArgs e)
        {
            try
            {
                ParcelWasScanned = false;
                Task.Run(new Action(() =>
                {
                    driver.WriteCoils(61, new bool[] { false, false, false });
                }));
                ParcelType roundparcel = this.ParcelsAtLine.Find(x => x.CurrentTactNumber > this.TactNumber-2 && x.CurrentTactNumber<this.TactNumber+2);
                    if (roundparcel != null)
                    {
                    Task.Run(new Action(() =>
                    {
                        roundparcel.CurrentTactNumber = 0;
                        roundparcel.Recircuit = false;

                        if (roundparcel.DestinationStand.Name != "Odrzuty")
                        {
                        //paczka przeszła kółko, ma dane zst, nie trzeba skanować
                        //zapal zieloną lampke
                        this.Parcels.Add(roundparcel);
                            ParcelsAtLine.Remove(roundparcel);

                            driver.WriteCoils(Green, new bool[] { true });
                        }
                        else
                        {
                        //paczka przeszła kółko, nie ma dane zst, Trzeba skanować
                        //zapal białą lampke
                        this.Parcels.Add(roundparcel);
                            ParcelsAtLine.Remove(roundparcel);

                            driver.WriteCoils(White, new bool[] { true });
                            driver.WriteCoils(White, new bool[] { true });
                        }
                    }));

                    }
                    else
                    {
                    Task.Run(new Action(() =>
                    {
                        //zapal białą lampke
                        ParcelType np = new ParcelType(this.driver, this.parcelstoptactnumber, this.Stands, machine.CurrentRun.Id, machine.CurrentSortProgram.Id);
                        np.OnParcelStopRun += Np_OnParcelStopRun;
                        this.Parcels.Add(np);

                        driver.WriteCoils(White, new bool[] { true, false, false });
                        driver.WriteCoils(White, new bool[] { true, false, false });
                    }));
                    }
          
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

        }

        private void Np_OnParcelStopRun(object sender, ParcelType.ParcelEventArgs e)
        {
            try
            {
            //Task.Run(new Action(() => { 
            ParcelType p = (ParcelType)sender;
            //p.DestinationStandItem.SortedParcels += 1;
            ParcelsAtLine.Remove(p);//}));
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

        }

        public void Startparcelsensor_ValueChanged(object sender, ModbusDriver.ModbusValueEventArgs e)
        {
            //Task.Run(new Action(() => { 
            try
            {
            if (this.Parcels.Count > 0)
            {
                try
                {
                    ParcelType p = this.Parcels.Last();
                    p.Recircuit = false;

                    FeederEventArgs args = new FeederEventArgs();
                    args.parcel = p;
                    EventHandler<FeederEventArgs> handler = OnParcelStartRun;
                    handler?.Invoke(this, args);
                    ParcelsAtLine.Add(p);
                    this.Parcels.Remove(p);
                }
                catch (Exception)
                {

                   
                }

            }
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }


            //}));

        }

        public void StartParcelSensorEndReading()
        {
            try
            {
            if (ParcelWasScanned==true)
                Task.Run(()=> driver.WriteCoils(61, new bool[] { false, false, false }));
            else
                Task.Run(()=> driver.WriteCoils(White, new bool[] {false,false, true }));//czerwona

            if (ignition == true)
            {
                ignition = false;
                Task.Run(() => driver.WriteCoils(61, new bool[] { false, false, false }));
            }
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }


        }

        private async void Skaner_OnDataReceivedAsync(object sender, RS232DeviceType.SkanerEventArgs e)
        {
            try
            {
            ParcelWasScanned = true;
            //Console.WriteLine(e.DataReceived);
          await  Scanned(e.DataReceived);
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

        }


        public async   Task Scanned(string number)
        {
            await Task.Run(new Action(() => {

                try
                {
                if (this.Parcels.Count > 0)
                {
                    if (this.Parcels.Count == 1)
                    {
                        //dodaje numer do przesyłki
                        Parcels.Last<ParcelType>().SetNumber(number, this.Stands);
                        driver.WriteCoils(White, new bool[] { false });
                        //zapal zieloną lampke
                        driver.WriteCoils(Green, new bool[] { true });
                        
                    }
                    else
                    {
                        ParcelsAtLine.AddRange(this.Parcels.ToArray());
                        this.Parcels.Clear();
                        driver.WriteCoils(White, new bool[] { false });
                        //Zapala czerwoną lampke przesyłki robią kółko
                        driver.WriteCoils(Red, new bool[] { true });
                        return;
                    }
                }  
                }
                catch (Exception ex)
                {
                    ErrorLog.SaveError(ex);
                }

                          
            }));
        }


        public class FeederEventArgs
        {
            public ParcelType parcel { get; set; }
        }

    }
}
