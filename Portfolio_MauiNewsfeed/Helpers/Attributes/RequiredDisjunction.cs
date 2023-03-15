using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_MauiNewsfeed.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class RequiredDisjunction : ValidationAttribute
    {
        private readonly string[] _disjunctiveProperties;

        public bool AllowNonNullDefaultValues { get; set; }

        public RequiredDisjunction(params string[] propertyNames)
        {
            _disjunctiveProperties = propertyNames;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ValidateDisjunctiveProperties(validationContext) ? ValidationResult.Success : new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
        }

        private bool ValidateDisjunctiveProperties(ValidationContext validationContext)
        {
            List<object> propertyValues = new List<object>();

            foreach (string propertyName in _disjunctiveProperties)
                propertyValues.Add(validationContext.ObjectType.GetProperty($"{propertyName}").GetValue(validationContext.ObjectInstance, null));

            if (AllowNonNullDefaultValues)
                foreach (object propertyValue in propertyValues)
                {
                    if (propertyValue != null && (string)propertyValue != string.Empty)
                        return true;
                }
            else
                foreach (object propertyValue in propertyValues)
                {
                    if (!propertyValue.IsNullOrDefault() && (string)propertyValue != string.Empty)
                        return true;
                }

            return false;
        }
    }
}
