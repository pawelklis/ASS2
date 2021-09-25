using System;

namespace ASS2
{
    public class StandItemType
    {
        public string Id { get; set; }
        public DirectionType Direction { get; set; }
        public ColorType Color { get; set; }

        public int MissedParcels { get; set; }
        public int SortedParcels { get; set; }

        public int Lamp1OnTacts;
        public bool Lamp1IsOn;
                     
        public StandItemType()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Direction = new DirectionType() { Id = "", Name = "" };

            
        }
    }
}