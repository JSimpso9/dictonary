using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Comp4300_Project1.Tests
{
    public static class DistanceConversionTests
    {
        public static void DistanceConverter_ReturnsDoubleValueIfValid_ReturnsDouble(DistanceConverter distanceConverter)
        {
            try 
            {
                double num = 5280;
                double result = distanceConverter.Convert(num, "Feet", "Miles");
                if (result == 1)
                {
                    Console.WriteLine("PASSED: DistanceConverter_ReturnsDoubleValueIfValid_ReturnsDouble()");
                }
                else
                {
                    Console.WriteLine("FAILED: DistanceConverter_ReturnsDoubleValueIfValid_ReturnsDouble()");
                }
            }
            catch (Exception ex) {
                Console.WriteLine (ex.Message);
            }
        }

        public static void DistanceConverter_InvalidUnit_ThrowsKeyNotFoundException(DistanceConverter distanceConverter)
        {
            try
            {
                double input = 100;
                double result = distanceConverter.Convert(input, "Meters (m)", ""); // Invalid target unit

                // If no exception is thrown, it's a failed test
                Console.WriteLine("FAILED: DistanceConverter_InvalidUnit_ThrowsKeyNotFoundException() — No exception thrown.");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("PASSED: DistanceConverter_InvalidUnit_ThrowsKeyNotFoundException()");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FAILED: DistanceConverter_InvalidUnit_ThrowsKeyNotFoundException() — Unexpected exception: {ex.Message}");
            }
        }
    }
}
