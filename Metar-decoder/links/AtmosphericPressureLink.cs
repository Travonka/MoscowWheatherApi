using System;
using System.Collections.Generic;
using System.Text;
using Metar_decoder.interfaces;
using Entities;
using System.Text.RegularExpressions;
using Metar_decoder.Extensions;
namespace Metar_decoder.links
{
    public class AtmosphericPressureLink : ILink
    {
        const string pressureRegex = @"\b(Q[0-9]{4})\b";
        public (object, string) Parse(string rawData)
        {
            Regex regex = new Regex(pressureRegex);
            MatchCollection match = regex.Matches(rawData);
            return (pressureConstructor(match[0].Groups), regex.Replace(rawData, "", 1));
        }
        private AtmosphericPressure pressureConstructor(GroupCollection group)
        {
            AtmosphericPressure pressure = new AtmosphericPressure();
            if (group[1].Success)
            {
                pressure.pressure = int.Parse(group[1].Value.Substring(1, 4));
            }
            return pressure;
        }
    }
}
