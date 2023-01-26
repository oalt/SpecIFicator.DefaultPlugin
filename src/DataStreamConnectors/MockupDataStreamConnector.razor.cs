using MDD4All.SpecIF.DataProvider.MockupDataStream;
using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using SpecIFicator.Framework.Contracts;

namespace SpecIFicator.DefaultPlugin.DataStreamConnectors
{
    public partial class MockupDataStreamConnector : ISpecIfDataStreamConnector, IDisposable
    {
        public static string Title = "Mockup Connector";

        [Inject]
        private IStringLocalizer<MockupDataStreamConnector> L { get; set; }

        [CascadingParameter]
        public DataStreamSubscriberConnectorViewModel DataContext { get; set; }

        protected override void OnInitialized()
        {
            //_configurationReaderWriter = new FileConfigurationReaderWriter<MongoDbConnectorConfiguration>();

            //_configuration = _configurationReaderWriter.GetConfiguration();

            //if (_configuration == null)
            //{
            //    _configuration = new MongoDbConnectorConfiguration();
            //}

            //ConnectionString = _configuration.ConnectionString;

            DataContext.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }

        private async void HandleConnectClickAsync()
        {
            await Task.Run(() =>
            {
                DataContext.IsConnecting = true;

                DataContext.StatusMessageKey = "Message.Connecting";

                //if (_configuration != null && _configurationReaderWriter != null)
                //{
                //    _configuration.ConnectionString = ConnectionString;
                //    _configurationReaderWriter.StoreConfiguration(_configuration);
                //}

                DataContext.SpecIfStreamDataSubscriberProvider.StreamDataSubscriber = new MockupDataSubscriber();

                DataContext.IsConnecting = false;

                DataContext.ConnectCommand.Execute(null);
            });

        }

        public void Dispose()
        {
            DataContext.PropertyChanged -= OnPropertyChanged;
        }
    }
}