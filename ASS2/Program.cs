using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ASS2
{
    
    class Program
    {
         Timer tm;
        static Stopwatch st;
         static Timer tt;
        static DateTime start;
       static int tact;
        static MachineType m;
        static void Main(string[] args)
        {

          

            m = new MachineType();
            m.Id = 1;
            m.InitMachine(1);

            m.SetSortProgram(2);



            Task.Run(() => {

                for (int i = 0; i < 100; i++)
                {
                    m.TactSensor.SetValue();
                    System.Threading.Thread.Sleep(500);
                }
            
            
            });



        //m.OnTacted += M_OnTacted;

        //tt = new Timer();
        //tt.Interval = 500;
        //tt.Elapsed += Tt_Elapsed;
        //start = DateTime.Now;
        //tt.Start();

        //st = new Stopwatch();
        //for (int i = 0; i < 385*10; i++)
        //{
        //    st.Start();
        //    if (st.ElapsedMilliseconds == 500)
        //        st.Stop();
        //}



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

        private static void M_OnTacted(object sender, EventArgs e)
        {
            Console.WriteLine("tacted" + m.TactSensor.TactLenghtTime.TotalMilliseconds.ToString());
        }

        private static void Tt_Elapsed(object sender, ElapsedEventArgs e)
        {
            tact += 1;
            Console.Title = tact.ToString() + " " + m.TactSensor.Counter.CircleNumber + " " + m.Driver.TactSensor.Counter.TactNumber;
            if (tact == 385)
            {
                tact = 0;
                TimeSpan circletime = DateTime.Now - start;
                Console.WriteLine((double)circletime.TotalMilliseconds/60/1000 + " " + circletime.ToString());


                start = DateTime.Now;
            }
            st = new Stopwatch();
            st.Start();
            m.Driver.TactSensor.Value = true;
            m.Driver.TactSensor.Value = false;
            st.Stop();
            Console.Title += " /" +st.ElapsedMilliseconds + " " + st.ElapsedMilliseconds.ToString() +"[ms]" + st.ElapsedTicks + "[ticks]";
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
