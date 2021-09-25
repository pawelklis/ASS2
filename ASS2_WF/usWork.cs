using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASS2;

namespace ASS2_WF
{
    public partial class usWork : UserControl
    {
        private Timer refreshtimer;
        private Timer StatTimer;

       

        public usWork()
        {
            InitializeComponent();
        }
        public MachineType machine;
        private void usWork_Load(object sender, EventArgs e)
        {
            //this.machine  = MachineType.Load<MachineType>(1);

            machine.OnLogAdded += Machine_OnLogAdded;
            LoadSortPrograms();
            refreshtimer = new Timer();
            refreshtimer.Interval = 500;
            refreshtimer.Tick += Refreshtimer_Tick;
            refreshtimer.Start();

            StatTimer = new Timer();
            StatTimer.Interval = 1000 * 60;
            StatTimer.Tick += StatTimer_TickAsync;
            StatTimer.Start();


            ToolTip t = new ToolTip();
            
            t.SetToolTip(checkBox1, "Status połączenia z maszyną");
            t = new ToolTip();
            t.SetToolTip(lbRun, "Przebieg");
            t = new ToolTip();
            t.SetToolTip(lbTactTime, "Czas taktu");
            t = new ToolTip();
            t.SetToolTip(lbFeederParcels, "Liczba przesyłek na podajniku");
            t = new ToolTip();
            t.SetToolTip(lbparcelsonline, "Liczba przesyłek na taśmie");
            t = new ToolTip();
            t.SetToolTip(lbcirclenumber, "Numer okrążenia");
            t = new ToolTip();
            t.SetToolTip(lbtactnumber, "Numer taktu");



            BindCharts();
            
            label4.Parent = this;

            runText();
        }

        private void Machine_OnLogAdded(object sender, MachineType.MachineLogEventArgs e)
        {
            Task.Run(() =>
            {
                listBox1.Invoke(new Action(() =>
                {
                    listBox1.Items.Insert(0, e.item.Time + " " + e.item.Event);
                }));
            });
        }

        private  void StatTimer_TickAsync(object sender, EventArgs e)
        {
            BindCharts();
        }

        private async void Refreshtimer_Tick(object sender, EventArgs e)
        {
            //return;
            try
            {
                if (machine.Driver.Connected == false)
                    label4.Invoke(new Action(() => { label4.Visible = true; label4.BringToFront(); }));
                else
                    label4.Invoke(new Action(() => { label4.Visible = false; label4.BringToFront(); }));
            }
            catch (Exception)
            {

                
            }

          await  Task.Run(() => {
                  try
                {
                    if (machine.BeltRunning == true)
                    {
                        pictureBox2.Invoke(new Action(() => pictureBox2.Image = ASS2_WF.Properties.Resources.workOn));
                    }
                    else
                    {
                        pictureBox2.Invoke(new Action(() => pictureBox2.Image = ASS2_WF.Properties.Resources.workoff));
                    }
                }
                catch (Exception)
                {
                }        
          });
                    var allsorted = await machine.AllSortedAsync();
                    var allmissed = await machine.AllMissedAsync();
            await Task.Run(() => {
                  try
                {


                    checkBox1.Invoke(new Action(() => { checkBox1.Checked = machine.Driver.Connected; }));
                    lbTactTime.Invoke(new Action(() => { lbTactTime.Text = machine.TactSensor.TactLenghtTime.Milliseconds.ToString() + "[ms]"; }));
                    lbFeederParcels.Invoke(new Action(() => { lbFeederParcels.Text = machine.Feeder1.Parcels.Count.ToString(); }));
                    lbparcelsonline.Invoke(new Action(() => { lbparcelsonline.Text = machine.ParcelsOnRun.Count.ToString(); }));
                    lbcirclenumber.Invoke(new Action(() => { lbcirclenumber.Text = machine.Driver.TactSensor.Counter.CircleNumber.ToString(); }));
                    lbtactnumber.Invoke(new Action(() => { lbtactnumber.Text = machine.Driver.TactSensor.Counter.TactNumber.ToString(); }));
                    lbsp.Invoke(new Action(() => { lbsp.Text = machine.CurrentSortProgram.Name; }));
                    lbAllsorted.Invoke(new Action(() => { lbAllsorted.Text = allsorted.ToString(); }));
                    lbAllMissed.Invoke(new Action(() => { lbAllMissed.Text = allmissed.ToString(); }));

                    if (machine.CurrentRun == null)
                        machine.CurrentRun = new RunType();
                    if (machine.CurrentRun.IsWorking() == false)
                        btnStartRun.Invoke(new Action(() => { btnStartRun.Enabled = true;}));
                    else
                        if (machine.ParcelsOnRun.Count > 0)
                        btnStartRun.Invoke(new Action(() => { btnStartRun.Enabled = false;}));

                }
                catch (Exception)
                {
                }          
            });



      

          
        }

        void LoadSortPrograms()
        {
            List<SortProgramType> spl = SortProgramType.LoadWhere<SortProgramType>("machineid=1");
            cbSortProgram.Items.Clear();
            foreach(var sp in spl)
            {
                cbSortProgram.Items.Add(new ComboboxItem() { Text = sp.Name, Value = sp.Id });
            }

            if (spl.Count > 0)
            {
                cbSortProgram.SelectedIndex = 0;
                
                InitMachine();

            }

        }

