using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SpecIFicator.DefaultPlugin.ViewModels;
using System.ComponentModel;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document
{
    public partial class DocumentItemContainer
    {
        [Inject]
        IJSRuntime JsRuntime { get; set; }

        [Parameter]
        public NodeViewModel DataContext { get; set; }

        private HierarchyViewModel ParentViewModel { get; set; }

        [Parameter]
        public EventCallback OnLoadingFinished { get; set; }

        ElementReference ElementReference { get; set; }

        private void OnSelectResource(NodeViewModel node)
        {
            node.Tree.SelectedNode = node;
        }

        private string ResourceSelectedStyle = "selected";

        private string ResourceUnselectedStyle = "unselected";

        protected override void OnInitialized()
        {
            DataContext.PropertyChanged += DataContextPropertyChanged;

            if (DataContext.Tree != null && DataContext.Tree is HierarchyViewModel)
            {
                ParentViewModel = (HierarchyViewModel)DataContext.Tree;
                ParentViewModel.PropertyChanged += OnSelectionChanged;
            }
        }

        private void OnSelectionChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (DataContext.IsSelected)
            {
                InvokeAsync(() =>
                {
                    ScrollToElementAsync();
                });

            }
        }

        private async Task ScrollToElementAsync()
        {
            await JsRuntime.InvokeVoidAsync("ScrollElementIntoView", ElementReference);
        }

        private void OnCommentButtonClick()
        {
            if(ParentViewModel is DefaultPluginHierarchyViewModel)
            {
                DefaultPluginHierarchyViewModel viewModel = (DefaultPluginHierarchyViewModel)ParentViewModel;

                viewModel.ShowCommentsCommand.Execute(null);
            }
        }

        private void DataContextPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsLoading")
            {
                if (DataContext.IsLoading == false)
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