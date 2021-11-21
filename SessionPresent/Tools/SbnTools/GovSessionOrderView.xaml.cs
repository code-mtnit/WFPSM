using Sbn.Products.GEP.GEPObject;
using System;
using System.Collections;
using System.Collections.Generic;
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
using System.ComponentModel;

namespace SessionPresent.Tools.SbnTools
{
    /// <summary>
    /// Interaction logic for GovSessionOrderView.xaml
    /// </summary>
    public partial class GovSessionOrderView : UserControl, ISessionItemViewer, INotifyPropertyChanged
    {
        private SessionItemViewModel _SessionItemViewModel = null;
        public SessionItemViewModel CurrentSessionItem { get; set; }
        public SessionItemViewModel CurrentCatalogueSessionItem {
            get
            {
                return _SessionItemViewModel;
            }
            set
            { _SessionItemViewModel = value; }
        }
        public GovSession CurrenGovSession { get; set; }

        public GovSessionOrderView()
        {
            InitializeComponent();
        }

        bool _IsSessionManager = false;

        public event PropertyChangedEventHandler PropertyChanged;

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

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        private void lsvSessionOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (e.AddedItems.Count == 0)
                return;

            var sItm = e.AddedItems[0] as SessionItemViewModel;
            if (sItm != null && !(sItm.Object is PreSessionOrder))
                sItm.IsSelected = true;

            var itmTemp = sItm.Parent;

            while (itmTemp != null)
            {
                itmTemp.IsExpanded = true;
                itmTemp = itmTemp.Parent;
            }

            lsvSessionOrder.SelectedItems.Clear();
        }

        MainViewModel _mvm = null;
        public void FillObject(object obj, object mvm)
        {

            _mvm = (MainViewModel)mvm;

            SessionItemViewModel sItm = obj as SessionItemViewModel;
            if (sItm == null)
                return;

            if (!(sItm.Object is GovSession))
                return;

            if (CurrentSessionItem == sItm)
                return;

            CurrentSessionItem = sItm;
            CurrenGovSession = sItm.Object as GovSession;
            if (CurrenGovSession.Title != null)
            {
                CurrenGovSession.Title = CurrenGovSession.Title.Replace("#", " ").Replace("\n", " ");
            }
            this.DataContext = CurrenGovSession;
            /*
            int i = 1;
            foreach (var s in CurrentSessionItem.Children)
            {
                if (((SessionItemViewModel)s).Object is PreSessionOrder)
                    continue;

                ((SessionItemViewModel)s).Order = i;
                i++;
            }
            */

            lsvSessionOrder.ItemsSource = CurrentSessionItem.Children;
            treeview.Items.Clear();
            treeview.ItemsSource = CurrentSessionItem.Children;


        }

        public void FillMetaData(ArrayList MetaData)
        {

        }

        public ArrayList GetMetaData()
        {
            return null;
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

        private void treeView1SeletedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is SessionItemViewModel)
            {
                if (((SessionItemViewModel)e.NewValue).Parent != null)
                    ((SessionItemViewModel)e.NewValue).Parent.IsExpanded = true;
            }

            /*
            if(this.treeview.SelectedItem != null &&((SessionItemViewModel) this.treeview.SelectedItem).Title .Contains("فهرست"))
            {

                var treeItem = ((TreeView)sender).ItemContainerGenerator.ContainerFromItem(e.NewValue) as TreeViewItem;
                treeItem.IsExpanded = false;
                
                foreach(object itm in treeItem.Items)
                {
                    var itmTree = ((TreeViewItem)treeItem).ItemContainerGenerator.ContainerFromItem(itm) as TreeViewItem;
                    if (itmTree != null)
                    {
                        itmTree.Height = 0;

                        itmTree.Visibility = Visibility.Hidden;
                    }
                }

                //treeItem.Items.Clear();
                e.Handled = true;
            }
            */


            //if (vm != null)
            {
                //    vm.CurrentViewItem = e.NewValue as SessionItemViewModel;
                //vm.CurrentViewItem = e.NewValue as SessionItemViewModel;
                /*
                if (e.NewValue != null && ((SessionItemViewModel)e.NewValue).ObjectViewer != null &&((SessionItemViewModel) e.NewValue).ObjectViewer.GetType().Name == "CatalugeView")
                {
                    var treeItem = ((TreeView)sender).ItemContainerGenerator.ContainerFromItem(e.NewValue) as TreeViewItem;

                    treeItem.IsExpanded = false;
                }*/
            }

        }

        private void treeview_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            /*
            foreach (var s in CurrentSessionItem.Children)
            {
                if (s.Title.Contains("فهرست"))
                {

                    var treeItem = this.treeview.ItemContainerGenerator.ContainerFromItem(s) as TreeViewItem;

                    foreach (object itm in treeItem.Items)
                    {
                        var itmTree = ((TreeViewItem)treeItem).ItemContainerGenerator.ContainerFromItem(itm) as TreeViewItem;
                        if (itmTree != null)
                        {
                            itmTree.Height = 0;

                            itmTree.Visibility = Visibility.Hidden;
                        }
                    }
                    
                }
            }*/
        }

        private void treeview_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {

        }

        private void treeview_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void treeview_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void treeview_IsHitTestVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void treeview_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            foreach (var s in CurrentSessionItem.Children)
            {
                if (s.Title.Contains("فهرست"))
                {

                    var treeItem = this.treeview.ItemContainerGenerator.ContainerFromItem(s) as TreeViewItem;
                   // treeItem.IsExpanded = false;
                   // treeItem.IsExpanded = true;
                    
                    foreach (object itm in treeItem.Items)
                    {
                        ((SessionItemViewModel)itm).IsExpanded = true;
                        var itmTree = ((TreeViewItem)treeItem).ItemContainerGenerator.ContainerFromItem(itm) as TreeViewItem;
                        if (itmTree != null)
                        {
                            itmTree.Height = 0;

                            itmTree.Visibility = Visibility.Hidden;
                        }
                    }

                }
            }
            */
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!IsSessionManager)
                return;

            var frm = new frmSessionOrderItemInfo();
            frm.FillObject(ref _SessionItemViewModel);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {


                int i = 1;
                List<SessionItemViewModel> sortItems = CurrentSessionItem.Children.Select(x => x as SessionItemViewModel).ToList();
                sortItems =  sortItems.OrderBy(x => x.Order).ToList();

                treeview.ItemsSource = sortItems;
                // dataGridView1.Refresh();
            }

            frm.Dispose();


        }

        private void treeview_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem = VisualUpwardSearch(e.OriginalSource as DependencyObject);

            if (treeViewItem != null)
            {
                //treeViewItem.Focus();
                e.Handled =false;

                CurrentCatalogueSessionItem = (SessionItemViewModel)treeViewItem.DataContext;

            }
        }

        static TreeViewItem VisualUpwardSearch(DependencyObject source)
        {
            while (source != null && !(source is TreeViewItem))
                source = VisualTreeHelper.GetParent(source);

            return source as TreeViewItem;
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!IsSessionManager)
                return;

            var frm = new frmSessionTitle();
            frm.FillObject(CurrenGovSession, _mvm);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //_mvm.MainTitle = CurrenGovSession.Title;
                // dataGridView1.Refresh();
            }

            frm.Dispose();


        
    }
    }
}
