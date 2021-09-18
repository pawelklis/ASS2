using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASS2;

namespace ASS2WEB
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindChart1();
                BindCirlces();
            }
        }


        void BindChart1()
        {

            MysqlCore m = MysqlCore.DB_Main();
            DataTable dt = m.FillDatatable("select roundnumber as 'Okrążenie', parcelscount as 'Liczba przesyłek',Round(circletime/60/1000,2) as 'Czas' from roundstats order by id desc limit 100;");

            chart1.Series.Clear();
            chart1.DataSource = dt;
            chart1.Series.Add("Czas okrążenia");
            chart1.Series[0].XValueMember = "Okrążenie";
            chart1.Series[0].YValueMembers = "Czas";
            chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[0].IsValueShownAsLabel = true;

            chart1.Series.Add("Liczba przesyłek");
            chart1.Series[1].XValueMember = "Okrążenie";
            chart1.Series[1].YValueMembers = "Liczba przesyłek";
            chart1.Series[1].IsValueShownAsLabel = true;
            chart1.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[1].YAxisType = System.Web.UI.DataVisualization.Charting.AxisType.Secondary;

            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;

            chart1.ChartAreas[0].AxisY2.Enabled = System.Web.UI.DataVisualization.Charting.AxisEnabled.True;

            chart1.Titles.Add("Statystyka okrążeń");
            chart1.Legends.Add("Legend1");
            chart1.Legends[0].Docking = System.Web.UI.DataVisualization.Charting.Docking.Bottom;


            foreach (var s in chart1.Series)
            {
                s.ToolTip =  "Okr.: #VALX," + s.Name + ":" +" #VALY";
            }

            chart1.DataBind();



        }


        void BindCirlces()
        {
            MysqlCore m = MysqlCore.DB_Main();
            DataTable dt = m.FillDatatable("SELECT id, roundnumber FROM assdb.roundstats order by id desc limit 100;");
            ddlcircle.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlcircle.Items.Add(new ListItem() { Text = dt.Rows[i]["roundnumber"].ToString(), Value = dt.Rows[i]["id"].ToString() });

            }
            try
            {
                bindc2();
            }
            catch (Exception)
            {

                
            }
        }

        void bindc2()
        {
            int id = int.Parse(ddlcircle.SelectedValue);
            RoundStatType rs = RoundStatType.Load<RoundStatType>(id);

            chart2.Series.Clear();
            chart2.DataSource = rs.StatItems;


            chart2.Series.Add("Czujnik STOP");
            chart2.Series[0].XValueMember = "TactNumber";
            chart2.Series[0].YValueMembers = "StopSensorReads";
            chart2.Series[0].IsValueShownAsLabel = false;
            chart2.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Point;
            chart2.Series[0].YAxisType = System.Web.UI.DataVisualization.Charting.AxisType.Secondary;

            chart2.Series.Add("Czujnik taktu");
            chart2.Series[1].XValueMember = "TactNumber";
            chart2.Series[1].YValueMembers = "TactSensorReads";
            chart2.Series[1].IsValueShownAsLabel = false;
            chart2.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Point;
            chart2.Series[1].YAxisType = System.Web.UI.DataVisualization.Charting.AxisType.Secondary;

            chart2.Series.Add("Czujnik START Przesyłki");
            chart2.Series[2].XValueMember = "TactNumber";
            chart2.Series[2].YValueMembers = "StartParcelSensorReads";
            chart2.Series[2].IsValueShownAsLabel = false;
            chart2.Series[2].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Point;
            chart2.Series[2].YAxisType = System.Web.UI.DataVisualization.Charting.AxisType.Secondary;

            chart2.Series.Add("Czujnik Start detekcji");
            chart2.Series[3].XValueMember = "TactNumber";
            chart2.Series[3].YValueMembers = "StartDetectionSensorReads";
            chart2.Series[3].IsValueShownAsLabel = false;
            chart2.Series[3].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Point;
            chart2.Series[3].YAxisType = System.Web.UI.DataVisualization.Charting.AxisType.Secondary;


            chart2.Series.Add("Czas taktu");
            chart2.Series[4].XValueMember = "TactNumber";
            chart2.Series[4].YValueMembers = "TactTime";
            chart2.Series[4].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series[4].IsValueShownAsLabel = false;
            chart2.Series[4].Color = System.Drawing.Color.Red;
            chart2.Series[4].BorderWidth = 2;

            chart2.ChartAreas[0].AxisX.Interval = 1;
            chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY2.Maximum = 10;
            chart2.ChartAreas[0].AxisY2.Minimum = 0;
            chart2.ChartAreas[0].AxisY2.Enabled = System.Web.UI.DataVisualization.Charting.AxisEnabled.True;

            chart2.Titles.Add("Statystyka okrążeń");
            chart2.Legends.Add("Legend1");
            chart2.Legends[0].Docking = System.Web.UI.DataVisualization.Charting.Docking.Bottom;


            foreach (var s in chart2.Series)
            {
                s.ToolTip = "Takt: #VALX," + s.Name + ":" + " #VALY";
            }

            chart2.DataBind();

        }
        protected void ddlcircle_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindc2();
        }
    }
}