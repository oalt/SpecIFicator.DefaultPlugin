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

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public partial class HierarchyDocumentItem : IDocumentItem
    {
        [CascadingParameter]
        public HierarchyContext DataContext { get; set; }

        public string Type => "SpecIF:Hierarchy";
    }
}