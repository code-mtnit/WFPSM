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
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using Sbn.Products.GEP.GEPObject;

namespace SessionPresent.Tools.SbnTools
{
    /// <summary>
    /// Interaction logic for GovSessionMemberOpinionView.xaml
    /// </summary>
    public partial class GovSessionMemberOpinionView : Window, IBallotViewer
    {

        public GovSessionMemberOpinionViewModel CurrentViewModel
        {
            get { return DataContext as GovSessionMemberOpinionViewModel; }
            set { DataContext = value; }
        }

        public GovSessionMemberOpinionView()
        {
            InitializeComponent();

            Closed += GovSessionMemberOpinionView_Closed;
            Messenger.Default.Register<GovSessionMemberOpinionViewModel>(this,"Close",Close);
        }

        void GovSessionMemberOpinionView_Closed(object sender, EventArgs e)
        {
            Messenger.Default.Unregister<GovSessionMemberOpinionViewModel>(this,"Close",Close);
        }

        private void Close(GovSessionMemberOpinionViewModel obj)
        {
            
        }

        public bool Save()
        {
            return false;
        }

        public void ShowBallot(string ballotMetaData)
        {
            var memOpin = new GovSessionMemberOpinionViewModel();
            var opinion = new Sbn.Products.GEP.GEPObject.GovSessionMemberOpinion();
            opinion.InitializeFromXML(ballotMetaData, "GovSessionMemberOpinion", null);
            memOpin.CurrentModel = opinion;
            memOpin.CurrentModel.CorrelateSessionMember = SbnTools.SbnObjectTools.CurrentGovSessionMember;
            CurrentViewModel = memOpin;

            ShowDialog();


        }
    }
}
