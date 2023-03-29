using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.ViewModels;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.StatementBrowser
{
    public partial class StatementBrowser
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