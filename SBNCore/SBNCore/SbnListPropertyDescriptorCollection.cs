using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Sbn.Core
{
    public class SbnListPropertyDescriptorCollection : PropertyDescriptor
    {
        [NonSerialized]
        private SbnObject _Obj = null;
        private ISbnObject collection = null;
        private int index = -1;

        public SbnListPropertyDescriptorCollection(ISbnObject coll ,  object obj , int idx) :
            base("#" + idx.ToString(), null)
        {
            this.collection = coll;
            this.index = idx;
            this._Obj = (SbnObject )obj;
        }

        public override AttributeCollection Attributes
        {
            get
            {
                return new AttributeCollection(null);
            }
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override Type ComponentType
        {
            get
            {
                return this.collection.GetType();
            }
        }

        public override string DisplayName
        {
            get
            {
               // SbnObject  obj = ((List<SbnObject>)this.collection)[index];
                return _Obj .ToString();
            }
        }

        public override string Description
        {
            get
            {
                //SbnObject obj = ((List<SbnObject>)this.collection)[index];
                return _Obj.ToString();

               // return sb.ToString();
            }
        }

        public override object GetValue(object component)
        {
            return _Obj;// ((List<SbnObject>)this.collection)[index]; 
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override string Name
        {
            get { return "#" + index.ToString(); }
        }

        public override Type PropertyType
        {
            get { return _Obj.GetType(); }
        }

        public override void ResetValue(object component)
        {
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }

        public override void SetValue(object component, object value)
        {
            // this.collection[index] = value;
        }
    }
}
