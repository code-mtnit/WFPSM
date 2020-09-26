namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("اصوات کمیسیون"), DisplayName("اصوات کمیسیون"), ItemsType("Sbn.Products.GEP.GEPObject.CommissionSessionVoice")]
    public class CommissionSessionVoices : SbnListObject<CommissionSessionVoice>
    {
        public override object Clone(string sNodeName)
        {
            CommissionSessionVoices Voices = new CommissionSessionVoices();
            foreach (CommissionSessionVoice Voice in this)
            {
                Voices.Add((CommissionSessionVoice)Voice.Clone(sNodeName));
            }
            return Voices;
        }
    }
}
