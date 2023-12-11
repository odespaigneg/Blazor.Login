using System;

namespace Blazor.Login.Server.Models
{
    public class Order : BaseEntity
    {
        public string OrderNo { get; set; }

        public DateTime OrderDate { get; set; }

        public string Status { get; set; }

        public decimal OrderTotal { get; set; }
    }
}
