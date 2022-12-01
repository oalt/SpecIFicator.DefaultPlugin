using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;
using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.ViewModels;
using MDD4All.UI.BlazorComponents.Services;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class ResourcePanel
    {
        [Inject]
        public ClipboardDataProvider ClipboardDataProvider { get; set; }
        
        [Parameter]
        public ResourceViewModel ResourceViewModel { get; set; }

        private string CopyButtonIconClass { get; set; } = "bi bi-clipboard-fill";

        private async void CopyKeyToClipboardAsync()
        {
            string copyIcon = CopyButtonIconClass;
            CopyButtonIconClass = "bi bi-check";
            await ClipboardDataProvider.WriteTextAsync(ResourceViewModel.Key.ToString());
            await Task.Delay(TimeSpan.FromSeconds(2));
            CopyButtonIconClass = copyIcon;
            StateHasChanged();


        }
    }
}