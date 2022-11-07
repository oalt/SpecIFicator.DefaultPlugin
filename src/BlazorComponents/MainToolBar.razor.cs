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
        public HierarchyEditorViewModel HierarchyEditorViewModel { get; set; }

        protected override void OnInitialized()
        {
            
        }

        private void OnEditResourceClicked()
        {
            HierarchyEditorViewModel.StartEditResourceCommand.Execute(HierarchyEditorViewModel.EDIT_EXISTING);
            StateHasChanged();
        }

        private void OnNewChildResourceClicked()
        {
            HierarchyEditorViewModel.StartEditResourceCommand.Execute(HierarchyEditorViewModel.NEW_CHILD);
            StateHasChanged();
        }

        private void OnNewResourceBelowClicked()
        {
            HierarchyEditorViewModel.StartEditResourceCommand.Execute(HierarchyEditorViewModel.NEW_BELOW);
            StateHasChanged();
        }

        private void OnNewResourceAboveClicked()
        {
            HierarchyEditorViewModel.StartEditResourceCommand.Execute(HierarchyEditorViewModel.NEW_ABOVE);
            StateHasChanged();
        }

        private void OnDeleteResourceClicked()
        {
            HierarchyEditorViewModel.StartDeleteResourceCommand.Execute(null);
            StateHasChanged();
        }

        private async Task OnEditDialogClose(bool accepted)
        {
            if(accepted)
            {
                HierarchyEditorViewModel.ConfirmEditResourceCommand.Execute(null);
            }
            else
            {
                HierarchyEditorViewModel.CancelEditResourceCommand.Execute(null);
            }
            StateHasChanged();
        }

        private async Task OnDeleteDialogClose(bool accepted)
        {
            if(accepted)
            {
                HierarchyEditorViewModel.DeleteResourceCommand.Execute(null);
            }
            else
            {
                HierarchyEditorViewModel.CancelDeleteResourceCommand.Execute(null);
            }
            StateHasChanged();
        }

    }
}