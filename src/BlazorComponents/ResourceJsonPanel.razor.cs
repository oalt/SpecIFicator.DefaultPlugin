using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.ViewModels;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class ResourceJsonPanel
    {
        [Parameter]
        public ResourceViewModel DataContext { get; set; }
    }
}