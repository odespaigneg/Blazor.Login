using Blazor.Login.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Blazor.Login.Client.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<OrderDto>> GetLatestOrders()
        {
            var result = await _httpClient.GetFromJsonAsync<List<OrderDto>>("api/order/orders");
            return result;
        }
    }
}
