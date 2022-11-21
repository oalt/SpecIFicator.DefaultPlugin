using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using SpecIFicator.Framework.CascadingValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document
{
    public partial class DocumentView
    {
        [CascadingParameter]
        public HierarchyEditorContext DataContext { get; set; }

        private NodeViewModel HierarchyViewModel { get; set; }

        protected override void OnInitialized()
        {
            HierarchyViewModel = DataContext.HierarchyEditorViewModel.RootNode;
        }

        private void OnSelectResource(NodeViewModel node)
        {
            DataContext.HierarchyEditorViewModel.SelectedNode = node;
        }

        private string ResourceSelectedStyle = "selected";

        private string ResourceUnselectedStyle = "unselected";

    }
}
