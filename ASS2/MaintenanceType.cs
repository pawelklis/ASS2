using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ASS2
{
    public class MaintenanceType
    {
        private  Timer timer { get; set; }

        private  ModbusDriver Driver { get; set; }
        private  int  currentAddress{get;set;}
        private  bool[] currentValues { get; set; }


        public  void LampAllTest(ModbusDriver driver,List<LampType> Lamps, List<ColorType>Colors)
        {
            List<bool> values = new List<bool>();
            Driver = driver;
            timer?.Stop();
            timer = new Timer();
            timer.Interval = 5000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();


            foreach (var l in Lamps)
            {
                foreach (var c in Colors)
                {
                    currentAddress = l.Address;
                    currentValues = c.Values.ToArray();
                }
            }


        }

        private  void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Driver.WriteCoils(currentAddress, currentValues);
        }
    }
}
