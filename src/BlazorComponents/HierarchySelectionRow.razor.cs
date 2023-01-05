using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MDD4All.SpecIF.ViewModels;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class HierarchySelectionRow
    {
        [Inject]
        private IStringLocalizer<ProjectsBrowser> L { get; set; }

        [Parameter]
        public NodeViewModel DataContext { get; set; }

        [Parameter]
        public bool IsLoading { get; set; }
        
        [Parameter]
        public EventCallback<bool> IsLoadingChanged { get; set; }

        protected override void OnInitialized()
        {
            DataContext.PropertyChanged += DataContextPropertyChanged;
        }

        private void DataContextPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "IsLoading")
            {
                if(DataContext.IsLoading == false)
                {
                    InvokeAsync(() =>
                    {
                        IsLoadingChanged.InvokeAsync(false);
                    });
                    
                }
            }
        }
    }
}