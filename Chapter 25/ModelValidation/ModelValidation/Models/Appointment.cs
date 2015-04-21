﻿namespace ModelValidation.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class Appointment
    {
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        [Remote("ValidateDate", "Home")]
        public DateTime Date { get; set; }

        public bool TermsAccepted { get; set; }
    }
}