namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description("پرونده هاي شخصي"), DisplayName("پرونده هاي شخصي"), ItemsType("Sbn.Products.GEP.GEPObject.PersonalFolder"), SystemName("GEP")]
    public class PersonalFolders : SbnListObject<PersonalFolder>
    {
        public override object Clone(string sNodeName)
        {
            PersonalFolders folders = new PersonalFolders();
            foreach (PersonalFolder folder in this)
            {
                folders.Add((PersonalFolder) folder.Clone(sNodeName));
            }
            return folders;
        }
    }
}
