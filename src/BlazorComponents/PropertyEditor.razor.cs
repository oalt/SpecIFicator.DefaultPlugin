using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.DataModels.Manipulation;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class PropertyEditor
    {
        [Parameter]
        public PropertyViewModel PropertyViewModel { get; set; }

        private string SelectedEnumValue
        {
            get
            {
                return PropertyViewModel.Property.GetSingleEnumerationValue();
            }

            set
            {
                PropertyViewModel.Property.SetSingleEnumerationValue(value);
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
                PropertyViewModel.Property.SetMultipleEnumerationValue(new List<string>(value));
            }
        }
    }
}
