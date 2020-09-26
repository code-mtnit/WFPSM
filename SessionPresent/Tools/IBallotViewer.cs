using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionPresent.Tools
{
    public interface IBallotViewer
    {
        bool Save();


        void ShowBallot(string ballotMetaData);
    }
}
