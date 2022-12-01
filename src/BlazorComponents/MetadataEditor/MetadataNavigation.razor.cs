using Microsoft.AspNetCore.Components;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.MetadataEditor
{
    public partial class MetadataNavigation
    {
        [Parameter]
        public Type SelectedComponentType { get; set; }

        [Parameter]
        public EventCallback<Type> SelectedComponentTypeChanged { get; set; }

        private bool collapseNavMenu = true;
        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;
        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        private async Task UpdateSelectedTypeAsync(Type type)
        {
            await SelectedComponentTypeChanged.InvokeAsync(type);
        }
    }
}