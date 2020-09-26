using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using Sbn.Controls.Imaging;
using Sbn.Systems.WMC;
namespace Sbn.Products.GAP.GAPObject
{
    [Description("ضمیمه")]
    [DisplayName("ضمیمه")]
    [ObjectCode("30005")]
    [SystemName("GAP")]
    [ItemsType("Sbn.Products.GAP.GAPObject.PursuitAttachments")]
    [Serializable]
    public class PursuitAttachment : SbnBinary
    {
        public PursuitAttachment()
            : base()
        {
        }
        public PursuitAttachment(SbnBinary InitialObject)
            : base(InitialObject)
        {
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override SbnObject Clone(string sNodeName)
        {
            PursuitAttachment retObject = new PursuitAttachment(this);
            return retObject;
        }
    }
}
