using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using VisNetwork.Blazor.Models;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Revision
{
    public partial class ResourceRevisionView
    {
        [Parameter]
        public ResourceViewModel DataContext { get; set; }

        public List<string> SelectedNodes { get; set; }

        private void OnNodeSelectionChanged(NodeSelectEventArguments arguments)
        {
            SelectedNodes = arguments.SelectedNodes;
        }
    }
}