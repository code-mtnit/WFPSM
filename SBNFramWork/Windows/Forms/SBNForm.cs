using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Sbn.FramWork.Windows.Forms.OtherForms.AeroNonClientButtons;
using Sbn.FramWork.Windows.Forms.ToolStripFolder.Renderer;

namespace Sbn.FramWork.Windows.Forms
{
    public partial class SBNForm : Form
    {

        public delegate void LoadCompletedEventHandler();
        /// <summary>
        /// این رویداد بعد از نمایش کامل پنجره و ظاهر شدن تمام کنترلها رخ می دهد
        /// </summary>
        public event LoadCompletedEventHandler LoadCompleted;

       // private Sbn.FramWork.Windows.Forms.OtherForms.SBNFormController controller;
        //private bool _isExtended = false;

        //public bool ISExtended
        //{
        //    get { return _isExtended; }
        //    set
        //    {
        //        _isExtended = value;

        //        if (value)
        //        {
        //            SetStyle(ControlStyles.ResizeRedraw, true);
        //            DoubleBuffered = true;

        //            controller = new Sbn.FramWork.Windows.Forms.OtherForms.SBNFormController(this);
                    
        //            controller.ExtendMargins(0, 70, 0, 0, true, true);

        //        }
        //        else
        //        {
        //            if (controller != null)
        //                controller.ReleaseHandle();

        //            //ExtendMargins(0, 0, 0, 0, true, false);
        //            ////SetStyle(ControlStyles.ResizeRedraw, true);
        //            //DoubleBuffered = false;
        //        }
        //        //Application.DoEvents();
        //        //Refresh();
        //        Invalidate();
        //    }
        //}

        public SBNForm()
        {
            InitializeComponent();
            Shown += new EventHandler(BaseForm_Shown);
        }

        void BaseForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            if (LoadCompleted != null)
                LoadCompleted();
        }
      
    }
}
