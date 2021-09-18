using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public class RoundStatItem
    {
        public int TactNumber { get; set; }
        public int TactTime { get; set; }
        public int StartDetectionSensorReads { get; set; }
        public int StartParcelSensorReads { get; set; }
        public int StopSensorReads { get; set; }
        public int TactSensorReads { get; set; }

    }
}
