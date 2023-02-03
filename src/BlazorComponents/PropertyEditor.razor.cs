using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.DataModels.Manipulation;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class PropertyEditor
    {
        [Parameter]
        public PropertyViewModel PropertyViewModel { get; set; }

        [Parameter]
        public bool IsMultilinguismEnabled { get; set; } = false;

        [Parameter]
        public string PrimaryLanguage { get; set; } = "en";

        [Parameter]
        public string SecondaryLanguage { get; set; } = "de";

        private string SelectedEnumValue
        {
            get
            {
                return PropertyViewModel.Property.GetSingleEnumerationValue();
            }

            set
            {
                PropertyViewModel.SetSingleEnumerationValue(value);
            }
        }

        private string[] SelectedEnumValues
        {

            get
            {
                string[] result = { };

                List<string> values = new List<string>();

                values = PropertyViewModel.Property.GetMultipleEnumerationValue();
                
                return values.ToArray();
            }

            set
            {
                PropertyViewModel.SetMultipleEnumerationValue(new List<string>(value));
            }
        }

        protected override void OnInitialized()
        {
            PropertyViewModel.PrimaryLanguage = PrimaryLanguage;
            PropertyViewModel.SecondaryLanguage = SecondaryLanguage;
        }
    }
}
