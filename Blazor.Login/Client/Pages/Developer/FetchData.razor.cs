using Microsoft.JSInterop;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SharedModel = Blazor.Login.Shared.Models;


namespace Blazor.Login.Client.Pages.Developer
{
    public partial class FetchData
    {
        SharedModel.DeveloperDto[] developers { get; set; }

        protected override async Task OnInitializedAsync()
        {
            developers = await client.GetFromJsonAsync<SharedModel.DeveloperDto[]>("api/developer");
        }

        async Task Delete(int developerId)
        {
            SharedModel.DeveloperDto dev = developers.First(x => x.Id == developerId);

            if (await js.InvokeAsync<bool>("confirm", $"Do you want to delete {dev.FirstName}'s ({dev.Id}) Record?"))
            {
                await client.DeleteAsync($"api/developer/{developerId}");
                await OnInitializedAsync();
            }
        }
    }
}
