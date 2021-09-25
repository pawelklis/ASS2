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

            try
            {
            foreach (var item in this.Items)
            {
                dt.Rows.Add(item.Name, item.PnaFrom, item.PnaTo, item.WSR);
            }
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }


            return dt;
        }
        public void AddItem(DirectionItemType item)
        {
            try
            {
            this.Items.Add(item);
            this.Save();
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

        }



        public bool isInRange(string PNA, string parceltyp)
        {

            try
            {
            if (PNA == null)
                PNA = "99999";
                PNA = PNA.Replace("-", "");
                foreach (var sd in Items)
                {
                if (sd.ParcelTypes == null)
                    sd.ParcelTypes = "";
                    if (parceltyp == null)
                        parceltyp = "P";

                    if (sd.IsInParcelType(parceltyp).Result)
                    {

                        if (string.IsNullOrEmpty(sd.PnaFrom))
                            return false;
                        if (sd.PnaFrom == " ")
                            return false;
                        if (string.IsNullOrEmpty(sd.PnaTo))
                            sd.PnaTo = sd.PnaFrom;
                        if (sd.PnaTo == " ")
                            sd.PnaTo = sd.PnaFrom;

                        if (int.Parse(PNA) >= int.Parse(sd.PnaFrom) && int.Parse(PNA) <= int.Parse(sd.PnaTo))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }


            



            return false;
        }

    }
}
