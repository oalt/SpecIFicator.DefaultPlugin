using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document
{
    public partial class DocumentItemContainer
    {
        [Parameter]
        public NodeViewModel DataContext { get; set; }

        [Parameter] 
        public EventCallback OnLoadingFinished { get; set; }

        private void OnSelectResource(NodeViewModel node)
        {
            node.Tree.SelectedNode = node;
        }

        private string ResourceSelectedStyle = "selected";

        private string ResourceUnselectedStyle = "unselected";

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
                        OnLoadingFinished.InvokeAsync();
                    });
                }
            }
            
        }
    }
}