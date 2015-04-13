namespace MvcModels.Models
{
    using System.Web.Mvc;
    using MvcModels.Infrastructure;

    //[Bind(Include = "City")]
    [ModelBinder(typeof(AddressSummaryBinder))]
    public class AddressSummary
    {
        public string City { get; set; }
        public string Country { get; set; }
    }
}