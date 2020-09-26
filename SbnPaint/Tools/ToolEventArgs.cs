using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sbn.FramWork.Drawing;

namespace Sbn.AdvancedControls.Imaging.SbnPaint.Tools
{
    public class ToolEventArgs : EventArgs
    {
        private Tool _tool;

        public Tool Tool
        {
            get { return _tool; }
            set { _tool = value; }
        }

        public ToolEventArgs(Tool tool)
        {
            _tool = tool;
        }
    }
}
