using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Blazor.Login.Library.Demo
{
    public partial class TableWidgetDemo<TItem>
    {
        [Parameter]
        public RenderFragment HeaderTemplateDemo { get; set; }

        [Parameter]
        public RenderFragment<TItem> RowTemplateDemo { get; set; }

        [Parameter]
        public RenderFragment FooterTemplateDemo { get; set; }

        [Parameter]
        public IReadOnlyList<TItem> Items { get; set; }
    }
}
