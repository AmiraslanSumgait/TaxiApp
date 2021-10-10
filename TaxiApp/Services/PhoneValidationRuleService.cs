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
    class PhoneValidationRuleService : ValidationRule
    {
        public PhoneValidationRuleService()
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
            else if (!Regex.IsMatch(valueString, @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}"))
            {
                return new ValidationResult(false, $"Invalid phone number format");
            }
            return new ValidationResult(true, null);
        }
    }
}
