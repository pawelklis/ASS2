﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public class CounterType : DataBaseStorageHelper
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public int TactNumber { get; set; }
        public int CircleNumber { get; set; }

        private int TactCountsAll;
        public CounterType() { }
        public CounterType(int machineid, int AllTactsCount)
        {
            List<CounterType> lo = CounterType.LoadWhere<CounterType>(" machineid =" + machineid);
            if (lo?.Count > 0)
            {
                CounterType o = lo[0];
                this.Id = o.Id;
                this.MachineId = machineid;
                this.TactNumber = o.TactNumber;
                this.CircleNumber = o.CircleNumber;
            }

            this.MachineId = machineid;
            this.TactCountsAll = AllTactsCount;

        }

        public void AddTact()
        {
            Task.Run(new Action(() =>
            {
            this.TactNumber += 1;

            if (this.TactNumber >= this.TactCountsAll)
            {
                if (this.CircleNumber + 1 > int.MaxValue)
                    this.CircleNumber = 0;

                this.CircleNumber += 1;
                this.TactNumber = 0;
            }


                this.SaveAsync();
            }));
        }
    }
}
