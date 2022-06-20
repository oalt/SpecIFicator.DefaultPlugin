using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDD4All.SpecIF.DataProvider.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SpecIFicator.Framework.Contracts;
using SpecIFicator.Framework.CascadingValues;
using MDD4All.SpecIF.DataProvider.File;
using MDD4All.Configuration.Contracts;
using SpecIFicator.DefaultPlugin.Configuration;
using MDD4All.Configuration;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.DefaultPlugin.DataConnectors
{
    public partial class SpecIfMultiFileConnector : ISpecIfDataConnector
    {
        public static string Title = "Files";

        [Inject]
        private IStringLocalizer<SpecIfMultiFileConnector> L { get; set; }

        [Parameter]
        public string MetadataPath { get; set; } = "";

        [Parameter]
        public string DataPath { get; set; } = "";

        private IConfigurationReaderWriter<MultiFileConnectorConfiguration> configurationReaderWriter;

        private MultiFileConnectorConfiguration configuration;

        protected override void OnInitialized()
        {
            configurationReaderWriter = new FileConfigurationReaderWriter<MultiFileConnectorConfiguration>();

            configuration = configurationReaderWriter.GetConfiguration();

            if(configuration == null)
            {
                configuration = new MultiFileConnectorConfiguration();
            }

            MetadataPath = configuration.MetadataPath;
            DataPath = configuration.DataPath;

        }

        [CascadingParameter]
        private SpecIfDataConnectorContext _dataContext { get; set; }

        private void HandleConnectClick()
        {

            if(configuration != null && configurationReaderWriter != null)
            {
                configuration.MetadataPath = MetadataPath;
                configuration.DataPath = DataPath;
                configurationReaderWriter.StoreConfiguration(configuration);
            }

            ISpecIfMetadataReader metadataReader = new SpecIfFileMetadataReader(MetadataPath);
            ISpecIfDataReader dataReader = new SpecIfFileDataReader(DataPath);

            _dataContext.SpecIfDataProviderFactory.MetadataReader = metadataReader;
            _dataContext.SpecIfDataProviderFactory.DataReader = dataReader;
            _dataContext.SpecIfDataProviderFactory.DataWriter = new SpecIfFileDataWriter(DataPath, metadataReader, dataReader);
            
            _dataContext.ConnectAction?.Invoke();
        }


    }
}