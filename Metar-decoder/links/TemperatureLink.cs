using System;
using System.Collections.Generic;
using System.Text;
using Metar_decoder.interfaces;
using Entities;
using System.Text.RegularExpressions;
namespace Metar_decoder.links
{
    
    public class TemperatureLink : ILink
    {
        private string temperatureRegex = @"\b((M?[0-9]{2})/(M?[0-9]{2}))\b";
        public (object, string) Parse(string rawData)
        {
            Regex regex = new Regex(temperatureRegex);
            Match match = regex.Match(rawData);
            return (temperatureConstructor(match.Groups) , regex.Replace(rawData, ""));
        }
        private Temperature temperatureConstructor(GroupCollection group)
        {
            Temperature temperature = new Temperature();
            if (group[1].Success)
            {
                if (group[2].Success)
                {
                    string temp = group[2].Value;
                    temperature.temperature =  temp[0] == 'M' ?  (-1) * int.Parse(temp.Substring(1,2)) 
                                                              : int.Parse(temp.Substring(0, 2));
                }
                if (group[3].Success)
                {
                    string temp = group[3].Value;
                    temperature.dewPoint = temp[0] == 'M' ? (-1) * int.Parse(temp.Substring(1, 2))
                                                              : int.Parse(temp.Substring(0, 2));
                }
            }
            return temperature;
        }
    }
}
