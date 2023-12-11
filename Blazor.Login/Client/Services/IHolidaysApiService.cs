using Blazor.Login.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.Login.Client.Services
{
    public interface IHolidaysApiService
    {
        Task<List<HolidayResponse>> GetHolidays(HolidayRequest holidaysRequest);
    }
}
