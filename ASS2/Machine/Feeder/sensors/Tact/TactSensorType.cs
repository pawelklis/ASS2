using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ASS2
{
    public class TactSensorType : SensorType
    {

        public string Id { get; set; }
        public SensorType.SensorName Name { get; set; }
        public int Address { get; set; }
        public DateTime ValueChangedTime { get; set; }
        public TimeSpan TactLenghtTime { get; set; }

        private Timer WorkDetectionTimer { get; set; }
        private DateTime SupposedTactTime { get; set; }

        private RS232DeviceType serialsensor { get; set; }
        public CounterType Counter { get; set; }

        public void Connect()
        {
            try
            {
                this.serialsensor = new RS232DeviceType();
                this.serialsensor.OnDataReceived+= Serialsensor_OnDataReceived;
                this.serialsensor.Connect("COM47", "takt", 9600, 0,true);
            }
            catch (Exception)
            {

            }

        }

        private void Serialsensor_OnDataReceived(object sender, RS232DeviceType.SkanerEventArgs e)
        {
            if (e.DataReceived.Length > 0)
            {
                this.SetValue();// = true;
            }
            else
            {
                this.Value = false;
            };
        }

        //private bool myVal { get; set; }
        public event EventHandler<ModbusDriver.ModbusValueEventArgs> ValueChanged;
        public event EventHandler<EventArgs> BeltStart;
        public event EventHandler<EventArgs> BeltStop;
        public event EventHandler<EventArgs> TactMissed;
        public bool Value { get; set; }



        public void SetValue()
        {
            this.Value = false;
//            this.Counter.AddTact();


            try
            {



                // Task.Run(() =>
                // {

                this.TactLenghtTime = DateTime.Now - ValueChangedTime;

                if (TactLenghtTime.Milliseconds > 0)
                {

                    ModbusDriver.ModbusValueEventArgs me = new ModbusDriver.ModbusValueEventArgs();
                    me.Address = this.Address;
                    me.OldValue = false;
                    me.NewValue = true;
                    me.Name = this.Name.ToString();
                    EventHandler<ModbusDriver.ModbusValueEventArgs> handler = ValueChanged;
                    handler?.Invoke(this, me);
                }



                if (TactLenghtTime.TotalMilliseconds > 700)
                {
                    EventHandler<EventArgs> handler1 = TactMissed;
                    handler1?.Invoke(this, null);
                }

                BeltStarted();
                this.ValueChangedTime = DateTime.Now;
                //  });

                //this.Value = false;
                //Task.Run(() =>
                //{

                //});
                //this.Counter.TactNumber += 1;

            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }
            //myVal = true;


            //myVal = false;

            //}));
        }
        public TactSensorType()
        {
            this.Counter = new CounterType();
        }
        public TactSensorType(int machineid, int alltactscount)
        {
            this.Counter = new CounterType(machineid, alltactscount);
        }
        private void BeltStarted()
        {
            Task.Run(() =>
            {
                try
                {
                    this.SupposedTactTime = DateTime.Now.AddMilliseconds(900);
                    EventHandler<EventArgs> handler = BeltStart;
                    handler?.Invoke(this, new EventArgs());

                    WorkDetectionTimer?.Stop();
                    WorkDetectionTimer = new Timer();
                    WorkDetectionTimer.Interval = 10;
                    WorkDetectionTimer.Elapsed += WorkDetectionTimer_Elapsed;
                    WorkDetectionTimer.Start();
                }
                catch (Exception ex)
                {
                    ErrorLog.SaveError(ex);
                }

            });

        }

        private void WorkDetectionTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //Task.Run(new Action(() =>
            //{
            try
            {
                if (DateTime.Now > this.SupposedTactTime)
                {
                    EventHandler<EventArgs> handler = BeltStop;
                    handler?.Invoke(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

            // }));
        }
    }
}
