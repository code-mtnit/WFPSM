using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SessionPresent.Model
{
    
     public class Ballot 
    {
         public long Id { get; set; }

         public SessionUser SessionUser { get; set; }

         public OpinionType OpinionType { get; set; }

         public string BollotMetaData { get; set; }

         [XmlElement(Type = typeof(Voting))]
         public Voting Voting { get; set; }



         public string RefrenceAssemblly { get; set; }

         public string BallotViewerClassName { get; set; }

    }


}
