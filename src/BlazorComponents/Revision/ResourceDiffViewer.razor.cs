using Microsoft.AspNetCore.Components;
using MDD4All.SpecIF.ViewModels;
using MDD4All.SpecIF.ViewModels.Revisioning;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Revision
{
    public partial class ResourceDiffViewer
    {
        [Parameter]
        public ResourceViewModel DataContext { get; set; }

        [Parameter]
        public string RevisionToCompare { get; set; }

        public ResourceViewModel ResourceRevisionToCompare
        {
            get
            {
                return DataContext.ResourceRevisionViewModel.GetSelectedResourceRevision(RevisionToCompare);
            }
        }

        private List<PropertyDiffViewModel> Diffs { get; set; }

        protected override void OnInitialized()
        {
            Diffs = DataContext.ResourceRevisionViewModel.GetPropertyDiffs(RevisionToCompare);
        }
    }
}