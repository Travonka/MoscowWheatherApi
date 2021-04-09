using System;
using System.Collections.Generic;
using System.Text;
using Metar_decoder.interfaces;
using Entities;
using System.Text.RegularExpressions;
using Metar_decoder.Extensions;
namespace Metar_decoder.links
{
    
    public class WindLink : ILink
    {
        private const string windRegex = @"(VRB?|([0-9]{3}))([0-9]{2})(G[0-9]{2})?(KMH|MPS|KT)\s(([0-9]{3})V([0-9]{3})\s)?"; 
        public (object, string) Parse(string rawData) 
        {
            Regex regex = new Regex(windRegex);
            
            Match match = regex.Match(rawData);
            return (WindConstruction(match.Groups) , regex.Replace(rawData, "", 1));
        }
        private Wind WindConstruction(GroupCollection group)
        {
            Wind wind = new Wind();
            if (group[1].Value.Contains("VRB"))
            {
                wind.variable = true;
            }
            else 
            {
                wind.direction = int.Parse(group[2].Value);
            }
            wind.speed = int.Parse(group[3].Value);
            if (group[4].Value.Contains("G"))
            {
                wind.gustsSpeed = int.Parse(group[4].Value.Remove(0,1));
                wind.gusts = true;
            }
            else
            {
                wind.gusts = false;
            }
            if (group[6].Success)
            {
                wind.changes = true;
                wind.from = int.Parse(group[7].Value);
                wind.to = int.Parse(group[8].Value);
            }
            wind.measurmnet = group[5].Value.ToEnum<Measurmnet>(Measurmnet.KMH);
            return wind;
        }
        
    }
}
