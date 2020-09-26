using System;
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

namespace SessionPresent.Views
{
    /// <summary>
    /// Interaction logic for DesktopView.xaml
    /// </summary>
    public partial class DesktopView : UserControl
    {
        public event EventHandler SelectedItem;
        private void OnSelectedItem(object obj)
        {
            if (SelectedItem != null)
                SelectedItem(obj , null);
        }

        public DesktopView()
        {
            InitializeComponent();
        }

        private void WrapPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void GovSessionOrderView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void lsvSessions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                OnSelectedItem(e.AddedItems[0]);
                var itm = e.AddedItems[0] as SessionItemViewModel;
               // itm.IsSelected = true;
                ((MainViewModel)DataContext).CurrentViewItem = itm;
                //if (itm.ObjectViewer != null)
                //    this.Visibility = System.Windows.Visibility.Hidden;
            }

           // lsvSessions.SelectedItems.Clear();
            lsvExternalTools.SelectedItems.Clear();
        }
    }
}
