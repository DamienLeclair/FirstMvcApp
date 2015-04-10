namespace MvcModels.Models
{
    using System.Web.Mvc;

    [Bind(Include = "City")]
    public class AddressSummary
    {
        public string City { get; set; }
        public string Country { get; set; }
    }
}