using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public class DirectionItemType : DataBaseStorageHelper
    {
        public string Id { get; set; }
        public string Name { get; set; } 
        public string PnaFrom { get; set; }
        public string PnaTo { get; set; }
        public string WSR { get; set; }




        public DirectionItemType()
        {
            this.Id = Guid.NewGuid().ToString();
        }

    }
}
