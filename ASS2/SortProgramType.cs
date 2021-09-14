using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public class SortProgramType:DataBaseStorageHelper
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public string Name { get; set; }
        public List<SortProgramItemType> Items { get; set; }

        public SortProgramType() {
            this.Items = new List<SortProgramItemType>();
        }
        public SortProgramType(int machineid, string name)
        {
            this.MachineId = machineid;
            this.Name = name;
            this.Items = new List<SortProgramItemType>();

            for (int i = 0; i < 12; i++)
            {
                for (int x = 0; x < 7; x++)
                {
                    SortProgramItemType item = new SortProgramItemType();
                    item.StandIndex = i;
                    item.DirectionIndex = x;
                    this.Items.Add(item);
                }
            }
        }
        public SortProgramItemType GetItem(int standindex,int directionindex)
        {
            return this.Items.Find(x =>x.StandIndex==standindex && x.DirectionIndex == directionindex);
        }

        public static SortProgramType LoadMachineId(int machineId) 
        {
            string tb = typeof(SortProgramType).ToString().Replace("ASS2.", "").Replace("Type", "s");
            return MysqlCore.DB_Main().NewGetSingleObject<SortProgramType>("Select * from `" + tb + "` where MachineId=" + machineId);
        }


    }
}
