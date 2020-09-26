using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

namespace SessionPresent.Tools.FolderLaws
{
    /// <summary>
    /// Interaction logic for LawsSearchView.xaml
    /// </summary>
    public partial class LawsSearchView : UserControl ,ISessionItemViewer
    {

        public SessionItemViewModel CurrentViewItem;
        public LawsSearchView()
        {
            InitializeComponent();
        }

        public void FillObject(object obj, object mvm)
        {

            DataContext = obj;
            
        }

        void ShowItem(SessionItemViewModel sItm)
        {
            CurrentViewItem = sItm;

            if (CurrentViewItem.Object is SessionItemViewModel)
            {

            }
            else
            {

                var file = new FileInfo(CurrentViewItem.Object.ToString());

                if (file.Extension == ".rtf")
                {
                    DocViewer.WebBrowser1.Visibility = System.Windows.Visibility.Hidden;
                    DocViewer.rch.Visibility = System.Windows.Visibility.Visible;
                    
                    TextRange textrange;
                    FileStream FileStream1;

                    textrange = new TextRange(DocViewer.rch.Document.ContentStart, DocViewer.rch.Document.ContentEnd);

                    using (FileStream1 = new FileStream(CurrentViewItem.Object.ToString(), FileMode.OpenOrCreate))
                    {
                        textrange.Load(FileStream1, System.Windows.DataFormats.Rtf);
                    }
                }
                else if (file.Extension == ".htm" || file.Extension == ".html")
                {
                    DocViewer.rch.Visibility = System.Windows.Visibility.Hidden;
                    DocViewer.WebBrowser1.Visibility = System.Windows.Visibility.Visible;
                    
                    System.Uri uri = new System.Uri(file.FullName);
                    DocViewer.WebBrowser1.Navigate(uri);
                }
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e.AddedItems.Count == 0)
                    return;


                var itm = e.AddedItems[0] as SessionItemViewModel;
              
                //ShowItem(sItm);
                if (itm == null)
                    return;

                var itmTemp = itm.Parent;

                while (itmTemp != null)
                {
                    itmTemp.IsExpanded = true;
                    itmTemp = itmTemp.Parent;
                }

                itm.IsSelected = true;
                
            }
            catch
            {

            }


        
            
        }


        public void FillMetaData(ArrayList MetaData)
        {
            //if (MetaData == null)
            //    return;

            //int pagenumber = -1;
            //bool IsVoewWordDoc = false;

            //foreach (BaseClass.ObjectMetaData omd in MetaData)
            //{
            //    switch (omd.Tag)
            //    {
            //        case "DocItemPath":
            //            foreach(SessionItem itm in lsvDocs.ItemsSource)
            //            {
            //                if (itm.Object != null && itm.Object.ToString() ==omd.Text )
            //                {
            //                    lsvDocs.SelectedItems.Add(itm);
            //                    break;
            //                }
            //            }
                       
            //            break;
            //        case "DocItemPosition":
            //            double _VerticalOffset = 0;
            //            if (double.TryParse(omd.Text, System.Globalization.NumberStyles.AllowDecimalPoint , CultureInfo.CreateSpecificCulture("es-ES"), out _VerticalOffset))
            //            {

            //            }
            //            DocViewer.rch.ScrollToVerticalOffset(_VerticalOffset);
                      
            //            break;
            //        case "DocItemPositionWebBrowser":
                    
            //            var doc = DocViewer.WebBrowser1.Document as mshtml.HTMLDocument;


            //            var p = Point.Parse(omd.Text);
            //            if (doc != null && p != null)
            //                doc.parentWindow.scrollTo((int)p.X, (int)p.Y);
            //            break;
            //        default:
            //            break;
            //    }
           // }
        }

        public ArrayList GetMetaData()
        {

            return null;


            var metas = new ArrayList();

            if (CurrentViewItem != null && CurrentViewItem.Object != null)
            {
                var DocItem = new BaseClass.ObjectMetaData();
                DocItem.Tag = "DocItemPath";
                DocItem.Text = CurrentViewItem.Object.ToString();

                metas.Add(DocItem);


                if (DocViewer.WebBrowser1.Visibility == System.Windows.Visibility.Visible)
                {
                    try
                    {
                        var doc = DocViewer.WebBrowser1.Document as mshtml.HTMLDocument;
                        if (doc != null)
                        {

                            var DocItemPosition = new BaseClass.ObjectMetaData();
                            DocItemPosition.Tag = "DocItemPositionWebBrowser";
                            DocItemPosition.Text = new Point(doc.parentWindow.document.body.getAttribute("ScrollLeft"), doc.parentWindow.document.body.getAttribute("ScrollTop")).ToString();

                            metas.Add(DocItemPosition);
                        }
                    }
                    catch
                    {

                    }




                }

                if (DocViewer.rch.Visibility == System.Windows.Visibility.Visible)
                {
                    var DocItemPosition = new BaseClass.ObjectMetaData();
                    DocItemPosition.Tag = "DocItemPosition";
                    DocItemPosition.Text = DocViewer.rch.VerticalOffset.ToString(CultureInfo.CreateSpecificCulture("es-ES"));

                    metas.Add(DocItemPosition);
                }



             
            }

            return metas;
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
