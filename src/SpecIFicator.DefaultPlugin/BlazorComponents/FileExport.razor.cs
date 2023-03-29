using MDD4All.FileAccess.Contracts;
using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class FileExport
    {
        [Inject]
        private IStringLocalizer<FileExport> L { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private ISpecIfDataProviderFactory DataProviderFactory { get; set; }

        [Inject]
        private IFileSaver FileSaver { get; set; }


        [CascadingParameter]
        public string KeyString { get; set; }

        public FileExportViewModel DataContext { get; set; }

        protected override void OnInitialized()
        {
            DataContext = new FileExportViewModel(KeyString, 
                                                  DataProviderFactory,
                                                  FileSaver);
        }

        private void OnHandleExportClicked()
        {
            // Show a modal dialog after the current event handler is completed,
            // to avoid potential reentrancy caused by running a nested message loop in the WebView2 event handler.
            // https://github.com/MicrosoftEdge/WebView2Feedback/issues/2542
            SynchronizationContext.Current?.Post((_) => 
            {
                DataContext.ExportHierarchyCommand.Execute(null);
                StateHasChanged();
            }, null);
        }

        private void OnCancelClicked()
        {
            NavigationManager.NavigateTo("/");
        }

        private void OnSuccessDialogClose()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}