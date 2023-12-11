using Blazor.Login.Shared.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Blazor.Login.Client.Pages.Test
{
    public partial class ToDoItem
    {
        [Parameter]
        public ToDo Item { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnMinutesAdded { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnMinutesSubtracted { get; set; }

        public async Task AddMinute(MouseEventArgs e)
        {
            Item.Minutes += 1;
            await OnMinutesAdded.InvokeAsync(e);
        }

        public async Task SubtractMinute(MouseEventArgs e)
        {
            Item.Minutes -= 1;
            await OnMinutesSubtracted.InvokeAsync(e);
        }
    }
}
