using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Prosfores
{
    internal class DimosTools
    {
        static async Task Read(string[] input, string startHeader, string endHeader, string returnData)
        {

            string html = string.Empty;
            var client = new HttpClient();

            foreach (string s in input)
            {
                var result = await client.GetAsync(s);
                CookieContainer cookieContainer = new CookieContainer();
                Console.WriteLine(result.StatusCode);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(s);
                request.CookieContainer = cookieContainer;
                request.UserAgent = @"Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:59.0) Gecko/20100101 Firefox/59.0";


                Console.WriteLine("Άνοιγμα συνδέσμου: {0}", s);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        html = reader.ReadToEnd();
                    }

                }



            }

            Console.WriteLine(html);

        }
    }
}
