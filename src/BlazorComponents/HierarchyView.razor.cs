using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using SpecIFicator.Framework.CascadingValues;
using SpecIFicator.Framework.Configuration;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class HierarchyView
    {
        [Inject]
        private IStringLocalizer<HierarchyView> L { get; set; }

        [CascadingParameter]
        public HierarchyEditorContext DataContext { get; set; }

        private Type _documentViewType;



        private Type _rawViewType;

        private Type ResourceViewType
        {
            get
            {
                Type result = null;

                Key classKey = null;

                if(DataContext.HierarchyViewModel.SelectedNode != null)
                {
                    HierarchyViewModel selectedNode = DataContext.HierarchyViewModel.SelectedNode as HierarchyViewModel;

                    if(selectedNode != null)
                    {
                        classKey = selectedNode.RootResourceClassKey;

                        result = DynamicConfigurationManager.GetComponentType("ResourceView",
                                                                              GetType().FullName,
                                                                              classKey);

                    }
                }

                return result;
                
            }
        }

        protected override void OnInitialized()
        {
            DataContext.HierarchyViewModel.PropertyChanged += OnPropertyChanged;

            _documentViewType = DynamicConfigurationManager.GetComponentType("DocumentView",
                                                                             GetType().FullName,
                                                                             DataContext.HierarchyViewModel.RootResourceClassKey
                                                                            );

            
        }

        private void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs arguments)
        {
            if (arguments.PropertyName == "SelectedNode")
            {
                StateHasChanged();
            }
        }
    }
}