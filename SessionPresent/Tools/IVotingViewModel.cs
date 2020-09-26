using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionPresent.Tools
{
    public interface IVotingViewModel
    {

        string VotingSubject { get; set; }

        string VotingSubjectMetaData { get; set; }

        int ExternalObjectId { get; set; }

        string ExternalObjectAliasCode { get; set; }

        string ExternalObjectTitle { get; set; }
    }
}
