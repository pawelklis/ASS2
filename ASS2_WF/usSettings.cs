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
    public partial class usSettings : UserControl
    {
        public MachineType machine;
        public usSettings()
        {
            InitializeComponent();
        }

        private void usSettings_Load(object sender, EventArgs e)
        {

            txCom.Text = machine.dict.SerialConfigs[0].PortName;
            txspeed.Value = machine.dict.SerialConfigs[0].Speed;
            txdelay.Value = machine.dict.SerialConfigs[0].Delay;

            txparcelstoptactnumber.Value = machine.dict.ParcelStopRunTactNumber;
            txstartdetectionparcel.Value = machine.dict.FeederStartDetectionSensorTactNumber;
            txstopsensortact.Value = machine.dict.StopSensorTact;
            txtactscount.Value = machine.dict.TactsCount;
            this.panel1.Controls.Clear();

            int tp = 0;
            foreach(var s in machine.dict.Stands)
            {
                usLSettings us = new usLSettings();
                us.machine = machine;
                us.stand = s;
                us.Top = tp;
                panel1.Controls.Add(us);
                tp += (us.Height + 5);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            machine.dict.SerialConfigs[0].PortName = txCom.Text;
            machine.dict.SerialConfigs[0].Speed =(int)txspeed.Value;
            machine.dict.SerialConfigs[0].Delay = (int)txdelay.Value;
            machine.dict.ParcelStopRunTactNumber = (int)txparcelstoptactnumber.Value;
            machine.dict.FeederStartDetectionSensorTactNumber = (int)txstartdetectionparcel.Value;
            machine.dict.StopSensorTact = (int)txstopsensortact.Value;
            machine.dict.TactsCount = (int)txtactscount.Value;
            machine.dict.SaveAsync();
        }
    }
}
