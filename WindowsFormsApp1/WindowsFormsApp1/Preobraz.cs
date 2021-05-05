using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace WindowsFormsApp1
{
   /* class Preobraz
    {
       public string TranslateText()
        {
            string s=" ";
            WebRequest request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates/145"
                   +"&text"+s);
            WebResponse response = request.GetResponse();
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                
                string line;
                if ((line = stream.ReadLine())!=null)
                {
                    Translation translation = JsonConvert.DeserializeObject<Translation>(line);
                    foreach (string str in translation.text)
                    {
                        s = str;
                    }


                }

            }
            return s;
                
        }

    }

    internal class Translation
    {
        public string[] text { get; set; }
    }*/
}

