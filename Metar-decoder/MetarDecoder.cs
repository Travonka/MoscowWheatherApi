using System;
using Entities;
using Metar_decoder.interfaces;
using Metar_decoder.links;
using System.Collections.Generic;
using System.Reflection;

namespace Metar_decoder
{
    public class MetarDecoder
    {
        static readonly List<ILink> chain = new List<ILink>()
        { 
            new AirportLink(),
            new CloudLink(),
            new TemperatureLink(),
            new VisabilityLink(),
            new WindLink(),
            new DateLink(),
            new WheatherConditionLink(),
            new AtmosphericPressureLink()
        };
        static readonly List<ILink> chain2 = new List<ILink>()
        {
        };

        public static WeatherData Decode(string rawData)
        {
            rawData = rawData.ToUpper();
            var _rawData = rawData.Split();
            WeatherData weatherData = new WeatherData();
            object data;
            foreach (var link in chain)
            {
               (data, rawData) = link.Parse(rawData);
                foreach (var property in weatherData.GetType().GetProperties())
                {
                    if (property.PropertyType.FullName == data.GetType().FullName)
                    {
                        property.SetValue(weatherData, data, null);
                    }
                }
            }

            return weatherData;
        }

       

        public static bool IsCorrect(string rawData)
        {
            return true;
        }
    }
}
