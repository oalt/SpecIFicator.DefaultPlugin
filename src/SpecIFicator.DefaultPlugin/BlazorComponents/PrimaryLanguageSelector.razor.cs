using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MDD4All.SpecIF.ViewModels;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class PrimaryLanguageSelector
    {
        [Inject]
        private IStringLocalizer<MultilanguageSelector> L { get; set; }

        [Parameter]
        public HierarchyViewModel DataContext { get; set; }
    }
}