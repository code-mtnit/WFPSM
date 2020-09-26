using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Sbn.AdvancedControls.Imaging.ImageViewer
{
    public class PageImageList : List<Image>
    {
    }
    /// <summary>
    /// Specifies the zoom mode for the <see cref="CoolPrintPreviewControl"/> control.
    /// </summary>
    public enum ZoomMode
    {
        /// <summary>
        /// Show the preview in actual size.
        /// </summary>
        ActualSize,
        /// <summary>
        /// Show a full page.
        /// </summary>
        FullPage,
        /// <summary>
        /// Show a full page width.
        /// </summary>
        PageWidth,
        /// <summary>
        /// Show two full pages.
        /// </summary>
        TwoPages,
        /// <summary>
        /// Use the zoom factor specified by the <see cref="CoolPrintPreviewControl.Zoom"/> property.
        /// </summary>
        Custom
    }
    /// <summary>
    /// enumerations that specifies how the mouse behaves over the control
    /// </summary>
    public enum PreviewMode
    {
        REGIONSELECTION,    //enables the user to select a region to zoom
        ZOOMIN,             //enables the user to zoom in to a point
        ZOOMOUT,            //anables the user to zoom out to a point
        PAN,                //anables the user to grab and pan the image
        NONE
    }
}
