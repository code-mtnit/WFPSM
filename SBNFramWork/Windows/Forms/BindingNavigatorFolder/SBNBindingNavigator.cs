using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms
{
    public partial class SBNBindingNavigator : SBNToolStrip
    {
        public SBNBindingNavigator()
        {
            InitializeComponent();

            tsbtnMoveFirst.Click += new EventHandler(tsbtnMoveFirst_Click);
            tsbtnMoveLastItem.Click += new EventHandler(tsbtnMoveLastItem_Click);
            tsbtnMoveNextItem.Click += new EventHandler(tsbtnMoveNextItem_Click);
            tsbtnMovePrevious.Click += new EventHandler(tsbtnMovePrevious_Click);
        }

        void tsbtnMovePrevious_Click(object sender, EventArgs e)
        {
            if (BindingSource != null) BindingSource.MovePrevious();
        }

        void tsbtnMoveNextItem_Click(object sender, EventArgs e)
        {
            if (BindingSource != null) BindingSource.MoveNext();
        }

        void tsbtnMoveLastItem_Click(object sender, EventArgs e)
        {
            if (BindingSource != null) BindingSource.MoveLast();
        }


        private BindingSource _bindingSource;

        /// <summary>
        /// Gets or sets the <see cref="T:System.Windows.Forms.BindingSource"/> component that is the source of data.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="T:System.Windows.Forms.BindingSource"/> component associated with this <see cref="T:System.Windows.Forms.BindingNavigator"/>. The default is null.
        /// 
        /// </returns>
        [TypeConverter(typeof(ReferenceConverter))]
        [DefaultValue(null)]
        public BindingSource BindingSource
        {
            get { return _bindingSource; }
            set
            {
                _bindingSource = value;
                if (_bindingSource != null)
                {
                    tsbtnMoveFirst.Enabled = true;
                    tsbtnMoveLastItem.Enabled = true;
                    tsbtnMoveNextItem.Enabled = true;
                    tsbtnMovePrevious.Enabled = true;
                    tslblCountItem.Text = "از" + "{" + value.Count + "}";
                    _bindingSource.CurrentChanged += BindingSourceCurrentChanged;
                }
                else
                {
                    tsbtnMoveFirst.Enabled = false;
                    tsbtnMoveLastItem.Enabled = false;
                    tsbtnMoveNextItem.Enabled = false;
                    tsbtnMovePrevious.Enabled = false;
                }
            }
        }

        void BindingSourceCurrentChanged(object sender, EventArgs e)
        {
            var current = BindingSource.Current;
            if (current != null)
            {
                tstxtPosition.Text = BindingSource.IndexOf(current).ToString(CultureInfo.InvariantCulture);
                tslblCountItem.Text = "از" + "{" + BindingSource.Count + "}";
            }

            else
            {
                tstxtPosition.Text = "0";
            }
        }

        private void tsbtnMoveFirst_Click(object sender, EventArgs e)
        {
            if (BindingSource != null) BindingSource.MoveFirst();
        }
    }
}
