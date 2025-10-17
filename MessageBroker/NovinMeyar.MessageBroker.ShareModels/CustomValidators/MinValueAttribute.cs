using System.ComponentModel.DataAnnotations;

namespace NovinMeyar.Helpers.CustomValidators
{
    public class MinValueAttribute : ValidationAttribute
    {
        private int _minValue;
        public MinValueAttribute(int value)
        {
            _minValue = value;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (value is int)
                {
                    int minimum = (int)value;
                    if (minimum < _minValue)
                    {
                        return new ValidationResult($"حداقل مقدار باید {_minValue} باشد");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
