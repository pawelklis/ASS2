using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public class RunStatType:DataBaseStorageHelper
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public int CircleNumber { get; set; }
        public DateTime RunStart { get; set; }
        public DateTime RunStop { get; set; }

        public List<RunStatItemType> Items { get; set; }


        public RunStatType(RunType run, List<StandType> stands, int machineId, int circleNumber)
        {
            this.MachineId = machineId;
            this.CircleNumber = circleNumber;
            this.RunStart = run.StartTime;
            this.RunStop = run.EndTime;

            this.Items = new List<RunStatItemType>();
            foreach(var s in stands)
            {
                foreach(var i in s.Items)
                {
                    RunStatItemType ri = new RunStatItemType()
                    {
                        StandName = s.Name,
                        DirectionName = i.Direction?.Name,
                        SortedParcels = i.SortedParcels,
                        MissedParcels = i.MissedParcels
                    };
                    this.Items.Add(ri);
                }
            }

            this.SaveAsync();
        }

    }
}
