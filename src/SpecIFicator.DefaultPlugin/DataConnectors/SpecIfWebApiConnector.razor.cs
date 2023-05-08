using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using SpecIFicator.Framework.Contracts;
using MDD4All.Configuration.Contracts;
using SpecIFicator.DefaultPlugin.Configurations;
using MDD4All.Configuration;
using MDD4All.SpecIF.ViewModels;

namespace SpecIFicator.DefaultPlugin.DataConnectors
{
    public partial class SpecIfWebApiConnector : ISpecIfDataConnector
    {
        [Inject]
        private IStringLocalizer<SpecIfWebApiConnector> L { get; set; }

        public static string Title = "SpecIF Web API";

        private string ApiURL { get; set; }

        private string ApiKey { get; set; }

        private IConfigurationReaderWriter<WebApiConnectorConfiguration> _configurationReaderWriter;

        private WebApiConnectorConfiguration _configuration;

        protected override void OnInitialized()
        {
            _configurationReaderWriter = new FileConfigurationReaderWriter<WebApiConnectorConfiguration>("SpecIFicator/plugins");

            _configuration = _configurationReaderWriter.GetConfiguration();

            if (_configuration == null)
            {
                _configuration = new WebApiConnectorConfiguration();
            }

            ApiURL = _configuration.URL;
            ApiKey = _configuration.ApiKey;


        }


        [CascadingParameter]
        private DataConnectorViewModel DataContext { get; set; }

        private void HandleConnectClick()
        {

            if (_configuration != null && _configurationReaderWriter != null)
            {
                _configuration.URL = ApiURL;
                _configuration.ApiKey = ApiKey;
                _configurationReaderWriter.StoreConfiguration(_configuration);
            }

            //ISpecIfMetadataReader metadataReader = new SpecIfFileMetadataReader(MetadataPath);
            //ISpecIfDataReader dataReader = new SpecIfFileDataReader(DataPath);

            //DataContext.SpecIfDataProviderFactory.MetadataReader = metadataReader;
            //DataContext.SpecIfDataProviderFactory.DataReader = dataReader;
            //DataContext.SpecIfDataProviderFactory.DataWriter = new SpecIfFileDataWriter(DataPath, metadataReader, dataReader);

            DataContext.ConnectCommand.Execute(null);
        }
    }
}