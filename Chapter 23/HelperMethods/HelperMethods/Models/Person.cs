namespace HelperMethods.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    [DisplayName("New Person")]
    public class Person
    {
        [HiddenInput(DisplayValue = false)]
        public int PersonId { get; set; }

        [DisplayName("First")]
        public string FirstName { get; set; }
        [DisplayName("Last")]
        public string LastName { get; set; }
        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public Address HomeAddress { get; set; }
        [DisplayName("Approved")]
        public bool IsApproved { get; set; }

        [UIHint("Enum")]
        public Role Role { get; set; }
    }
}