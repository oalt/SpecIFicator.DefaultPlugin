using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;

namespace SpecIFicator.UI.BlazorComponents.Document
{
    public partial class ParagraphResource : IDocumentItem
    {
        [Parameter]
        public HierarchyViewModel HierarchyViewModel { get; set; }

        public string Type => "SpecIF:Paragraph";
    }
}
