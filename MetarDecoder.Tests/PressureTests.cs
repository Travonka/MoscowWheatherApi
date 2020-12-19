using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Entities;
using Metar_decoder.links;
using MetarDecoder.Tests.Utils;
namespace MetarDecoder.Tests
{
    public class PressureTests
    {
        [Fact]
        public void Pressure_1()
        {
            string temp = "UAAA 221700Z 16002MPS 0500 R23R/1800D R23L/1400N FZFG FU SCT200 M11/M13 Q1028 R88/CLRD65 NOSIG";
            //Arrange
            AtmosphericPressure pressure = new AtmosphericPressure();
            pressure.pressure = 1028;
            AtmosphericPressureLink pressureLink = new AtmosphericPressureLink();
            //Act
            AtmosphericPressure atmosphericPressure = (AtmosphericPressure)pressureLink.Parse(temp).Item1;
            //Assert
            Assert.Equal(pressure, atmosphericPressure, new Comparator<AtmosphericPressure>());
        }
    }
}
