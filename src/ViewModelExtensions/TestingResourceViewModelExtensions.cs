using MDD4All.SpecIF.DataModels.Manipulation;
using MDD4All.SpecIF.ViewModels;

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
    }
}
