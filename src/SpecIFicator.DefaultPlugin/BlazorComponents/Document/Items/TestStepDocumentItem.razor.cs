using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.ViewModels;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public partial class TestStepDocumentItem : IDocumentItem
    {
        [CascadingParameter]
        public NodeViewModel DataContext { get; set; }

        

        public string Type => "U2TP:TestStep";

        
    }
}