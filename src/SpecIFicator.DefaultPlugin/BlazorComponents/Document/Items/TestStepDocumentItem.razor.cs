using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.ViewModels;
using System.Resources;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public partial class TestStepDocumentItem : IDocumentItem
    {
        [CascadingParameter]
        public NodeViewModel DataContext { get; set; }

        

        public string Type => "U2TP:TestStep";

        public ResourceManager ResourceManager => null;
    }
}