using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document
{
    public partial class DocumentView
    {
        [CascadingParameter]
        public HierarchyViewModel DataContext { get; set; }

        protected override void OnInitialized()
        {
            DataContext.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "SelectedNode")
            {
                InvokeAsync(() => StateHasChanged());
            }
        }

        protected void OnLoadingFinished()
        {
            InvokeAsync(() => StateHasChanged());
        }

    }
}
