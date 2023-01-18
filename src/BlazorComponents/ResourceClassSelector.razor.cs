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

        private Key _selectedResourceClass;

        [Parameter]
        public Key SelectedResourceClassKey { get; set; }

        [Parameter]
        public EventCallback<Key> SelectedResourceClassKeyChanged { get; set; }

        [Parameter]
        public string CssStyles { get; set; } = "form-control";

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

        protected async override Task OnInitializedAsync()
        {
            MetadataReader = DataProviderFactory.MetadataReader;

            if (AvailableResourceClasses != null && AvailableResourceClasses.Any())
            {
                ResourceClass firstResourceClass = AvailableResourceClasses[0];

                _selectedResourceClass = new Key(firstResourceClass.ID, firstResourceClass.Revision);

                await SelectedResourceClassKeyChanged.InvokeAsync(_selectedResourceClass);
            }
        }

        private async Task OnHierarchySelectionChange(ChangeEventArgs args)
        {
            Console.WriteLine(args.Value.ToString());
            string selection = args.Value.ToString();
            if (!string.IsNullOrEmpty(selection))
            {
                _selectedResourceClass = new Key();
                _selectedResourceClass.InitailizeFromKeyString(selection);

                await SelectedResourceClassKeyChanged.InvokeAsync(_selectedResourceClass);
            }


        }

    }
}