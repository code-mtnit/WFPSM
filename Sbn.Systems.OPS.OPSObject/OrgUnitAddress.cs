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
namespace Sbn.Systems.OPS.OPSObject
{
[Description("آدرس سازمان")]
[DisplayName ("آدرس سازمان")]
[ObjectCode ("21020")]
[SystemName ("OPS")]
[ItemsType ("Sbn.Systems.OPS.OPSObject.OrgUnitAddresses")]
[Serializable]
public class OrgUnitAddress : SbnObject 
{
public OrgUnitAddress() 
: base() 
{ 
} 
public OrgUnitAddress(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private MFOrgUnit _CoOrgUnit;
/// <summary>
/// سازمان مرتبط
/// </summary>
[Description("سازمان مرتبط")]
[DisplayName("سازمان مرتبط")]
[Category("")]
[DocumentAttributeID("27426")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("MFOrgUnit")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public MFOrgUnit CoOrgUnit
{
get { return _CoOrgUnit; }
set { _CoOrgUnit = value; }
}
private Telephones _Telephones;
/// <summary>
/// تماسها
/// </summary>
[Description("تماسها")]
[DisplayName("تماسها")]
[Category("")]
[DocumentAttributeID("27427")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("Telephones")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public Telephones Telephones
{
get { return _Telephones; }
set { _Telephones = value; }
}
private Address _CoAddress;
/// <summary>
/// نشانی مرتبط
/// </summary>
[Description("نشانی مرتبط")]
[DisplayName("نشانی")]
[Category("")]
[DocumentAttributeID("27428")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("Address")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public Address CoAddress
{
get { return _CoAddress; }
set { _CoAddress = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._CoOrgUnit = new MFOrgUnit() ;
this._Telephones = new Telephones() ;
this._CoAddress = new Address() ;
}
public override SbnObject Clone(string sNodeName)
{
OrgUnitAddress retObject = new OrgUnitAddress(this);
if (! object.ReferenceEquals( this.CoOrgUnit , null))
retObject.CoOrgUnit = (MFOrgUnit)this.CoOrgUnit.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.Telephones , null))
retObject.Telephones = (Telephones)this.Telephones.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoAddress , null))
retObject.CoAddress = (Address)this.CoAddress.Clone(sNodeName) ;
return retObject;
}
public static string at_CoOrgUnitID
{
get
{
return "OrgUnitAddress.CoOrgUnitID";
}
}
public static string at_CoOrgUnitFirstLevelAttributes
{
get
{
return "OrgUnitAddress.CoOrgUnitFirstLevelAttributes";
}
}
public static string at_CoOrgUnit_ChildUnitsFirstLevelAttributes
{
get
{
return "OrgUnitAddress.CoOrgUnit.ChildUnitsFirstLevelAttributes";
}
}
public static string at_CoOrgUnit_ParentUnitFirstLevelAttributes
{
get
{
return "OrgUnitAddress.CoOrgUnit.ParentUnitFirstLevelAttributes";
}
}
public static string at_CoOrgUnit_PositionsFirstLevelAttributes
{
get
{
return "OrgUnitAddress.CoOrgUnit.PositionsFirstLevelAttributes";
}
}
public static string at_CoOrgUnit_AddressInfosFirstLevelAttributes
{
get
{
return "OrgUnitAddress.CoOrgUnit.AddressInfosFirstLevelAttributes";
}
}
public static string at_TelephonesID
{
get
{
return "OrgUnitAddress.TelephonesID";
}
}
public static string at_TelephonesFirstLevelAttributes
{
get
{
return "OrgUnitAddress.TelephonesFirstLevelAttributes";
}
}
public static string at_CoAddressID
{
get
{
return "OrgUnitAddress.CoAddressID";
}
}
public static string at_CoAddressFirstLevelAttributes
{
get
{
return "OrgUnitAddress.CoAddressFirstLevelAttributes";
}
}
public static string at_CoAddress_CoCityFirstLevelAttributes
{
get
{
return "OrgUnitAddress.CoAddress.CoCityFirstLevelAttributes";
}
}
public static string at_CoAddress_CoProvinceFirstLevelAttributes
{
get
{
return "OrgUnitAddress.CoAddress.CoProvinceFirstLevelAttributes";
}
}
}
}
