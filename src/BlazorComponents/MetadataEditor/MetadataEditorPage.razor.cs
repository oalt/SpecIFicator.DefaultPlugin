using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.MetadataEditor
{
    public partial class MetadataEditorPage
    {
        [Inject]
        private IStringLocalizer<MetadataEditorPage> L { get; set; }

        private Type? ActiveType { get; set; } = null;
    }
}