using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Metar_decoder.interfaces;
using Entities;
using Metar_decoder.Extensions;
namespace Metar_decoder.links
{
   
    public class VisabilityLink : ILink
    {
        private const string visabilityRegex = @"(\b([0-9]{4})\b|\b(([0-9]{4})([A-Z]{2}))\b)";
        public (object, string) Parse(string rawData) 
        {
            Regex regex = new Regex(visabilityRegex);
            Match match = regex.Match(rawData);
            MatchCollection matchCollection = regex.Matches(rawData);
            return (visabilityConstructor(matchCollection), regex.Replace(rawData, ""));
        }
        private Visability visabilityConstructor(MatchCollection matchCollection)
        {
            Visability visability = new Visability();
            foreach (Match match in matchCollection)
            {
                GroupCollection group = match.Groups;
                if (group[2].Success && visability.prevailingVisibility == 0)
                {

                    visability.prevailingVisibility = int.Parse(group[2].Value);
                    visability.measurmnet = DistanceMeasurmnet.Meters;
                }
                if (group[3].Success)
                {

                    visability.minimumVisability = int.Parse(group[4].Value);
                    visability.direction = group[5].Value.ToEnum<Directions>(Directions.none);
                }
            }
            return visability;
        }
    }
}
