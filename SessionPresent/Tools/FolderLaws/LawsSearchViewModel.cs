using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using SessionPresent.ViewModel;

namespace SessionPresent.Tools.FolderLaws
{
    public class LawsSearchViewModel : GalaSoft.MvvmLight.ViewModelBase
    {

        ObservableCollection<SessionItemViewModel> _currentItems;
        public ObservableCollection<SessionItemViewModel> CurrentItems
        {
            get
            {
                return _currentItems;

            }
            set
            {
                _currentItems = value;
                RaisePropertyChanged("CurrentItems");
            }
        }


        ObservableCollection<SessionItemViewModel> _selectedItems;
        public ObservableCollection<SessionItemViewModel> SelectedItems
        {
            get
            {
                return _selectedItems;

            }
            set
            {
                _selectedItems = value;
                RaisePropertyChanged("SelectedItems");
            }
        }



        public LawsSearchViewModel()
        {

            
            CurrentItems = new ObservableCollection<SessionItemViewModel>();
            // Properties.Settings.Default.OtherDocsPath
            var files = System.IO.Directory.GetFiles(Properties.Settings.Default.OtherDocsPath);

            foreach(var itm in files)
            {
                SessionItemViewModel sItm = new SessionItemViewModel();
                sItm.Title = Path.GetFileNameWithoutExtension(itm);
                sItm.Object = itm;
                CurrentItems.Add(sItm);

            }
        }

    }
}
