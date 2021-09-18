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

            m.StressSimulation();





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
