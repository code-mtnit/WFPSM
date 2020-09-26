using Sbn.Products.GEP.GEPObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SessionPresent.ViewModel;

namespace SessionPresent.Tools.SbnTools
{
    /// <summary>
    /// Interaction logic for CatalugeView.xaml
    /// </summary>
    public partial class CatalugeView : UserControl, ISessionItemViewer, INotifyPropertyChanged
    {
        public CatalugeView()
        {
            InitializeComponent();

        }

        public void FillObject(object obj, object mvm)
        {
            DataContext = obj;
            Offer off = new Offer();

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (e.AddedItems.Count == 0)
            //    return;

            //var itm = e.AddedItems[0] as SessionItem;
            //if (itm == null)
            //    return;

            //var itmTemp = itm.Parent;

            //while (itmTemp != null)
            //{
            //    itmTemp.IsExpanded = true;
            //    itmTemp = itmTemp.Parent;
            //}

            //itm.IsSelected = true;
            //lsvOffers.SelectedItems.Clear();


        }

        public void FillMetaData(ArrayList MetaData)
        {

        }

        public ArrayList GetMetaData()
        {
            return null;
        }

        private void lsvOffers_MouseLeftButtonDown (object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left)
                return;

            //   IsSessionManager = !IsSessionManager;


            //rr.MouseDown
            //if (e.AddedItems.Count == 0)
            //    return;

            var itm = ((DataGridRow)sender).Item as SessionItemViewModel;
            if (itm == null)
                return;

            var itmTemp = itm.Parent;

            while (itmTemp != null)
            {
                itmTemp.IsExpanded = true;
                itmTemp = itmTemp.Parent;
            }

            itm.IsSelected = true;
            // lsvOffers.SelectedItems.Clear();
        }





        bool _IsSessionManager = false;
        public bool IsSessionManager
        {
            get
            {
                return _IsSessionManager;
            }
            set
            {
                _IsSessionManager = value;

                OnPropertyChanged("IsSessionManager");



            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members

        private void mnuItmEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!IsSessionManager)
                return;

            var off = ((SessionItemViewModel)lsvOffers.SelectedItem).Object as Offer;
            if (off != null)
            {
                var frm = new frmEditOfferInfo();
                frm.FillObject(off);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // dataGridView1.Refresh();
                }

                frm.Dispose();

            }

        }


        public string GetVotingMetaData()
        {
            throw new NotImplementedException();
        }


        public string GetBallotMetaData()
        {
            throw new NotImplementedException();
        }


        public void InitialVotingViewModel(IVotingViewModel votingViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
