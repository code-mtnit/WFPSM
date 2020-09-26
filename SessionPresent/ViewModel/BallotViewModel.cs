using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SessionPresent.Model;

namespace SessionPresent.ViewModel
{
    public class BallotViewModel : ViewModelBase
    {

        public Ballot CurrentModel { get; set; }
        public BallotViewModel()
        {
            SaveCommand = new RelayCommand(Save, CanSave);
        }


        private bool CanSave()
        {
            return true;
        }

        private void Save()
        {

            //Save Ballot in DB


            Messenger.Default.Send("Close",this);
        }


        OpinionType _opinionType = OpinionType.NoneIdea;
        public OpinionType OpinionType
        {
            get { return _opinionType; }
            set
            {
                _opinionType = value;
                if (CurrentModel != null)
                    CurrentModel.OpinionType = value;

                RaisePropertyChanged("OpinionType");

            }
        }


        public RelayCommand SaveCommand { get; set; }


    }
}
