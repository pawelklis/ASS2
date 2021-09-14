using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ASS2
{
    
    class Program
    {
         Timer tm;
        static MachineType m;
        static void Main(string[] args)
        {
            //CounterType.CreateTable(new CounterType(1, 385));
            //RunStatType.CreateTable(new RunStatType(new RunType(), null,1,0));

            //SortProgramType.CreateTable(new SortProgramType());


           

            //DictType dict = new DictType();
            //DictType.CreateTable(dict);
            //dict.Save();

            //Timer tm = new Timer();
            //tm.Interval = 1000;
            //tm.Elapsed += Tm_Elapsed;
            //tm.Start();

            //MachineType m = new MachineType();
            //m.Name = "Komorniki";

            //m.Save();m

            m = MachineType.Load<MachineType>(1);
            m.InitMachine(1);

            MachineType machine = m;

            //ModbusDriver d = new ModbusDriver();
            //d.ConnectClient("192.254.52.3", 502);

            //var x = m.Driver.Client.ReadDiscreteInputs(0, 16);

            //m.LampTestTurnOnAll();
            //m.LampTestTurnOffAll();
            //m.dict.SerialConfigs.Add(new RS232ConfigType() { Delay = 20, Id = Guid.NewGuid().ToString(), Name = "Skaner1", PortName = "Com41", Speed = 9600 });
            //m.dict.Save();

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

            Task.Run(new Action(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                machine.Driver.TactSensor.Value = true;
                machine.Driver.TactSensor.Value = false;
                    System.Threading.Thread.Sleep(500);
                }


            }));

            Task.Run(new Action(() =>
            {
                int numi = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    Console.WriteLine(m.TactSensor.TactLenghtTime.TotalMilliseconds + " " + m.Feeder1.Parcels.Count + " " + m.ParcelsOnRun.Count);
                    System.Threading.Thread.Sleep(1000);
                    machine.Driver.StartDetectionSensor.Value = true;
                    machine.Driver.StartDetectionSensor.Value = false;
                    System.Threading.Thread.Sleep(2000);
                    if (machine.Feeder1.Parcels.Count > 0)
                        machine.Feeder1.Parcels[0].SetNumber(numery[numi], machine.dict.Stands);
                    System.Threading.Thread.Sleep(2000);

                    machine.Driver.StartParcelSensor.Value = true;
                    machine.Driver.StartParcelSensor.Value = false;

                    if (machine.ParcelsOnRun.Count > 0)
                        machine.ParcelsOnRun.Last().SetLenght(1200);

                    numi++;
                    if (numi > numery.Count - 1)
                        numi = 0;

                }
            }));





            Program p = new Program();
            //p.test(m);
            //m.LampTest();

            //m.Driver.WriteCoils(0, new bool[] { true, true });

            //DirectionType d = new DirectionType();
            //d.Name = "Komorniki ";
            //d.Items.Add(new DirectionItemType() { Name = "Komorniki", PnaFrom = "62000", PnaTo = "63000" });
            //m.Stands[0].Items.Add(new StandItemType() { Direction = d });

            //m.Save();

            //ParcelType p = new ParcelType();
            //ParcelType.CreateTable(p);
            //p.SetNumber("1",m.Stands);
            //p.SaveAsync();


            // var przesylka = SledzenieServiceType.SprawdzPrzesylke("1");
            // var x = SledzenieServiceType.SprawdzPrzesylkeAsync("1");

            //Console.WriteLine("poszło");

            //DataTable dt = m.PrintSettings();
            //dt.TableName = "set1";
            //dt.WriteXml(@"C:\Users\klispawel\Downloads\set.xml");



            //m.LampTest();


        //DirectionType d = new DirectionType();
        //d.Name = "WER Wrocław";
        //DirectionType.CreateTable(d);

        //d.AddItem(new DirectionItemType() { Name = "Kłodzko" });
        //d.AddItem(new DirectionItemType() { Name = "Wałbrzych" });
        //d.Items[0].AddPNARange("57300", "57399");
        //d.Items[0].AddWSR("WKL");
        //d.Save();

        //DirectionType nd = DirectionType.Load<DirectionType>(d.Id);

        ////Console.WriteLine(x.Result.numer);

        rp:
            string a =Console.ReadLine();

            if (a == "1")
                m.Driver.WriteCoils(0, m.dict.Colors[0].Values.ToArray());
            if (a == "2")
                m.Driver.WriteCoils(0, m.dict.Colors[1].Values.ToArray());
            if (a == "3")
                m.Driver.WriteCoils(0, m.dict.Colors[2].Values.ToArray());
            if (a == "4")
                m.Driver.WriteCoils(0, m.dict.Colors[3].Values.ToArray());
            if (a == "5")
                m.Driver.WriteCoils(0, m.dict.Colors[4].Values.ToArray());
            if (a == "6")
                m.Driver.WriteCoils(0, m.dict.Colors[5].Values.ToArray());
            if (a == "7")
                m.Driver.WriteCoils(0, m.dict.Colors[6].Values.ToArray());

            if (a == "0")
                m.Driver.WriteCoils(0, new bool[] { false, false, false, false, false });

            goto rp;
            //Console.ReadKey();
        }

       
        void test(MachineType mm)
        {
            tm = new Timer();
            tm.Interval = 500;
            tm.Elapsed += Tm_Elapsed;
            tm.Start();
        }
        
         bool onof;

         void Tm_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (onof == false)
            {
                m.Driver.WriteCoils(0, m.dict.Colors[7].Values.ToArray());
                onof = true;
            }
            else
            {
                m.Driver.WriteCoils(0, new bool[] { false, false, false, false, false });
                onof = false;
            }


        }

    }
}
