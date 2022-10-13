using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;

namespace SpecIFicator.UI.BlazorComponents.Document
{
    public interface IDocumentItem
    {
        [Parameter]
        HierarchyViewModel HierarchyViewModel { get; set; }

        string Type { get; }
    }
}
