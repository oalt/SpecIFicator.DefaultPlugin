using EA;
using GalaSoft.MvvmLight.Command;
using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.DataModels.Manipulation;
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

        public TestExecutionViewModel(HierarchyViewModel hierarchyViewModel)

        {
            HierarchyViewModel = hierarchyViewModel;
            InitializeCommands();

        }
        private void InitializeCommands()
        {
            GoToPreviousCommand = new RelayCommand(ExecuteGoToPrevious);
            GoToNextCommand = new RelayCommand(ExecuteGoToNext);
            SaveTestResultCommand = new RelayCommand(ExecuteSaveTestResult);

        }

        public HierarchyViewModel HierarchyViewModel { get; set; }

        public ResourceViewModel SelectedResource
        {
            get
            {
                ResourceViewModel result = null;
                if (HierarchyViewModel.SelectedNode != null)
                {
                    NodeViewModel? selectedNode = HierarchyViewModel.SelectedNode as NodeViewModel;

                    result = selectedNode.ReferencedResource;
                }

                return result;
            }
        }

        public NodeViewModel SelectedNode
        {
            get
            {
                NodeViewModel result = null;

                result = HierarchyViewModel.SelectedNode as NodeViewModel;

                return result;
            }
        }

        public Dictionary<string, string> VerdictValues
        {
            get
            {
                Dictionary<string, string> result = new Dictionary<string, string>();

                result.Add("V-Verdict-0", "None");
                result.Add("V-Verdict-1", "Pass");
                result.Add("V-Verdict-2", "Inconclusive");
                result.Add("V-Verdict-3", "Fail");
                result.Add("V-Verdict-4", "Error");

                return result;
            }
        }

        public string Verdict
        {
            get
            {
                string result = "";


                if (SelectedResource != null)
                {
                    if (SelectedResource.ResourceClassID == "RC-TestStep" || SelectedResource.ResourceClassID == "RC-TestCase")
                    {
                        result = SelectedResource.Resource.GetPropertyValue("U2TP:Verdict", SelectedResource.MetadataReader);
                    }
                }
                return result;
            }
            set
            {
                string tmp = value;
                ;
            }
        }
        public string ReasonMessage
        {
            get
            {
                string result = "";


                if (SelectedResource != null)
                {
                    if (SelectedResource.ResourceClassID == "RC-TestStep")
                    {
                        result = SelectedResource.Resource.GetPropertyValue("U2TP:ReasonMessage", SelectedResource.MetadataReader);
                    }

                }
                return result;
            }
            set
            {
            }
        }
        public string TestCaseTestResult
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

                NodeViewModel? selectedNode = HierarchyViewModel.SelectedNode as NodeViewModel;

                if (selectedNode != null)
                {
                    result = selectedNode.TestCaseTitle();
                }

                return result;
            }
        }

        public ICommand GoToNextCommand { get; private set; }

        public ICommand GoToPreviousCommand { get; private set; }

        public ICommand SaveTestResultCommand { get; private set; }
        public NodeViewModel child { get; private set; }

        private void ExecuteGoToPrevious()
        {
            if (SelectedResource.ResourceClassID == "RC-TestStep")
            {
                NodeViewModel currentNodeViewModel = SelectedNode as NodeViewModel;

                NodeViewModel previousTestStep = null;

                NodeViewModel parent = currentNodeViewModel.Parent as NodeViewModel;

                foreach (NodeViewModel child in parent.Children)
                {
                    if (child == currentNodeViewModel)
                    {
                        break;
                    }
                    else
                    {
                        previousTestStep = child;
                    }
                }
                if (previousTestStep != null)
                {
                    HierarchyViewModel.SelectedNode = previousTestStep;
                }
                else
                {
                    NodeViewModel parentTestCase = currentNodeViewModel.Parent as NodeViewModel;
                    HierarchyViewModel.SelectedNode = parentTestCase;
                }
            }
            if (SelectedResource.ResourceClassID == "RC-TestCase")
            {
                NodeViewModel currentNodeViewModel = SelectedNode as NodeViewModel;

                NodeViewModel previousTestCase = null;

                // Suche den vorherigen TestCase und setze die Variable previousTestCase

                NodeViewModel parent = currentNodeViewModel.Parent as NodeViewModel;

                foreach (NodeViewModel child in parent.Children)
                {
                    if (child == currentNodeViewModel)
                    {
                        break;
                    }
                    else
                    {
                        previousTestCase = child;
                    }
                }

                if (previousTestCase != null)
                {
                    HierarchyViewModel.SelectedNode = previousTestCase;
                }
                //else
                //{
                //    NodeViewModel previousNodeViewModel = currentNodeViewModel as NodeViewModel;
                //    HierarchyViewModel.SelectedNode = previousNodeViewModel;
                //}
            }

        }
        private void ExecuteGoToNext()
        {
            if (SelectedResource.ResourceClassID == "RC-TestStep")
            {
                NodeViewModel currentNodeViewModel = SelectedNode as NodeViewModel;
                NodeViewModel parent = currentNodeViewModel.Parent as NodeViewModel;
                NodeViewModel nextTestStep = null;

                bool foundCurrentTestStep = false;

                foreach (NodeViewModel child in parent.Children)
                {
                    if (foundCurrentTestStep && child.ReferencedResource.ResourceClassID == "RC-TestStep")
                    {
                        nextTestStep = child;
                        break;
                    }
                    if (child == currentNodeViewModel)
                    {
                        foundCurrentTestStep = true;
                    }
                }

                // next teststep found
                if (nextTestStep != null)
                {
                    HierarchyViewModel.SelectedNode = nextTestStep;

                }
                else
                {
                    NodeViewModel grandparend = parent.Parent as NodeViewModel;
                    if (grandparend != null)
                    {
                        NodeViewModel nextTestCase = null;

                        bool currentTestCaseFound = false;
                        foreach (NodeViewModel child in grandparend.Children)
                        {
                            if (currentTestCaseFound && child.ReferencedResource.ResourceClassID == "RC-TestCase")
                            {
                                nextTestCase = child;
                                break;
                            }

                            if (child == parent)
                            {
                                currentTestCaseFound = true;
                            }
                        }

                        if (nextTestCase != null)
                        {
                            HierarchyViewModel.SelectedNode = nextTestCase;
                        }

                    }

                }

            }
            else if (SelectedResource.ResourceClassID == "RC-TestCase")
            {
                NodeViewModel currentNodeViewModel = SelectedNode as NodeViewModel;

                if (currentNodeViewModel.Children != null && currentNodeViewModel.Children.Count > 0) 
                {
                    NodeViewModel child = currentNodeViewModel.Children[0] as NodeViewModel;
                    HierarchyViewModel.SelectedNode = child;
                    
                }


            }

        }

        private void ExecuteSaveTestResult()
        {



        }

    }
}