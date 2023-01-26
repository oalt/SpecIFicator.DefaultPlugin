using MDD4All.SpecIF.DataProvider.Contracts.DataStreams;
using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.DataStreams
{
    public partial class DataStreamLoggerPage
    {
        [Inject]
        private IStringLocalizer<DataStreamLoggerPage> L { get; set; }

        [Inject]
        private ISpecIfStreamDataSubscriberProvider SpecIfStreamDataSubscriberProvider { get; set; }

        public DataStreamSubscriberConnectorViewModel DataContext { get; set; } = new DataStreamSubscriberConnectorViewModel();

        protected override void OnInitialized()
        {
            DataContext.SpecIfStreamDataSubscriberProvider = SpecIfStreamDataSubscriberProvider;
            DataContext.ConnectAction = HandleConnectClick;
        }

        private void HandleConnectClick()
        {
            InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }
    }
}