using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.TestExecution
{
    public partial class TestExecutionPanelHeader
    {
        [Inject]
        private IStringLocalizer<TestExecutionPanel> L { get; set; }

        [Parameter]
        public HierarchyViewModel DataContext { get; set; }
    }
}
