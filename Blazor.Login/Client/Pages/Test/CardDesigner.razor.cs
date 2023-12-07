using Blazor.Login.Shared.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;

namespace Blazor.Login.Client.Pages.Test
{
    public partial class CardDesigner
    {
        public string Heading { get; set; } = "Heading";

        public string Description { get; set; } = "Description";

        public List<StyleInfo> Styles { get; set; }

        public string SelectedStyleCssClass { get; set; }

        protected override void OnInitialized()
        {
            Styles = new List<StyleInfo>()
            {
                new StyleInfo() { Name = "Primary", CssClass = "bg-primary" },
                new StyleInfo() { Name = "Secondary", CssClass = "bg-secondary" },
                new StyleInfo() { Name = "Success", CssClass = "bg-success" }
            };

            SelectedStyleCssClass = "bg-primary";
        }

        public void ResetCard(MouseEventArgs e)
        {
            Heading = "Heading";
            Description = "Description";
        }

        public void UpdateHeading(ChangeEventArgs e)
        {
            Heading = e.Value.ToString();
        }

        public void UpdateDescription(ChangeEventArgs e)
        {
            Description = e.Value.ToString();
        }
    }
}
