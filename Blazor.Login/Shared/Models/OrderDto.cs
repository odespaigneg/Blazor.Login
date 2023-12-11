using System;

namespace Blazor.Login.Shared.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal OrderTotal { get; set; }
    }
}
