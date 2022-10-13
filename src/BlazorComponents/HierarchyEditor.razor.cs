using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.DataModels.Manipulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecIFicator.Framework.CascadingValues;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class HierarchyEditor
    {
        [Inject]
        private ISpecIfDataProviderFactory DataProviderFactory { get; set; }

       
        private ISpecIfMetadataReader MetadataReader { get; set; }

        
        private ISpecIfDataReader DataReader { get; set; }

        
        private ISpecIfDataWriter DataWriter { get; set; }

        [CascadingParameter]
        public HierarchyEditorContext DataContext { get; set; }

        public HierarchyViewModel HierarchyViewModel { get; set; }

        private HierarchyViewModel SelectedNode { get; set; }

        private Key SelectedHierarchyKey { get; set; } = new Key();

        protected override void OnInitialized()
        {
            MetadataReader = DataProviderFactory.MetadataReader;
            DataReader = DataProviderFactory.DataReader;
            DataWriter = DataProviderFactory.DataWriter;

            HierarchyViewModel = DataContext.HierarchyViewModel;
        }

        private List<ResourceClass> AvailableResourceClasses
        {
            get
            {
                List<ResourceClass> result = new List<ResourceClass>();

                result = MetadataReader.GetAllResourceClasses();

                return result;
            }
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
