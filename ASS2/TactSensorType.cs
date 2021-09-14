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

        public CounterType Counter { get; set; }



        private bool myVal { get; set; }
        public event EventHandler<ModbusDriver.ModbusValueEventArgs> ValueChanged;
        public event EventHandler<EventArgs> BeltStart;
        public event EventHandler<EventArgs> BeltStop;
        public new bool Value
        {
            get { return myVal; }
            set
            {
                Task.Run(new Action(() =>
                {

                    if (value != myVal)
                    {

                        if (value == true)
                        {
                            BeltStarted();
                            TactLenghtTime = DateTime.Now - ValueChangedTime;
                            this.ValueChangedTime = DateTime.Now;

                            ModbusDriver.ModbusValueEventArgs me = new ModbusDriver.ModbusValueEventArgs();
                            me.Address = this.Address;
                            me.OldValue = myVal;
                            me.NewValue = value;
                            me.Name = this.Name.ToString();
                            EventHandler<ModbusDriver.ModbusValueEventArgs> handler = ValueChanged;
                            handler?.Invoke(this, me);

                            this.Counter.TactNumber += 1;
                            this.Counter.AddTact();
                        }

                        myVal = value;
                    }
                }));
            }
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
            Task.Run(new Action(() =>
            {
                this.SupposedTactTime = DateTime.Now.AddMilliseconds(700);
                EventHandler<EventArgs> handler = BeltStart;
                handler?.Invoke(this, new EventArgs());

                WorkDetectionTimer?.Stop();
                WorkDetectionTimer = new Timer();
                WorkDetectionTimer.Interval = 100;
                WorkDetectionTimer.Elapsed += WorkDetectionTimer_Elapsed;
                WorkDetectionTimer.Start();
            }));

        }

        private void WorkDetectionTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now > this.SupposedTactTime)
            {
                EventHandler<EventArgs> handler = BeltStop;
                handler?.Invoke(this, new EventArgs());
            }
        }
    }
}
