using Entities;
using Metar_decoder.interfaces;
using System.Text.RegularExpressions;

namespace Metar_decoder.links
{   
    public class AirportLink : ILink
    {
        const string airportRegex = @"[A-Z]{4}";
        public (object, string remainMetart) Parse(string rawData) 
        {
            Regex regex = new Regex(airportRegex);
            MatchCollection matches = regex.Matches(rawData);
            return (new Airport()
            {
                ICAO = matches[0].Value
            }, regex.Replace(rawData, "", 1));
        }
    }
}
