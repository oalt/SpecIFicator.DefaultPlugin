using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MDD4All.SpecIF.DataModels;
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

        
        private Key SelectedResourceClassKey { get; set; }

        protected override void OnInitialized()
        {
            
        }

        private void EditResource()
        {
            HierarchyEditorViewModel.StartEditResourceCommand.Execute(null);
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

    }
}