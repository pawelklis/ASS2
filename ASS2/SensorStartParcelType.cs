using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
   public class SensorStartParcelType
    {

        public string Id { get; set; }
        public SensorType.SensorName Name { get; set; }
        public int Address { get; set; }
        private bool myVal { get; set; }
        public int FeederIndex;

        private DateTime TrueValue;
        private DateTime falseValue;

        public event EventHandler<ModbusDriver.ModbusValueEventArgs> ValueChanged;
        public event EventHandler<StartSensorEventArgs> OnLenghtReaded;
        public bool Value
        {
            get { return myVal; }
            set
            {
                if (value != myVal)
                {
                    Task.Run(new Action(() => { 
                    if (value == false)
                            TrueValue = DateTime.Now;
                        if (value == true)
                        {
                            falseValue = DateTime.Now;
                            StartSensorEventArgs args = new StartSensorEventArgs();
                            args.TimeValue = falseValue - TrueValue;
                            EventHandler<StartSensorEventArgs> handler = OnLenghtReaded;
                            handler?.Invoke(this, args);

                        }
                    
                    if(value==false)
                        RaiseEvent(value);

                    myVal = value;}));
                }

            }
        }

        public void RaiseEvent(bool newval)
        {


            ModbusDriver.ModbusValueEventArgs me = new ModbusDriver.ModbusValueEventArgs();
            me.Address = this.Address;
            me.OldValue = myVal;
            me.NewValue = newval;
            me.Name = this.Name.ToString();
            EventHandler<ModbusDriver.ModbusValueEventArgs> handler = ValueChanged;
            handler?.Invoke(this, me);
        }

        public class StartSensorEventArgs
        {
            public TimeSpan TimeValue { get; set; }
        }

    }
}
