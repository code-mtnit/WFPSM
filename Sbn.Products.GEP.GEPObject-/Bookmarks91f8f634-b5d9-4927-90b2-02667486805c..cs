namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, DisplayName(""), Description(""), SystemName("GEP"), ItemsType("Sbn.Products.GEP.GEPObject.Bookmark")]
    public class Bookmarks : SbnListObject<Bookmark>
    {
        public override object Clone(string sNodeName)
        {
            Bookmarks bookmarks = new Bookmarks();
            foreach (Bookmark bookmark in this)
            {
                bookmarks.Add((Bookmark) bookmark.Clone(sNodeName));
            }
            return bookmarks;
        }
    }
}
