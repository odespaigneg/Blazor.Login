using Blazor.Login.Client.Services;
using Blazor.Login.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.Login.Client.Pages.WebApiTest
{
    public partial class HolidaysExplorer
    {
        private HolidayRequest HolidaysModel = new HolidayRequest();
        private List<HolidayResponse> Holidays = new List<HolidayResponse>();

        [Inject]
        protected IHolidaysApiService HolidaysApiService { get; set; }

        private async Task HandleValidSubmit()
        {
            Holidays = await HolidaysApiService.GetHolidays(HolidaysModel);
        }
    }
}
