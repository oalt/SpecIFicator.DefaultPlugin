using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using VisNetwork.Blazor.Models;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Revision
{
    public partial class ResourceRevisionView
    {
        [CascadingParameter]
        public HierarchyViewModel DataContext { get; set; }

        private ResourceViewModel SelectedResource
        {
            get
            {
                ResourceViewModel result = null;

                if (DataContext.SelectedNode != null)
                {
                    NodeViewModel nodeViewModel = DataContext.SelectedNode as NodeViewModel;
                    if (nodeViewModel != null)
                    {
                        result = nodeViewModel.ReferencedResource;
                    }
                }
                return result;
            }
        }

        public List<string> SelectedNodes { get; set; }

        private void OnNodeSelectionChanged(NodeSelectEventArguments arguments)
        {
            SelectedNodes = arguments.SelectedNodes;
        }
    }
}