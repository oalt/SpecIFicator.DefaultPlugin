using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MDD4All.SpecIF.ViewModels;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class StatementPropertyPanel
    {
        [Inject]
        private IStringLocalizer<StatementPropertyPanel> L { get; set; }

        [Parameter]
        public StatementViewModel DataContext { get; set; }

        [Parameter]
        public bool IsMultilinguismEnabled { get; set; } = false;

        [Parameter]
        public string PrimaryLanguage { get; set; } = "en";

        [Parameter]
        public string SecondaryLanguage { get; set; } = "de";
    }
}