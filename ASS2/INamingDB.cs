using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public interface INamingDB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Js { get; set; }
    }
}
