using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Ink;
using Sbn.Controls.Imaging.ImagingObject;
using Sbn.FramWork.Windows.Forms.AdvancedControls.Popup;

namespace Sbn.Controls.Imaging
{
    public partial class Annotation : UserControl
    {

        public event EventHandler OnSaveImage; 
        public event EventHandler ApplayShape;
        public event EventHandler CancelShape;
        public Annotation()
        {
            
            
            InitializeComponent();
            drawingPanel1.AutoScroll = true;
        }


        private void drawingPanel1_Resize(object sender, EventArgs e)
        {
           
        }

     

       
        public byte[] StreamImage
        {
            get
            {

                System.Drawing.Image img = ImageAnnotation;
                if (img != null)
                {
                    System.IO.MemoryStream ms = new MemoryStream();
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    
                    byte[] strem = new byte[ms.Length];
                    
                    strem = ms.GetBuffer();
                    return strem;
                }
                else
                    return null;
            }

            //set
            //{
            //    _stream = value;
            //}
        }


        public Image ImageAnnotation
        {
            get
            {
                
                var imgNew = this.drawingPanel1.GetFlattedImage(drawingPanel1.Shapes);
                if (imgNew != null)
                    ((Bitmap)imgNew).MakeTransparent(Color.White);
                
                return imgNew;
            }
            set
            {
                drawingPanel1.ApplaypActiveCurve();
                drawingPanel1.Shapes.Clear();
                if (value != null)
                {
                    var shape = new Sbn.AdvancedControls.Imaging.SbnPaint.Image((Bitmap) value,
                                                                                new Rectangle(0, 0,
                                                                                              (int)
                                                                                              value.PhysicalDimension.
                                                                                                  Width,
                                                                                              (int)
                                                                                              value.PhysicalDimension.
                                                                                                  Height));
                    drawingPanel1.Shapes.Add(shape);
                }
                drawingPanel1.Refresh();
                
            }
        }

        

    

        public Sbn.AdvancedControls.Imaging.SbnPaint.DrawCurveLine DrawCurve = new Sbn.AdvancedControls.Imaging.SbnPaint.DrawCurveLine();
        public Sbn.AdvancedControls.Imaging.SbnPaint.DrawFreeLine DrawLine = new Sbn.AdvancedControls.Imaging.SbnPaint.DrawFreeLine();
        public Sbn.AdvancedControls.Imaging.SbnPaint.Draft DraftPen = new Sbn.AdvancedControls.Imaging.SbnPaint.Draft();
        public Sbn.AdvancedControls.Imaging.SbnPaint.RectangleBody RectanglePen = new Sbn.AdvancedControls.Imaging.SbnPaint.RectangleBody();
        private ActiveTools _ActiveTool = ActiveTools.Pointer;
        public ActiveTools ActiveTool
        {
            get
            {
                return _ActiveTool;
            }
            set
            {
                _ActiveTool = value;
                deSelectAll(null);
                
               drawingPanel1.ApplaypActiveCurve();
                switch (value)
                {
                    case ActiveTools.Curve:
                        {
                            DrawCurve = new Sbn.AdvancedControls.Imaging.SbnPaint.DrawCurveLine();
                            this.drawingPanel1.ActiveTool = DrawCurve;
                            break;
                        }

                    case ActiveTools.pActiveCurve:
                        {
                            try
                            {
                                drawingPanel1.CurrentPen.Width = penSelectorViewStrip1.PenSelector.SelectedPenWidth;
                                var curve = new Sbn.AdvancedControls.Imaging.SbnPaint.pActiveCurve();
                                drawingPanel1.ActiveTool = curve;
                                
                                tsbtnPen.Checked = true;
                              
                            }
                            catch
                            {

                            }

                            break;
                        }


                    case ActiveTools.Pen:
                        {
                            Sbn.FramWork.Drawing.CompositeShape group = new Sbn.FramWork.Drawing.CompositeShape();
                            DrawLine = new Sbn.AdvancedControls.Imaging.SbnPaint.DrawFreeLine();

                            // DrawLine.Offset = 5;
                            this.drawingPanel1.ActiveTool = DrawLine;
                            Type tt = this.GetType();

                            break;
                        }
                    case ActiveTools.Draft:
                        {
                            if (this.DraftPen == null)
                                this.DraftPen = new Sbn.AdvancedControls.Imaging.SbnPaint.Draft();

                            this.DraftPen.CurrentPen.Width = penSelectorViewStrip1.PenSelector.SelectedPenWidth;
                            this.DraftPen.CurrentPen.Color = drawingPanel1.BackColor;
                            this.drawingPanel1.ActiveTool = DraftPen;
                            break;
                        }

                    case ActiveTools.Pointer:
                        {
                            this.drawingPanel1.ActiveTool = new Sbn.AdvancedControls.Imaging.SbnPaint.Pointer();
                            Cursor = System.Windows.Forms.Cursors.Default;
                            tsPointer.Checked = true;
                            break;
                        }

                    case ActiveTools.Hand:
                        {
                            //bool Temp = tsbtnHand.Checked;
                            //deselectAll();
                            //tsbtnHand.Checked = Temp;
                            //if (this.tsbtnEditImage.Checked)
                            //{
                            //    this.AllowMoveByMouse = this.tsbtnHand.Checked;
                            //}
                            //else
                            //{
                            //    this.AllowMoveByMouse = true;
                            //}
                            Cursor = System.Windows.Forms.Cursors.Hand;
                            break;
                        }


                    case ActiveTools.Rect:
                        {
                            if (RectanglePen == null)
                                RectanglePen = new Sbn.AdvancedControls.Imaging.SbnPaint.RectangleBody();

                            RectanglePen.Appearance.BorderWidth = penSelectorViewStrip1.PenSelector.SelectedPenWidth;
                            this.drawingPanel1.ActiveTool = new Sbn.AdvancedControls.Imaging.SbnPaint.DrawShape(RectanglePen);
                            //   Cursor = new Cursor(this.GetType() ,"Rectangle.cur");
                            break;
                        }
                }
            }
        }


