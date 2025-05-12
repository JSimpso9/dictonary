using System;
using System.Collections.Generic;
using Xunit;

namespace Comp4300_Project1.Tests
{
    public class DistanceConversionTests
    {
        [Fact]
        public void DistanceConverter_ReturnsDoubleValueIfValid_ReturnsDouble()
        {
            // Arrange
            var distanceConverter = new DistanceConverter();
            double num = 5280;

            // Act
            double result = distanceConverter.Convert(num, "Feet", "Miles");

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void DistanceConverter_InvalidUnit_ThrowsKeyNotFoundException()
        {
            // Arrange
            var distanceConverter = new DistanceConverter();
            double input = 100;

            // Act & Assert
            var exception = Assert.Throws<KeyNotFoundException>(() => distanceConverter.Convert(input, "Meters (m)", ""));
            Assert.IsType<KeyNotFoundException>(exception);
        }
    }
}
