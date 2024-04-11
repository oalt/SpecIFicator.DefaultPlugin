using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.ViewModels;
using System.Resources;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public partial class ActorDocumentItem : IDocumentItem
    {
        [CascadingParameter]
        public NodeViewModel DataContext { get; set; }

        public string Type => "FMC:Actor";

        public ResourceManager ResourceManager => null;
    }
}