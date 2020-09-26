using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace Sbn.Libs.AssemblyTools
{


    public class Methods
    {

        public static List<PropertyInfo> GetBrowsableAttributes(Type type)
        {
            try
            {

                List<PropertyInfo> pInfos = new List<PropertyInfo>();

//                Type type = obj.GetType();

                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(type);

                foreach (PropertyInfo pInfo in type.GetProperties())
                {

                    System.ComponentModel.PropertyDescriptor myProperty = properties.Find(pInfo.Name, false);
                    if(!object.ReferenceEquals(null , myProperty) && myProperty.IsBrowsable)
                        pInfos.Add(pInfo);
                }

                return pInfos;
            }
            catch
            {
                throw;
            }
        }

        private static string GetAttributesValue(Object Info, Type attType)
        {
            try
            {
                Object[] myAttributes = null;
                if(Info is MemberInfo)

                    myAttributes = ((MemberInfo)Info).GetCustomAttributes(attType, true);
                else
                    myAttributes =  ((PropertyInfo) Info).GetCustomAttributes(attType, true);

                if (myAttributes.Length > 0)
                {

                    switch (attType.Name)
                    {
                        case "DescriptionAttribute":
                            {
                                return ((System.ComponentModel.DescriptionAttribute)myAttributes[0]).Description;
                            }
                            break;
                        case "CategoryAttribute":
                            {
                                return ((System.ComponentModel.CategoryAttribute)myAttributes[0]).Category;
                            }
                            break;
                        case "Browsable":
                            {
                                return ((System.ComponentModel.BrowsableAttribute)myAttributes[0]).Browsable.ToString();
                            }
                            break;
                        case "DocumentAttributeID":
                            {
                                return ((DocumentAttributeID)myAttributes[0]).Description;
                            }
                            break;
                        case "DisplayNameAttribute":
                            {
                                return ((DisplayNameAttribute)myAttributes[0]).DisplayName;
                            }
                            break;
                        case "IsMiddleTableExist":
                            {
                                return ((IsMiddleTableExist)myAttributes[0]).Description;
                            }
                            break;
                        case "RelationTable":
                            {
                                return ((RelationTable)myAttributes[0]).Description;
                            }
                            break;
                        case "IsRelationalAttribute":
                            {
                                return ((IsRelationalAttribute)myAttributes[0]).Description;
                            }
                            break;
                        case "AttributeType":
                            {
                                return ((AttributeType)myAttributes[0]).Description;
                            }
                            break;
                            
                    }

                }
                else
                {
                    return null;
                }


            }
            catch
            {
                throw;
            }
            return null;

        }

        public static string GetAttributesValue(MemberInfo propInfo, Type attType)
        {
            try
            {
                return GetAttributesValue((Object)propInfo, attType);

            }
            catch
            {
                throw;
            }
            return null;

        }

        public static string GetAttributesValue(PropertyInfo propInfo, Type attType)
        {
            try
            {
                return GetAttributesValue((Object)propInfo, attType);


            }
            catch 
            {
                throw;
            }
            return null;

        }

        public static string GetObjectAttributeValue(Type type , Type attType)
        {
            try
            {
                // Get Class Name
                // Gets the attributes for the property.
                AttributeCollection attributes = TypeDescriptor.GetAttributes(type);

                //   TypeDescriptor.GetProperties(type)[type.Name].Attributes;

                DescriptionAttribute myAttribute = null;

                switch (attType.Name )
                {
                    case "Category":
                        {
                            myAttribute = (DescriptionAttribute)attributes[typeof(CategoryAttribute)];
                        }
                        break;
                    case "DisplayName":
                        {
                            myAttribute = (DescriptionAttribute)attributes[typeof(DisplayNameAttribute)];
                        }
                        break;
                    case "Description":
                        {
                            myAttribute = (DescriptionAttribute)attributes[typeof(DescriptionAttribute)];
                        }
                        break;
                    case "ObjectCode":
                        {
                            return ((ObjectCode)attributes[typeof(ObjectCode)]).Description;
                        }
                        break;
                    case "SystemName":
                        {
                            return ((SystemName)attributes[typeof(SystemName)]).Description;
                        }
                        break;
                    case "ItemsType":
                        {
                            return ((ItemsType)attributes[typeof(ItemsType)]).Description;
                        }
                        break;
 
                }
                   
                return myAttribute.Description;
            }
            catch
            {
                throw;
            }
        }
    }
}
