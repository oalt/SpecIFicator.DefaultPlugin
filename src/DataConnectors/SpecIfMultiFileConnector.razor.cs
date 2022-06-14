using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDD4All.SpecIF.DataProvider.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SpecIFicator.Framework.Contracts;

namespace SpecIFicator.DefaultPlugin.DataConnectors
{
    public partial class SpecIfMultiFileConnector : ISpecIfDataConnector
    {
        public string Title
        {
            get
            {
                return "Files";
            }
        }

        private ISpecIfDataProviderFactory _providerFactory;

        public ISpecIfDataProviderFactory SpecIfDataProviderFactory
        {
            get
            {
                return _providerFactory;
            }
        }

        [Parameter]
        public string MetadataPath { get; set; } = "";

        [Parameter]
        public string DataPath { get; set; } = "";

    }
}