﻿namespace ModelValidation.Infrastructure.Attributes
{
    using System.ComponentModel.DataAnnotations;

    public class MustBeTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is bool && (bool)value;
        }
    }
}