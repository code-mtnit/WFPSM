using System;
using GalaSoft.MvvmLight.Command;
using SessionPresent.Model;
using SessionPresent.Tools;

namespace SessionPresent.ViewModel
{
    public class SessionItemViewModel : TreeViewItemViewModel, IComparable<SessionItemViewModel>
    {

        private string _TitleBackColor;
        private string _TitleForeColor;

        public SessionItemViewModel()
           : base(null,false)
        {
            Title = "آیتم جدید";

            VotingCommand = new RelayCommand(Votting , CanDoVoting);
        }

        private bool CanDoVoting()
        {
            return true;
        }


     

        private void Votting()
        {
            var votingViewModel = new VotingViewModel(this);
           
            var win = new Views.VotingView();
            win.DataContext = votingViewModel;
            win.ShowDialog();   
            
        }

        public SessionItemViewModel(SessionItemViewModel parent)
            : base(parent, false)
        {

            VotingCommand = new RelayCommand(Votting, CanDoVoting);
        }

        private bool _visible = true;


        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Title))
                return Title;

            return base.ToString();
        }

        object _object;
        public object Object
        {
            get
            {
                return _object;
            }
            set
            {
                _object = value;
                OnPropertyChanged("Object");
            }

        }


        private string _backColor;


        ISessionItemViewer _objectViewer;
        public ISessionItemViewer ObjectViewer
        {
            get
            {
                return _objectViewer;
            }
            set
            {
                _objectViewer = value;
                OnPropertyChanged("ObjectViewer");
            }

        }




        public string RefrenceAssemblly { get; set; }

        public string BallotViewerClassName { get; set; }

        public string ObjectViewerClassName { get; set; }

        
        public long Order
        {
            get { return _order; }
            set { _order = value;
                OnPropertyChanged("Order");

            }
        }

        private long _order = 0;


        private bool _canVoting = false;

        public bool CanVoting
        {
            get { return _canVoting; }
            set
            {
                _canVoting = value;
                OnPropertyChanged("CanVoting");
            }
        }



        private bool _canMessaging = false;
        public bool canMessaging
        {
            get { return canMessaging; }
            set
            {
                canMessaging = value;
                OnPropertyChanged("canMessaging");
            }
        }
        public int CompareTo(SessionItemViewModel other)
        {
            return this.Order.CompareTo(other.Order);
        }


        public RelayCommand VotingCommand { get; set; }
        public string TitleBackColor
        {
            get
            {
                return _TitleBackColor;
            }

            set
            {
                _TitleBackColor = value;
            }
        }


        public string TitleForeColor
        {
            get
            {
                return _TitleForeColor;
            }

            set
            {
                _TitleForeColor = value;
            }
        }
        public string BackColor
        {
            get
            {
                return _backColor;
            }

            set
            {
                _backColor = value;
            }
        }

        public int ItemWidth
        {
            get
            {
                return itemWidth;
            }

            set
            {
                itemWidth = value;
            }
        }

        public string ItemIcon
        {
            get
            {
                return itemIcon;
            }

            set
            {
                itemIcon = value;
            }
        }

        public bool IsVisibleInSessionOrderTree
        {
            get
            {
                return _visible;
            }

            set
            {
                _visible = value;
            }
        }

        int itemWidth;

        string itemIcon;
    }
}
