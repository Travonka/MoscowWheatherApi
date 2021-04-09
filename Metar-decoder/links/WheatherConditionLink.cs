using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Metar_decoder.interfaces;
using Entities;
using Metar_decoder.Extensions;
namespace Metar_decoder.links
{
    
    public class WheatherConditionLink : ILink
    {
        public (object, string) Parse(string rawData)
        {
            string conditionRegex = conditionRegexConstructor();
            string descriptionRegex = descriptionRegexConstructor();
            string regexPattern = "(" + descriptionRegex + conditionRegex + ")";
            Regex regex = new Regex(regexPattern);
            MatchCollection match = regex.Matches(rawData);
            if (match.Count != 0) {
                return (wheaterConstructor(match[0].Groups), regex.Replace(rawData, "", 1));
            }
            else { return ( new WheaterConditions(), rawData); }
        }
        private string conditionRegexConstructor()
        {
            string regex = "";
            foreach (var k in Enum.GetValues(typeof(Condition)))
            {
                regex = regex + k.ToString() + "|";
            }
            regex = regex.Remove(regex.Length - 1);
            regex = "(" + regex + ")";
            return regex;
        }
        private string descriptionRegexConstructor()
        {
            string regex = "";
            foreach (var k in Enum.GetValues(typeof(Description)))
            {
                regex = regex + k.ToString() + "|";
            }
            regex = regex.Remove(regex.Length - 1);
            regex = "(" + regex + ")";
            return regex;
        }
        private WheaterConditions wheaterConstructor(GroupCollection group)
        {
            WheaterConditions wheater = new WheaterConditions();
            wheater.wheaterConditions = group[3].Value.ToEnum<Condition>(Condition.undefined);
            wheater.wheaterDescription = group[2].Value.ToEnum<Description>(Description.undefined);
            return wheater;
        }

    }
}
