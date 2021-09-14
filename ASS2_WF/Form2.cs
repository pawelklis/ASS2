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
    public partial class Form2 : Form
    {
        MachineType m;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m.TactSensor.Value = true;
            m.TactSensor.Value = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            m = new MachineType();
            m.Id = 1;
            m.InitMachine(2);
            m.OnTacted += M_OnTacted;
        }

        private void M_OnTacted(object sender, EventArgs e)
        {
            try
            {
                listBox2.Invoke(new Action(() => { listBox2.Items.Clear(); }));
                listBox1.Invoke(new Action(() => { listBox1.Items.Clear(); }));
                foreach (var p in m.Feeder1.Parcels)
                {
                    listBox1.Invoke(new Action(() => { listBox1.Items.Add(p.GuidID); }));
                }
                foreach (var p in m.ParcelsOnRun)
                {
                    listBox2.Invoke(new Action(() => { listBox2.Items.Add(p.GuidID + " " + p.Number + " " + p.DestinationStandItem.Direction.Name + " " + p.DestinationStand.Lamp1.TactOnNumber + " " + p.DestinationStandItem.Lamp1OnTacts + " " + p.CurrentTactNumber + " " + p.Recircuit + " " + p.RoundCounts + " " + p.Lenght); }));
                }

           
                progressBar1.Invoke(new Action(()=>      progressBar1.Value = m.TactSensor.Counter.TactNumber));
                label1.Invoke(new Action(() => label1.Text = progressBar1.Value.ToString()));
            }
            catch (Exception)
            {

           
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            m.Driver.StartDetectionSensor.Value = true;
            m.Driver.StartDetectionSensor.Value = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            m.Driver.StartParcelSensor.Value = true;
            m.Driver.StartParcelSensor.Value = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            m.Driver.StopSensor.Value = true;
            m.Driver.StopSensor.Value = false;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                button1.PerformClick();
            if (e.KeyCode == Keys.Z)
                button2.PerformClick();
            if (e.KeyCode == Keys.X)
                button3.PerformClick();
            if (e.KeyCode == Keys.C)
                button4.PerformClick();

        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
          

        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                button1.PerformClick();
            if (e.KeyCode == Keys.Z)
                button2.PerformClick();
            if (e.KeyCode == Keys.X)
                button3.PerformClick();
            if (e.KeyCode == Keys.C)
                button4.PerformClick();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Task.Run(new Action(() => { 
            for (int i = 0; i < 10000000; i++)
            {
                    if (m.TactSensor.Counter.TactNumber == 50)
                    {
                        //button3.Invoke(new Action(() => { button3.PerformClick(); }));
                    }
               
                        //if (m.ParcelsOnRun.Count > 0)
                            //if (m.ParcelsOnRun[0]?.CurrentTactNumber == m.Feeder1.TactNumber)
                               //button2.Invoke(new Action(() => { button2.PerformClick(); }));
                    

                    //if(m.ParcelsOnRun.Count>0)
                        //if(m.ParcelsOnRun[0]?.CurrentTactNumber==350)
                            //button1.Invoke(new Action(() => button4.PerformClick()));

                    button1.Invoke(new Action(()=> button1.PerformClick()));

        
                    System.Threading.Thread.Sleep(500);

                    //if (m.TactSensor.Counter.TactNumber > 60)
                    //    if (m.TactSensor.Counter.TactNumber < 383)
                    //        System.Threading.Thread.Sleep(50);

                    //if (m.TactSensor.Counter.TactNumber < 60)
                    //    System.Threading.Thread.Sleep(500);
                    //if (m.TactSensor.Counter.TactNumber > 383)
                    //    System.Threading.Thread.Sleep(500);
                }
            }));
        }
    }
}
