using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASS2;

namespace ScanningApp
{
    public class ScanerApp
    {

        public RS232DeviceType Scaner { get; set; }


        public void Connect()
        {
            Scaner = new RS232DeviceType();
            Scaner.OnDataReceived += Scaner_OnDataReceived;
            Scaner.Connect("Com43", "sc1", 9600, 40);
        }

        private void Scaner_OnDataReceived(object sender, RS232DeviceType.SkanerEventArgs e)
        {
            try
            {
            HandScan hs = new HandScan();
            hs.time = DateTime.Now;
            hs.Number = e.DataReceived;
            MysqlCore.DB_Main().ExecuteNonQuery("INSERT INTO`scanningapp.handscan` (`time`,`Number`) VALUES ('" + hs.time  + "','"+ hs.Number + "'); ");
            Console.WriteLine(hs.time + " " + hs.Number);
            }
            catch (Exception)
            {

            
            }

        }
    }
}
