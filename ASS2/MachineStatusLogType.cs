using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public class MachineStatusLogType
    {
        public DateTime Time { get; set; }
        public string Event { get; set; }
        public MachineEventsLogs logtype { get; set; }
        public string Description { get; set; }


        public MachineStatusLogType()
        {
           
        }        

        public enum MachineEventsLogs
        {
            Start_programu,
            Sterowanie_połączono,
            Sterowanie_rozłączono,
            Przenośnik_uruchomiony,
            Przenośnik_zatrzymany,
            Brak_taktu
        }

        public MachineStatusLogType(MachineEventsLogs EventName,string description="")
        {
            this.Time = DateTime.Now;
            this.Event = EventName.ToString();
            this.logtype = EventName;
            this.Description = description;
        }
    }

}
