using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.DataModels.Manipulation;
using Microsoft.Extensions.Localization;
using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.ViewModels;
using MDD4All.SpecIF.DataProvider.Contracts;
using SpecIFicator.Framework.Configuration;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.TestExecution
{
    public partial class TestExecutionPanel
    {
        [Inject]
        private IStringLocalizer<HierarchyEditor> L { get; set; }

        [Inject]
        private ISpecIfDataProviderFactory DataProviderFactory { get; set; }


        private ISpecIfMetadataReader MetadataReader { get; set; }


        private ISpecIfDataReader DataReader { get; set; }


        private ISpecIfDataWriter DataWriter { get; set; }

        // the hierarchy key
        [CascadingParameter]
        public string DataContext { get; set; }

        public HierarchyViewModel HierarchyViewModel { get; set; }

        private NodeViewModel SelectedNode { get; set; }

        private Type _treeType;

        private Type _hierarchyViewType;


        protected override void OnInitialized()
        {
            MetadataReader = DataProviderFactory.MetadataReader;
            DataReader = DataProviderFactory.DataReader;
            DataWriter = DataProviderFactory.DataWriter;

            if (DataContext != null)
            {
                Key key = new Key();
                key.InitailizeFromKeyString(DataContext);

                HierarchyViewModel = new HierarchyViewModel(DataProviderFactory, key);

                HierarchyViewModel.PropertyChanged += OnStateChanged;

                _treeType = DynamicConfigurationManager.GetComponentType("TestExecutionTree",
                                                                         GetType().FullName,
                                                                         HierarchyViewModel
                                                                            .RootNode.RootResourceClassKey);

                _hierarchyViewType = DynamicConfigurationManager.GetComponentType("TestExecutionView",
                                                                                  GetType().FullName,
                                                                                  HierarchyViewModel.RootNode.RootResourceClassKey);

            }
        }

        private void OnStateChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "StateChanged")
            {
                StateHasChanged();
            }
        }
    }
}