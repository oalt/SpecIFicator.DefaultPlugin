using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.DataModels.Manipulation;
using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using VisNetwork.Blazor;
using VisNetwork.Blazor.Models;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.StatementBrowser
{
    public partial class StatementGraphPanel
    {
        [Parameter]
        public ResourceViewModel DataContext
        {
            get
            {
                return CurrentResourceViewModel;
            }

            set
            {
                UpdateGraph(value);
            }
        }

        private ResourceViewModel CurrentResourceViewModel { get; set; }

        public NetworkData GraphData { get; set; }

        private NetworkOptions _networkOptions;

        private NetworkOptions NetworkOptions(Network network)
        {
            return _networkOptions;
        }

        protected override void OnInitialized()
        {

            CurrentResourceViewModel = DataContext;
            GraphData = DataContext.StatementGraph;
            _networkOptions = DataContext.StatementGraphOptions;
            CurrentResourceViewModel.PropertyChanged += OnPropertyChanged;

        }

        private void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "StatementsInitialized")
            {
                InvokeAsync(() =>
                {
                    StateHasChanged();
                });
            }
        }

        private void OnNodeDoubleClick(ClickEvent clickEvent)
        {
            List<string> nodes = clickEvent.Nodes;
            if (nodes != null && nodes.Any())
            {
                Key key = new Key();
                key.InitailizeFromKeyString(nodes[0]);

                foreach (StatementViewModel statement in CurrentResourceViewModel.Statements)
                {
                    if (statement != null)
                    {
                        if (statement.SubjectResource.Key.Equals(key))
                        {
                            UpdateGraph(statement.SubjectResource);
                            break;
                        }
                        if (statement.ObjectResource.Key.Equals(key))
                        {
                            UpdateGraph(statement.ObjectResource);
                            break;
                        }
                    }
                }

            }
        }

        private void UpdateGraph(ResourceViewModel newViewModel)
        {
            if (CurrentResourceViewModel != null)
            {
                CurrentResourceViewModel.PropertyChanged -= OnPropertyChanged;
            }
            CurrentResourceViewModel = newViewModel;
            GraphData = CurrentResourceViewModel.StatementGraph;
            CurrentResourceViewModel.PropertyChanged += OnPropertyChanged;
        }
    }
}