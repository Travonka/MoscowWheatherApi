using System;
using System.Diagnostics;

namespace WorkTimetest
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            var parsed =
                Metar_decoder.MetarDecoder.Decode(
                    "UUWW 042000Z 21003MPS CAVOK 01/M04 Q1008 R24/190060 NOSIG");
            sw.Stop();
            Console.WriteLine(sw.Elapsed);


        }
    }
}
