using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;
using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.ViewModels;
using MDD4All.SpecIF.DataProvider.Contracts;
using System.Reflection.Metadata;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class MainToolBar
    {
        [Inject]
        private IStringLocalizer<MainToolBar> L { get; set; }

        [Inject]
        private ISpecIfDataProviderFactory DataProviderFactory { get; set; }

        [Parameter]
        public HierarchyViewModel HierarchyViewModel { get; set; }

        private bool _editDialogOpen = false;

        private Key SelectedResourceClassKey { get; set; }

        protected override void OnInitialized()
        {
            
        }

        

        

        private void OpenEditDialog()
        {
            _editDialogOpen = true;
            StateHasChanged();
        }

        
    }
}