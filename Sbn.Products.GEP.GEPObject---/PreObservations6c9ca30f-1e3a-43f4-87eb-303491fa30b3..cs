namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, DisplayName(""), SystemName("GEP"), ItemsType("Sbn.Products.GEP.GEPObject.PreObservation"), Description("")]
    public class PreObservations : SbnListObject<PreObservation>
    {
        public override object Clone(string sNodeName)
        {
            PreObservations observations = new PreObservations();
            foreach (PreObservation observation in this)
            {
                observations.Add((PreObservation) observation.Clone(sNodeName));
            }
            return observations;
        }
    }
}