        private void tsbtnPen_CheckedChanged(object sender, EventArgs e)
        {
            //if (tsbtnPen.Checked)
            //{
            //    tsbtnEraser.Checked = false;
            //    tsPointer.Checked = false;
            //  //  this.ActiveTool = ActiveTools.pActiveCurve;
            //}
        }

        private void tsPointer_Click(object sender, EventArgs e)
        {
            ActiveTool = ActiveTools.Pointer;
        }

        private void deSelectAll(ToolStripButton ts)
        {

            tsbtnEraser.Checked = false;
            tsbtnPen.Checked = false;
            tsPointer.Checked = false;

           

            //foreach (ToolStripItem tsbtn in this.toolStrip1.Items)
            //{
            //    if (tsbtn is ToolStripButton)
            //    {
            //        if (tsbtn != ts)
            //        {
            //            ((ToolStripButton)tsbtn).Checked = false;

            //        }
            //    }
            //}
        }

        private void tsPointer_CheckedChanged(object sender, EventArgs e)
        {
            //if (this.tsPointer.Checked)
            //{
            //    tsbtnPen.Checked = false;
            //    tsbtnEraser.Checked = false;
            //    this.ActiveTool = ActiveTools.Pointer;
            //}
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            var aTools = ActiveTool;
            drawingPanel1.Delete();
            ActiveTool = aTools;
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            drawingPanel1.ApplaypActiveCurve();
            //byte[] bb = this.StreamImage;
            //System.IO.StreamWriter sw = new StreamWriter("c:\\tempp.png");
            //sw.BaseStream.Write(bb, 0, bb.Length);
            //sw.Close();
            if (this.drawingPanel1.Shapes.Count != 0)
            {
                if (OnSaveImage != null)
                {
                    OnSaveImage(this.ImageAnnotation, e);
                }
            }
            else
            {
                MessageBox.Show("ÂÌç  ’ÊÌ—Ì œ—Ã ‰ê—œÌœÂ");
            }

            
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            this.drawingPanel1.Invalidate();
              ActiveTool = ActiveTools.Pointer;
        }

        private void tsbtnNewLine_Click(object sender, EventArgs e)
        {
           // this.drawingPanel1.Height += 200;
            this.drawingPanel1.AutoScrollMinSize = new Size(this.drawingPanel1.AutoScrollMinSize.Width,this.drawingPanel1.AutoScrollMinSize.Height + 200);
        }

