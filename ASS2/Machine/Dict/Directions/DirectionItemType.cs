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
        public string ParcelTypes { get; set; }

        public async Task<List<string>> ParcelTypesList()
        {
            
            List<string> l = new List<string>();
            await Task.Run(() => {

                try
                {
                string[] s = this.ParcelTypes.Split(',');

            foreach(var ss in s)
            {
                l.Add(ss.Replace(" ", ""));

            }
                }
                catch (Exception ex)
                {
                    ErrorLog.SaveError(ex);
                }


            });
            return l;
        }

        public async Task<bool> IsInParcelType(string parceltyp)
        {
            try
            {
            List<string> pt = await ParcelTypesList();
            if (pt.Contains(parceltyp))
                return true;
            return false;
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }
            return false;
        }

        public DirectionItemType()
        {
            this.Id = Guid.NewGuid().ToString();
        }

    }
}
