using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.ViewModels;
using SpecIFicator.Framework.CascadingValues;
using MDD4All.UI.DataModels.Tree;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class HierarchyTree
    {
        [CascadingParameter]
        public HierarchyEditorContext DataContext { get; set; }


        public NodeViewModel HierarchyViewModel { get; set; }

        protected override void OnInitialized()
        {
            HierarchyViewModel = DataContext.HierarchyEditorViewModel.RootNode;

            DataContext.HierarchyEditorViewModel.PropertyChanged += OnPropertyChanged;
        }

        void OnSelectionChanged(ITreeNode node)
        {
            DataContext.HierarchyEditorViewModel.SelectedNode = node as NodeViewModel;
        }

        private void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs arguments)
        {
            if (arguments.PropertyName == "StateChanged")
            {
                StateHasChanged();
            }
        }
    }
}