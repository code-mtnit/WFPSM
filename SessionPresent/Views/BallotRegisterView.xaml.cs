using System;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using SessionPresent.Tools.SbnTools;

namespace SessionPresent.Views
{
    /// <summary>
    /// Interaction logic for GovSessionMemberOpinionView.xaml
    /// </summary>
    public partial class BallotRegisterView : Window
    {
        public BallotRegisterView()
        {
            InitializeComponent();

            Closed += GovSessionMemberOpinionView_Closed;
            Messenger.Default.Register<ViewModel.BallotViewModel>(this, "Close", Close);
        }

        void GovSessionMemberOpinionView_Closed(object sender, EventArgs e)
        {
            Messenger.Default.Unregister<ViewModel.BallotViewModel>(this, "Close", Close);
        }

        private void Close(ViewModel.BallotViewModel obj)
        {
            
        }
    }
}
