namespace SayusiAndo.Carbon.BlazoredFast.Components.TreeView
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Components;

    public partial class BfTreeView
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> UnknownParameters { get; set; }

        private BfTreeItem _selected;

        public async Task Select(BfTreeItem item)
        {
            if (_selected != null)
            {
                _selected.Selected = !_selected.Selected;
                _selected = item;
                await InvokeAsync(StateHasChanged).ConfigureAwait(false);
            }
        }
    }
}