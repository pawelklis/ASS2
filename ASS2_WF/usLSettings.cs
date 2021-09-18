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
    public partial class usLSettings : UserControl
    {
        public MachineType machine;
        public StandType stand;
        public usLSettings()
        {
            InitializeComponent();
        }

        private void usLSettings_Load(object sender, EventArgs e)
        {

            this.groupBox4.Text = stand.Name;
            this.S1NM1.Value = stand.Lamp1.TactOnNumber;
            this.S1NM2.Value = stand.Lamp2.TactOnNumber;
        }

        private void S1NM1_ValueChanged(object sender, EventArgs e)
        {
            stand.Lamp1.TactOnNumber = (int)this.S1NM1.Value;
        }

        private void S1NM2_ValueChanged(object sender, EventArgs e)
        {
            stand.Lamp2.TactOnNumber = (int)this.S1NM2.Value;
        }

        private void S1L1_Click(object sender, EventArgs e)
        {
            if(machine.BeltRunning==true)
                if(machine.ParcelsOnRun.Count>0)
                    stand.Lamp1.TactOnNumber = machine.ParcelsOnRun[0].CurrentTactNumber;
        }

        private void S1L2_Click(object sender, EventArgs e)
        {
            if (machine.BeltRunning == true)
                if (machine.ParcelsOnRun.Count > 0)
                    stand.Lamp2.TactOnNumber = machine.ParcelsOnRun[0].CurrentTactNumber;
        }
    }
}
