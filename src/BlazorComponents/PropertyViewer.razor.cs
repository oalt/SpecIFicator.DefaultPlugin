using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.DataModels.Manipulation;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class PropertyViewer
    {
        [Parameter]
        public PropertyViewModel PropertyViewModel { get; set; }

        

    }
}
