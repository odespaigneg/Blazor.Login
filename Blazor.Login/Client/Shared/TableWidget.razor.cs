using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Blazor.Login.Client.Shared
{
    public partial class TableWidget<TItem>
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment HeaderTemplate { get; set; }

        [Parameter]
        public RenderFragment<TItem> RowTemplate { get; set; }

        [Parameter]
        public RenderFragment FooterTemplate { get; set; }

        [Parameter]
        public IReadOnlyList<TItem> Items { get; set; }
    }
}
