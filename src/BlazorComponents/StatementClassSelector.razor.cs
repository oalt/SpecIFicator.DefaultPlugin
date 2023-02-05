using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.DataProvider.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MDD4All.SpecIF.DataModels.Manipulation;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class StatementClassSelector
    {
        [Inject]
        private IStringLocalizer<StatementClassSelector> L { get; set; }

        [Inject]
        private ISpecIfDataProviderFactory DataProviderFactory { get; set; }

        private Key _selectedStatementClass;

        [Parameter]
        public Key SelectedStatementClassKey { get; set; }

        [Parameter]
        public EventCallback<Key> SelectedStatementClassKeyChanged { get; set; }

        [Parameter]
        public Key SubjectClassKey { get; set; }

        [Parameter]
        public Key ObjectClassKey { get; set; }

        [Parameter]
        public string CssStyles { get; set; } = "form-control";

        private List<StatementClass> AvailableStatementClasses
        {
            get
            {
                List<StatementClass> result = new List<StatementClass>();

                result = DataProviderFactory.MetadataReader.GetAllStatementClasses();

                return result;
            }
        }

        private List<StatementClass> FilteredStatementClasses
        {
            get
            {
                List<StatementClass> result = new List<StatementClass>();

                List<StatementClass> availableStatements = AvailableStatementClasses;

                if(SubjectClassKey == null || ObjectClassKey == null)
                {
                    result = availableStatements;
                }
                else
                {

                    foreach(StatementClass statementClass in availableStatements)
                    {
                        bool subjectMatch = false;
                        bool objectMatch = false;

                        if (statementClass.SubjectClasses != null && statementClass.SubjectClasses.Count > 0)
                        {
                            Key subjectMatchKey = statementClass.SubjectClasses.Find(key => key.ID == SubjectClassKey.ID);

                            if (subjectMatchKey != null)
                            {
                                subjectMatch = true;
                            }

                        }
                        else
                        {
                            subjectMatch = true;
                        }

                        if (statementClass.ObjectClasses != null && statementClass.ObjectClasses.Count > 0)
                        {
                            Key objectMatchKey = statementClass.ObjectClasses.Find(key => key.ID == ObjectClassKey.ID);

                            if(objectMatchKey != null)
                            {
                                objectMatch = true;
                            }

                        }
                        else
                        {
                            objectMatch = true;
                        }

                        if(subjectMatch && objectMatch)
                        {
                            result.Add(statementClass);
                        }
                    }
                }

                return result;
            }
        }

        protected async override Task OnInitializedAsync()
        {
            if (FilteredStatementClasses != null && FilteredStatementClasses.Any())
            {
                StatementClass firstStatementClass = FilteredStatementClasses[0];

                _selectedStatementClass = new Key(firstStatementClass.ID, firstStatementClass.Revision);

                await SelectedStatementClassKeyChanged.InvokeAsync(_selectedStatementClass);
            }
        }

        private async Task OnStatementClassSelectionChange(ChangeEventArgs args)
        {
            Console.WriteLine(args.Value.ToString());
            string selection = args.Value.ToString();
            if (!string.IsNullOrEmpty(selection))
            {
                _selectedStatementClass = new Key();
                _selectedStatementClass.InitailizeFromKeyString(selection);

                await SelectedStatementClassKeyChanged.InvokeAsync(_selectedStatementClass);
            }


        }
    }
}