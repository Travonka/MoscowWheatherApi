using System;
using System.Collections.Generic;
using System.Text;
using Metar_decoder.interfaces;
using Entities;
using System.Text.RegularExpressions;
using Metar_decoder.Extensions;
namespace Metar_decoder.links
{
    
    public class CloudLink : ILink
    {
        const string cloudRegex = @"\b(([A-Z]{3}[0-9]{3})|(VV[0-9]{3}))\b";
        public (object, string) Parse(string rawData)  
        {
            Regex regex = new Regex(cloudRegex);
            MatchCollection match = regex.Matches(rawData);
            if (match.Count == 0)
            {
                return ((new Cloud(), rawData));
            }
            return (CloudConstructor(match[0].Groups), regex.Replace(rawData, "", 1));
        }
        private Cloud CloudConstructor(GroupCollection group)
        {
            Cloud cloudCoverege = new Cloud();
            if (group[1].Success)
            {
                if (group[2].Success)
                {
                    string temp = group[2].Value;
                    cloudCoverege.lowerBoundaryAltitude = int.Parse(temp.Substring(3,3)) * 100;
                    cloudCoverege.coverege = temp.Substring(0, 3).ToEnum<CloudCoverege>(CloudCoverege.undefined);
                }
                else
                {
                    string temp = group[3].Value;
                    cloudCoverege.verticalVisability = int.Parse(temp.Substring(2, 3));
                }
            
            }
            return cloudCoverege;
        }
    }
}
