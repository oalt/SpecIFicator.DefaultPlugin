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
using SpecIFicator.Framework.Configuration;
using Microsoft.Extensions.Localization;
using SpecIFicator.DefaultPlugin.DataConnectors;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class HierarchyEditor
    {
        [Inject]
        private IStringLocalizer<HierarchyEditor> L { get; set; }

        [Inject]
        private ISpecIfDataProviderFactory DataProviderFactory { get; set; }

       
        private ISpecIfMetadataReader MetadataReader { get; set; }

        
        private ISpecIfDataReader DataReader { get; set; }

        
        private ISpecIfDataWriter DataWriter { get; set; }

        [CascadingParameter]
        public HierarchyEditorContext DataContext { get; set; }

        public HierarchyEditorViewModel HierarchyEditorViewModel { get; set; }

        private HierarchyViewModel SelectedNode { get; set; }

        private Type _treeType;

        private Type _hierarchyViewType;


        protected override void OnInitialized()
        {
            MetadataReader = DataProviderFactory.MetadataReader;
            DataReader = DataProviderFactory.DataReader;
            DataWriter = DataProviderFactory.DataWriter;

            HierarchyEditorViewModel = DataContext.HierarchyEditorViewModel;

            HierarchyEditorViewModel.PropertyChanged += OnStateChanged;

            _treeType = DynamicConfigurationManager.GetComponentType("Tree",
                                                                     GetType().FullName,
                                                                     DataContext.HierarchyEditorViewModel
                                                                        .RootNode.RootResourceClassKey);

            _hierarchyViewType = DynamicConfigurationManager.GetComponentType("HierarchyView",
                                                                              GetType().FullName,
                                                                              HierarchyEditorViewModel.RootNode.RootResourceClassKey);

            
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
