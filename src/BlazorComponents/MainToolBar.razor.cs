using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MDD4All.SpecIF.ViewModels;
using MDD4All.SpecIF.DataProvider.Contracts;
using System.Reflection.Metadata;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class MainToolBar
    {
        [Inject]
        private IStringLocalizer<MainToolBar> L { get; set; }

        [Inject]
        private ISpecIfDataProviderFactory DataProviderFactory { get; set; }

        [Parameter]
        public HierarchyViewModel DataContext { get; set; }

        protected override void OnInitialized()
        {
            DataContext.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            StateHasChanged();
        }

        private void OnEditResourceClicked()
        {
            DataContext.StartEditResourceCommand.Execute(HierarchyViewModel.EDIT_EXISTING);
            StateHasChanged();
        }

        private void OnNewChildResourceClicked()
        {
            DataContext.StartEditResourceCommand.Execute(HierarchyViewModel.NEW_CHILD);
            StateHasChanged();
        }

        private void OnNewResourceBelowClicked()
        {
            DataContext.StartEditResourceCommand.Execute(HierarchyViewModel.NEW_BELOW);
            StateHasChanged();
        }

        private void OnNewResourceAboveClicked()
        {
            DataContext.StartEditResourceCommand.Execute(HierarchyViewModel.NEW_ABOVE);
            StateHasChanged();
        }

        private void OnDeleteResourceClicked()
        {
            DataContext.StartDeleteResourceCommand.Execute(null);
            StateHasChanged();
        }

        private void OnAddStatementClicked()
        {
            DataContext.StartAddStatementCommand.Execute(null);
            StateHasChanged();
        }

        private async Task OnAddStatementDialogClose(bool accepted)
        {
            if (accepted)
            {
                DataContext.ConfirmAddStatementCommand.Execute(null);
            }
            else
            {
                DataContext.CancelAddStatementCommand.Execute(null);
            }
            StateHasChanged();
        }

        private async Task OnEditDialogClose(bool accepted)
        {
            if(accepted)
            {
                DataContext.ConfirmEditResourceCommand.Execute(null);
            }
            else
            {
                DataContext.CancelEditResourceCommand.Execute(null);
            }
            StateHasChanged();
        }

        private async Task OnDeleteDialogClose(bool accepted)
        {
            if(accepted)
            {
                DataContext.DeleteResourceCommand.Execute(null);
            }
            else
            {
                DataContext.CancelDeleteResourceCommand.Execute(null);
            }
            StateHasChanged();
        }

    }
}