using GalaSoft.MvvmLight.Command;
using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.DataModels.Manipulation;
using MDD4All.SpecIF.ViewModels;
using SpecIFicator.DefaultPlugin.ViewModelExtensions;
using System.Windows.Input;

namespace SpecIFicator.DefaultPlugin.ViewModels
{
    public class TestExecutionViewModel
    {
        private int changedat;
        private string testDate;
        private string title;
        private string description;

        public TestExecutionViewModel(HierarchyViewModel hierarchyViewModel)

        {
            HierarchyViewModel = hierarchyViewModel;
            InitializeCommands();

        }
        private void InitializeCommands()
        {
            GoToPreviousCommand = new RelayCommand(ExecuteGoToPrevious);
            GoToNextCommand = new RelayCommand(ExecuteGoToNext);
            SaveTestResultCommand = new RelayCommand(ExecuteSaveTestResult, CanSave);

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
                NodeViewModel? result = null;

                result = HierarchyViewModel.SelectedNode as NodeViewModel;

                //NodeViewModel? result = HierarchyViewModel.SelectedNode as NodeViewModel; 

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

        private Dictionary<Key, Resource> ChangedResources = new Dictionary<Key, Resource>();

        public string Verdict
        {
            get
            {
                string result = "";
                if (SelectedResource != null)
                {
                    if (SelectedResource.ResourceClassID == "RC-TestStep" || SelectedResource.ResourceClassID == "RC-TestCase")
                    {
                        result = SelectedResource.Resource.GetPropertyValue("U2TP:Verdict", SelectedResource.MetadataReader);//aktuelle verdict 
                    }
                }
                return result;
            }

            set
            {
                if (SelectedResource != null)
                {
                    List<PropertyViewModel> properties = SelectedResource.Properties;

                    foreach (PropertyViewModel property in properties)
                    {
                        if (property.PropertyClass.ID == "PC-TestVerdict")
                        {
                            Key selectedResourceKey = new Key(SelectedResource.Resource.ID, SelectedResource.Resource.Revision);

                            if (!ChangedResources.ContainsKey(selectedResourceKey))
                            {
                                ChangedResources.Add(selectedResourceKey, SelectedResource.Resource);
                            }

                            property.SetSingleEnumerationValue(value);
                            HierarchyViewModel.StateChanged = true;
                            break;
                        }
                    }
                }

                string resultingVerdict = "V-Verdict-0";
                
                if (SelectedResource != null)
                {
                    List<PropertyViewModel> propertiesViewModel = SelectedResource.Properties;

                    foreach (NodeViewModel child in SelectedNode.Parent.Children)
                    {
                        string childVerdict = child.ReferencedResource.Resource.GetPropertyValue("U2TP:Verdict", SelectedResource.MetadataReader);

                        if (childVerdict != null)
                        {
                            if (SelectedResource.ResourceClassID == "RC-TestStep")
                            {
                                if (childVerdict == "V-Verdict-0" && resultingVerdict == "V-Verdict-0")  // None: nicht getestet
                                {
                                    resultingVerdict = "V-Verdict-0";
                                }
                                else if (childVerdict == "V-Verdict-1" && (resultingVerdict == "V-Verdict-1" || resultingVerdict == "V-Verdict-0")) //Pass
                                {
                                    resultingVerdict = "V-Verdict-1";
                                }
                                else if (childVerdict == "V-Verdict-2" && (resultingVerdict == "V-Verdict-2" || resultingVerdict == "V-Verdict-1" || resultingVerdict == "V-Verdict-0")) //Inconclusive
                                {
                                    resultingVerdict = "V-Verdict-2";
                                }
                                else if (childVerdict == "V-Verdict-3" && (resultingVerdict == "V-Verdict-3" || resultingVerdict == "V-Verdict-1" || resultingVerdict == "V-Verdict-2" || resultingVerdict == "V-Verdict-0")) //Fail
                                {
                                    resultingVerdict = "V-Verdict-3";
                                }
                                else if (childVerdict == "V-Verdict-4" && (resultingVerdict == "V-Verdict-4" || resultingVerdict == "V-Verdict-1" || resultingVerdict == "V-Verdict-0" || resultingVerdict == "V-Verdict-2" || resultingVerdict == "V-Verdict-3")) //Error
                                {
                                    resultingVerdict = "V-Verdict-4";
                                }
                            }
                        }
                    }

                    NodeViewModel parentNode = SelectedNode.Parent as NodeViewModel;

                    List<PropertyViewModel> properties = parentNode.ReferencedResource.Properties;

                    foreach (PropertyViewModel property in properties)
                    {
                        if (property.PropertyClass.ID == "PC-TestVerdict")
                        {
                            Key key = new Key(SelectedResource.Resource.ID, SelectedResource.Resource.Revision);

                            if (!ChangedResources.ContainsKey(key))
                            {

                                ChangedResources.Add(key, parentNode.ReferencedResource.Resource);
                            }


                            property.SetSingleEnumerationValue(resultingVerdict);
                            HierarchyViewModel.StateChanged = true;
                            break;
                        }
                    }

                    // Wenn TestCase und TestStep Pass sind, sollte TestSuite als Pass dargestellt werden.
                    NodeViewModel nodeTestsuite = SelectedNode.Parent.Parent as NodeViewModel;

                    List<PropertyViewModel> propertyViewModels = nodeTestsuite.ReferencedResource.Properties;

                    foreach (PropertyViewModel propertyView in propertyViewModels)
                    {
                        if (propertyView.PropertyClass.ID == "PC-TestVerdict")
                        {
                            Key key = new Key(SelectedResource.Resource.ID, SelectedResource.Resource.Revision);

                            if (!ChangedResources.ContainsKey(key))
                            {
                                ChangedResources.Add(key, nodeTestsuite.ReferencedResource.Resource);
                            }
                            propertyView.SetSingleEnumerationValue(resultingVerdict);
                            HierarchyViewModel.StateChanged = true;
                            break;
                        }
                    }
                }
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

                if (SelectedResource != null)
                {
                    if (SelectedResource.ResourceClassID == "RC-TestStep")
                    {
                        SelectedResource.Resource.SetPropertyValue("U2TP:ReasonMessage", value, SelectedResource.MetadataReader);
                        
                        Key selectedResourceKey = new Key(SelectedResource.Resource.ID, SelectedResource.Resource.Revision);

                        if (!ChangedResources.ContainsKey(selectedResourceKey))
                        {
                            ChangedResources.Add(selectedResourceKey, SelectedResource.Resource);
                        }
                    }

                }
            }
        }
        
        public string ReasonMessageFormat
        {
            get
            {
                string result = "plain";

                if(SelectedResource != null && SelectedResource.ResourceClassID == "RC-TestStep")
                {
                    foreach(PropertyClass propertyClass in SelectedResource.PropertyClasses)
                    {
                        if(propertyClass.Title == "U2TP:ReasonMessage" && !string.IsNullOrEmpty(propertyClass.Format))
                        {
                            result = propertyClass.Format;
                            break;
                        }
                    }
                }

                return result;
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

        public string TestObject
        {
            get
            {
                string result = "";

                if (SelectedResource != null && SelectedResource.Properties != null)
                {
                    result = SelectedResource.Resource.GetPropertyValue("ISTQB:TestObject", SelectedResource.MetadataReader);
                }

                return result;
            }

        }

        public ICommand GoToNextCommand { get; private set; }

        public ICommand GoToPreviousCommand { get; private set; }

        public ICommand SaveTestResultCommand { get; private set; }


        private void ExecuteGoToPrevious()
        {
            if (SelectedResource.ResourceClassID == "RC-TestStep" || SelectedResource.ResourceClassID == "RC-TestCase")
            {
                NodeViewModel? currentNodeViewModel = SelectedNode as NodeViewModel;

                NodeViewModel? previousTestStep = null;

                NodeViewModel? parent = currentNodeViewModel.Parent as NodeViewModel;

                foreach (NodeViewModel? child in parent.Children)
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
                    NodeViewModel? parentTestCase = currentNodeViewModel.Parent as NodeViewModel;
                    HierarchyViewModel.SelectedNode = parentTestCase;
                }
            }
        }
        private void ExecuteGoToNext()
        {
            if (SelectedResource.ResourceClassID == "RC-TestStep")
            {
                NodeViewModel? currentNodeViewModel = SelectedNode as NodeViewModel;
                NodeViewModel? parent = currentNodeViewModel.Parent as NodeViewModel;
                NodeViewModel? nextTestStep = null;

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
                    NodeViewModel? grandparend = parent.Parent as NodeViewModel;
                    if (grandparend != null)
                    {
                        NodeViewModel? nextTestCase = null;

                        bool currentTestCaseFound = false;


                        foreach (NodeViewModel child in grandparend.Children)
                        {
                            if (child.ReferencedResource != null)
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
                        }

                        if (nextTestCase != null)
                        {
                            HierarchyViewModel.SelectedNode = nextTestCase;
                        }
                    }
                }
            }
            else if (SelectedResource.ResourceClassID == "RC-TestCase" || SelectedResource.ResourceClassID == "RC-TestSuite")
            {
                NodeViewModel? currentNodeViewModel = SelectedNode as NodeViewModel;

                if (currentNodeViewModel.Children != null && currentNodeViewModel.Children.Count > 0)
                {
                    NodeViewModel? child = currentNodeViewModel.Children[0] as NodeViewModel;
                    HierarchyViewModel.SelectedNode = child;
                }
            }
        }

        private void ExecuteSaveTestResult()
        {


            ChangedResources.Clear();

        }

        private bool CanSave()
        {
            return ChangedResources.Count > 0;
        }

        

    }
}