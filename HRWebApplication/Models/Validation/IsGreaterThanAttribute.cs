using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HRWebApplication.Models.Validation
{
    public sealed class IsGreaterThanAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly string testedPropertyName;
        private readonly bool allowEqual;

        public IsGreaterThanAttribute(string testedPropertyName, bool allowEqualDates = false)
        {
            this.testedPropertyName = testedPropertyName;
            this.allowEqual = allowEqualDates;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyTestedInfo = validationContext.ObjectType.GetProperty(this.testedPropertyName);
            if (propertyTestedInfo == null)
            {
                return new ValidationResult(string.Format("unknown property {0}", this.testedPropertyName));
            }

            var propertyTestedValue = propertyTestedInfo.GetValue(validationContext.ObjectInstance, null);

            if (value == null || !(value is int))
            {
                return ValidationResult.Success;
            }

            if (propertyTestedValue == null || !(propertyTestedValue is int))
            {
                return ValidationResult.Success;
            }

            // Compare values
            if ((int)value >= (int)propertyTestedValue)
            {
                if (this.allowEqual && value == propertyTestedValue)
                {
                    return ValidationResult.Success;
                }
                else if ((int)value > (int)propertyTestedValue)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = this.ErrorMessageString,
                ValidationType = "isgreaterthan"
            };
            rule.ValidationParameters["propertytested"] = this.testedPropertyName;
            rule.ValidationParameters["allowequal"] = this.allowEqual;
            yield return rule;
        }
    }

}
