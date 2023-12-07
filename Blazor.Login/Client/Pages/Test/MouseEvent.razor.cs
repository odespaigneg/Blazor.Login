using Microsoft.AspNetCore.Components.Web;

namespace Blazor.Login.Client.Pages.Test
{
    public partial class MouseEvent
    {
        private string coordinates = "";

        private void Move(MouseEventArgs e)
        {
            coordinates = $"{e.ScreenX}:{e.ScreenY}";
        }
    }
}