        void InitMachine()
        {
            ComboboxItem item = (ComboboxItem)cbSortProgram.SelectedItem;
            machine.InitMachine(item.Value);
            runText();
        }

        void runText()
        {
            if (machine.CurrentRun == null)
            {
                btnStartRun.Text = "Start";
                cbSortProgram.Enabled = true;
                lbRun.Text = "Przebieg: STOP";
            }
            else
            {
                if (machine.CurrentRun.IsWorking() == true)
                {
                    btnStartRun.Text = "Stop";
                    cbSortProgram.Enabled = false;
                    lbRun.Text = "Przebieg: " + machine.CurrentRun.StartTime.ToString();
                }
                else
                {
                    btnStartRun.Text = "Start";
                    cbSortProgram.Enabled = true;
                    lbRun.Text = "Przebieg: STOP";
                }
            }
        }

        private void btnStartRun_Click(object sender, EventArgs e)
        {
            ComboboxItem sp = (ComboboxItem)cbSortProgram.SelectedItem;
            machine.StartStopRun(sp.Value);
            runText();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            panel3.Left = panel1.Width / 2 - panel3.Width / 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            machine.StressSimulation(false); ;


        }

        private async void BindCharts()
        {
            
            List<Task> tasks = new List<Task>();
            var task1 = Task.Run(() => {
                try
                {
                    chart1.Invoke(new Action(() => { chart1.Series.Clear(); 
                    chart1.Series.Add("Przesyłek/min");
                    chart1.DataSource = machine.StatTable;
                    chart1.Series[0].XValueMember = "Czas";
                    chart1.Series[0].YValueMembers = "Liczba przesyłek";
                    chart1.Series[0].IsValueShownAsLabel = true;
                        chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;

                    chart1.ChartAreas[0].AxisY.Title = "Liczba przesyłek";
                    chart1.ChartAreas[0].AxisX.Interval = 1;
                    chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
                    chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                    chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

                    chart1.Legends.Clear();
                    chart1.Titles.Clear();
                    chart1.Titles.Add("Liczba przesyłek na godzinę");
                    chart1.Titles[0].Font = new Font("Arial", 14);

                    chart1.DataBind();
                    }));
                }
                catch (Exception)
                {

                   
                }

            });
            tasks.Add(task1);


             var task2 = Task.Run(() => {
                 try
                 {
                     chart2.Invoke(new Action(async () =>
                     {
                         chart2.Series.Clear();
                         DataTable dt = await machine.GetStandStats();
                         chart2.DataSource = dt;
                         chart2.Legends.Clear();
                         chart2.Legends.Add(new System.Windows.Forms.DataVisualization.Charting.Legend("Legend1"));


                         chart2.Series.Add("Wysortowane");
                         chart2.Series[0].Legend = "Legend1";
                         chart2.Series[0].XValueMember = "Stanowisko";
                         chart2.Series[0].YValueMembers = "Wysortowane";
                         chart2.Series[0].IsValueShownAsLabel = true;

                         chart2.Series.Add("Recyrkulacja");
                         chart2.Series[1].XValueMember = "Stanowisko";
                         chart2.Series[1].YValueMembers = "Recyrkulacja";
                         chart2.Series[1].IsValueShownAsLabel = true;


                         chart2.Series.Add("Obciążenie");
                         chart2.Series[2].XValueMember = "Stanowisko";
                         chart2.Series[2].YValueMembers = "Obciążenie";
                         chart2.Series[2].IsValueShownAsLabel = true;
                         chart2.Series[2].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;

                         chart2.ChartAreas[0].AxisX.Interval = 1;
                         chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                         chart2.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
                         chart2.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                         chart2.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
                         chart2.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
                         chart2.ChartAreas[0].AxisY2.MinorGrid.Enabled = false;
                         chart2.ChartAreas[0].AxisY2.Maximum = 100;
                         chart2.ChartAreas[0].AxisY2.Title = "Udział % w ogóle";
                         chart2.ChartAreas[0].AxisY.Title = "Liczba przesyłek";


                         chart2.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
                         chart2.Titles.Clear();
                         chart2.Titles.Add("Statystyka rozdziału");
                         chart2.Titles[0].Font = new Font("Arial", 14);


                         chart2.Series[0].Label = "#VALYszt";
                         chart2.Series[1].Label = "#VALYszt";
                         chart2.Series[2].Label = "#VALY %";

                         

                         chart2.DataBind();
                     }));
                 }
                 catch (Exception)
                 {


                 }
             });
            tasks.Add(task2);

            await Task.WhenAll(tasks);


            //if (pr!=null)
            //{
            //    pr.Invoke(new Action(() => {
            //        Task.Run(() => {pr.BindDG(machine.PArcelsAtLineTable().Result); });
            //    }));
            //}

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BindCharts();
        }

        private void chart1_Resize(object sender, EventArgs e)
        {

        }

        private void usWork_Resize(object sender, EventArgs e)
        {
            try
            {
                label4.Top = (this.Height / 2) - (label4.Height / 2);
                label4.Left = (this.Width / 2) - (label4.Width / 2);
            }
            catch (Exception)
            {


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.machine.StartDetectionSensor.Value = true;
            this.machine.StartDetectionSensor.Value = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        frmparcels pr;
        private void button4_Click(object sender, EventArgs e)
        {

            pr = new frmparcels();
            pr.machine = this.machine;
            pr.Show();
            pr.BringToFront();

        }
    }
}
