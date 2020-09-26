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
    /// Interaction logic for LawView.xaml
    /// </summary>
    public partial class LawView : UserControl, ISessionItemViewer
    {
        public SessionItemViewModel CurrentViewItem;
        public LawView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
            
        }

        private void clickHyperLink(object sender, MouseEventArgs e)
        {
           
            
        }

      



        public void FillObject(object obj, object mvm)
        {

            DataContext = obj;
            CurrentViewItem = obj as SessionItemViewModel;
            
            if (CurrentViewItem.Object is SessionItemViewModel)
            {

            }
            else
            {

                var file = new FileInfo(CurrentViewItem.Object.ToString());
                //fDocReader.
                if (file.Extension == ".rtf")
                {
                    WebBrowser1.Visibility = System.Windows.Visibility.Hidden;
                    rch.Visibility = System.Windows.Visibility.Visible;

                    TextRange textrange;
                    FileStream FileStream1;

                    textrange = new TextRange(rch.Document.ContentStart, rch.Document.ContentEnd);

                    using (FileStream1 = new FileStream(CurrentViewItem.Object.ToString(), FileMode.OpenOrCreate))
                    {
                        textrange.Load(FileStream1, System.Windows.DataFormats.Rtf);
                    }
                }
                else if (file.Extension == ".htm" || file.Extension == ".html")
                {
                    rch.Visibility = System.Windows.Visibility.Hidden;
                    WebBrowser1.Visibility = System.Windows.Visibility.Visible;

                    System.Uri uri = new System.Uri(file.FullName);
                    WebBrowser1.Navigate(uri);
                }
                else if (file.Extension == ".mht" )
                {
                    rch.Visibility = System.Windows.Visibility.Hidden;
                    WebBrowser1.Visibility = System.Windows.Visibility.Visible;

                    System.Uri uri = new System.Uri(file.FullName);
                    WebBrowser1.Navigate(uri);
                }
            }
        }

        public void FillMetaData(ArrayList MetaData)
        {
            if (MetaData == null)
                return;

            int pagenumber = -1;
            bool IsVoewWordDoc = false;

            foreach (BaseClass.ObjectMetaData omd in MetaData)
            {
                switch (omd.Tag)
                {
                    //case "DocItemPath":
                    //    foreach (SessionItem itm in lsvDocs.ItemsSource)
                    //    {
                    //        if (itm.Object != null && itm.Object.ToString() == omd.Text)
                    //        {
                    //            lsvDocs.SelectedItems.Add(itm);
                    //            break;
                    //        }
                    //    }

                       // break;
                    case "DocItemPosition":
                        double _VerticalOffset = 0;
                        if (double.TryParse(omd.Text, System.Globalization.NumberStyles.AllowDecimalPoint, CultureInfo.CreateSpecificCulture("es-ES"), out _VerticalOffset))
                        {

                        }
                        rch.ScrollToVerticalOffset(_VerticalOffset);

                        break;
                    case "DocItemPositionWebBrowser":

                        var doc = WebBrowser1.Document as mshtml.HTMLDocument;


                        var p = Point.Parse(omd.Text);
                        if (doc != null && p != null)
                            doc.parentWindow.scrollTo((int)p.X, (int)p.Y);
                        break;
                    default:
                        break;
                }
            }
        }

        public ArrayList GetMetaData()
        {


            var metas = new ArrayList();

            if (CurrentViewItem != null && CurrentViewItem.Object != null)
            {
                //var DocItem = new BaseClass.ObjectMetaData();
                //DocItem.Tag = "DocItemPath";
                //DocItem.Text = CurrentViewItem.Object.ToString();

                //metas.Add(DocItem);


                if (WebBrowser1.Visibility == System.Windows.Visibility.Visible)
                {
                    try
                    {
                        var doc = WebBrowser1.Document as mshtml.HTMLDocument;
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

                if (rch.Visibility == System.Windows.Visibility.Visible)
                {
                    var DocItemPosition = new BaseClass.ObjectMetaData();
                    DocItemPosition.Tag = "DocItemPosition";
                    DocItemPosition.Text = rch.VerticalOffset.ToString(CultureInfo.CreateSpecificCulture("es-ES"));

                    metas.Add(DocItemPosition);
                }




            }

            return metas;
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            CurrentViewItem.Parent.IsSelected = true;
        }

        private void mnuItmBack_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                WebBrowser1.GoBack();
            }
            catch
            {

            }
        }

        private void mnuItmForward_Click(object sender, RoutedEventArgs e)
        {
          

            try
            {
                WebBrowser1.GoForward();
            }
            catch
            {

            }
        }

        private void mnuItmUp_Click(object sender, RoutedEventArgs e)
        {

            var doc = WebBrowser1.Document as mshtml.HTMLDocument;


          
            if (doc != null)
                doc.parentWindow.scrollTo(0, 0);
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
