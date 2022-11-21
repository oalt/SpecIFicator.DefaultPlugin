using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using SpecIFicator.Framework.CascadingValues;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class RawViewer
    {
        [CascadingParameter]
        public HierarchyEditorContext DataContext { get; set; }

        ResourceViewModel SelectedResource
        {
            get
            {
                ResourceViewModel result = null;
                if (DataContext != null && DataContext.HierarchyEditorViewModel.SelectedNode != null)
                {
                    NodeViewModel selectedNode = DataContext.HierarchyEditorViewModel.SelectedNode as NodeViewModel;

                    result = selectedNode.ReferencedResource;
                }

                return result;
            }
        }
    }
}