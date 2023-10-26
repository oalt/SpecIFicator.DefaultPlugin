using MDD4All.SpecIF.DataModels;
using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.DataModels.Manipulation;
using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.ViewModels;
using Microsoft.Extensions.Localization;
using SpecIFicator.DefaultPlugin.ViewModels;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.TestExecution
{
    public partial class TestSuiteCreator
    {
        [Inject]
        public IStringLocalizer<TestSuiteCreator> L { get; set; }

        [Inject]
        private ISpecIfDataProviderFactory DataProviderFactory { get; set; }

        [CascadingParameter]
        public string? KeyString { get; set; }

        [Inject]
        private NavigationManager MyNav { get; set; }

        public TestSuiteSelectionTreeViewModel DataContext { get; set; }

        public string Title { get; set; }

        protected override void OnInitialized()
        {
            Key hierarchyRootKey = new Key();
            hierarchyRootKey.InitailizeFromKeyString(KeyString);

            TestSuiteSelectionTreeViewModel testSuiteSelectionTreeViewModel = new TestSuiteSelectionTreeViewModel(DataProviderFactory, hierarchyRootKey);
            DataContext = testSuiteSelectionTreeViewModel;
        }
        public void OnCancelButtonClick()
        {
            MyNav.NavigateTo("/");
        }
        public void OnOkButtonClick()
        {
            DataContext.CreateTestSuiteCommand.Execute(null);

        }
       // [Inject]
        //private IStringLocalizer<ProjectsBrowser> L { get; set; }

        private ResourceViewModel? NewTestSuiteViewModel { get; set; }

        private async Task OnNewTestSuiteClose(bool accepted)
        {
            if (accepted)
            {
                //DataContext.CreateTestSuiteCommand.Execute(null);
            }
            if (!accepted) // else
            {
                MyNav.NavigateTo("/");
            }
            DataContext.ShowNewTestSuite = false;
            StateHasChanged();
        }
    }
}









