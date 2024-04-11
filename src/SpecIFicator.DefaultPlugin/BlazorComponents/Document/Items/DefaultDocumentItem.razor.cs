using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Resources;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public partial class DefaultDocumentItem : IDocumentItem
    {
        [CascadingParameter]
        public NodeViewModel DataContext { get; set; }

        public string Type => "default";

        public ResourceManager ResourceManager => null;
    }
}
