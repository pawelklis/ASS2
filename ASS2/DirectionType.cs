using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public class DirectionType : DataBaseStorageHelper
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int IdMachine { get; set; }
        public List<DirectionItemType> Items { get; set; }


        public DirectionType()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Items = new List<DirectionItemType>();
        }
        public DataTable ToTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("pnafrom");
            dt.Columns.Add("pnato");
            dt.Columns.Add("wsr");

            foreach(var item in this.Items)
            {
                dt.Rows.Add(item.Name, item.PnaFrom, item.PnaTo, item.WSR);
            }
            return dt;
        }
        public void AddItem(DirectionItemType item)
        {
            
            this.Items.Add(item);
            this.Save();
        }

        public bool isInRange(string PNA)
        {
            if (PNA == null)
                PNA = "99999";
            PNA = PNA.Replace("-", "");
            foreach (var sd in Items)
            {
                if (int.Parse(PNA) >= int.Parse(sd.PnaFrom) && int.Parse(PNA) <= int.Parse(sd.PnaTo))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
