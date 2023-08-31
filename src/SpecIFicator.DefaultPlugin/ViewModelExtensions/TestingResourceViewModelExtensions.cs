using MDD4All.SpecIF.DataModels.Manipulation;
using MDD4All.SpecIF.ViewModels;
using SpecIFicator.DefaultPlugin.BlazorComponents;

namespace SpecIFicator.DefaultPlugin.ViewModelExtensions
{
    public static class TestingResourceViewModelExtensions
    {

        public static string TestData(this ResourceViewModel resourceViewModel)
        {
            string result = "";

            if (resourceViewModel.Resource != null && resourceViewModel.Resource.Properties != null)
            {
                result = resourceViewModel.Resource.GetPropertyValue("ISTQB:TestData", resourceViewModel.MetadataReader);
            }

            return result;
        }

        public static string ExpectedResult(this ResourceViewModel resourceViewModel)
        {
            string result = "";

            if (resourceViewModel.Resource != null && resourceViewModel.Resource.Properties != null)
            {
                result = resourceViewModel.Resource.GetPropertyValue("ISTQB:ExpectedResult", resourceViewModel.MetadataReader);
            }

            return result;
        }

        public static string TestPrecondition(this ResourceViewModel resourceViewModel)
        {
            string result = "";

            if (resourceViewModel.Resource != null && resourceViewModel.Resource.Properties != null)
            {
                result = resourceViewModel.Resource.GetPropertyValue("ISTQB:Precondition", resourceViewModel.MetadataReader);
            }

            return result;
        }

        public static string TestCaseTitle(this NodeViewModel nodeViewModel)
        {
            string result = "";

            if (nodeViewModel.ReferencedResource.ResourceClassID == "RC-TestStep")
            {
                NodeViewModel parentNode = nodeViewModel.Parent as NodeViewModel;

                if (parentNode != null &&
                    parentNode.ReferencedResource.ResourceClassID == "RC-TestCase") 
                {
                    result = parentNode.ReferencedResource.Title;
                }

            }
            else if(nodeViewModel.ReferencedResource.ResourceClassID == "RC-TestCase")
            {
                result = nodeViewModel.ReferencedResource.Title;
            }
            
            return result;
        }

        public static string TestCaseIcon(this NodeViewModel nodeViewModel)
        {
            string result = "";

            if (nodeViewModel.ReferencedResource.ResourceClassID == "RC-TestStep")
            {
                NodeViewModel parentNode = nodeViewModel.Parent as NodeViewModel;

                if (parentNode != null &&
                    parentNode.ReferencedResource.ResourceClassID == "RC-TestCase")
                {
                    result = parentNode.ReferencedResource.Icon;
                }

            }
            else if (nodeViewModel.ReferencedResource.ResourceClassID == "RC-TestCase")
            {
                result = nodeViewModel.ReferencedResource.Icon;
            }

            return result;
        }

    }
}
