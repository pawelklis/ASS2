using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public class SortProgramItemType
    {
        public string Id { get; set; }
        public int StandIndex { get; set; }
        public int DirectionIndex { get; set; }
        public DirectionType Direction { get; set; }
        public ColorType Color { get; set; }

        public SortProgramItemType()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Direction = new DirectionType();
            this.Color = new ColorType();
        }



    }
}
