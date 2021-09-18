using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASS2;

namespace ASS2WEB
{
    public partial class drp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            dw(id);
        }

        DataTable GetRunData(int runid)
        {  
            DataTable dt = new DataTable();
            dt.Columns.Add("Numer");
            dt.Columns.Add("Nazwa");
            dt.Columns.Add("GUID");
            dt.Columns.Add("Czas sortowania");
            dt.Columns.Add("Długość");
            dt.Columns.Add("PNA");
            dt.Columns.Add("Stanowisko");
            dt.Columns.Add("Kierunek");
            dt.Columns.Add("Liczba okrążeń");
            dt.Columns.Add("Przebieg ID");
            dt.Columns.Add("Program sortowaniczy ID");
            dt.Columns.Add("UP nadania");
            dt.Columns.Add("UP przeznaczenia");
            dt.Columns.Add("Data nadania");

            try
            {

            foreach (var p in ParcelType.LoadWhere<ParcelType>("runid=" + runid))
            {
                dt.Rows.Add(p.Number,p.parceltypename, p.GuidID, p.CreateTime, p.Lenght, p.DestinationUnitPostCode, p.DestinationStand.Name,
                    p.DestinationStandItem.Direction.Name,
                    p.RoundCounts, p.RunId, p.SortProgramID, p.UPnad, p.UPdor, p.Datanad);
            }
            }
            catch (Exception)
            {

               
            }




            return dt;
        }
        void dw(string runid)
        {
            DataTable dt = GetRunData(int.Parse(runid));



            byte[] Content = System.Text.Encoding.GetEncoding(1252).GetBytes(ToCSV(dt));
            Response.ContentType = "text/csv";
            Response.AddHeader("content-disposition", "attachment; filename=" + "Run_parcels_" + runid + ".csv");
            Response.BufferOutput = true;
            Response.ContentEncoding = Encoding.GetEncoding(1252);
            Response.OutputStream.Write(Content, 0, Content.Length);
            Response.End();
        }

        string ToCSV(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder line = new StringBuilder();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                line.Append(dt.Columns[i]);
                if (i < dt.Columns.Count - 1)
                {
                    line.Append(";");
                }
            }
            sb.AppendLine(line.ToString());
            line = new StringBuilder();

            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(';'))
                        {
                            value = String.Format("\"{0}\"", value);
                            line.Append(value);
                        }
                        else
                        {
                            line.Append(dr[i].ToString());
                        }
                    }
                    if (i < dt.Columns.Count - 1)
                    {
                        line.Append(";");
                    }
                }
                sb.AppendLine(line.ToString());
                line = new StringBuilder();
            }


            string a = sb.ToString();

            return sb.ToString();
        }
    }
}