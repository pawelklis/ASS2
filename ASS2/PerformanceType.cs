using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public class PerformanceType
    {

        private Stopwatch st;
        private DateTime startexecution { get; set; }
        private DateTime stopexecution { get; set; }
        private string cmdname { get; set; }

        public void StartMeasure(string cmdName)
        {
            this.cmdname = cmdName;
            this.st = new Stopwatch();
            this.st.Start();
        }

        public void StopMeasure()
        {
            this.st.Stop();
            Console.WriteLine(this.cmdname + ": " + st.Elapsed.Seconds + "[s] " + st.ElapsedMilliseconds + "[ms] " + " Ticks: " + st.Elapsed.Ticks + " [tick] " + st.Elapsed.TotalMilliseconds.ToString() + "[total ms]"); ;
        }


    }
}
