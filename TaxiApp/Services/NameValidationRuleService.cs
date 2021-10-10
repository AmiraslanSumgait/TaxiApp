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
    class NameValidationRuleService : ValidationRule
    {
        public NameValidationRuleService()
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
            else if (!Regex.IsMatch(valueString, @"^[a-zA-Z]+$"))
            {
                return new ValidationResult(false, $"Invalid format");
            }
            return new ValidationResult(true, null);
        }
    }
}
