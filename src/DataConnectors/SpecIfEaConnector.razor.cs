using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using SpecIFicator.Framework.Contracts;
using MDD4All.Configuration.Contracts;
using SpecIFicator.DefaultPlugin.Configuration;
using MDD4All.Configuration;
using EAAPI = EA;
using MDD4All.SpecIF.DataProvider.EA;
using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.DataProvider.MongoDB;
using MDD4All.SpecIF.ViewModels;
using System.ComponentModel;

namespace SpecIFicator.DefaultPlugin.DataConnectors
{
    public partial class SpecIfEaConnector : ISpecIfDataConnector
    {
        [Inject]
        private IStringLocalizer<SpecIfEaConnector> L { get; set; }

        public static string Title = "Enterprise Architect";

        public string ConnectionString { get; set; } = @"D:\alto_daten\EA\TdSE2021.eapx";

        private IConfigurationReaderWriter<EaConnectorConfiguration> _configurationReaderWriter;

        private EaConnectorConfiguration _configuration;

        public string MongoDbConnectionString { get; set; }

        private IConfigurationReaderWriter<MongoDbConnectorConfiguration> _mongoDbConfigurationReaderWriter;

        private MongoDbConnectorConfiguration _mongoDbConnectorConfiguration;

        protected override void OnInitialized()
        {
            _configurationReaderWriter = new FileConfigurationReaderWriter<EaConnectorConfiguration>();

            _configuration = _configurationReaderWriter.GetConfiguration();

            if (_configuration == null)
            {
                _configuration = new EaConnectorConfiguration();
            }

            ConnectionString = _configuration.ConnectionString;


            _mongoDbConfigurationReaderWriter = new FileConfigurationReaderWriter<MongoDbConnectorConfiguration>();

            _mongoDbConnectorConfiguration = _mongoDbConfigurationReaderWriter.GetConfiguration();

            if(_mongoDbConnectorConfiguration == null)
            {
                _mongoDbConnectorConfiguration = new MongoDbConnectorConfiguration();
            }

            MongoDbConnectionString = _mongoDbConnectorConfiguration.ConnectionString;

            DataContext.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs arguments)
        {
            InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }

        [CascadingParameter]
        private DataConnectorViewModel DataContext { get; set; }

        private async Task HandleConnectClickAsync()
        {
            await Task.Run(() =>
            {
                DataContext.IsConnecting = true;

                if (_configuration != null && _configurationReaderWriter != null)
                {
                    _configuration.ConnectionString = ConnectionString;
                    _configurationReaderWriter.StoreConfiguration(_configuration);
                }


                try
                {
                    DataContext.StatusMessageKey = "Message.OpeningModel";
                    ISpecIfMetadataReader metadataReader = new SpecIfMongoDbMetadataReader(_mongoDbConnectorConfiguration.ConnectionString);

                    string progId = "EA.Repository";
                    Type type = Type.GetTypeFromProgID(progId);
                    EAAPI.Repository repository = Activator.CreateInstance(type) as EAAPI.Repository;

                    //_logger.LogInformation("Starting Enterprise Architect...");

                    bool openResult = repository.OpenFile(ConnectionString);

                    if (openResult)
                    {

                        repository.ShowWindow(1);

                        //_logger.LogInformation("Model open.");


                        // TODO: Fix this:
                        //EaDataIntegrator eaDataIntegrator = new EaDataIntegrator(repository, metadataReader);


                        DataContext.StatusMessageKey = "Message.ProvidingData";

                        DataContext.SpecIfDataProviderFactory.DataReader = new SpecIfEaDataReader(repository, metadataReader);
                        DataContext.SpecIfDataProviderFactory.MetadataReader = metadataReader;

                        DataContext.ConnectCommand.Execute(null);
                    }

                }
                catch
                {

                }
                finally
                {
                    DataContext.IsConnecting = false;
                }


            });
        }
    }
}