using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class MultilanguageSelector
    {
        [Inject]
        private IStringLocalizer<MultilanguageSelector> L { get; set; }

        [Parameter]
        public HierarchyViewModel DataContext { get; set; }


    }
}