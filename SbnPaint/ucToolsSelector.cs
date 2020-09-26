using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ColorPicker;
using Sbn.FramWork.Drawing;
using Microsoft.Ink;

namespace Sbn.AdvancedControls.Imaging.SbnPaint
{
   


    public partial class ucToolsSelector : UserControl
    {

        /// <summary>
        /// added by ghmhm for drawing free lines with tabletpc pen
        /// </summary>
       
        Pen blackPen = null;
        private const float MediumInkWidth = 100;
        private DrawingPanel _currentDrawingPanel;

        public DrawingPanel CurrentDrawingPanel
        {
            get { return _currentDrawingPanel; }
            set
            {
                _currentDrawingPanel = value;
                if (value != null)
                {
                    _currentDrawingPanel.ActiveToolChaged += new EventHandler<Tools.ToolEventArgs>(_currentDrawingPanel_ActiveToolChaged);
                    _currentDrawingPanel.CurrentPenChange += new EventHandler(_currentDrawingPanel_CurrentPenChange);
                    foreach (var dropDownItem in toolStrip1.Items)
                    {
                        if (dropDownItem is ToolStripButton)
                        {
                            (dropDownItem as ToolStripButton).Enabled = true;
                        }
                    }
                  
                    
                }
                else
                {
                    foreach (var dropDownItem in toolStrip1.Items)
                    {
                        if (dropDownItem is ToolStripButton)
                        {
                            (dropDownItem as ToolStripButton).Enabled = false;
                        }
                    }
                 
                }
            }
        }

        void _currentDrawingPanel_CurrentPenChange(object sender, EventArgs e)
        {
            ucButtomSelectPenWidth1.PenWidth = CurrentDrawingPanel.CurrentPen.Width;
            pnlForColor.BackColor = CurrentDrawingPanel.CurrentPen.Color;

        }

        void _currentDrawingPanel_ActiveToolChaged(object sender, Tools.ToolEventArgs e)
        {
            if (e.Tool == null)
                return;


            if (e.Tool is Pointer)
            {
                tsbtnPointer.Checked = true;
            }
            else if (e.Tool is DrawShape)
            {
                if (e.Tool.Ghost.ReferenceShape is Text)
                    tsbtnText.Checked = true;
                else if (e.Tool.Ghost.ReferenceShape is RectangleBody)
                    tsbtnRectangle.Checked = true;
                else if (e.Tool.Ghost.ReferenceShape is Ellipse)
                    tsbtnEllipse.Checked = true;
            }
            else if (e.Tool is DrawCurveLine)
            {
                tsbtnCurveLine.Checked = true;
            }
            else if (e.Tool is DrawFreeLine)
            {
                tsbtnPencil.Checked = true;
            }
            else if (e.Tool is pActiveCurve)
            {
                tsbtnPactiveCurve.Checked = true;
            }
            else if (e.Tool is Draft)
            {
                tsbtnEraser.Checked = true;
            }
        }

        //void _currentDrawingPanel_ActiveToolChaged(object sender, EventArgs e)
        //{
        //    if (CurrentDrawingPanel.ActiveTool is Pointer)
        //    {
        //        tsbtnPointer.Checked = true;
        //    }else if (CurrentDrawingPanel.ActiveTool is DrawShape)
        //    {
        //        if (CurrentDrawingPanel.ActiveTool.Ghost.ReferenceShape is Text)
        //            tsbtnText.Checked = true;
        //        else if (CurrentDrawingPanel.ActiveTool.Ghost.ReferenceShape is RectangleBody)
        //            tsbtnRectangle.Checked = true;
        //        else if (CurrentDrawingPanel.ActiveTool is Ellipse)
        //            tsbtnEllipse.Checked = true;
        //    }
            
        //}

        public ucToolsSelector()
        {
            InitializeComponent();
            
        }

        public DrawCurveLine DrawCurve = new Sbn.AdvancedControls.Imaging.SbnPaint.DrawCurveLine();
        private Ellipse DrawEllipse;
        public DrawFreeLine DrawLine = new Sbn.AdvancedControls.Imaging.SbnPaint.DrawFreeLine();
       
       
        
        public Tool ActiveTool
        {
            get
            {
                if (CurrentDrawingPanel != null)
                  return   CurrentDrawingPanel.ActiveTool;

                return null;
            }
            set
            {

                if (CurrentDrawingPanel != null)
                {
                    CurrentDrawingPanel.ActiveTool = value;
                }

            }

        }

