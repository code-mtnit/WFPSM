using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using BaseClass;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SessionPresent.Model;
using SessionPresent.Tools;

namespace SessionPresent.ViewModel
{
    public class VotingViewModel : ViewModelBase, IVotingViewModel
    {

        public Voting CurrentModel { get; set; }

        public VotingViewModel()
        {
            StartVotingCommand = new RelayCommand(StartVoting,CanStartVoting);
            CurrentModel = new Voting();
        }

        public SessionItemViewModel SessionItem { get; set; }

        public VotingViewModel(SessionItemViewModel sessionitem)
        {
            StartVotingCommand = new RelayCommand(StartVoting, CanStartVoting);
            CurrentModel = new Voting();
            
            SessionItem = sessionitem;

            SessionItem.ObjectViewer.InitialVotingViewModel(this);
        }

        private bool CanStartVoting()
        {
            if (CurrentModel == null)
                return false;

            return true;
        }

        private void StartVoting()
        {
            var govSessionMemOpinion = new Sbn.Products.GEP.GEPObject.GovSessionMemberOpinion();
            govSessionMemOpinion.CorrelateOffer = new Sbn.Products.GEP.GEPObject.Offer();
            govSessionMemOpinion.CorrelateOffer.ID = 1;
            govSessionMemOpinion.CorrelateOffer.AliasCode = "54471";
            govSessionMemOpinion.CorrelateOffer.Title = "پیشنهاد تستی";

            var xmlString = govSessionMemOpinion.GetXML("GovSessionMemberOpinion");




            if (SCUtility.m_AppDef == null || SCUtility.m_AppDef.ArrClients == null)
                return;





            CurrentModel.Session = new Session();
           
            //Register Voting

           // CurrentModel.VotingSubject = govSessionMemOpinion.CorrelateOffer.Title;
           // CurrentModel.VotingSubjectMetaData = SessionItem.ObjectViewer.GetVotingMetaData();// govSessionMemOpinion.CorrelateOffer.GetXML("Offer");
            CurrentModel.VotingDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            CurrentModel.VotingTime = DateTime.Now.TimeOfDay;
            var ballot = new Model.Ballot();
            ballot.Voting = CurrentModel;
           // ballot.BollotMetaData = SessionItem.ObjectViewer.GetBallotMetaData();// xmlString;
            ballot.OpinionType = OpinionType.NoneIdea;
            ballot.RefrenceAssemblly = SessionItem.RefrenceAssemblly;
            ballot.BallotViewerClassName = SessionItem.BallotViewerClassName;




            var StatusQueryData = new QueryData();
            StatusQueryData.Type = Consts.SectionType.DoAction;
            var obj = new ObjectMetaData();

            obj.Tag = "Voting";



            var XmlDoc = new XmlDocument();
            var type = typeof(Ballot);

            var XmlSerializer = new XmlSerializer(type);
            using (var ms = new MemoryStream())
            {
                XmlSerializer.Serialize(ms, ballot);
                ms.Position = 0;
                XmlDoc.Load(ms);
                obj.Text = XmlDoc.InnerXml;


            }



            StatusQueryData.ArrCounter.Add(obj);

            foreach (BaseClass.ClientInfo row in SCUtility.m_AppDef.ArrClients)
            {


                // this.Text = "Waiting for reply...";

                ClientInfo CliInfoS = new ClientInfo(row.IP, row.Name);
                Thread ClientStatusQuery = new Thread(delegate()
                {
                    ReplyData ReplyDataObj;

                    try
                    {
                        string QueryString = StatusQueryData.Serialize();
                        String ReplyString = MonitorInfoViewer.Comm.SendQuery(CliInfoS.IP, SCUtility.m_AppDef.m_Port, QueryString);
                        ReplyDataObj = ReplyData.Deserialize(ReplyString);
                    }
                    catch (Exception)
                    {
                        ReplyDataObj = null;
                    }
                });
                //  Thread ClientStatusQuery = new Thread(UpdateStatusDelegate() {});
                ClientStatusQuery.Start();

            }

        }


        public RelayCommand StartVotingCommand { get; set; }


        public string VotingSubject
        {
            get { return CurrentModel.VotingSubject; }
            set
            {
                CurrentModel.VotingSubject = value;
                
            }
        }

        public int ExternalObjectId
        {
            get { return CurrentModel.ExternalObjectId; }
            set
            {
                CurrentModel.ExternalObjectId = value;

            }
        }

        public string ExternalObjectAliasCode
        {
            get { return CurrentModel.ExternalObjectAliasCode; }
            set
            {
                CurrentModel.ExternalObjectAliasCode = value;

            }
        }

        public string ExternalObjectTitle
        {
            get { return CurrentModel.ExternalObjectTitle; }
            set
            {
                CurrentModel.ExternalObjectTitle = value;

            }
        }


        public string VotingSubjectMetaData
        {
            get { return CurrentModel.VotingSubjectMetaData; }
            set
            {
                CurrentModel.VotingSubjectMetaData = value;

            }
        }
    }
}
