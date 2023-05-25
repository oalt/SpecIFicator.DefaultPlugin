using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.ViewModels;
using MDD4All.UI.DataModels.Tree;
using SpecIFicator.DefaultPlugin.ViewModelExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpecIFicator.DefaultPlugin.ViewModels
{
    public class TestExecutionViewModel
    {
        private HierarchyViewModel _hierarchyViewModel;

        public TestExecutionViewModel(HierarchyViewModel hierarchyViewModel) 
        {
            _hierarchyViewModel = hierarchyViewModel;
            InitializeCommands();
        }

        private void InitializeCommands()
        {

        }

        public string Verdict
        {
            get
            {
                return "";
            }

            set
            {

            }
        }

        public string ReasonMessage 
        { 
            get
            {
                return "";
            }

            set
            { 
            }
        }

        public string TestCaseTitle
        {
            get
            {
                string result = "";

                NodeViewModel selectedNode = _hierarchyViewModel.SelectedNode as NodeViewModel;

                if(selectedNode != null)
                {
                    result = selectedNode.TestCaseTitle();
                }

                return result;
            }
        }

        public ICommand GoToNextCommand { get; private set; }

        public ICommand GoToPreviousCommand { get; private set; }

        public ICommand SaveTestResultCommand { get; private set; }
    
    }
}
