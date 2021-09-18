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
    public partial class stats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRuns();
            }
        }

        void BindRuns()
        {
            List<RunType> runs = RunType.LoadAll<RunType>();
            foreach(var r in runs)
            {
                ddlrun.Items.Add(new ListItem() { Text = r.StartTime + " - " + r.EndTime, Value = r.Id.ToString() });
            }


        }

        protected void ddlrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            int runid = int.Parse(ddlrun.SelectedValue);
            BindRunDetails(runid);
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
        void BindRunDetails(int runid)
        {
            try
            {


                DataTable dt = GetRunData(runid);
         


                chart1.Series.Clear();
                chart1.DataSource = dt;
                chart1.Series.Add("Wysortowane");
                chart1.Series[0].XValueMember = "Stanowisko kierunek";
                chart1.Series[0].YValueMembers = "Wysortowane";
                chart1.Series[0].IsValueShownAsLabel = true;

                chart1.Series.Add("Recyrkulacja");
                chart1.Series[1].XValueMember = "Stanowisko kierunek";
                chart1.Series[1].YValueMembers = "Recyrkulacja";
                chart1.Series[1].IsValueShownAsLabel = true;

                chart1.ChartAreas[0].AxisX.Interval = 1;
                chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                chart1.DataBind();


                chart2.Series.Clear();
                chart2.DataSource = dt;
                chart2.Series.Add("Udział sumy stanowiska w ogóle");
                chart2.Series[0].XValueMember = "Stanowisko";
                chart2.Series[0].YValueMembers = "Udział sumy stanowiska w ogóle";
                chart2.Series[0].Label = "#VALX #VALY %";
                chart2.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;

                chart2.ChartAreas[0].Area3DStyle.Enable3D = true;
                chart2.ChartAreas[0].Area3DStyle.Inclination = 0;
                chart2.Series[0]["PieLabelStyle"] = "Outside";
                chart2.Series[0].BorderWidth = 1;
                chart2.Series[0].BorderDashStyle = System.Web.UI.DataVisualization.Charting.ChartDashStyle.Solid;
                chart2.Series[0].BorderColor = System.Drawing.Color.FromArgb(200, 26, 59, 105);

                chart2.DataBind();

                chart3.Series.Clear();
                chart3.DataSource = dt;
                chart3.Series.Add("Udział kierunku w ogóle");
                chart3.Series[0].XValueMember = "Kierunek";
                chart3.Series[0].YValueMembers = "Udział kierunku w ogóle";
                chart3.Series[0].Label = "#VALX #VALY %";
                chart3.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;

                chart3.Series[0]["PieLabelStyle"] = "Outside";
                chart3.Series[0].BorderWidth = 1;
                chart3.Series[0].BorderDashStyle = System.Web.UI.DataVisualization.Charting.ChartDashStyle.Solid;
                chart3.Series[0].BorderColor = System.Drawing.Color.FromArgb(200, 26, 59, 105);
                chart3.ChartAreas[0].Area3DStyle.Enable3D = true;
                chart3.ChartAreas[0].Area3DStyle.Inclination = 0;

                chart3.DataBind();

         
            }
            catch (Exception)
            {

                
            }
 
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("dr.aspx?id="+ddlrun.SelectedValue);
        }
        protected void imgDownload_Click(object sender, ImageClickEventArgs e)
        {



            Response.Redirect("drp.aspx?id=" + ddlrun.SelectedValue);



        }


    }
}