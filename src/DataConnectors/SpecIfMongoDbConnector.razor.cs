using MDD4All.Configuration;
using MDD4All.Configuration.Contracts;
using MDD4All.SpecIF.DataProvider.MongoDB;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using SpecIFicator.DefaultPlugin.Configuration;
using SpecIFicator.Framework.CascadingValues;
using SpecIFicator.Framework.Contracts;

namespace SpecIFicator.DefaultPlugin.DataConnectors
{
    public partial class SpecIfMongoDbConnector : ISpecIfDataConnector
    {
        [Inject]
        private IStringLocalizer<SpecIfMongoDbConnector> L { get; set; }

        public static string Title = "MongoDB";

        public string ConnectionString { get; set; } = "mongodb://127.0.0.1:27017";

        private IConfigurationReaderWriter<MongoDbConnectorConfiguration> configurationReaderWriter;

        private MongoDbConnectorConfiguration configuration;

        protected override void OnInitialized()
        {
            configurationReaderWriter = new FileConfigurationReaderWriter<MongoDbConnectorConfiguration>();

            configuration = configurationReaderWriter.GetConfiguration();

            if (configuration == null)
            {
                configuration = new MongoDbConnectorConfiguration();
            }

            ConnectionString = configuration.ConnectionString;
        }

        [CascadingParameter]
        private SpecIfDataConnectorContext _dataContext { get; set; }

        private void HandleConnectClick()
        {

            if (configuration != null && configurationReaderWriter != null)
            {
                configuration.ConnectionString = ConnectionString;
                configurationReaderWriter.StoreConfiguration(configuration);
            }

            _dataContext.SpecIfDataProviderFactory.MetadataReader = new SpecIfMongoDbMetadataReader(ConnectionString);
            _dataContext.SpecIfDataProviderFactory.MetadataWriter = new SpecIfMongoDbMetadataWriter(ConnectionString);
            _dataContext.SpecIfDataProviderFactory.DataReader = new SpecIfMongoDbDataReader(ConnectionString);
            _dataContext.SpecIfDataProviderFactory.DataWriter = new SpecIfMongoDbDataWriter(ConnectionString,
                                                                                                  _dataContext.SpecIfDataProviderFactory.MetadataReader,
                                                                                                  _dataContext.SpecIfDataProviderFactory.DataReader);

            _dataContext.ConnectAction?.Invoke();
        }
    }
}