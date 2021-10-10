using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TaxiApp.Services
{
    class EmailValidationRuleService : ValidationRule
    {
        public EmailValidationRuleService()
        {

        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string valueString = value as string;
            if (valueString == null)
            {
                valueString = "";
            }
            if (valueString.Length == 0)
            {
                return new ValidationResult(false, $"Cannot empty");
            }
            else if(!Regex.IsMatch(valueString, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                return new ValidationResult(false, $"Invalid email format");
            }
            return new ValidationResult(true, null);
        }
    }
}
