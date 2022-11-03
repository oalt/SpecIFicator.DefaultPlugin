using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class PropertyViewer
    {
        [Parameter]
        public PropertyViewModel PropertyViewModel { get; set; }


    }
}
