using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Entities;
using Metar_decoder.links;
using MetarDecoder.Tests.Utils;
namespace MetarDecoder.Tests
{
    public class CloudTests
    {
        [Fact]
        public void CloudTest_1()
        {
            string metar = "UAAA 221700Z 16002MPS 0500 R23R/1800D R23L/1400N FZFG FU SCT200 M11/M13 Q1028 R88/CLRD65 NOSIG";
            //Arrange
            Cloud cloud = new Cloud()
            { coverege = CloudCoverege.SCT,
                lowerBoundaryAltitude = 2000
            };

            CloudLink cloudLink = new CloudLink();
            //Act
            Cloud temp = (Cloud)cloudLink.Parse(metar).Item1;
            //Assert
            Assert.Equal(cloud, temp, new Comparator<Cloud>());
        }
        [Fact]
        public void CloudTest_2()
        {
            string metar = "UAAA 221700Z 16002MPS 0500 R23R/1800D R23L/1400N FZFG FU VV001 M11/M13 Q1028 R88/CLRD65 NOSIG";
            //Arrange
            Cloud cloud = new Cloud()
            {
                verticalVisability = 1
            };

            CloudLink cloudLink = new CloudLink();
            //Act
            Cloud temp = (Cloud)cloudLink.Parse(metar).Item1;
            //Assert
            Assert.Equal(cloud, temp, new Comparator<Cloud>());
        }
    }
}
