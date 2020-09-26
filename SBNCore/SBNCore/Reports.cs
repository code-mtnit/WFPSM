using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sbn.Core
{
    [Serializable]
    public class Reports : SbnListObject<Report>
    {
        public Reports()
            : base()
        {

        }


        public override object Clone(string sNodeName)
        {
            throw new NotImplementedException();
        }
    }
}
