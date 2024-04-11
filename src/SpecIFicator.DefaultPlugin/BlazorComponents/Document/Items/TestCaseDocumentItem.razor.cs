using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.ViewModels;
using Microsoft.Extensions.Localization;
using System.Resources;
using System.Globalization;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public partial class TestCaseDocumentItem : IDocumentItem
    {
        [Inject]
        public IStringLocalizerFactory StringLocalizerFactory { get; set; }

        [CascadingParameter]
        public NodeViewModel DataContext { get; set; }

        public string Type => "ISTQB:TestCase";

        public ResourceManager ResourceManager { get; } = Resources.BlazorComponents.Document.Items.TestCaseDocumentItem.ResourceManager;

        private CultureInfo _primaryCulture;
        private CultureInfo _secondaryCulture;

        protected override void OnInitialized()
        {
            _primaryCulture = new CultureInfo(DataContext.PrimaryLanguage);
            _secondaryCulture = new CultureInfo(DataContext.SecondaryLanguage);

            
        }
    }
}