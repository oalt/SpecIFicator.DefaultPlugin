using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;
using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.ViewModels;
using SpecIFicator.DefaultPlugin.ViewModels;

namespace SpecIFicator.DefaultPlugin.BlazorComponents
{
    public partial class CommentEditor
    {
        [Inject]
        private IStringLocalizer<CommentEditor> L { get; set; }

        [Parameter]
        public CommentsViewModel DataContext { get; set; }
    }
}