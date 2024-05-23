using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MDD4All.SpecIF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpecIFicator.DefaultPlugin.ViewModels
{
    public class CommentsViewModel : ViewModelBase
    {

        private HierarchyViewModel _hierarchyViewModel;

        public CommentsViewModel(HierarchyViewModel context) 
        { 
            _hierarchyViewModel = context;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            NewCommentCommand = new RelayCommand(ExecuteNewComment);
            SaveCommentCommand = new RelayCommand(ExecuteSaveComment);
            CancelEditCommentCommand = new RelayCommand(ExecuteCancelEditComment);
        }

        private List<ResourceViewModel> Comments 
        {
            get
            {
                return new List<ResourceViewModel>();
            }

            set
            {
            }
        }

        private ResourceViewModel CommentUnderEdit { get; set; } = null;

        public bool ShowCommentEditor
        {
            get
            {
                return CommentUnderEdit != null;
            }
        }

        public ICommand NewCommentCommand { get; private set; }

        public ICommand SaveCommentCommand { get; private set; }

        public ICommand CancelEditCommentCommand { get; private set; }

        private void ExecuteNewComment()
        {
            CommentUnderEdit = new ResourceViewModel(_hierarchyViewModel.MetadataReader,
                                                     _hierarchyViewModel.DataReader,
                                                     _hierarchyViewModel.DataWriter);
        }

        private void ExecuteSaveComment()
        {
            CommentUnderEdit = null;
            RaisePropertyChanged();
        }

        private void ExecuteCancelEditComment()
        {
            CommentUnderEdit = null;
            RaisePropertyChanged();
        }

    }
}
