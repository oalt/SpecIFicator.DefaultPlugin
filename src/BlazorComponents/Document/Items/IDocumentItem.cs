using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public interface IDocumentItem
    {
        [CascadingParameter]
        public NodeViewModel DataContext { get; set; }

        string Type { get; }
    }
}
