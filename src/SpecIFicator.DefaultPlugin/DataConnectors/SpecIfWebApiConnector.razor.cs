using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using SpecIFicator.Framework.Contracts;
using MDD4All.Configuration.Contracts;
using SpecIFicator.DefaultPlugin.Configurations;
using MDD4All.Configuration;
using MDD4All.SpecIF.ViewModels;
using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.DataProvider.WebAPI;
using MDD4All.SpecIF.DataProvider.MongoDB.Setup;
using MongoDB.Driver.Core.Configuration;
using System.ComponentModel;
using MDD4All.SpecIF.DataProvider.MongoDB;
using MDD4All.SpecIF.DataProvider.Base.Cache;

namespace SpecIFicator.DefaultPlugin.DataConnectors
{
    public partial class SpecIfWebApiConnector : ISpecIfDataConnector
    {
        [Inject]
        private IStringLocalizer<SpecIfWebApiConnector> L { get; set; }
        [Inject]
        private IHttpClientFactory HttpClientFactory { get; set; }

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
            DataContext.IsConnecting = true;
            DataContext.StatusMessageKey = "Message.Connencting";

            if (_configuration != null && _configurationReaderWriter != null)
            {
                _configuration.URL = ApiURL;
                _configuration.ApiKey = ApiKey;
                _configurationReaderWriter.StoreConfiguration(_configuration);
            }

            ISpecIfMetadataReader webApiMetadataReader = new SpecIfWebApiMetadataReader(ApiURL);
            CachedSpecIfMetadataReader cachedMetadaReader = new CachedSpecIfMetadataReader(webApiMetadataReader);

            ISpecIfMetadataReader metadataReader = cachedMetadaReader;
            ISpecIfMetadataWriter metadataWriter = new SpecIfWebApiMetadataWriter(ApiURL, ApiKey);
            ISpecIfDataReader dataReader = new SpecIfWebApiDataReader(ApiURL, ApiKey);
            ISpecIfDataWriter dataWriter = new SpecIfWebApiDataWriter(ApiURL, ApiKey, metadataReader, dataReader);

            DataContext.SpecIfDataProviderFactory.MetadataReader = metadataReader;
            DataContext.SpecIfDataProviderFactory.MetadataWriter = metadataWriter;
            DataContext.SpecIfDataProviderFactory.DataReader = dataReader;
            DataContext.SpecIfDataProviderFactory.DataWriter = dataWriter;

            DataContext.ConnectCommand.Execute(null);

            DataContext.IsConnecting = false;
        }
    }
}