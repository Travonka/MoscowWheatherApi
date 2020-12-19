using System;
using Metar_decoder;
using Metar_decoder.links;
using Entities;
using System.Threading;
namespace ConsoleDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            string Metar = "UUEE 142300Z 11003MPS 1100 1000NE R06R/2000U R06L/2000N SN OVC014 M06/M07 Q1020 R06R/590320 R06L/590320 TEMPO 0600 +SHSN BKN010CB";
            var temp = MetarDecoder.Decode(Metar);
            Console.WriteLine(temp.ICAO);
            //Act
            //Assert
        }
    }
}
