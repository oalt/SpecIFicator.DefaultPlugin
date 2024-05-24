using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.ViewModels;
using SpecIFicator.DefaultPlugin.ViewModels;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class CommentPanel
    {
        [Inject]
        private IStringLocalizer<CommentPanel> L { get; set; }

        [Parameter]
        public HierarchyViewModel HierarchyViewModel { get; set; }

        private CommentsViewModel DataContext { get; set; }

        protected override void OnInitialized()
        {
            DataContext = new CommentsViewModel(HierarchyViewModel);
            DataContext.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }
    }
}