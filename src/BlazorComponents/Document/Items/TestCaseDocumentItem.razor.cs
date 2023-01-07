using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.ViewModels;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public partial class TestCaseDocumentItem : IDocumentItem
    {
        [CascadingParameter]
        public NodeViewModel DataContext { get; set; }

        public string Type => "ISTQB:TestCase";
    }
}