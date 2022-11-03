using MDD4All.SpecIF.DataFactory;
using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MDD4All.SpecIF.DataModels.Manipulation;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class ProjectsBrowser
    {
        private ProjectsViewModel _projectsViewModel;

        [Inject]
        private IStringLocalizer<ProjectsBrowser> L { get; set; }

        [Inject]
        private ISpecIfDataProviderFactory DataProviderFactory { get; set; }

        private ISpecIfMetadataReader MetadataReader { get; set; }
        
        private ISpecIfDataReader DataReader { get; set; }

        private ISpecIfDataWriter DataWriter { get; set; }

        private bool ShowNewHierarchyDialog { get; set; }

        private ResourceViewModel NewHierarchyViewModel { get; set; }

        private Key SelectedHierarchyKey { get; set; }

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
            DataReader = DataProviderFactory.DataReader;
            DataWriter = DataProviderFactory.DataWriter;

            ResourceClass firstResourceClass = AvailableResourceClasses[0];

            SelectedHierarchyKey = new Key(firstResourceClass.ID, firstResourceClass.Revision);

            _projectsViewModel = new ProjectsViewModel(MetadataReader, DataWriter, DataReader);
        }

        private void OnNewHierarchyButtonClicked()
        {
            Resource hierarchyResource = SpecIfDataFactory.CreateResource(SelectedHierarchyKey, MetadataReader);

            NewHierarchyViewModel = new ResourceViewModel(MetadataReader, DataReader, DataWriter, hierarchyResource);
            NewHierarchyViewModel.IsInEditMode = true;

            ShowNewHierarchyDialog = true;
            StateHasChanged();

            
        }


        private async Task OnNewHierarchyDialogClose(bool accepted)
        {
            if (accepted)
            {
                _projectsViewModel.CreateNewHierarchyCommand.Execute(NewHierarchyViewModel.Resource);
            }



            ShowNewHierarchyDialog = false;
            StateHasChanged();

            //string json = JsonConvert.SerializeObject(NewHierarchyViewModel.Resource, Formatting.Indented);

            //Console.WriteLine(json);

            
        }

        private async Task OnHierarchySelectionChange(ChangeEventArgs args)
        {
            Console.WriteLine(args.Value.ToString());
            string selection = args.Value.ToString();
            if (!string.IsNullOrEmpty(selection))
            {
                SelectedHierarchyKey.InitailizeFromKeyString(selection);
            }
        }

    }

    
}
