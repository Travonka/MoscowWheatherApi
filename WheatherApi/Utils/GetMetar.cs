using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;

namespace MoscowWheatherApi.Utils
{
    public class GetMetar
    {
        private string adress = "https://tgftp.nws.noaa.gov/data/observations/metar/stations/UUEE.TXT";
        public async Task<string> Get()
        {
            string metar = "";
            var request = WebRequest.Create(adress);
            var response = await request.GetResponseAsync();
            await using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    reader.ReadLine();
                    metar = reader.ReadLine();
                }
            }
            
            response.Close();
            return metar;
        }
    }
}
