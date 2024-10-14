using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.RequirementConsolidation
{
    public partial class ConsolidationView
    {
        [Inject]
        private IStringLocalizer<ConsolidationView> L { get; set; }
    }
}