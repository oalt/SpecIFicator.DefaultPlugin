using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.ViewModels;
using System.Resources;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public partial class TestSuiteDocumentItem : IDocumentItem
    {
        [CascadingParameter]
        public NodeViewModel DataContext { get; set; }

        public string Type => "U2TP:TestSuite";

        public ResourceManager ResourceManager => null;
    }
}