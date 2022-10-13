using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using SpecIFicator.UI.BlazorComponents.Document;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document
{
    public partial class DefaultResource : IDocumentItem
    {
        [Parameter]
        public HierarchyViewModel HierarchyViewModel { get; set; }

        public string Type => "default";
    }
}
