using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sbn.Core;

namespace Sbn.Systems.WMC.WMCObject
{
    [Serializable]
    public class AOActivities : SbnListObject<AOActivity>
    {
        public AOActivities()
            : base()
        {
        }

        public override object Clone(string sNodeName)
        {
            throw new NotImplementedException();
        }
    }
}
