using MDD4All.FileAccess.Contracts;
using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.TestExecution
{
    partial class TestExecutionView
    {
        [CascadingParameter]
        public HierarchyViewModel? DataContext { get; set; }

        ResourceViewModel SelectedResource
        {
            get
            {
                ResourceViewModel result = null;
                if (DataContext != null && DataContext.SelectedNode != null)
                {
                    NodeViewModel? selectedNode = DataContext.SelectedNode as NodeViewModel;

                    result = selectedNode.ReferencedResource;
                }

                return result;
            }
        }

        NodeViewModel SelectedNode
        {
            get
            {
                NodeViewModel result = null;

                result = DataContext.SelectedNode as NodeViewModel;

                return result;
            }
        }

        [CascadingParameter]
        public HierarchyViewModel? ExceptedResult { get; set; }

        [CascadingParameter]
        public HierarchyViewModel? ReasonMessage { get; set; }

        private void OnSaveButtonClick()
        {
            //DataContext.SaveCommand.Execute(null); 
         
        }
        private void OnNextButtonClick()
        {
            //DataContext.NextCommand.Execute(null);
        }
        private void OnBackButtonClick()
        {
            //DataContext.BackCommand.Execute(null);

        }

    }
}
