using Blazor.Login.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Blazor.Login.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductDto>> GetTopSellingProducts()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ProductDto>>("api/product/products");
            return result;
        }
    }
}
