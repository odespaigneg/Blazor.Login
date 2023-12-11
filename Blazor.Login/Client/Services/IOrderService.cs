using Blazor.Login.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.Login.Client.Services
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetLatestOrders();
    }
}
