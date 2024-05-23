using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;
using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.ViewModels;
using SpecIFicator.DefaultPlugin.ViewModels;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class CommentPanel
    {
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
            StateHasChanged();
        }
    }
}