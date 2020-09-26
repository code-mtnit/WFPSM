using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using MSXML2;
using Sbn.Systems.WMC;

namespace Sbn.Products.GEP.GEPObject
{
    [Description("پیام جلسه دولت")]
    [DisplayName("پیام جلسه دولت")]
    [ObjectCode("13278")]
    [SystemName("GEP")]
    [ItemsType("Sbn.Products.GEP.GEPObject.GovSessionMessagings")]
    [Serializable]
    public class GovSessionMessaging : SbnObject
    {
        public GovSessionMessaging()
        : base()
        {
        }
        public GovSessionMessaging(SbnObject InitialObject)
        : base(InitialObject)
        {
        }
        private string _MessageText;
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [DisplayName("")]
        [Category("")]
        [DocumentAttributeID("27423")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string MessageText
        {
            get { return _MessageText; }
            set { _MessageText = value; }
        }
        private int _DurationTime;
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [DisplayName("")]
        [Category("")]
        [DocumentAttributeID("27424")]
        [IsRelationalAttribute("false")]
        [AttributeType("Int")]
        [Browsable(true)]
        public int DurationTime
        {
            get { return _DurationTime; }
            set { _DurationTime = value; }
        }
        private int _DelayTime;
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [DisplayName("")]
        [Category("")]
        [DocumentAttributeID("27425")]
        [IsRelationalAttribute("false")]
        [AttributeType("Int")]
        [Browsable(true)]
        public int DelayTime
        {
            get { return _DelayTime; }
            set { _DelayTime = value; }
        }
        private string _MessageTitle;
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [DisplayName("")]
        [Category("")]
        [DocumentAttributeID("27426")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string MessageTitle
        {
            get { return _MessageTitle; }
            set { _MessageTitle = value; }
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void Initialize()
        {
            base.Initialize();
            this._MessageText = "";
            this._DurationTime = 0;
            this._DelayTime = 0;
            this._MessageTitle = "";
        }
        public override SbnObject Clone(string sNodeName)
        {
            GovSessionMessaging retObject = new GovSessionMessaging(this);
            retObject.MessageText = this._MessageText;
            retObject.DurationTime = this._DurationTime;
            retObject.DelayTime = this._DelayTime;
            retObject.MessageTitle = this._MessageTitle;
            return retObject;
        }
        public static string at_MessageText
        {
            get
            {
                return "GovSessionMessaging.MessageText";
            }
        }
        public static string at_DurationTime
        {
            get
            {
                return "GovSessionMessaging.DurationTime";
            }
        }
        public static string at_DelayTime
        {
            get
            {
                return "GovSessionMessaging.DelayTime";
            }
        }
        public static string at_MessageTitle
        {
            get
            {
                return "GovSessionMessaging.MessageTitle";
            }
        }
    }

    [Serializable, DisplayName(""), Description(""), SystemName("GEP"), ItemsType("Sbn.Products.GEP.GEPObject.GovSessionMessaging")]
    public class GovSessionMessagings : SbnListObject<GovSessionMessaging>
    {
        public override object Clone(string sNodeName)
        {
            GovSessionMessagings categories = new GovSessionMessagings();
            foreach (GovSessionMessaging category in this)
            {
                categories.Add((GovSessionMessaging)category.Clone(sNodeName));
            }
            return categories;
        }
    }
}

