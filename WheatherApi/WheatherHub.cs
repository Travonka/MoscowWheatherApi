using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metar_decoder;
using Newtonsoft.Json;
using MoscowWheatherApi.Utils;
namespace MoscowWheatherApi
{
    public class WheatherHub
    {
        private GetMetar getMetar;
        private static WheatherHub instance;
        private WheatherHub()
        {
            getMetar = new GetMetar();
        }
        public static WheatherHub getInstance()
        {
            if (instance == null)
            {
                instance = new WheatherHub();               
            }
            return instance;
        }
        public string GetWheather()
        {
            string metar = getMetar.Get();
            var decodedMetar = MetarDecoder.Decode(metar);
            return JsonConvert.SerializeObject(decodedMetar);
        }
    }
}
