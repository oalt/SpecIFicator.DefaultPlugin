using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using SpecIFicator.Framework.Configuration;
using SpecIFicator.Framework.Configuration.DataModels;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class HierarchyView
    {
        [Inject]
        public IStringLocalizerFactory LocalizerFactory { get; set; }

        [Inject]
        private IStringLocalizer<HierarchyView> L { get; set; }

        [CascadingParameter]
        public HierarchyViewModel DataContext { get; set; }

        private NodeViewModel SelectedNode
        {
            get
            {
                return (NodeViewModel)DataContext.SelectedNode;
            }
        }

        //private Type ResourceViewType
        //{
        //    get
        //    {
        //        Type result = null;

        //        Key classKey = null;

        //        if(DataContext.SelectedNode != null)
        //        {
        //            NodeViewModel selectedNode = DataContext.SelectedNode as NodeViewModel;

        //            if(selectedNode != null)
        //            {
        //                classKey = selectedNode.RootResourceClassKey;

        //                result = DynamicConfigurationManager.GetComponentType("ResourceView",
        //                                                                      GetType().FullName,
        //                                                                      classKey);

        //            }
        //        }

        //        return result;
                
        //    }
        //}

        private List<ComponentDefinition> ComponentDefinitions { get; set; } = new List<ComponentDefinition>();

        protected override void OnInitialized()
        {
            DataContext.PropertyChanged += OnPropertyChanged;

            DynamicComponentConfiguration configuration = DynamicConfigurationManager.GetDynamicComponentConfiguration(GetType().FullName);

            if(configuration != null)
            {
                foreach(ComponentDefinition? component in configuration.Components)
                {
                    if(component != null)
                    {
                        ComponentDefinitions.Add(component);
                    }
                }
            }
        }

        private void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs arguments)
        {
            //if (arguments.PropertyName == "SelectedNode")
            //{
                StateHasChanged();
            //}
        }
    }
}