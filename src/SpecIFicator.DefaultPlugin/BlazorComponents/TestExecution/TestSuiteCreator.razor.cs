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
        private NavigationManager NavigationManager { get; set; }

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
            NavigationManager.NavigateTo("/");
        }
        public void OnOkButtonClick()
        {
            DataContext.CreateTestSuiteCommand.Execute(null);
            if(DataContext.TestSuiteHierarchyKey != null)
            {
                NavigationManager.NavigateTo("/pluginPage/36AB7319-01C7-4F3F-9594-A89DBA0BC0A1/" + DataContext.TestSuiteHierarchyKey.ToString());
            }
        }


        private ResourceViewModel? NewTestSuiteViewModel { get; set; }

        private async Task OnNewTestSuiteClose(bool accepted)
        {
            if (accepted)
            {
                //DataContext.CreateTestSuiteCommand.Execute(null);
            }
            if (!accepted) // else
            {
                NavigationManager.NavigateTo("/");
            }
            DataContext.ShowNewTestSuite = false;
            StateHasChanged();
        }
    }
}









