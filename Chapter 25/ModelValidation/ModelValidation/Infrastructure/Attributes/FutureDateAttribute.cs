namespace ModelValidation.Infrastructure.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FutureDateAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value) && value is DateTime && ((DateTime)value) > DateTime.Now;
        }
    }
}