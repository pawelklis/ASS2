using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ASS2
{
    public class ParcelType:DataBaseStorageHelper
    {
        public event EventHandler<ParcelEventArgs> OnParcelStopRun;

        public int Id { get; private set; }
        public string GuidID { get;private set; }
        public DateTime CreateTime { get;private set; }
        public string Number { get;private set; }
        public int Lenght { get; private set; }
        public string DestinationUnitPostCode { get; private set; }
        public StandType DestinationStand { get;private  set; }
        public StandItemType DestinationStandItem { get;private  set; }
        public int CurrentTactNumber { get; set; }

        public bool Recircuit;
        public int RoundCounts { get; set; }

        private int StopRunTactNumber;

        private Timer Lamp2OffTimer;
        

        private ModbusDriver driver;
        public ParcelType(ModbusDriver Driver,int stopruntactnumber, List<StandType> Stands)
        {
            this.driver = Driver;
            this.CreateTime = DateTime.Now;
            this.GuidID = Guid.NewGuid().ToString();
            this.StopRunTactNumber = stopruntactnumber;
            this.SetOdrzuty(Stands, OdrzutyReason.brakskanu);
            this.Number = "";
        }

        public async void AddTact(int alltacts)
        {
            await Task.Run(new Action(() => {
                this.CurrentTactNumber += 1;
                if (this.CurrentTactNumber > alltacts)
                {
                    this.CurrentTactNumber = 0;
                    this.RoundCounts += 1;
                }
                if (this.RoundCounts > 5)
                    this.StopRun();

                if (this.CurrentTactNumber == this.DestinationStand.Lamp1.TactOnNumber)
                     Lamp1On();
                if (this.CurrentTactNumber == this.DestinationStand.Lamp2.TactOnNumber)
                    Lamp2On();

                if (this.CurrentTactNumber > this.StopRunTactNumber)
                    if(this.Recircuit==false)
                        this.StopRun();
            }));
        }

        public void NextRound()
        {
            this.Recircuit = true;
            this.RoundCounts += 1;
            this.DestinationStandItem.MissedParcels += 1;
        }
        public void StopRun()
        {
            if (this.RoundCounts < 5)
            {
                if(this.DestinationStandItem.Direction.Name=="Brak skanu")
                {
                    this.Recircuit = true;
                    this.RoundCounts += 1;
                    return;
                }
            }


            this.DestinationStandItem.SortedParcels += 1;

            ParcelEventArgs args = new ParcelEventArgs();
            args.parcel = this;
            EventHandler<ParcelEventArgs> handler = OnParcelStopRun;
            handler?.Invoke(this, args);
        }

        public async void Lamp1On()
        {
            await Task.Run(new Action(() =>
            {
                if (this.DestinationStand.Name == "Odrzuty")
                {
                    if (this.DestinationStandItem.Direction.Name == "Brak skanu")
                        return;

                    //this.driver.WriteCoils(this.DestinationStand.LampOdrzuty1.Address, new bool[] { true });
                    this.DestinationStandItem.Lamp1OnTacts = 10;
                }
                else
                {
                    this.DestinationStandItem.Lamp1OnTacts = 10;
                }

            }));

        }
        public async void Lamp2On()
        {
            await Task.Run(new Action(() =>
            {
                if (this.Lenght == 0)
                    this.Lenght = 1000;

                if (this.DestinationStand.Name == "Odrzuty")
                {
                    if (this.DestinationStandItem.Direction.Name == "Brak skanu")
                        return;

                    this.DestinationStand.Lamp2.LightOn(this.DestinationStandItem.Color, this.driver);

                    Lamp2OffTimer?.Stop();
                    Lamp2OffTimer = new Timer();
                    Lamp2OffTimer.Interval = this.Lenght;
                    Lamp2OffTimer.Elapsed += Lamp2OffTimer_Elapsed;
                    Lamp2OffTimer.Start();
                }
                else
                {
                    this.DestinationStand.Lamp2.LightOn(this.DestinationStandItem.Color, this.driver);

                    Lamp2OffTimer?.Stop();
                    Lamp2OffTimer = new Timer();
                    Lamp2OffTimer.Interval = this.Lenght;
                    Lamp2OffTimer.Elapsed += Lamp2OffTimer_Elapsed;
                    Lamp2OffTimer.Start();
                }


            }));
        }



        private void Lamp2OffTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.DestinationStand.Lamp2.LightOff(this.driver);
            Lamp2OffTimer.Stop();
            Lamp2OffTimer = null;
        }

        public new async void SaveAsync()
        {
            await Task.Run(new Action(() => {
                this.Save();
            }));
            //Console.WriteLine("Saved " + " [" + (DateTime.Now- this.CreateTime).Milliseconds.ToString() + "ms]");
        }
        public async void SetNumber(string number, List<StandType> Stands)
        {
            await Task.Run(new Action(() =>
             {
                 this.Number = number;
                 this.DestinationUnitPostCode = SledzenieServiceType.SprawdzPrzesylke(this.Number)?.danePrzesylki?.urzadPrzezn?.daneSzczegolowe?.pna; // SledzenieServiceType.SprawdzPrzesylkeAsync(this.Number).Result.danePrzesylki.urzadPrzezn.daneSzczegolowe.pna;

                 if (this.DestinationUnitPostCode == null)
                     this.SetOdrzuty(Stands, OdrzutyReason.brakdanych);

                 DateTime SettingSledzenieTime = DateTime.Now;
                 //Console.WriteLine(this.DestinationUnitPostCode + " [" + ( SettingSledzenieTime-this.CreateTime).Milliseconds.ToString() + "ms]");


                 void IterateStands()
                 {
                     foreach (var stand in Stands)
                     {
                         foreach (var item in stand.Items)
                         {
                             if (item.Direction != null)
                             {
                                 if (item.Direction.isInRange(this.DestinationUnitPostCode))
                                 {
                                     this.DestinationStand = stand;
                                     this.DestinationStandItem = item;
                                     return;
                                 }
                             }
                         }
                     }

                     //if (this.DestinationStand == null)
                     //    this.DestinationStand = Stands.Find(x => x.Name == "Odrzuty");
                     //if (this.DestinationStandItem == null)
                     //    this.DestinationStandItem = DestinationStand.Items[1];

                     //if (this.DestinationStand == null)
                        // SetOdrzuty(Stands, OdrzutyReason.brakwplanie);
                     //if (this.DestinationStandItem == null)
                     if(this.DestinationStandItem.Direction.Name!= "Brak danych w ZST")
                         SetOdrzuty(Stands, OdrzutyReason.brakwplanie);
                 };

                 IterateStands();
                 DateTime SettingDirectionTime = DateTime.Now;
                 //Console.WriteLine(this.DestinationStandItem.Direction.Name + " [" + (SettingDirectionTime-this.CreateTime).Milliseconds.ToString() + "ms]");
             }));
            this.SaveAsync();
        }

        public void SetOdrzuty(List<StandType> Stands, OdrzutyReason Reason)
        {
       
                this.DestinationStand = Stands.Find(x => x.Name == "Odrzuty");
    
                this.DestinationStandItem = DestinationStand.Items[(int)Reason];

            //this.DestinationStandItem.Direction = new DirectionType() { Name = "Brak skanu" };
        }

        public enum OdrzutyReason
        {
            brakskanu,
            brakdanych,
            brakwplanie
        }

        public void SetLenght(int lenght)
        {
            this.Lenght = lenght;
        }


        public class ParcelEventArgs
        {
           public ParcelType parcel { get; set; }
        }
    }
}
