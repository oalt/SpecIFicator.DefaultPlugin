using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using SpecIFicator.Framework.CascadingValues;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public partial class DefaultDocumentItem : IDocumentItem
    {
        [CascadingParameter]
        public HierarchyEditorContext DataContext { get; set; }

        public string Type => "default";
    }
}
