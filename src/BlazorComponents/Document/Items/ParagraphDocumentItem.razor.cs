using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using SpecIFicator.Framework.CascadingValues;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public partial class ParagraphDocumentItem : IDocumentItem
    {
        [CascadingParameter]
        public HierarchyContext DataContext { get; set; }

        public string Type => "SpecIF:Paragraph";
    }
}
