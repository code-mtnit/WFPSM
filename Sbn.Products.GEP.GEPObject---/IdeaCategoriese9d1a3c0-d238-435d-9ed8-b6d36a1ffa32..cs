namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, DisplayName(""), Description(""), SystemName("GEP"), ItemsType("Sbn.Products.GEP.GEPObject.IdeaCategory")]
    public class IdeaCategories : SbnListObject<IdeaCategory>
    {
        public override object Clone(string sNodeName)
        {
            IdeaCategories categories = new IdeaCategories();
            foreach (IdeaCategory category in this)
            {
                categories.Add((IdeaCategory) category.Clone(sNodeName));
            }
            return categories;
        }
    }
}
