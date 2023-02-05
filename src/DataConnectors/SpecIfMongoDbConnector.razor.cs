using MDD4All.Configuration;
using MDD4All.Configuration.Contracts;
using MDD4All.SpecIF.DataProvider.Base.Cache;
using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.DataProvider.MongoDB;
using MDD4All.SpecIF.DataProvider.MongoDB.Setup;
using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using SpecIFicator.DefaultPlugin.Configuration;
using SpecIFicator.Framework.Contracts;

namespace SpecIFicator.DefaultPlugin.DataConnectors
{
    public partial class SpecIfMongoDbConnector : ISpecIfDataConnector
    {
        [Inject]
        private IStringLocalizer<SpecIfMongoDbConnector> L { get; set; }

        [CascadingParameter]
        private DataConnectorViewModel DataContext { get; set; }

        public static string Title = "MongoDB";

        private string ConnectionString { get; set; } = "mongodb://127.0.0.1:27017";

        private IConfigurationReaderWriter<MongoDbConnectorConfiguration> _configurationReaderWriter;

        private MongoDbConnectorConfiguration _configuration;

        protected override void OnInitialized()
        {
            _configurationReaderWriter = new FileConfigurationReaderWriter<MongoDbConnectorConfiguration>("SpecIFicator/plugins");

            _configuration = _configurationReaderWriter.GetConfiguration();

            if (_configuration == null)
            {
                _configuration = new MongoDbConnectorConfiguration();
            }

            ConnectionString = _configuration.ConnectionString;

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

                if (_configuration != null && _configurationReaderWriter != null)
                {
                    _configuration.ConnectionString = ConnectionString;
                    _configurationReaderWriter.StoreConfiguration(_configuration);
                }

                ISpecIfMetadataReader mongoDbMetadataReader = new SpecIfMongoDbMetadataReader(ConnectionString);

                CachedSpecIfMetadataReader cachedMetadaReader = new CachedSpecIfMetadataReader(mongoDbMetadataReader);

                cachedMetadaReader.ReinitializeCache();

                DataContext.SpecIfDataProviderFactory.MetadataReader = cachedMetadaReader;
                DataContext.SpecIfDataProviderFactory.MetadataWriter = new SpecIfMongoDbMetadataWriter(ConnectionString);
                DataContext.SpecIfDataProviderFactory.DataReader = new SpecIfMongoDbDataReader(ConnectionString);
                DataContext.SpecIfDataProviderFactory.DataWriter = new SpecIfMongoDbDataWriter(ConnectionString,
                                                                                               DataContext.SpecIfDataProviderFactory.MetadataReader,
                                                                                               DataContext.SpecIfDataProviderFactory.DataReader);

                AdminDatabaseInitializer adminDatabaseInitializer = new AdminDatabaseInitializer(ConnectionString);

                if (!adminDatabaseInitializer.AdminDbExists())
                {
                    DataContext.StatusMessageKey = "Message.Initializing";
                    adminDatabaseInitializer.InitalizeAdminData();
                }

                DataContext.ConnectCommand.Execute(null);

                DataContext.IsConnecting = false;
            });

        }

    }
}