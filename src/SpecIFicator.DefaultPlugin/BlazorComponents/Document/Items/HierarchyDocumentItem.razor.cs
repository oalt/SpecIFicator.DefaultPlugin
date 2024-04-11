using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.ViewModels;
using System.Resources;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public partial class HierarchyDocumentItem : IDocumentItem
    {
        [CascadingParameter]
        public NodeViewModel DataContext { get; set; }

        public string Type => "SpecIF:Hierarchy";

        public ResourceManager ResourceManager => null;
    }
}