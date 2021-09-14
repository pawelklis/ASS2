using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public class ColorType
    {
        public List<bool> Values { get; set; }
        public ColorsList Name { get; set; }

        public ColorType()
        {

        }
        public ColorType(string name)
        {
            foreach (var c in Enum.GetValues(typeof(ColorsList)))
            {
                if (c.ToString() == name)
                {
                    this.Name = (ColorsList)c;
                    return;
                }
            }
        }
        public ColorType(ColorsList name)
        {
            this.Name = name;
        }

        public string ValuesString(int address)
        {
            int i = address;
            string s = "";
            foreach(var v in this.Values)
            {
                s +="PIN:" + i + "-" + v.ToString() + ",";
                i++;
            }
            
            return s;
        }

        public string CssString()
        {
            if (Name == ColorsList.BiałoNiebieski)
                return "background-image: repeating-linear-gradient(to left, white 10%, blue 20% )";
            if (Name == ColorsList.BiałoZielony)
                return "background-image: repeating-linear-gradient(to left, white 10%, green 20% )";
            if (Name == ColorsList.BiałoCzerwony)
                return "background-image: repeating-linear-gradient(to left, white 10%, red 20% )";

            if (Name == ColorsList.Niebieski)
                return "background-color: blue;";

            if (Name == ColorsList.Zielony)
                return "background-color: green;";
            if (Name == ColorsList.Czerwony)
                return "background-color: red;";
            if (Name == ColorsList.Żółty)
                return "background-color: yellow;";

            return "background-color: white;";
        }


        public enum ColorsList
        {            
            Biały,
            Zielony,
            Niebieski,
            Czerwony,
            Żółty,
            BiałoZielony,
            BiałoNiebieski,
            BiałoCzerwony
        }

    }
}
