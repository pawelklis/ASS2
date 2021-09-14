using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public interface SensorType
    {
        public string Id { get; set; }
        public SensorName Name { get; set; }
        public int Address { get; set; }

        public  bool Value { get; set; }
   //     public  event EventHandler<ModbusDriver.ModbusValueEventArgs> ValueChanged;

        //public SensorType()
        //{
        //    this.Id = Guid.NewGuid().ToString();
        //}



        public enum SensorName
        {
            startdetectionsensor,
            startparcelsensor,
            tactsensor,
            stopsensor
        }
    }
}
