using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Entities;
using Metar_decoder.links;
using MetarDecoder.Tests.Utils;
namespace MetarDecoder.Tests
{
    public class TemperatureTests
    {
        [Fact]
        public void temperatureTest_1()
        {
            //Arrange
            Temperature actualTemperature = new Temperature()
            {
                temperature = 11,
                dewPoint = -13
            };
            TemperatureLink temperatureLink = new TemperatureLink();

            //Act
            Temperature temperature = (Temperature)temperatureLink.Parse("UAAA 221700Z 16002MPS 0500 R23R/1800D " +
                                                                         "R23L/1400N FZFG FU SCT200 11/M13 Q1028 R88/CLRD65 NOSIG").Item1;

            //Assert
            Assert.Equal(actualTemperature, temperature, new Comparator<Temperature>());

        }

    }
}
