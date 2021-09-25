using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public class StandType
    {
        public string Id { get; set; }
        public int OrderNumber { get; set; }
        public string Name { get; set; }
        public int Lamp1Index { get; set; }
        public int Lamp2Index { get; set; }
        public List<StandItemType> Items { get; set; }

        public LampType Lamp1;
        public LampType Lamp2;



        public StandType()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Items = new List<StandItemType>();

        }

       public void SetLamps(LampType lamp1, LampType lamp2)
        {
            this.Lamp1 = lamp1;
            this.Lamp2 = lamp2;


    }

    }
}
