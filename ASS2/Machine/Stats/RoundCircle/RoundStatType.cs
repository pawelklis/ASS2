using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public class RoundStatType : DataBaseStorageHelper
    {
        public int Id { get; set; }
        public int RoundTime { get; set; }
        public int RoundNumber { get; set; }
        public int ParcelsCount { get; set; }
        public int MachineId { get; set; }
        public int SortProgramId { get; set; }
        public List<MachineStatusLogType> logs { get; set; }
        public List<RoundStatItem> StatItems { get; set; }

        public DateTime CircleStartTime { get; set; }
        public DateTime CircleEndTime { get; set; }
        public int CircleTime { get; set; }

        public RoundStatType()
        {

        }
        public RoundStatType(int roundnumber, int machineid, int sortprogramid)
        {
            try
            {
                this.StatItems = new List<RoundStatItem>();

                this.CircleStartTime = DateTime.Now;
                this.RoundNumber = roundnumber;
                this.MachineId = machineid;
                this.SortProgramId = sortprogramid;
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

        }

        public void AddItem(int tactnnumber, int startdetectionsensorreads, int startparcelreads, int stopsensorreads, int tactsensorreads, int tacttime)
        {
            Task.Run(() =>
            {

                try
                {
                    //if (tactnnumber==1)
                    //             this.StatItems.Clear();


                    RoundStatItem i = new RoundStatItem()
                    {
                        StartDetectionSensorReads = startdetectionsensorreads,
                        StartParcelSensorReads = startparcelreads,
                        StopSensorReads = stopsensorreads,
                        TactNumber = tactnnumber,
                        TactSensorReads = tactsensorreads,
                        TactTime = tacttime
                    };
                    this.StatItems.Add(i);
                }
                catch (Exception ex)
                {
                    ErrorLog.SaveError(ex);
                }


            });
        }

        public async void EndCircle(List<MachineStatusLogType> logs)
        {
            try
            {
                await Task.Run(() =>
                {
                    this.logs = logs;
                    this.CircleEndTime = DateTime.Now;
                    this.CircleTime = (int)(CircleEndTime - CircleStartTime).TotalMilliseconds;

                    this.Save();

                    this.StatItems.Clear();
                });

            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }



        }
    }
}
