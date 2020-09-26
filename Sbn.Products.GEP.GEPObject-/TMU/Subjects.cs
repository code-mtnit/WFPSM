using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using MSXML2;
namespace Sbn.Products.GEP.GEPObject.TMU
{
    [Description("")]
    [DisplayName("")]
    [ItemsType("Sbn.Products.GEP.GEPObject.TMU.Subject")]
    [SystemName("GEP")]
    [Serializable]
    public class Subjects : SbnListObject<Subject>
    {
        #region Constructors
        public Subjects()
            : base()
        {
        }
        #endregion Constructors
        public override object Clone(string sNodeName)
        {
            Subjects Col = new Subjects();
            foreach (Subject objMember in this)
            {
                Col.Add((Subject)objMember.Clone(sNodeName));
            }
            return Col;
        }
    }

}
