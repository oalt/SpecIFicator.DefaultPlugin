using MDD4All.FileAccess.Contracts;
using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using SpecIFicator.DefaultPlugin.ViewModels;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.TestExecution
{
    partial class TestExecutionView
    {
        [CascadingParameter]
        public HierarchyViewModel HierarchyViewModel { get; set; }

        public TestExecutionViewModel DataContext { get; set; }

        protected override void OnInitialized()
        {
            DataContext = new TestExecutionViewModel(HierarchyViewModel);
        }

        private void OnSaveButtonClick()
        {
            DataContext.SaveTestResultCommand.Execute(null); 

        }
        private void OnNextButtonClick()
        {
            DataContext.GoToNextCommand.Execute(null);
        }
        private void OnBackButtonClick()
        {
            DataContext.GoToPreviousCommand.Execute(null);

        }

    }
}
