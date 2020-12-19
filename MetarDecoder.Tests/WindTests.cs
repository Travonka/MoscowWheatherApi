using System;
using Xunit;
using Metar_decoder.links;
using Entities;
using MetarDecoder.Tests.Utils;
namespace MetarDecoder.Tests
{
    public class WindTests
    {
        [Fact]
        public void CanParseWind()
        {
            //Arrange
            WindLink windLink = new WindLink();
            Wind _wind = new Wind();
                _wind.measurmnet = Measurmnet.MPS;
                _wind.direction = 170;
                _wind.speed = int.Parse("03");
                _wind.gusts = false;
                _wind.gustsSpeed = 0;
                _wind.from = 130;
                _wind.to = 220;
                _wind.variable = false;
                _wind.changes = true;
            //Act
            var data = windLink.Parse("UUEE 17003MPS 130V220 OVC007 02/00 Q1027 R06R/290051 R06L/290051 NOSIG").Item1;
            Wind temp = (Wind)data;
            //Assert
            Assert.Equal(_wind, temp, new Comparator<Wind>());

        }
    }
}
