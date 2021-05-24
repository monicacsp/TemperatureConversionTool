using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemperatureConverter.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace TemperatureConverter.Controllers.Tests
{
    [TestClass()]
    public class TemperatureConverterCtrlTests
    {
        private readonly ILogger<TemperatureConverterCtrl> _logger;

        [TestMethod()]
        public void ValidateFormulas_fromCelsius()
        {
            double tempC = 0;
            double tempF = (tempC * 9) / 5 + 32;
            double tempK = tempC + 273.15;


            TemperatureConverterCtrl tempTypesCtrl = new TemperatureConverterCtrl(_logger);
            TemperatureTypes tempTypes = new TemperatureTypes();
            tempTypes = tempTypesCtrl.Get("celsius", "0");

            Assert.AreEqual(tempF, tempTypes.TemperatureF, "Formula has changed");
            Assert.AreEqual(tempK, tempTypes.TemperatureK, "Formula has changed");
        }

        [TestMethod()]
        public void ValidateFormulas_fromFahrenheit()
        {
            double tempF = 0;
            double tempC = (tempF - 32) * 5 / 9;
            double tempK = tempC + 273.15;


            TemperatureConverterCtrl tempTypesCtrl = new TemperatureConverterCtrl(_logger);
            TemperatureTypes tempTypes = new TemperatureTypes();
            tempTypes = tempTypesCtrl.Get("fahrenheit", "0");

            Assert.AreEqual(tempC, tempTypes.TemperatureC, "Formula has changed");
            Assert.AreEqual(tempK, tempTypes.TemperatureK, "Formula has changed");
        }

        [TestMethod()]
        public void ValidateFormulas_fromKelvin()
        {
            double tempK = 0;
            double tempC = tempK - 273.15;
            double tempF = (tempC * 9) / 5 + 32;


            TemperatureConverterCtrl tempTypesCtrl = new TemperatureConverterCtrl(_logger);
            TemperatureTypes tempTypes = new TemperatureTypes();
            tempTypes = tempTypesCtrl.Get("kelvin", "0");

            Assert.AreEqual(tempC, tempTypes.TemperatureC, "Formula has changed");
            Assert.AreEqual(tempF, tempTypes.TemperatureF, "Formula has changed");
        }
    }
}