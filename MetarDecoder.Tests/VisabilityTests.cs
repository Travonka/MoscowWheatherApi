using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Entities;
using Metar_decoder.links;
using MetarDecoder.Tests.Utils;
namespace MetarDecoder.Tests
{
    public class VisabilityTests
    {
        [Fact]
        public void CanParseVisability()
        { //Arrange
            Visability expectedVisability = new Visability()
            {
                prevailingVisibility = 0500,

            };
            VisabilityLink visabilityLink = new VisabilityLink();
            //Act
           Visability actualVisability =  (Visability)visabilityLink.
                                            Parse("UAAA 221700Z 16002MPS 0500 R23R/1800D R23L/1400N FZFG FU SCT200 M11/M13 Q1028 R88/CLRD65 NOSIG").Item1;
            //Assert
            Assert.Equal(expectedVisability, actualVisability, new Comparator<Visability>());
        }
        [Fact]
        public void CanParseVisability_1()
        { //Arrange
            Visability expectedVisability = new Visability()
            {
                prevailingVisibility = 0500,
                minimumVisability = 150,
                direction = Directions.NE
            };
            VisabilityLink visabilityLink = new VisabilityLink();
            //Act
            Visability actualVisability = (Visability)visabilityLink.
                                             Parse("UAAA 221700Z 16002MPS 0500 0150NE R23R/1800D R23L/1400N FZFG FU SCT200 M11/M13 Q1028 R88/CLRD65 NOSIG").Item1;
            //Assert
            Assert.Equal(expectedVisability, actualVisability, new Comparator<Visability>());
        }
        [Fact]
        public void CanParseVisability_2()
        { //Arrange
            Visability expectedVisability = new Visability()
            { 
                minimumVisability = 150,
                direction = Directions.NE
            };
            VisabilityLink visabilityLink = new VisabilityLink();
            //Act
            Visability actualVisability = (Visability)visabilityLink.
                                             Parse("UAAA 221700Z 16002MPS 0150NE R23R/1800D R23L/1400N FZFG FU SCT200 M11/M13 Q1028 R88/CLRD65 NOSIG").Item1;
            //Assert
            Assert.Equal(expectedVisability, actualVisability, new Comparator<Visability>());
        }
    }
}
