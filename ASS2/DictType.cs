using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public class DictType:DataBaseStorageHelper
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public List<DirectionType> Directions { get; set; }

        public string iModbusIP { get; set; }
        public int ModbusPort { get; set; }

        public List<LampType> Lamps { get; set; }
        public List<ColorType> Colors { get; set; }
        public List<StandType> Stands { get; set; }
        public List<RS232ConfigType> SerialConfigs { get; set; }

        public int OdrzutyLamp1Tact { get; set; }
        public int OdrzutyLamp2Tact { get; set; }
        public int TactsCount { get; set; }
        public int StopSensorTact { get; set; }
        public int ParcelStopRunTactNumber { get; set; }
        public int FeederStartDetectionSensorTactNumber { get; set; }
        public static new T Load<T>(int MachineID) where T : new()
        {
            string tb = typeof(T).ToString().Replace("ASS2.", "").Replace("Type", "s");
            return MysqlCore.DB_Main().NewGetSingleObject<T>("Select * from `" + tb + "` where machineid=" + MachineID);
        }
        public DictType()
        {
            this.Lamps = new List<LampType>();
            int adr = 0;
            bool islmap1 = true;
            for (int i = 0; i < 12 * 2; i++)
            {
                LampType l = new LampType() { Address = adr, TactOnNumber = adr * 4 };
                l.IsLamp1 = islmap1;
                this.Lamps.Add(l);
                
                if (islmap1 == true)
                {
                    
                    islmap1 = false;
                }
                else
                {
                    islmap1 = true;
                    adr += 5;
                }

            }

            this.Stands = new List<StandType>();
            int li = 0;
            for (int i = 0; i < 12; i++)
            {
                StandType s = new StandType();
                s.Name = "Stanowisko " + (int)(i + 1);
                s.OrderNumber = i;
                s.Lamp1Index = li;
                s.Lamp2Index = (int)(li + 1);
                s.Items = new List<StandItemType>()
                {
                    new StandItemType(){ Color=new ColorType(), Direction=new DirectionType()},
                    new StandItemType(){ Color=new ColorType(), Direction=new DirectionType()},
                    new StandItemType(){ Color=new ColorType(), Direction=new DirectionType()},
                    new StandItemType(){ Color=new ColorType(), Direction=new DirectionType()},
                    new StandItemType(){ Color=new ColorType(), Direction=new DirectionType()},
                    new StandItemType(){ Color=new ColorType(), Direction=new DirectionType()},
                    new StandItemType(){ Color=new ColorType(), Direction=new DirectionType()}
                };
                
                this.Stands.Add(s);
                li += 2;
            }



            this.Directions = new List<DirectionType>();
            this.SerialConfigs = new List<RS232ConfigType>();

            this.Colors = new List<ColorType>() {
            new ColorType(){ Name= ColorType.ColorsList.Biały, Values=new List<bool>(){false,false,false,true,false}},
            new ColorType(){ Name= ColorType.ColorsList.Zielony, Values=new List<bool>(){false,false, true, false,false}},
            new ColorType(){ Name= ColorType.ColorsList.Niebieski, Values=new List<bool>(){ true, false,false,false,false}},
            new ColorType(){ Name= ColorType.ColorsList.Czerwony, Values=new List<bool>(){false, true, false,false,false}},
            new ColorType(){ Name= ColorType.ColorsList.BiałoZielony, Values=new List<bool>(){false,false, true, true, false}},
            new ColorType(){ Name= ColorType.ColorsList.BiałoNiebieski, Values=new List<bool>(){ true, false,false, true, false}},
            new ColorType(){ Name= ColorType.ColorsList.Czerwony, Values=new List<bool>(){false, true, false, true, false}},
            new ColorType(){ Name= ColorType.ColorsList.Żółty, Values=new List<bool>(){false,false,false,false,true}}
            };



        }
    }
}
