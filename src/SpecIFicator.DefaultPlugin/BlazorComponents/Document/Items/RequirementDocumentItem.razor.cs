using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Resources;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public partial class RequirementDocumentItem : IDocumentItem
    {

        public string Type => "IREB:Requirement";

        [CascadingParameter]
        public NodeViewModel DataContext { get; set; }

        public ResourceManager ResourceManager => null;
    }
}
