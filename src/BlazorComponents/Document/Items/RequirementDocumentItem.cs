using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using SpecIFicator.Framework.CascadingValues;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public partial class RequirementDocumentItem : IDocumentItem
    {


        public string Type => "IREB:Requirement";

        [CascadingParameter]
        public HierarchyEditorContext DataContext { get; set; }
    }
}
