using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_MauiNewsfeed.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class RequireDisjunctive : ValidationAttribute
    {
        private readonly string[] _disjunctiveProperties;

        public RequireDisjunctive(params string[] propertyNames)
        {
            _disjunctiveProperties = propertyNames;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ValidateDisjunctiveProperties(validationContext) ? ValidationResult.Success : new ValidationResult(ErrorMessage);
        }

        private bool ValidateDisjunctiveProperties(ValidationContext validationContext)
        {
            List<object> propertyValues = new List<object>();

            foreach (string propertyName in _disjunctiveProperties)
                propertyValues.Add(validationContext.ObjectType.GetProperty($"{propertyName}").GetValue(validationContext.ObjectInstance, null));

            List<bool> results = new List<bool>();

            foreach (object propertyValue in propertyValues)
            {
                if (propertyValue.IsNullOrDefault() || (string)propertyValue == string.Empty)
                    results.Add(false);
                else
                    results.Add(true);
            }

            return results.Any(x => x == true);
        }
    }
}
