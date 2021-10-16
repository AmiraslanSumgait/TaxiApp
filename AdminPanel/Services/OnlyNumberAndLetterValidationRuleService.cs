using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using TaxiApp;

namespace AdminPanel
{
    class OnlyNumberAndLetterValidationRuleService:ValidationRule //@"^[a-zA-Z0-9\_]+$"
    {
        public OnlyNumberAndLetterValidationRuleService()
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
            else if (!Regex.IsMatch(valueString, @"^[a-zA-Z0-9]+$"))
            {
                ErrorService.IsError = true;
                return new ValidationResult(false, $"Invalid format");
            }
            ErrorService.IsError = false;
            return new ValidationResult(true, null);
        }
    }
}
