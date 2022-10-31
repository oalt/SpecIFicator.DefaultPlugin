using Microsoft.AspNetCore.Components;
using SpecIFicator.Framework.CascadingValues;
using SpecIFicator.Framework.Configuration;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class HierarchyView
    {
        [CascadingParameter]
        public HierarchyEditorContext DataContext { get; set; }

        private Type _documentViewType;



        private Type _rawViewType;

        private Type _resourceViewType;

        protected override void OnInitialized()
        {


            _documentViewType = DynamicConfigurationManager.GetComponentType("DocumentView",
                                                                             GetType().FullName,
                                                                             DataContext.HierarchyViewModel.RootResourceClassKey
                                                                            );


        }
    }
}