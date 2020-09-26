using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SessionPresent.ViewModel;

namespace SessionPresent.Tools
{
    public interface ISessionItemViewer
    {

         void FillObject(object obj , object mvm );

         void FillMetaData(ArrayList MetaData);
         ArrayList GetMetaData();

        //string GetVotingMetaData();

        //string GetBallotMetaData();


        void InitialVotingViewModel(IVotingViewModel votingViewModel);

    }
}
