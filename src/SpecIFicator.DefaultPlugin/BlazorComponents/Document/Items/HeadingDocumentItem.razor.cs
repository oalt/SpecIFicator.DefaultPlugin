using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Resources;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    public partial class HeadingDocumentItem : IDocumentItem
    {
        public string Type => "SpecIF:Heading";

        [CascadingParameter]
        public NodeViewModel DataContext { get; set; }

        public ResourceManager ResourceManager => null;

        private string CssClass
        {
            get
            {
                string result = "";

                if(DataContext != null)
                {
                    switch(DataContext.Depth)
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
