using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.ViewModels;
using MDD4All.SpecIF.ViewModels.Search;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MDD4All.SpecIF.DataModels.Manipulation;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class ResourceSearch
    {
        [Inject]
        private IStringLocalizer<ResourceSearch> L { get; set; }

        [Parameter]
        public ResourceSearchViewModel DataContext { get; set; }


        private void OnSerachButtonClicked()
        {
            if(DataContext != null)
            {
                DataContext.RunSearchCommand.Execute(null);
                StateHasChanged();
            }
        }

        private async Task OnResourceSelectionChange(ChangeEventArgs changeEventArguments)
        {
            string keyString = changeEventArguments.Value.ToString();

            Key key = new Key();
            key.InitailizeFromKeyString(keyString);

            DataContext.SelectedResource = DataContext.SearchResults.Find(resource => resource.Key.Equals(key));
        }
    }
}