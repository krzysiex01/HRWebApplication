using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HRWebApplication.Models.Validation
{
    public sealed class IsPastDateAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly bool allowEqualDates;

        public IsPastDateAttribute(bool allowEqualDates = false)
        {
            this.allowEqualDates = allowEqualDates;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !(value is DateTime))
            {
                return ValidationResult.Success;
            }

            if ((DateTime)value >= DateTime.Now)
            {
                if (allowEqualDates && (DateTime)value == DateTime.Now)
                {
                    return ValidationResult.Success;
                }
                else if ((DateTime)value > DateTime.Now)
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
                ValidationType = "ispastdate"
            };
            rule.ValidationParameters["allowequaldates"] = this.allowEqualDates;
            yield return rule;
        }
    }
}
