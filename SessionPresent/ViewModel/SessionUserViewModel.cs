using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SessionPresent.Model;
using SessionPresent.Tools;

namespace SessionPresent.ViewModel
{
    public class SessionUserViewModel : ISessionUser
    {
        public SessionUser CurrentModel { get; set; }
        public SessionUserViewModel()
        {
            
        }

        public SessionUserViewModel(SessionUser user)
        {
            CurrentModel = user;
        }

        public int Id
        {
            get
            {
                if (CurrentModel != null)
                    return CurrentModel.Id;

                return 0;
            }
            set
            {
                if (CurrentModel != null)
                    CurrentModel.Id = value;
            }
        }

        public string Title
        {
            get
            {
                if (CurrentModel != null)
                    return CurrentModel.Title;

                return "";
            }
            set
            {
                if (CurrentModel != null)
                    CurrentModel.Title = value;
            }
        }

        public string Description
        {
            get
            {
                if (CurrentModel != null)
                    return CurrentModel.Description;

                return "";
            }
            set
            {
                if (CurrentModel != null)
                    CurrentModel.Description = value;
            }
        }

        public string AliasCode
        {
            get
            {
                if (CurrentModel != null)
                    return CurrentModel.AliasCode;

                return "";
            }
            set
            {
                if (CurrentModel != null)
                    CurrentModel.AliasCode = value;
            }
        }
    }
}
