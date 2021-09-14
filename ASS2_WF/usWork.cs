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


        private List<string> numery;//symulacja

        public usWork()
        {
            InitializeComponent();
        }
        public MachineType machine;
        private void usWork_Load(object sender, EventArgs e)
        {
            numery = new List<string>();//symulacja
            numery.Add("EE922075416PL");//symulacja
            numery.Add("EE922177962PL");//symulacja
            numery.Add("EE922182239PL");//symulacja
            numery.Add("EE922170845PL");//symulacja
            numery.Add("EE922180706PL");//symulacja
            numery.Add("EE922060819PL");//symulacja
            numery.Add("EE922102584PL");//symulacja
            numery.Add("EE922204416PL");//symulacja
            numery.Add("EE922050079PL");//symulacja
            numery.Add("EE922135809PL");//symulacja
            numery.Add("EE922062647PL");//symulacja
            numery.Add("EE922051131PL");//symulacja
            numery.Add("EE922093335PL");//symulacja
            numery.Add("EE922181304PL");//symulacja
            numery.Add("EE922173210PL");//symulacja
            numery.Add("EE922074693PL");//symulacja
            numery.Add("EE922106714PL");//symulacja
            numery.Add("EE922169365PL");//symulacja
            numery.Add("EE922218675PL");//symulacja
            numery.Add("EE922148161PL");//symulacja
            numery.Add("EE922057845PL");//symulacja
            numery.Add("EE922121314PL");//symulacja
            numery.Add("EE922054610PL");//symulacja
            numery.Add("EE921783550PL");//symulacja
            numery.Add("EE354118933PL");//symulacja
            numery.Add("EE579107203PL");//symulacja
            numery.Add("EE263547297PL");//symulacja
            numery.Add("EE572467215PL");//symulacja
            numery.Add("EE922227669PL");//symulacja
            numery.Add("EE505167054PL");//symulacja
            numery.Add("EE458662065PL");//symulacja
            numery.Add("EE552383508PL");//symulacja
            numery.Add("EE552383508PL");//symulacja
            numery.Add("EE566046219PL");//symulacja
            numery.Add("EE566046222PL");//symulacja
            numery.Add("EE584722967PL");//symulacja
            numery.Add("EE923041918PL");//symulacja
            numery.Add("EE572019084PL");//symulacja
            numery.Add("EE572467238PL");//symulacja
            numery.Add("EE585124523PL");//symulacja
            numery.Add("EE541280710PL");//symulacja
            numery.Add("EE585072256PL");//symulacja

            refreshtimer = new Timer();
            refreshtimer.Interval = 100;
            refreshtimer.Tick += Refreshtimer_Tick;
            refreshtimer.Start();

            LoadSortPrograms();
        }

        private void Refreshtimer_Tick(object sender, EventArgs e)
        {
            Task.Run(new Action(() => {

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
                try
                {
                    checkBox1.Invoke(new Action(() => { checkBox1.Checked = machine.Driver.Connected; }));
                    lbTactTime.Invoke(new Action(() => { lbTactTime.Text = machine.TactSensor.TactLenghtTime.Milliseconds.ToString() + "[ms]"; }));
                    lbFeederParcels.Invoke(new Action(() => { lbFeederParcels.Text = machine.Feeder1.Parcels.Count.ToString(); }));

                }
                catch (Exception)
                {                   
                }
                try
                {
                    int i1 = dg1.FirstDisplayedScrollingRowIndex;
                    int i2 = dg2.FirstDisplayedScrollingRowIndex;
                    //dg1.Invoke(new Action(() => { dg1.DataSource = machine.PArcelsAtLineTable().Result; }));
                    //dg2.Invoke(new Action(() => { dg2.DataSource = machine.StandStatsTable().Result; }));

                    if(i1>-1)
                    dg1.Invoke(new Action(() => {
                        dg1.FirstDisplayedScrollingRowIndex = i1;
                    }));
                    if(i2>-1)
                    dg2.Invoke(new Action(() => {
                        dg2.FirstDisplayedScrollingRowIndex = i2;
                    }));
                }
                catch (Exception)
                {
                }
            
            
            }));
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
            machine.StartStopRun();
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
            Task.Run(new Action(() =>
            {
                int numi = 0;
                for (int i = 0; i < 1000000; i++)
                {

                    System.Threading.Thread.Sleep(1000);
                    machine.Driver.StartDetectionSensor.Value = true;
                    machine.Driver.StartDetectionSensor.Value = false;
                    System.Threading.Thread.Sleep(2000);
                    if(machine.Feeder1.Parcels.Count>0)
                        machine.Feeder1.Parcels[0].SetNumber(numery[numi], machine.dict.Stands);
                    System.Threading.Thread.Sleep(2000);

                    machine.Driver.StartParcelSensor.Value = true;
                    machine.Driver.StartParcelSensor.Value = false;

                    if(machine.ParcelsOnRun.Count>0)
                        machine.ParcelsOnRun.Last().SetLenght(1200);

                    numi++;
                    if (numi > numery.Count-1)
                        numi = 0;

                }
            }));


        }
    }
}
