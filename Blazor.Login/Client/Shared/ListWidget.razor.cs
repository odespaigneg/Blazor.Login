using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Blazor.Login.Client.Shared
{
    public partial class ListWidget<TItem>
    {
        [Parameter]
        public RenderFragment<TItem> ItemTemplate { get; set; }

        [Parameter]
        public IReadOnlyList<TItem> Items { get; set; }
    }
}
