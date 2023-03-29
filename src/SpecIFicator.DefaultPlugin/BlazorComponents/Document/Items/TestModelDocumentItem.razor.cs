using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public partial class TestModelDocumentItem : IDocumentItem
    {
        [CascadingParameter]
        public NodeViewModel DataContext { get; set; }

        public string Type => "U2TP:TestModel";
    }
}