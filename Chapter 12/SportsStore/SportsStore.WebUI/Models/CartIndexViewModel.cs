namespace SportsStore.WebUI.Models
{
    using SportsStore.Domain.Entities;

    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}