using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecIFicator.UI.BlazorComponents.Document
{
    public partial class DocumentView
    {
        [Parameter]
        public List<HierarchyViewModel> Content { get; set; }
    }
}
