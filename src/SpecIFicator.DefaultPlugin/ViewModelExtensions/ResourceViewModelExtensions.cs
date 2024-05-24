using MDD4All.SpecIF.DataProvider.Contracts;
using MDD4All.SpecIF.ViewModels;
using MDD4All.SpecIF.DataModels.Manipulation;

namespace SpecIFicator.DefaultPlugin.ViewModelExtensions
{
    public static class ResourceViewModelExtensions
    {
        public static bool HasComments(this ResourceViewModel resourceViewModel, ISpecIfMetadataReader metadataReader)
        {
            bool result = false;

            if (resourceViewModel.IncomingStatements != null)
            {
                foreach (StatementViewModel incomingStatement in resourceViewModel.IncomingStatements)
                {
                    if (incomingStatement.StatementClassKey.ID == "SC-refersTo")
                    {
                        ResourceViewModel commentElement = incomingStatement.SubjectResource;
                        if (commentElement.Resource.GetTypeName(metadataReader) == "SpecIF:Comment")
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
