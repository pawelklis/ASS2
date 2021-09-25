using ASS2.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS2
{
    public static class SledzenieServiceType
    {
        public static async Task<ASS2.ServiceReference1.Przesylka> SprawdzPrzesylkeAsync(string nr)
        {
            return await Task.Run(()=> SprawdzPrzesylke(nr));
        }
        public static ASS2.ServiceReference1.Przesylka SprawdzPrzesylke(string nr)
        {
            SledzeniePortTypeClient service = new SledzeniePortTypeClient();
            service.ClientCredentials.UserName.UserName = "sledzeniepp";
            service.ClientCredentials.UserName.Password = "PPSA";
            ASS2.ServiceReference1.Przesylka p;
            try
            {
                p = service.sprawdzPrzesylkePl(nr);
            }
            catch (Exception)
            {

                return null;
            }

            
            return p;
        }
    }
}
