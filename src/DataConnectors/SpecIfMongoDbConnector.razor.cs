using MDD4All.Configuration;
using MDD4All.Configuration.Contracts;
using MDD4All.SpecIF.DataProvider.MongoDB;
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
        private DataConnectorViewModel DataContext { get; set; }

        private void HandleConnectClick()
        {

            if (configuration != null && configurationReaderWriter != null)
            {
                configuration.ConnectionString = ConnectionString;
                configurationReaderWriter.StoreConfiguration(configuration);
            }

            DataContext.SpecIfDataProviderFactory.MetadataReader = new SpecIfMongoDbMetadataReader(ConnectionString);
            DataContext.SpecIfDataProviderFactory.MetadataWriter = new SpecIfMongoDbMetadataWriter(ConnectionString);
            DataContext.SpecIfDataProviderFactory.DataReader = new SpecIfMongoDbDataReader(ConnectionString);
            DataContext.SpecIfDataProviderFactory.DataWriter = new SpecIfMongoDbDataWriter(ConnectionString,
                                                                                                  DataContext.SpecIfDataProviderFactory.MetadataReader,
                                                                                                  DataContext.SpecIfDataProviderFactory.DataReader);

            DataContext.ConnectCommand.Execute(null);
        }
    }
}