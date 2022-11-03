using MDD4All.SpecIF.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class PropertyEditor
    {
        [Parameter]
        public PropertyViewModel PropertyViewModel { get; set; }
    }
}
