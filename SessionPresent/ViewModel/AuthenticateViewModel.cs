using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SessionPresent.Model;

namespace SessionPresent.ViewModel
{
    public class AuthenticateViewModel : ViewModelBase
    {

        public event EventHandler Authenticated;

        protected virtual void OnAuthenticated()
        {
            EventHandler handler = Authenticated;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public SessionUser CurrentModel { get; set; }

        public AuthenticateViewModel()
        {
            AuthenticateCommand = new RelayCommand(Authenticate);
        }

        private void Authenticate()
        {

            // Get User From DB


            CurrentModel = new SessionUser();
            CurrentModel.Id = 1;
            CurrentModel.Title = "رسول مددی";

            if (CurrentModel.Id > 0)
                OnAuthenticated();
        }



        private string _password = "";

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }


        public RelayCommand AuthenticateCommand { get; set; }

    }
}
