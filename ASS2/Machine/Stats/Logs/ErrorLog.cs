using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public class ErrorLog
    {
        static string logPath = @"C:\ASS2\logs\";
        public static void SaveError(Exception ex)
        {
            try
            {
                Task.Run(() => {

                if (!System.IO.Directory.Exists(logPath))
                    System.IO.Directory.CreateDirectory(logPath);

                System.IO.File.WriteAllText(logPath + DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "") + ".txt",ex.Message +"\n" + ex.ToString());
                });
            }
            catch (Exception)
            {

               
            }
        }

    }
}
