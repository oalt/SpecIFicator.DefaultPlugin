using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.DataProvider.Contracts;
using System.Reflection.Metadata;
using SpecIFicator.DefaultPlugin.ViewModels;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.TestExecution
{
    public partial class TestSuiteSelectionTree
    {
        [Inject]
        private ISpecIfDataProviderFactory DataProviderFactory { get; set; }

        [Parameter]
        public string KeyString { get; set; }

        [Parameter]
        public TestSuiteSelectionTreeViewModel DataContext { get; set; }

        protected override void OnInitialized()
        {

        }
        public void CheckboxChanged(ChangeEventArgs e)
        {
            TestResourceNodeViewModel? selectedNode = DataContext.SelectedNode as TestResourceNodeViewModel;
            
            TestResourceNodeViewModel? Parent = selectedNode.Parent as TestResourceNodeViewModel;

            selectedNode.IsChecked = (bool)e.Value;

            bool checkValue = (bool)e.Value;

            if (checkValue == true) // häkchen gesetzt
            {
                CheckCurrentNodeAndAllChildNodes(selectedNode, checkValue);
                CheckParentNode(Parent, checkValue);
            }
            else // häkchen weg genommen
            {
                selectedNode.IsChecked = false;
                CheckCurrentNodeAndAllChildNodes(selectedNode, false);

                if (Parent != null  )
                {
                    bool AnyChildrenChecked = false;
                    foreach (TestResourceNodeViewModel child in Parent.Children)
                    {
                        if (child.IsChecked)
                        {
                           AnyChildrenChecked= true;
                        }
                    }
                    if (AnyChildrenChecked == false )
                    {
                        CheckParentNode(Parent, false);
                    } 
                } 
            }
        }
        //Methode "CheckCurrentNodeAndAllChildNotes" rekursiv aufgerufen, um den aktuellen Knoten und alle seine untergeordneten Knoten zu überprüfen. 
        // Und aktuelle Knoten erhält den Wert der Checkbox und dann wird die Methode für jeden untergeordneten Knoten aufgerufen.
        private void CheckCurrentNodeAndAllChildNodes(TestResourceNodeViewModel node, bool _isChecked)
        {
            node.IsChecked = _isChecked;

            //TestResourceNodeViewModel Parent = node.Parent as TestResourceNodeViewModel;

            if (node.Children != null && node.Children.Count > 0)
            {
                foreach (TestResourceNodeViewModel nodeChild in node.Children)
                {
                    CheckCurrentNodeAndAllChildNodes(nodeChild, _isChecked);
                }
            }
            //Klasse TestResourceNoteViewModel eine Eigenschaft Children hat, die eine Liste der untergeordneten Knoten enthält.
        }
        private void CheckParentNode(TestResourceNodeViewModel ParentNode, bool _isChecked)
        {
            if (ParentNode != null)
            {
                ParentNode.IsChecked = _isChecked;
            }
            
        }
    }
}