using System;
using System.Collections.Generic;
using System.Text;
using Metar_decoder.interfaces;
using System.Text.RegularExpressions;
using Entities;
namespace Metar_decoder.links
{
    class DateLink : ILink
    {
        const string dateRegex = "[0-9]{6}[Z]{1}";
        public (object, string) Parse(string rawData)
        {
            Regex regex = new Regex(dateRegex);
            MatchCollection match = regex.Matches(rawData);
            return (timeConstructor(match[0].Value), regex.Replace(rawData,"", 1));
        }
        private Date timeConstructor(string time)
        {

            string _day = time[0].ToString() + time[1].ToString();
            string hours = time[2].ToString() + time[3].ToString();
            string minutes = time[4].ToString() + time[5].ToString();
            Date date = new Date()
            {
                day = int.Parse(_day),
                time = hours + ":" + minutes
            };

            return date;
        }
    }
}
