using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.DataModels.Manipulation;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class PropertyViewer
    {
        [Parameter]
        public PropertyViewModel PropertyViewModel { get; set; }

        [Parameter]
        public bool IsMultilinguismEnabled { get; set; } = false;

        [Parameter]
        public string PrimaryLanguage { get; set; } = "en";

        [Parameter]
        public string SecondaryLanguage { get; set; } = "de";

    }
}
