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
    public partial class usMaintenance : UserControl
    {
        public MachineType machine;
        public usMaintenance()
        {
            InitializeComponent();
        }

        private void usMaintenance_Load(object sender, EventArgs e)
        {
            Task.Run(() => { 
            machine.InitMachine(1);
            });
            machine.OnTacted += Machine_OnTacted;
            machine.OnStartParcelSensorRead += Machine_OnStartParcelSensorRead;
            machine.OnLogAdded += Machine_OnLogAdded;

            foreach(var l in machine.dict.Lamps)
            {                
                    comboBox1.Items.Add(l.Address.ToString() + " " + l.IsLamp1.ToString());
            }
            foreach(var c in machine.dict.Colors)
            {
                comboBox2.Items.Add(c.Name.ToString());
            }


            lbstopp.Text = machine.dict.StopSensorTact.ToString();
            lbdetectp.Text = machine.dict.ParcelStopRunTactNumber.ToString();
        }

        private void Machine_OnLogAdded(object sender, MachineType.MachineLogEventArgs e)
        {
            Task.Run(() =>
            {

                if (e.item.logtype== MachineStatusLogType.MachineEventsLogs.Brak_taktu)
                {
                    listBox1.Invoke(new Action(() => { listBox1.Items.Insert(0, DateTime.Now + "  " + machine.TactSensor.Counter.TactNumber + " " + lbCounter.Text); }));
                }
            });

        }

        private void Machine_OnStartParcelSensorRead(object sender, EventArgs e)
        {
            lbCounter.Invoke(new Action(() => {  lbCounter.Text = "000"; }));
        }

        private void Machine_OnTacted(object sender, EventArgs e)
        {
            int ci = int.Parse(lbCounter.Text);
            lbCounter.Invoke(new Action(() => {
                lbCounter.Text = ((int)(ci + 1)).ToString();
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(machine.Driver.Connected)
                machine.LampTest();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (machine.Driver.Connected)
                machine.LampTestSingleOn();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (machine.Driver.Connected)
                machine.LampTestTurnOnAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (machine.Driver.Connected)
                machine.LampTestTurnOffAll();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string adres = comboBox1.Text.Split(' ')[0];
            string isl1= comboBox1.Text.Split(' ')[1];
            LampType l= machine.dict.Lamps.Find(x => x.Address == int.Parse(adres) && x.IsLamp1.ToString()==isl1);

            ColorType c= machine.dict.Colors.Find(x => x.Name.ToString() == comboBox2.Text);
            if (machine.Driver.Connected)
                l.LightOn(c, machine.Driver);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string adres = comboBox1.Text.Split(' ')[0];
            string isl1 = comboBox1.Text.Split(' ')[1];
            LampType l = machine.dict.Lamps.Find(x => x.Address == int.Parse(adres) && x.IsLamp1.ToString() == isl1);
            if (machine.Driver.Connected)
                l.LightOff(machine.Driver);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            machine.ParcelsOnRun.Clear();
            
            machine.OnTacted += Machine_OnTacted1;
            machine.Driver.StopSensor.ValueChanged += StopSensor_ValueChanged;
            machine.Driver.StartDetectionSensor.ValueChanged += StartDetectionSensor_ValueChanged;
            machine.Driver.StartParcelSensor.ValueChanged += StartParcelSensor_ValueChanged;
            
        }

        private void StartParcelSensor_ValueChanged(object sender, ModbusDriver.ModbusValueEventArgs e)
        {
            ParcelType p = new ParcelType(machine.Driver, machine.dict.StopSensorTact, machine.dict.Stands,0,0);
            machine.ParcelsOnRun.Add(p);
        }

        private void StartDetectionSensor_ValueChanged(object sender, ModbusDriver.ModbusValueEventArgs e)
        {
            lbdetectionsensortact.Invoke(new Action(() => { lbdetectionsensortact.Text = machine.ParcelsOnRun[0].CurrentTactNumber.ToString(); }));
        }

        private void StopSensor_ValueChanged(object sender, ModbusDriver.ModbusValueEventArgs e)
        {
            lbstopsensortact.Invoke(new Action(() => { lbstopsensortact.Text = machine.ParcelsOnRun[0].CurrentTactNumber.ToString(); }));
        }

        private void Machine_OnTacted1(object sender, EventArgs e)
        {
            if(machine.ParcelsOnRun.Count>0)
                lbparceltact.Invoke(new Action(() => { lbparceltact.Text = machine.ParcelsOnRun[0].CurrentTactNumber.ToString(); }));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
