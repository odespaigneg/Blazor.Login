using Blazor.Login.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.Login.Client.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetTopSellingProducts();
    }
}
