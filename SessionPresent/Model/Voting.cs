using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SessionPresent.Model
{
    public class Voting
    {

        public int Id { get; set; }

        public string VotingSubject { get; set; }

        public string VotingSubjectMetaData { get; set; }

        public DateTime VotingDate { get; set; }
        public TimeSpan VotingTime { get; set; }

        public virtual Session Session { get; set; }

        public int ExternalObjectId { get; set; }

        public string ExternalObjectAliasCode { get; set; }

        public string ExternalObjectTitle { get; set; }

        // [XmlElement(Type = typeof(String))]
        //public ICollection<Ballot> Ballots { get; set; }

    }
}
