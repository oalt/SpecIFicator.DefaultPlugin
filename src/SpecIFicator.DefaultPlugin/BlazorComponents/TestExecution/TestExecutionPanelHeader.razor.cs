using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.TestExecution
{
    public partial class TestExecutionPanelHeader
    {
        [Inject]
        private IStringLocalizer<TestExecutionPanel> L { get; set; }
    }
}
