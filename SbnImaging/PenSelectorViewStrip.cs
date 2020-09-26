using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;


namespace Sbn.Controls.Imaging
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class PenSelectorViewStrip : System.Windows.Forms.ToolStripControlHost
    {

        public PenSelectorViewStrip()
            : base(CreateControlInstance())
        { }


        private static Control CreateControlInstance()
        {
            ucPenWidth uc = new ucPenWidth();

            return uc;
        }


        public ucPenWidth PenSelector
        {
            get
            {
                return Control as ucPenWidth;
            }
        }

        public override System.Drawing.Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                //base.BackColor = value;
            }
        }
    }
}
