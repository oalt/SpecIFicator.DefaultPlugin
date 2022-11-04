using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using SpecIFicator.Framework.CascadingValues;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public partial class HeadingDocumentItem : IDocumentItem
    {
        public string Type => "SpecIF:Heading";

        [CascadingParameter]
        public HierarchyContext DataContext { get; set; }
    }
}
