using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;

namespace SpecIFicator.UI.BlazorComponents.Document
{
    public partial class RequirementResource : IDocumentItem
    {
        [Parameter]
        public HierarchyViewModel HierarchyViewModel { get; set; }

        public string Type => "IREB:Requirement";
    }
}
