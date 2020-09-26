using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;
using System.Globalization;

namespace BaseClass
{
    [Serializable()]
    public class ObjectMetaData
    {
        public bool Checked = false;
        public string Text = string.Empty;
        public string Tag = string.Empty;

        public ObjectMetaData()
        { }

        public ObjectMetaData(string i_Text, string i_Tag)
        {
            Text = i_Text;
            Tag = i_Tag;
        }

        public ObjectMetaData(bool i_Checked, string i_Text, string i_Tag)
            : this(i_Text, i_Tag)
        {
            Checked = i_Checked;
        }
    }

    public class CategoryNameComparer : IComparer
    {
        // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        int IComparer.Compare(Object x, Object y)
        {           
            return (((PerformanceCounterCategory)x).CategoryName.CompareTo(((PerformanceCounterCategory)y).CategoryName));
        }

    }

    public class myCultureComparer : IEqualityComparer
    {
        public CaseInsensitiveComparer myComparer;

        public myCultureComparer()
        {
            myComparer = CaseInsensitiveComparer.DefaultInvariant;
        }

        public myCultureComparer(CultureInfo myCulture)
        {
            myComparer = new CaseInsensitiveComparer(myCulture);
        }

        public new bool Equals(object x, object y)
        {
            if (myComparer.Compare(x, y) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(object obj)
        {
            return obj.ToString().ToLower().GetHashCode();
        }
    }

}
