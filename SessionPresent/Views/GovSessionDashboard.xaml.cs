using SessionPresent;
using SessionPresent.ViewModel;
using System;
using System.Diagnostics;
using System.Windows.Controls;

namespace SessionPresent.Views
{
    /// <summary>
    /// Interaction logic for TilesExample.xaml
    /// </summary>
    public partial class GovSessionDashboard : UserControl
    {
        public event EventHandler SelectedItem;
        private void OnSelectedItem(object obj)
        {
            if (SelectedItem != null)
                SelectedItem(obj, null);
        }
        public GovSessionDashboard()
        {
            InitializeComponent();
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

        private void Tile_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(((SessionItemViewModel)((MahApps.Metro.Controls.Tile)e.Source).DataContext).Title == " جستجوگر متین")
            {
                Process.Start(System.IO.Path.GetDirectoryName( Process.GetCurrentProcess().MainModule.FileName) + "\\TMUExecuter\\tmuexecuter.exe");
            }
            else
            ((MainViewModel)DataContext).CurrentViewItem = ((MahApps.Metro.Controls.Tile) e.Source).DataContext as SessionItemViewModel;
        }
    }
}
