using MDD4All.SpecIF.ViewModels;
using MDD4All.SpecIF.ViewModels.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class StatementCreator
    {
        [Inject]
        private IStringLocalizer<StatementCreator> L { get; set; }

        [Parameter]
        public CreateStatementViewModel DataContext { get; set; }

        private void OnBrowseButtonClicked()
        {
            DataContext.StartBrowseForOppositeResourceCommand.Execute(null);
            StateHasChanged();
        }

        private void OnSearchDialogClose()
        {
            DataContext.EndBrowseForOppositeResourceCommand.Execute(null);
            StateHasChanged();
        }

        private void OnDirectionSelectionChange(ChangeEventArgs changeEventArguments)
        {
            string value = changeEventArguments.Value.ToString();
            if(value == "in")
            {
                DataContext.DesiredDirection = StatementDirection.In;
            }
            else if(value == "out")
            {
                DataContext.DesiredDirection = StatementDirection.Out;
            }
            StateHasChanged();
        }
    }
}