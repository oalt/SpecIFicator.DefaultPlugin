using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;
using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.ViewModels;
using SpecIFicator.Framework.CascadingValues;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class ResourceView
    {
        [CascadingParameter]
        public HierarchyEditorContext DataContext { get; set; }

        

        ResourceViewModel SelectedResource
        {
            get
            {
                ResourceViewModel result = null;
                if(DataContext != null && DataContext.HierarchyViewModel.SelectedNode != null)
                {
                    HierarchyViewModel selectedNode = DataContext.HierarchyViewModel.SelectedNode as HierarchyViewModel;

                    result = selectedNode.ReferencedResource;
                }

                return result;
            }
        }

        protected override void OnInitialized()
        {
            
        }

        
    }
}