using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;

namespace SpecIFicator.UI.BlazorComponents.Document
{
    public partial class HeadingResource : IDocumentItem
    {
        public string Type => "SpecIF:Heading";

        [Parameter]
        public HierarchyViewModel HierarchyViewModel { get; set; }
    }
}
