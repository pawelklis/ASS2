using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public class StopSensorType:SensorType
    {
        public string Id { get; set; }
        public SensorType.SensorName Name { get; set; }
        public int Address { get; set; }
        private bool myVal { get; set; }
        public int TactNumber { get; set; }
        public event EventHandler<ModbusDriver.ModbusValueEventArgs> ValueChanged;

        public new bool Value
        {
            get { return myVal; }
            set
            {
               
                if (value != myVal)
                {
                    if (value == true)
                    {
                        try
                        {
                            ModbusDriver.ModbusValueEventArgs me = new ModbusDriver.ModbusValueEventArgs();
                            me.Address = this.Address;
                            me.OldValue = myVal;
                            me.NewValue = value;
                            me.Name = this.Name.ToString();
                            EventHandler<ModbusDriver.ModbusValueEventArgs> handler = ValueChanged;
                            handler?.Invoke(this, me);
                        }
                        catch (Exception ex)
                        {
                            ErrorLog.SaveError(ex);
                        }
                     

                      
                    }

                    myVal = value;
                }
            }
        }

    }
}