        private void tsbtnApplay_Click(object sender, EventArgs e)
        {
            var aTools = ActiveTool;
            var sh = drawingPanel1.ApplaypActiveCurve();
            
            ActiveTool = aTools;

            if (sh != null)
            {
                foreach (var shape in this.drawingPanel1.Shapes)
                {
                    shape.Selected = false;
                }

               // sh.Selected = true;
            }
        }

        private void tsbtnPen_Click(object sender, EventArgs e)
        {
            this.ActiveTool = ActiveTools.pActiveCurve;
        }

        private void tsbtnCancel_Click(object sender, EventArgs e)
        {
            //if (DrawLine != null)
            //{
            //    DrawLine.Cancel();
            //}

            if (CancelShape != null)
            {
                CancelShape(sender, e);
            }
        }

      

     
        private void Annotation_Load(object sender, EventArgs e)
        {
            ActiveTool = ActiveTools.pActiveCurve;
        }

      

        private void drawingPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && this.ActiveTool == ActiveTools.Pen)
            {
                DrawLine.Applay();
            }
        }
        
        private void Annotation_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void tsbtnAddColumn_Click(object sender, EventArgs e)
        {
           drawingPanel1.AutoScrollMinSize = new Size(this.drawingPanel1.AutoScrollMinSize.Width + 200, this.drawingPanel1.AutoScrollMinSize.Height );
        }

        private void tsmnuItmUndo_Click(object sender, EventArgs e)
        {
            tsbtnUndo_Click(sender, e);
        }

        private void tsmnuItmRedo_Click(object sender, EventArgs e)
        {
            tsbtnRedo_Click(sender, e);
        }

        private void tsmnuItmDelete_Click(object sender, EventArgs e)
        {
            drawingPanel1.Delete();
            
        }

        private void tsmnuItmRefresh_Click(object sender, EventArgs e)
        {
            tsbtnRefresh_Click(sender, e);
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
               drawingPanel1.Refresh();
        }
        

        private void tsbtnRedo_Click(object sender, EventArgs e)
        {
            drawingPanel1.Redo();
        }

        private void tsbtnUndo_Click(object sender, EventArgs e)
        {
            drawingPanel1.Undo();
        }

        private void tsbtnEraser_CheckedChanged(object sender, EventArgs e)
        {
            //if (tsbtnEraser.Checked)
            //{
            //   tsbtnPen.Checked = false;
            //    tsPointer.Checked = false;
            //    this.ActiveTool = ActiveTools.Draft;
            //}
        }

        private void tsbtnClearAll_Click(object sender, EventArgs e)
        {
            var aTools = ActiveTool;
            drawingPanel1.ApplaypActiveCurve();
            this.drawingPanel1.ClearImage();

            ActiveTool = aTools;
            //if (tsbtnPen.Checked)
            //{
            //    tsPointer.Checked = true;
            //    tsbtnPen.Checked = true;
            //}
           
        }

        private void tsddItmPenWiths_DropDownOpening(object sender, EventArgs e)
        {
            penSelectorViewStrip1.PenSelector.SelectedPenWidth = DrawLine.WidthPen;
        }

        private void tsddItmPenWiths_DropDownClosed(object sender, EventArgs e)
        {
            DrawLine.WidthPen = penSelectorViewStrip1.PenSelector.SelectedPenWidth;

            if (drawingPanel1.ActiveTool is Sbn.AdvancedControls.Imaging.SbnPaint.pActiveCurve)
            {
                tsddItmPenWiths.Text = "÷Œ«„  ﬁ·„ " + penSelectorViewStrip1.PenSelector.SelectedPenWidth;
                drawingPanel1.CurrentPen.Width = penSelectorViewStrip1.PenSelector.SelectedPenWidth;
               // (drawingPanel1.ActiveTool as Sbn.AdvancedControls.Imaging.SbnPaint.pActiveCurve).WidthPen = penSelectorViewStrip1.PenSelector.SelectedPenWidth;
            }
        }

        private void tsbtnPenColor_Click(object sender, EventArgs e)
        {
            colorDialog1.AnyColor = true;
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                tsbtnPenColor.BackColor = colorDialog1.Color;
                drawingPanel1.CurrentPen.Color = colorDialog1.Color;
            }
        }

        private void tsddItmPenWiths_DropDownOpened(object sender, EventArgs e)
        {
            penSelectorViewStrip1.PenSelector.SelectedPenWidth = DrawLine.WidthPen;
        }

    }
}
