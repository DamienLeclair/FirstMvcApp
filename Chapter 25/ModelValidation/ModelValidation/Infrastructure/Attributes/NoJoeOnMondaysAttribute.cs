namespace ModelValidation.Infrastructure.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using ModelValidation.Models;

    public class NoJoeOnMondaysAttribute : ValidationAttribute
    {
        public NoJoeOnMondaysAttribute()
        {
            ErrorMessage = "Joe cannot book an appointment on mondays";
        }

        public override bool IsValid(object value)
        {
            var appt = value as Appointment;

            if (appt == null || string.IsNullOrEmpty(appt.ClientName) || appt.Date == null)
            {
                return true;
            }

            return appt.ClientName != "Joe" && appt.Date.DayOfWeek != DayOfWeek.Monday;
        }
    }
}