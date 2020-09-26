using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Sbn.Products.GEP.GEPObject;
using SessionPresent.Model;

namespace SessionPresent.Tools.SbnTools
{
    public class GovSessionMemberOpinionViewModel : ViewModelBase
    {

        public GovSessionMemberOpinion CurrentModel { get; set; }
        public GovSessionMemberOpinionViewModel()
        {
            SaveCommand = new RelayCommand(Save,CanSave);
        }

        private bool CanSave()
        {
            return true;
        }

        private void Save()
        {

            Messenger.Default.Send("Close",CurrentModel);
        }


        OpinionType _opinionType = OpinionType.NoneIdea;
        public OpinionType OpinionType
        {
            get { return _opinionType; }
            set
            {
                _opinionType = value;
                RaisePropertyChanged("OpinionType");
            }
        }


        public RelayCommand SaveCommand { get; set; }



    }

    
}
