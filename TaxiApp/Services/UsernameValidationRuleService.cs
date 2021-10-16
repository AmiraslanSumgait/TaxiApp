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
    class UsernameValidationRuleService : ValidationRule
    {
        public UsernameValidationRuleService()
        {

        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string valueString = value as string;
            if (valueString == null)
            {
                ErrorService.IsError = true;
                valueString = "";
            }
            if (valueString.Length == 0)
            {
                ErrorService.IsError = true;
                return new ValidationResult(false, $"Cannot empty");
            }
            else if (!Regex.IsMatch(valueString, @"^(?=[A-Za-z0-9])(?!.*[._()\[\]-]{2})[A-Za-z0-9._()\[\]-]{3,15}$"))
            {
                ErrorService.IsError = true;
                return new ValidationResult(false, $"Must consist of between 3 to 15 allowed characters");
            }
            ErrorService.IsError = false;
            return new ValidationResult(true, null);
        }
    }
}
