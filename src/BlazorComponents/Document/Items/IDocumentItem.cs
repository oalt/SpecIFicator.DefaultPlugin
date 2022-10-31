using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using SpecIFicator.Framework.CascadingValues;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public interface IDocumentItem
    {
        [CascadingParameter]
        public HierarchyEditorContext DataContext { get; set; }

        string Type { get; }
    }
}
