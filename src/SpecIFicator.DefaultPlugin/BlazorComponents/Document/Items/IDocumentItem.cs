using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Resources;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public interface IDocumentItem
    {
        [CascadingParameter]
        public NodeViewModel DataContext { get; set; }

        string Type { get; }

        public ResourceManager ResourceManager { get; }
    }
}
