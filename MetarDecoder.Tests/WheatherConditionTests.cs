using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Entities;
using Metar_decoder.links;
using MetarDecoder.Tests.Utils;
namespace MetarDecoder.Tests
{
    public class WheatherConditionTests
    {
        [Fact]
        public void wheatherConditionTest_1()
        {
            //Arrange
            WheaterConditions expectedCond = new WheaterConditions();
            expectedCond.wheaterConditions = Entities.Condition.FG;
            expectedCond.wheaterDescription = Entities.Description.FZ;
            string Metar = "UAAA 221700Z 16002MPS 0500 R23R/1800D R23L/1400N FZFG FU SCT200 M11/M13 Q1028 R88/CLRD65 NOSIG";
            WheatherConditionLink conditionLink = new WheatherConditionLink();
            //Act
            WheaterConditions actualCond = (WheaterConditions)conditionLink.Parse(Metar).Item1;
            //Assert
            Assert.Equal(expectedCond, actualCond, new Comparator<WheaterConditions>());
        }
    }
}
