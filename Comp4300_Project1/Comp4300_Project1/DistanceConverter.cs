using System.Windows.Forms;
using System;
using System.Collections.Generic;


public partial class DistanceConverter { 

    private readonly Dictionary<string, double> dictionaryUnit = new Dictionary<string, double>
    {
        { "Micrometers (µm)", 1e-6 },
        { "Millimeters (mm)", 0.001 },
        { "Centimeters (cm)", 0.01 },
        { "Meters (m)", 1 },
        { "Kilometers (km)", 1000 },
        { "Inches (in)", 0.0254 },
        { "Feet (ft)", 0.3048 },
        { "Yards (yd)", 0.9144 },
        { "Miles (mi)", 1609.34 }
    };

    /// <summary>
    /// Gets the unit to convert.
    /// </summary>
    /// <value>
    /// The unit to convert.
    /// </value>
    public Dictionary<string, double> UnitToConvert => dictionaryUnit;

    /// <summary>
    /// Converts the specified value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="fromUnit">From unit.</param>
    /// <param name="toUnit">To unit.</param>
    /// <returns></returns>
    public double Convert(double value, string fromUnit, string toUnit)
    {
        if (!(dictionaryUnit.ContainsKey(fromUnit) && dictionaryUnit.ContainsKey(toUnit)))
        {
            throw new KeyNotFoundException("Invalid unit");
        }

        double meters = value * dictionaryUnit[fromUnit];
        return meters / dictionaryUnit[toUnit];
    }
}
