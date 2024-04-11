using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Resources;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public partial class ParagraphDocumentItem : IDocumentItem
    {
        [CascadingParameter]
        public NodeViewModel DataContext { get; set; }

        public string Type => "SpecIF:Paragraph";

        public ResourceManager ResourceManager => null;
    }
}
