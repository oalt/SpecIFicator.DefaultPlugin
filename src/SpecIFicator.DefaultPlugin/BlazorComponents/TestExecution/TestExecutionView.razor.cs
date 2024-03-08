using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using SpecIFicator.DefaultPlugin.ViewModels;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.TestExecution
{
    partial class TestExecutionView
    {
        [Inject] // Daten speichern in Ressource ----> (.resx)
        public IStringLocalizer<TestExecutionView> L { get; set; }

        [CascadingParameter]
        public HierarchyViewModel? HierarchyViewModel { get; set; }

        public TestExecutionViewModel? DataContext { get; set; }

        protected override void OnInitialized()
        {
            DataContext = new TestExecutionViewModel(HierarchyViewModel);

            HierarchyViewModel.PropertyChanged += OnPropertyChanged;
        }
        private void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            InvokeAsync(() =>
            {
                StateHasChanged();
            });
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

        private void OnPassButtonClick()
        {
            DataContext.Verdict = "V-Verdict-1";
        }

        private void OnFailButtonClick()
        {
            DataContext.Verdict = "V-Verdict-3";
        }

        private void OnInconclusiveButtonClick()
        {
            DataContext.Verdict = "V-Verdict-2";
        }

        private void OnErrorButtonClick()
        {
            DataContext.Verdict = "V-Verdict-4";
        }

        private void OnNotTestedButtonClick()
        {
            DataContext.Verdict = "V-Verdict-0";
        }
    }
}
