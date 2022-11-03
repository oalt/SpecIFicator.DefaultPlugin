using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.DataProvider.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MDD4All.SpecIF.DataModels.Manipulation;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class ResourceClassSelector
    {
        [Inject]
        private IStringLocalizer<ResourceClassSelector> L { get; set; }

        [Inject]
        private ISpecIfDataProviderFactory DataProviderFactory { get; set; }

        [Parameter]
        public Key SelectedResourceClassKey { get; set; } = new Key();

        private ISpecIfMetadataReader MetadataReader { get; set; }

        

        private List<ResourceClass> AvailableResourceClasses
        {
            get
            {
                List<ResourceClass> result = new List<ResourceClass>();

                result = MetadataReader.GetAllResourceClasses();

                return result;
            }
        }

        protected override void OnInitialized()
        {
            MetadataReader = DataProviderFactory.MetadataReader;
        }

        private async Task OnHierarchySelectionChange(ChangeEventArgs args)
        {
            Console.WriteLine(args.Value.ToString());
            string selection = args.Value.ToString();
            if (!string.IsNullOrEmpty(selection))
            {
                SelectedResourceClassKey = new Key();
                SelectedResourceClassKey.InitailizeFromKeyString(selection);
            }
        }

    }
}