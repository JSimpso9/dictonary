using System;
using Xunit;
using Comp4300_Project1;


namespace Comp4300_Project1.Tests
{
    public class DistanceConverterTests
    {
        private readonly DistanceConverter _converter;

        public DistanceConverterTests()
        {
            // Arrange
            _converter = new DistanceConverter();
        }

        [Fact]
        public void Convert_MetersToKilometers_ReturnsCorrectResult()
        {
            // Act
            double result = _converter.Convert(1000, "Meters (m)", "Kilometers (km)");

            // Assert
            Assert.Equal(1, result, 6); 
        }

        [Fact]
        public void Convert_KilometersToMiles_ReturnsCorrectResult()
        {
            // Act
            double result = _converter.Convert(1, "Kilometers (km)", "Miles (mi)");

            // Assert
            Assert.Equal(0.621371, result, 4);
        }


        [Fact]
        public void Convert_InvalidUnit_ThrowsKeyNotFoundException() =>
            // Assert
            _ = Assert.Throws<KeyNotFoundException>(() =>
    _converter.Convert(100, "I]", "Miles (mi)"));
    }
}