        private void tsbtnPointer_CheckedChanged(object sender, EventArgs e)
        {
            var tsItm = sender as ToolStripButton;

            if (tsItm != null && tsItm.Checked)
            {
                pictureBox1.Image = tsItm.Image;
                foreach (var dropDownItem in toolStrip1.Items)
                {
                    if (dropDownItem is ToolStripButton)
                    {
                        if (tsItm != (ToolStripButton)dropDownItem)
                        {
                            ((ToolStripButton)dropDownItem).Checked = false;
                        }
                    }
                }
            }
        }


        Pointer pointer ;
        private void tsbtnPointer_Click(object sender, EventArgs e)
        {
            if (pointer == null)
                pointer = new Pointer();

            ActiveTool = pointer;
        }

        Text DrawText ;
        private void tsbtnText_Click(object sender, EventArgs e)
        {
            if (DrawText == null)
                DrawText = new Text();

            ActiveTool = new DrawShape(this.DrawText); 
        }

       RectangleBody RectanglePen;
        private void tsbtnRectangle_Click(object sender, EventArgs e)
        {
            if (RectanglePen == null)
                RectanglePen = new RectangleBody();

            ActiveTool = new DrawShape(this.RectanglePen); 
        }

        private void tsbtnEllipse_Click(object sender, EventArgs e)
        {
            if (DrawEllipse == null)
                DrawEllipse = new Ellipse();

            ActiveTool = new DrawShape(DrawEllipse); 
        }

        private void tsbtnPencil_Click(object sender, EventArgs e)
        {
            DrawLine = new DrawFreeLine();
            ActiveTool = DrawLine;
        }

        private void tsbtnPactiveCurve_Click(object sender, EventArgs e)
        {

            Color clr = Color.Blue;
            float PenWidth = 10;
            if (CurrentDrawingPanel != null && CurrentDrawingPanel.CurrentPen != null)
            {
                clr = CurrentDrawingPanel.CurrentPen.Color;
                PenWidth = CurrentDrawingPanel.CurrentPen.Width;
            }

            this.ActiveTool = new pActiveCurve(PenWidth, clr);

          
        }

        public Sbn.AdvancedControls.Imaging.SbnPaint.Draft DraftPen;
        private void tsbtnEraser_Click(object sender, EventArgs e)
        {
            if (DraftPen == null)
                DraftPen = new Draft();
            ActiveTool = DraftPen;
        }


        public Sbn.AdvancedControls.Imaging.SbnPaint.Hand HandTool;
        private void tsbtnHand_Click(object sender, EventArgs e)
        {
            if (HandTool == null)
                HandTool = new Hand();
            ActiveTool = HandTool;
        }

        private void pnlBackColor_BackColorChanged(object sender, EventArgs e)
        {
            if (CurrentDrawingPanel != null)
                CurrentDrawingPanel.ImageBackColor = pnlBackColor.BackColor;
        }

        private void pnlForColor_BackColorChanged(object sender, EventArgs e)
        {
            if (CurrentDrawingPanel != null)
            {
                if (CurrentDrawingPanel.CurrentPen == null)
                {
                    CurrentDrawingPanel.CurrentPen = new Pen(Color.Black, 100);
                }
                CurrentDrawingPanel.CurrentPen = new Pen(pnlForColor.BackColor, CurrentDrawingPanel.CurrentPen.Width); ;
            }
        }

        private void tsbtnCurveLine_Click(object sender, EventArgs e)
        {
            DrawCurve = new DrawCurveLine();
            ActiveTool = DrawCurve;
        }

        private void pnlForColor_Click(object sender, EventArgs e)
        {
            ColorPickerDialog dlg = new ColorPickerDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                pnlForColor.BackColor = dlg.ColorPicker.SelectedColor;
            }
        }

        private void pnlBackColor_Click(object sender, EventArgs e)
        {
            ColorPickerDialog dlg = new ColorPickerDialog();
           if (dlg.ShowDialog(this) == DialogResult.OK)
           {
               pnlBackColor.BackColor = dlg.ColorPicker.SelectedColor;
           }
        }

        private void ucButtomSelectPenWidth1_SelectWidthChange(object sender, EventArgs e)
        {
            if (CurrentDrawingPanel != null)
            {
                //if (CurrentDrawingPanel.CurrentPen == null)
                //{
                //    CurrentDrawingPanel.CurrentPen = new Pen(Color.Black, 100);
                //}
                CurrentDrawingPanel.CurrentPen.Width = ucButtomSelectPenWidth1.PenWidth;// new Pen(CurrentDrawingPanel.CurrentPen.Color, ucButtomSelectPenWidth1.PenWidth); ;
               
            }
        }
    }
}
