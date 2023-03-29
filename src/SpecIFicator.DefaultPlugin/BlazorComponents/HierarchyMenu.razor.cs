using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class HierarchyMenu
    {
        [Inject]
        private IStringLocalizer<HierarchyMenu> L { get; set; }

        [Parameter]
        public string HierarchyKeyString { get; set; }

        private bool show = false;

        private async Task OutFocus()
        {
            await Task.Delay(200);
            this.show = false;
        }
    }
}