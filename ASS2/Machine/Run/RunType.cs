using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public class RunType:DataBaseStorageHelper
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MachineId { get; set; }
        public int SortProgramId { get; set; }


        public bool IsWorking()
        {
            if (EndTime < StartTime)
                return true;
            return false;
        }
    }
}
