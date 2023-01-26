using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.ViewModels;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.DataStreams
{
    public partial class ResourceLogEntry
    {
        [Parameter]
        public ResourceViewModel ResourceViewModel { get; set; }
    }
}