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
using Sbn.Controls.AdvancedControls.AddressBar;
using System.Windows.Markup;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.Windows.Controls.Primitives;

namespace FileBrowser.cs
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Browser : Window
    {
        public Browser()
        {
            InitializeComponent();
            bar.PathChanged += new RoutedPropertyChangedEventHandler<string>(bar_PathChanged);

            try
            {
                BitmapImage bImg = new BitmapImage();
                bImg.BeginInit();
                //bImg.StreamSource = new System.IO.MemoryStream(wrAccTemp.CoUI.IconStream);
                bImg.UriSource = new Uri("refresh.Png", UriKind.Relative);
                bImg.DecodePixelHeight = 32;
                bImg.DecodePixelWidth = 32;
                bImg.EndInit();
                imgRefresh.Source = bImg ;
                // tsmnuItm.Icon = new System.Windows.Controls.Image { Source = bImg };

                //  tsmnuItm.Icon = new System.Windows.Controls.Image { Source = new BitmapImage  };// Sbn.Systems.WMC.Tools.Utility.GetImage(wrAccTemp.CoUI.IconStream) };
            }
            catch
            {
                // tsmnuItm.Icon = global:: GadgetPresent.Properties.Resources.Xp_MadB_24x24;
            }
        }

        void bar_PathChanged(object sender, RoutedPropertyChangedEventArgs<string> e)
        {
           // bar.SelectedItem
        }

        /// <summary>
        /// A BreadcrumbItem needs to populate it's Items. This can be due to the fact that a new BreadcrumbItem is selected, and thus
        /// it's Items must be populated to determine whether this BreadcrumbItem show a dropdown button,
        /// or when the Path property of the BreadcrumbBar is changed and therefore the Breadcrumbs must be populated from the new path.
        /// </summary>
        private void BreadcrumbBar_PopulateItems(object sender, Sbn.Controls.AdvancedControls.AddressBar.BreadcrumbItemEventArgs e)
        {
            BreadcrumbItem item = e.Item;
            if (item.Items.Count == 0)
            {
                PopulateFolders(item);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Populate the Items of the specified BreadcrumbItem with the sub folders if necassary.
        /// </summary>
        /// <param name="item"></param>
        private static void PopulateFolders(BreadcrumbItem item)
        {
            BreadcrumbBar bar = item.BreadcrumbBar;
            string path = bar.PathFromBreadcrumbItem(item);
            string trace = item.TraceValue;
            if (trace.Equals("Computer"))
            {
                string[] dirs = System.IO.Directory.GetLogicalDrives();
                foreach (string s in dirs)
                {
                    string dir = s;
                    if (s.EndsWith(bar.SeparatorString)) dir = s.Remove(s.Length - bar.SeparatorString.Length, bar.SeparatorString.Length);
                    FolderItem fi = new FolderItem();
                    fi.Folder = dir;

                    item.Items.Add(fi);
                }
            }
            else
            {
                try
                {
                    string[] paths = System.IO.Directory.GetDirectories(path + "\\");
                    foreach (string s in paths)
                    {
                        string file = System.IO.Path.GetFileName(s);
                        FolderItem fi = new FolderItem();
                        fi.Folder = file;
                        item.Items.Add(fi);
                      
                        
                    }
                }
                catch { }
            }
        }

        private void BreadcrumbBar_PathConversion(object sender, PathConversionEventArgs e)
        {
            
            if (e.Mode == PathConversionEventArgs.ConversionMode.DisplayToEdit)
            {
                if (e.DisplayPath.StartsWith(@"Computer\", StringComparison.OrdinalIgnoreCase))
                {
                    e.EditPath = e.DisplayPath.Remove(0, 9);
                }
                else if (e.DisplayPath.StartsWith(@"Network\", StringComparison.OrdinalIgnoreCase))
                {
                    string editPath = e.DisplayPath.Remove(0, 8);
                    editPath = @"\\" + editPath.Replace('\\', '/');
                    e.EditPath = editPath;
                }
            }
            else
            {
                if (e.EditPath.StartsWith("c:", StringComparison.OrdinalIgnoreCase))
                {
                    e.DisplayPath = @"Desktop\Computer\" + e.EditPath;
                }
                else if (e.EditPath.StartsWith(@"\\"))
                {
                    e.DisplayPath = @"Desktop\Network\" + e.EditPath.Remove(0, 2).Replace('/', '\\');
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //try
            //{
            //    var btn1 = new Button();
                
               
            //    BitmapImage bImg = new BitmapImage();
            //    bImg.BeginInit();
            //    //bImg.StreamSource = new System.IO.MemoryStream(wrAccTemp.CoUI.IconStream);
            //    bImg.UriSource = new Uri("Web.Png", UriKind.Relative);
            //    bImg.DecodePixelHeight = 42;
            //    bImg.DecodePixelWidth = 42;
            //    bImg.EndInit();
               
            //    //imgRefresh = new System.Windows.Controls.Image { Source = bImg };
            //    imgRefresh.Source = bImg;
            //    // tsmnuItm.Icon = new System.Windows.Controls.Image { Source = bImg };

            //    btn1.Content = imgRefresh;
            //    bar.Buttons.Add(btn1);
            //    //  tsmnuItm.Icon = new System.Windows.Controls.Image { Source = new BitmapImage  };// Sbn.Systems.WMC.Tools.Utility.GetImage(wrAccTemp.CoUI.IconStream) };
            //}
            //catch
            //{
            //    // tsmnuItm.Icon = global:: GadgetPresent.Properties.Resources.Xp_MadB_24x24;
            //}


            DoubleAnimation da = new DoubleAnimation(100, new Duration(new TimeSpan(0, 0, 2)));
            da.FillBehavior = FillBehavior.Stop;
            bar.BeginAnimation(BreadcrumbBar.ProgressValueProperty, da);
        }

        /// <summary>
        /// The dropdown menu of a BreadcrumbItem was pressed, so delete the current folders, and repopulate the folders
        /// to ensure actual data.
        /// </summary>
        private void bar_BreadcrumbItemDropDownOpened(object sender, BreadcrumbItemEventArgs e)
        {
            //BreadcrumbItem item = e.Item;

            //// only repopulate, if the BreadcrumbItem is dynamically generated which means, item.Data is a  pointer to itself:
            //if (!(item.Data is BreadcrumbItem))
            //{
            //    item.Items.Clear();
            //    PopulateFolders(item);
            //}
        }

    }
}
