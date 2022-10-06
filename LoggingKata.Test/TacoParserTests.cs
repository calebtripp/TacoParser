using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {       
            var tacoParser = new TacoParser();
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort", -84.677017)]
        [InlineData("34.992219,-86.841402,Taco Bell Ardmore", -86.841402)]
        [InlineData("34.795116,-86.97191,Taco Bell Athens", -86.97191)]
        [InlineData("34.018008,-86.079099,Taco Bell Attall", -86.079099)]
        [InlineData("32.571331,-85.499655,Taco Bell Auburn", -85.499655)]

        public void ShouldParseLongitude(string line, double expected)
        {
            var tacoParserLong = new TacoParser();
            var actual = tacoParserLong.Parse(line).Location.Longitude; 
            Assert.Equal(expected, actual);  
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort", 34.073638)]
        [InlineData("34.992219,-86.841402,Taco Bell Ardmore", 34.992219)]
        [InlineData("34.795116,-86.97191,Taco Bell Athens", 34.795116)]
        [InlineData("34.018008,-86.079099,Taco Bell Attall", 34.018008)]
        [InlineData("32.571331,-85.499655,Taco Bell Auburn", 32.571331)]
        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParserLat = new TacoParser();
            var actual = tacoParserLat.Parse(line).Location.Latitude;
            Assert.Equal(expected, actual); 
        }
    }
}
