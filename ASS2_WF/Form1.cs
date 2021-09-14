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
            Machine = new MachineType();
            Machine = MachineType.Load<MachineType>(1);

            usWork usw = new usWork();
            usw.machine = this.Machine;
            usw.Dock = DockStyle.Fill;
            pnContainer.Controls.Clear();
            pnContainer.Controls.Add(usw);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Machine.Driver.StartParcelSensor.Value = true;
            Machine.Driver.StartParcelSensor.Value = false;
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
    }
}
