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


        private int White = 61;
        private int Green = 62;
        private int Red = 63;

        public int TactNumber;
        private int parcelstoptactnumber;
        List<ParcelType> ParcelsAtLine;

        public event EventHandler<FeederEventArgs> OnParcelStartRun;

        public FeederType(RS232ConfigType SkanerConfig, List<StandType>stands, ModbusDriver driver, int detectiontactnumber, List<ParcelType> parcelsAtLine, int parcelstoptactnumber)
        {
            this.driver = driver;
            this.Stands = stands;
            Parcels = new List<ParcelType>();
            Skaner = new RS232DeviceType();
            Skaner.OnDataReceived += Skaner_OnDataReceived;
            Skaner.Connect(SkanerConfig.PortName, SkanerConfig.Name, SkanerConfig.Speed, SkanerConfig.Delay);
            this.TactNumber = detectiontactnumber;
            this.ParcelsAtLine = parcelsAtLine;
            this.parcelstoptactnumber = parcelstoptactnumber;

            
        }

        //czerwona - 64, zielona - 63, biała - 62

        public void Startdetectionsensor_ValueChanged(object sender, ModbusDriver.ModbusValueEventArgs e)
        {
            Task.Run(new Action(() =>
            {
                //this.TactNumber = 10;
                //Console.WriteLine("Startdetectionsensor_ValueChanged");
                ParcelType roundparcel = this.ParcelsAtLine.Find(x => x.CurrentTactNumber == this.TactNumber);
                if (roundparcel != null)
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
                    }
                }
                else
                {
                    //zapal białą lampke
                    ParcelType np = new ParcelType(this.driver, this.parcelstoptactnumber, this.Stands);
                    np.OnParcelStopRun += Np_OnParcelStopRun;
                    this.Parcels.Add(np);

                    driver.WriteCoils(White, new bool[] { true });
                }
            }));
        }

        private void Np_OnParcelStopRun(object sender, ParcelType.ParcelEventArgs e)
        {
            Task.Run(new Action(() => { 
            ParcelType p = (ParcelType)sender;
            ParcelsAtLine.Remove(p);}));
        }

        public void Startparcelsensor_ValueChanged(object sender, ModbusDriver.ModbusValueEventArgs e)
        {
            //Task.Run(new Action(() => { 
            driver.WriteCoils(61, new bool[] { false, false, false });

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
            //}));

        }

        private void Skaner_OnDataReceived(object sender, RS232DeviceType.SkanerEventArgs e)
        {
            //Console.WriteLine(e.DataReceived);
            Scanned(e.DataReceived);
        }


        private async void Scanned(string number)
        {
            await Task.Run(new Action(() => {
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
            }));
        }


        public class FeederEventArgs
        {
            public ParcelType parcel { get; set; }
        }

    }
}
