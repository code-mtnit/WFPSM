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

namespace SessionPresent.Tools.SbnTools
{
    /// <summary>
    /// Interaction logic for PresentationView.xaml
    /// </summary>
    public partial class PresentationView : UserControl,ISessionItemViewer
    {
        public PresentationView()
        {
            InitializeComponent();
        }

        public void FillObject(object obj, object mvm)
        {
            if (this.DataContext == obj)
                return;


            this.DataContext = obj;
            var sItm = (obj as SessionItemViewModel);
            if (sItm != null)
            {
                
                if(sItm.Object is GovPresentation)
                {
                    var off = new Presentation();
                    off._PhysicalPath = ((GovPresentation)sItm.Object)._PhysicalPath;
                    off.Attachments = ((GovPresentation)sItm.Object).Attachments;
                    off.Title = ((GovPresentation)sItm.Object).Title;
                    this.ucViewPresentationPic1.FillObject(off, false);
                }
                else
                {
                    var off = sItm.Object as Presentation;
                    this.ucViewPresentationPic1.FillObject(off, false);

                }
            }
        }


        public void FillMetaData(ArrayList MetaData)
        {
            if (MetaData == null)
                return;
            int pagenumber = -1;
           

            foreach (BaseClass.ObjectMetaData omd in MetaData)
            {
                switch (omd.Tag)
                {
                    case "PageNumber":
                        if (int.TryParse(omd.Text, out pagenumber))
                        {

                        }
                        break;
                  
                    default:
                        break;
                }
            }

            if (pagenumber >= 0)
            {
                this.ucViewPresentationPic1.BindingSource.Position = pagenumber;
            }
        }

        public ArrayList GetMetaData()
        {
            var metas = new ArrayList();
            var PageNumber = new BaseClass.ObjectMetaData();
            PageNumber.Tag = "PageNumber";
            PageNumber.Text = this.ucViewPresentationPic1.BindingSource.Position.ToString();
            metas.Add(PageNumber);
            return metas;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ucViewPresentationPic1.ImageViewer.FitToWidth();
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
