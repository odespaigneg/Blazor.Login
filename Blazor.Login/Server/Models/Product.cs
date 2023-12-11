using Blazor.Login.Shared.Models;

namespace Blazor.Login.Server.Models
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
