using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.MetadataEditor
{
    public partial class DataImporter
    {
        [Inject]
        private IStringLocalizer<DataImporter> L { get; set; }

        [Inject]
        public IHttpClientFactory HttpClientFactory { get; set; }

        [Inject]
        private ISpecIfDataProviderFactory SpecIfDataProviderFactory { get; set; }

        private DataImportViewModel DataContext { get; set; }

        protected override void OnInitialized()
        {
            DataContext = new DataImportViewModel(HttpClientFactory, 
                                                  SpecIfDataProviderFactory.MetadataWriter, 
                                                  SpecIfDataProviderFactory.DataWriter);

            DataContext.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }

        private async Task OnFileSelectionChange(ChangeEventArgs changeEventArguments)
        {
            DataContext.MetadataFileURL = changeEventArguments.Value.ToString();   
        }

        
    }
}