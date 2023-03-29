using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class RawViewer
    {
        [CascadingParameter]
        public HierarchyViewModel DataContext { get; set; }

        ResourceViewModel SelectedResource
        {
            get
            {
                ResourceViewModel result = null;
                if (DataContext != null && DataContext.SelectedNode != null)
                {
                    NodeViewModel selectedNode = DataContext.SelectedNode as NodeViewModel;

                    result = selectedNode.ReferencedResource;
                }

                return result;
            }
        }
    }
}