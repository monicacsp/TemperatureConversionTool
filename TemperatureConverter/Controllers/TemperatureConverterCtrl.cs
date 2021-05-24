using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemperatureConverter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureConverterCtrl : ControllerBase
    {        
        private readonly ILogger<TemperatureConverterCtrl> _logger;



        public TemperatureConverterCtrl(ILogger<TemperatureConverterCtrl> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public TemperatureTypes Get(string name, string value)
        {
            TemperatureTypes convertedData = new TemperatureTypes();
            double numVal = 0;
            bool isValidNum = double.TryParse(value, out numVal);

            //Condition to set value during the initialisation of app
            if (string.IsNullOrEmpty(name) || name=="undefined")
            {
                convertedData.TemperatureC = numVal;
                convertedData.TemperatureF = (numVal * 9) / 5 + 32;
                convertedData.TemperatureK = numVal + 273.15;
            }
            else if (name == "celsius") {

                if (isValidNum)
                {
                    convertedData.TemperatureC = numVal;
                    convertedData.TemperatureF = (numVal * 9) / 5 + 32;
                    convertedData.TemperatureK = numVal + 273.15;
                }
                else {
                    convertedData.TemperatureF = null;//nulled to clear the input fields
                    convertedData.TemperatureK = null;
                    _logger.LogInformation(string.Format("Invalid {0} reading of {1}", name, value));
                }
                
            }
            else if (name == "fahrenheit") {

                if (isValidNum)
                {
                    convertedData.TemperatureF = numVal;
                    convertedData.TemperatureC = (numVal - 32) * 5 / 9;
                    convertedData.TemperatureK = convertedData.TemperatureC + 273.15;
                }
                else
                {
                    convertedData.TemperatureC = null;
                    convertedData.TemperatureK = null;
                }
            }
            else if (name == "kelvin")
            {
                if (isValidNum)
                {
                    convertedData.TemperatureK = numVal;
                    convertedData.TemperatureC = numVal - 273.15;
                    convertedData.TemperatureF = (convertedData.TemperatureC * 9) / 5 + 32;
                }
                else
                {
                    convertedData.TemperatureC = null;
                    convertedData.TemperatureF = null;
                }
            }          


            return convertedData;
        }
    }
}
