using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.ViewModels;
using VisNetwork.Blazor;
using VisNetwork.Blazor.Models;
using MDD4All.SpecIF.DataProvider.Contracts;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Revision
{
    public partial class RevisionGraph
    {
        [Inject]
        private ISpecIfDataProviderFactory DataProviderFactory { get; set; }

        [Parameter]
        public ResourceViewModel DataContext { get; set; }

        [Parameter]
        public EventCallback<NodeSelectEventArguments> OnNodeSelectionChangeCallback { get; set; }

        protected override void OnInitialized()
        {

        }

        private NetworkOptions NetworkOptions(Network network)
        {
            
            return DataContext.ResourceRevisionViewModel.NetworkOptions;
            
        }

        
        private async void OnSelectNode(ClickEvent clickEvent)
        {
            NodeSelectEventArguments arguments = new NodeSelectEventArguments
            {
                SelectedNodes = clickEvent.Nodes
            };

            await OnNodeSelectionChangeCallback.InvokeAsync(arguments);
        }
    }
}