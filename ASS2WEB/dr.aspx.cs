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
    public partial class dr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            dw(id);
        }
        DataTable GetRunData(int runid)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Stanowisko");
            dt.Columns.Add("Kierunek");
            dt.Columns.Add("Stanowisko kierunek");
            dt.Columns.Add("Wysortowane");
            dt.Columns.Add("Recyrkulacja");
            dt.Columns.Add("Razem");
            dt.Columns.Add("Udział sumy stanowiska w ogóle");
            dt.Columns.Add("Udział kierunku w stanowisku");
            dt.Columns.Add("Udział kierunku w ogóle");
            try
            {
                RunStatType rs = RunStatType.LoadWhere<RunStatType>(" runid=" + runid)[0];





                foreach (var i in rs.Items)
                {
                    double u1 = 0;
                    double u2 = 0;
                    double u3 = 0;

                    double sumall = 0;
                    double sumstand = 0;

                    foreach (var ii in rs.Items)
                    {
                        sumall += ii.SortedParcels + ii.MissedParcels;
                        if (ii.StandName == i.StandName)
                            sumstand += ii.SortedParcels + ii.MissedParcels;
                    }
                    u1 = Math.Round((sumstand / sumall) * 1, 2);
                    u2 = Math.Round(((i.SortedParcels + i.MissedParcels) / sumstand) * 1, 2);
                    u3 = Math.Round(((i.SortedParcels + i.MissedParcels) / sumall) * 1, 2);

                    if (double.IsNaN(u1))
                        u1 = 0;
                    if (double.IsNaN(u2))
                        u2 = 0;
                    if (double.IsNaN(u3))
                        u3 = 0;

                    if (!string.IsNullOrEmpty(i.DirectionName))
                        dt.Rows.Add(i.StandName, i.DirectionName, i.StandName + " " + i.DirectionName, i.SortedParcels, i.MissedParcels,
                            i.SortedParcels + i.MissedParcels,
                            u1, u2, u3);
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
            Response.AddHeader("content-disposition", "attachment; filename=" + "Run_stands_" + runid + ".csv");
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