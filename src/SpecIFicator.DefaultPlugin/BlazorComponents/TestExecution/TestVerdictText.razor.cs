using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.DataModels.Manipulation;
using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.TestExecution
{
    public partial class TestVerdictText
    {
        [Inject]
        private ISpecIfDataProviderFactory DataProviderFactory { get; set; }

        [Parameter]
        public ResourceViewModel DataContext { get; set; }

        [Inject]
        private IStringLocalizer<TestExecutionView> L { get; set; }

        public string VerdictTextID
        {
            get
            {
                string result = "";

                Resource resource = DataContext.Resource;

                if (resource != null)
                {
                    string verdictEnumID = resource.GetPropertyValue("U2TP:Verdict", DataProviderFactory.MetadataReader);

                    if (!string.IsNullOrEmpty(verdictEnumID))
                    {
                        switch (verdictEnumID)
                        {
                            case "V-Verdict-0":
                                result = "Label.Verdict.None";
                                break;

                            case "V-Verdict-1":
                                result = "Label.Verdict.Pass";
                                break;

                            case "V-Verdict-2":
                                result = "Label.Verdict.Inconclusive";
                                break;

                            case "V-Verdict-3":
                                result = "Label.Verdict.Fail";
                                break;

                            case "V-Verdict-4":
                                result = "Label.Verdict.Error";
                                break;
                        }
                    }
                }

                return result;
            }
        }
    }
}
