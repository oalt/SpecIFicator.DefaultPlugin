using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.DataProvider.Contracts.DataStreams;
using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.DataStreams
{
    public partial class ResourceLogger : IDisposable
    {
        [Inject]
        private ISpecIfDataProviderFactory? DataProviderFactory { get; set; }

        [Inject]
        public ISpecIfStreamDataSubscriberProvider? SpecIfStreamDataSubscriberProvider { get; set; }

        [Parameter]
        public ResourceViewModel? SelectedResource { get; set; }

        [Parameter]
        public EventCallback<ResourceViewModel> SelectedResourceChanged { get; set; }

        private void OnSpecIfDataReceived(object eventSource, SpecIfDataEventArguments specIfDataEventArguments)
        {
            foreach (Resource resource in specIfDataEventArguments.Data)
            {
                ResourceViewModel resourceViewModel = new ResourceViewModel(DataProviderFactory?.MetadataReader,
                                                                            DataProviderFactory?.DataReader,
                                                                            DataProviderFactory?.DataWriter,
                                                                            resource);

                _resourceViewModels.Add(resourceViewModel);
            }

            InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }

        private static List<ResourceViewModel> _resourceViewModels = new List<ResourceViewModel>();

        protected List<ResourceViewModel> ResourceViewModels
        {
            get
            {
                return _resourceViewModels;
            }
        }



        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (SpecIfStreamDataSubscriberProvider?.StreamDataSubscriber != null)
            {
                SpecIfStreamDataSubscriberProvider.StreamDataSubscriber.SpecIfDataReceived += OnSpecIfDataReceived;
            }

            //// update the UI every second to react on data changes
            //Timer timer = new Timer((_) =>
            //{
            //    InvokeAsync(() =>
            //    {
            //        StateHasChanged();
            //    });
            //}, null, 0, 1000);

        }



        protected void OnClearClicked()
        {
            _resourceViewModels.Clear();
            SelectedResource = null;

            InvokeAsync(() =>
            {
                StateHasChanged();
            });

        }

        private void OnSelectResource(ResourceViewModel node)
        {
            SelectedResource = node;
            SelectedResourceChanged.InvokeAsync(node);
        }

        private string ResourceSelectedStyle = "selected";

        private string ResourceUnselectedStyle = "unselected";


        private string StyleForSelection(ResourceViewModel resourceViewModel)
        {

            string result = "";
            //if (resourceViewModel.IsSelected)
            //{
            //    result = "background:yellow";
            //}
            return result;


        }

        public void Dispose()
        {
            if (SpecIfStreamDataSubscriberProvider?.StreamDataSubscriber != null)
            {
                SpecIfStreamDataSubscriberProvider.StreamDataSubscriber.SpecIfDataReceived -= OnSpecIfDataReceived;
            }
        }
    }
}