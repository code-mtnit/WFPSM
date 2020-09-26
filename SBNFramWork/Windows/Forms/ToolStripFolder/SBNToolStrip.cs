using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace Sbn.FramWork.Windows.Forms
{
    /// <summary>
    /// The Filmstrip control.
    /// </summary>
    [ToolboxItem(true),
    Description("A ToolStrip control for Windows forms."),
    ToolboxBitmap(typeof(ToolStrip), "SBNToolStrip"),
    DefaultEvent("OnSelectionChanged")]    
    public class SBNToolStrip : ToolStrip
    {
        
    }
}
