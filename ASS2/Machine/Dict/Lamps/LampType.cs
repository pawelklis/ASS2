using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public class LampType
    {
        public int Address { get; set; }
        public int TactOnNumber { get; set; }
        public bool IsLamp1 { get; set; }

        public void LightOn(ColorType color, ModbusDriver driver)
        {

            try
            {
            if (color == null)
                return;
            Task.Run(new Action(() =>
            {
                if (IsLamp1 == false)
                {
                    driver.WriteCoils(this.Address, color.Values.GetRange(0, 4).ToArray());
                }
                else
                {
                    bool[] ar = new bool[] { color.Values.Last<bool>() };
                    driver.WriteCoils(this.Address + 4, ar);
                }
            }));
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }


        }
        public void LightOff(ModbusDriver driver)
        {
            try
            {
            Task.Run(new Action(() =>
            {
                if (IsLamp1 == false)
                {
                    driver.WriteCoils(this.Address, new bool[] { false, false, false, false });
                }
                else
                {
                    bool[] ar = new bool[] { false };
                    driver.WriteCoils(this.Address + 4, ar);
                }
            }));
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

        }
    }
}
