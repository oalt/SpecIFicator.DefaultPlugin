using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;
using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.ViewModels;
using MDD4All.SpecIF.DataModels.Manipulation;
using MDD4All.SpecIF.DataProvider.Contracts;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.TestExecution
{
    public partial class TestVerdictIcon
    {
        [Inject]
        private ISpecIfDataProviderFactory DataProviderFactory { get; set; }
        
        [Parameter]
        public ResourceViewModel DataContext { get; set; }

        public string VerdictValue 
        {
            get
            {
                string result = "";

                Resource resource = DataContext.Resource;

                if (resource != null)
                {
                    string verdictID = resource.GetPropertyValue("U2TP:Verdict", DataProviderFactory.MetadataReader);
                    
                    if(!string.IsNullOrEmpty(verdictID))
                    {
                        result = verdictID;
                    }
                }

                return result;
            }
        }

        private string IconPath
        {
            get
            {
                string result = "/images/";

                switch (VerdictValue)
                {
                    case "V-Verdict-0":
                        result += "IconNotTested.png";
                        break;

                    case "V-Verdict-1":
                        result += "IconPass.png";
                        break;

                    case "V-Verdict-2":
                        result += "IconInconclusive.png";
                        break;

                    case "V-Verdict-3":
                        result += "IconFail.png";
                        break;

                    case "V-Verdict-4":
                        result += "IconError.png";
                        break;
                }

                return result;
            }
        }
    }
}