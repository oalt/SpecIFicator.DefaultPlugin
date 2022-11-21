using Microsoft.AspNetCore.Components;
using SpecIFicator.Framework.CascadingValues;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public partial class HeadingDocumentItem : IDocumentItem
    {
        public string Type => "SpecIF:Heading";

        [CascadingParameter]
        public HierarchyContext DataContext { get; set; }

        private string CssClass
        {
            get
            {
                string result = "";

                if(DataContext != null)
                {
                    switch(DataContext.HierarchyViewModel.Depth)
                    {
                        case 1:
                            result = "h1";
                            break;

                        case 2:
                            result = "h2";
                            break;

                        case 3:
                            result = "h3";
                            break;

                        case 4:
                        default:
                            result = "h4";
                            break;
                    }
                }

                return result;
            }
        }
    }
}
