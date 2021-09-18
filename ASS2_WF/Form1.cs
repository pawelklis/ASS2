using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASS2;

namespace ASS2_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MachineType Machine;
        
        private void Form1_Load(object sender, EventArgs e)
        {

            button1.Visible = false;
            button2.Visible = false;
            button5.Visible = false;
            button17.Visible = false;

            Machine = new MachineType();
            Machine = MachineType.Load<MachineType>(1);

            usWork usw = new usWork();
            usw.machine = this.Machine;
            usw.Dock = DockStyle.Fill;
            pnContainer.Controls.Clear();
            pnContainer.Controls.Add(usw);

            panel4.Parent = this;
            panel4.Dock = DockStyle.Fill;
            panel4.Visible = true;
            panel4.BringToFront();

            this.WindowState = FormWindowState.Maximized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Machine.Driver.TactSensor.Value = true;
            Machine.Driver.TactSensor.Value = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Task.Run(new Action(() => {
                for (int i = 0; i < 10000000; i++)
                {


                    Machine.Driver.TactSensor.Value = true;
                    Machine.Driver.TactSensor.Value = false;


                    System.Threading.Thread.Sleep(500);

               
                }
            }));
        }
        void ClearpnContrainer()
        {
                List<Control> lc = new List<Control>();
                foreach(Control c in this.pnContainer.Controls)
                {
                    if (c.Name != "usWork")
                    {
                        lc.Add(c);
                    }
                }

                foreach(var c in lc)
                {
                    this.pnContainer.Controls.Remove(c);
                }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (Machine.CurrentRun == null)
                Machine.CurrentRun = new RunType();
            if (Machine.CurrentRun.IsWorking() == false)
            {
                ClearpnContrainer();

                usMaintenance usm = new usMaintenance();
                usm.Dock = DockStyle.Fill;
                usm.machine = Machine;
                this.pnContainer.Controls.Add(usm);
                usm.BringToFront();
            }

     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearpnContrainer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearpnContrainer();

            usSettings usm = new usSettings();
            usm.Dock = DockStyle.Fill;
            usm.machine = Machine;
            this.pnContainer.Controls.Add(usm);
            usm.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txlogin.Text += "1";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txlogin.Text += "2";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txlogin.Text += "3";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txlogin.Text += "4";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txlogin.Text += "5";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txlogin.Text += "6";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            txlogin.Text += "7";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txlogin.Text += "8";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txlogin.Text += "9";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            txlogin.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (txlogin.Text == "1")
            {
                button1.Visible = true;
                button2.Visible = false;
                button5.Visible = false;
                button17.Visible = true;
                panel4.Visible = false;
            }
            if (txlogin.Text == "2")
            {
                button1.Visible = true;
                button2.Visible = false;
                button5.Visible = true;
                panel4.Visible = false;
                button17.Visible = true;
            }
            if (txlogin.Text == "3")
            {
                button1.Visible = true;
                button2.Visible = true;
                button5.Visible = true;
                panel4.Visible = false;
                button17.Visible = true;
            }

            txlogin.Text = "";


        }

        private void panel4_Resize(object sender, EventArgs e)
        {
            try
            {
                panel3.Left = (panel4.Width / 2) - (panel3.Width / 2);
                panel3.Top = (panel4.Height / 2) - (panel3.Height / 2);
            }
            catch (Exception)
            {

               
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {

            button1.Visible = false;
            button2.Visible = false;
            button5.Visible = false;
            button17.Visible = false;

            panel4.Parent = this;
            panel4.Dock = DockStyle.Fill;
            panel4.Visible = true;
            panel4.BringToFront();
        }
    }
}
