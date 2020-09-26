using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using Sbn.Core;
using MSXML2;
using Sbn.Systems.WMC;
using Sbn.Controls.Imaging.ImagingObject;
namespace Sbn.Systems.OPS.OPSObject
{
[Description("تصوير فرد")]
[DisplayName ("تصوير فرد")]
[ObjectCode ("21008")]
[SystemName ("OPS")]
[ItemsType ("Sbn.Systems.OPS.OPSObject.PersonPictures")]
[Serializable]
public class PersonPicture : ImageDocument 
{
public PersonPicture() 
: base() 
{ 
} 
public PersonPicture(ImageDocument InitialObject) 
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
PersonPicture retObject = new PersonPicture(this);
return retObject;
}
}
}
