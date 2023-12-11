using Blazor.Login.Client.Services;
using Blazor.Login.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Login.Client.Pages.RealWorldTest
{
    public partial class Dashboard
    {
        [Inject]
        private IOrderService OrderService { get; set; }

        [Inject]
        private IProductService ProductService { get; set; }

        private List<OrderDto> Orders { get; set; }
        private List<ProductDto> Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Orders = await OrderService.GetLatestOrders();
            Products = await ProductService.GetTopSellingProducts();
        }
    }
}
