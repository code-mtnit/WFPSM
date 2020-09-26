using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Media;
using Sbn.FramWork.Drawing;
using FlowDirection = System.Windows.FlowDirection;

namespace Sbn.AdvancedControls.Imaging.SbnPaint
{
    /// <summary>
    /// Draws and instantiates a shape.
    /// </summary>
    public class DrawShape : Draw
    {
        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="geometric">Reference GraphicsPath.</param>
        public DrawShape(GraphicsPath geometric)
        {
            IShape shape = new CustomShape(geometric.Clone() as GraphicsPath);
            Ghost = new Ghost(shape);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="shape">Shape to draw.</param>
        public DrawShape(IShape shape)
        {
            Ghost = new Ghost(shape);
        }

        #endregion

        #region IActions Interface

        /// <summary>
        /// Mouse down function.
        /// </summary>
        /// <param name="document">Informations transferred from DrawingPanel.</param>
        /// <param name="e">MouseEventArgs.</param>
        public override void MouseDown(IDocument document, MouseEventArgs e)
        {
            base.MouseDown(document, e);

            PointF point = document.GridManager.GetRoundedPoint(e.Location);
            Ghost.Location = point;
            Ghost.MirrorPoint = point;

            Ghost.MouseDown(document, e);
        }

        /// <summary>
        /// Mouse up function.
        /// </summary>
        /// <param name="document">Informations transferred from DrawingPanel.</param>
        /// <param name="e">MouseEventArgs.</param>
        public override void MouseUp(IDocument document, MouseEventArgs e)
        {
            Ghost.MouseUp(document, e);

            IShape shape = Ghost.Shape.Clone() as IShape;
            shape.Visible = true;
            shape.Selected = true;
            document.Shapes.Add(shape);

            if (shape is Text)
            {

                Point pp = document.DrawingControl.PointToScreen(new Point((int)shape.Location.X, (int)shape.Location.Y));
                frmAddText frm = new frmAddText();
                frm.Location = pp;
               
                frm.Size = new Size((int) shape.Dimension.Width , (int) shape.Dimension.Height);
                frm.ShowInTaskbar = false;
              
               if (frm.ShowDialog() == DialogResult.OK)
                {

                    StringFormat m_Formatdd = new StringFormat();
                    m_Formatdd.Alignment = StringAlignment.Near;
                    m_Formatdd.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.DirectionRightToLeft;
                    m_Formatdd.LineAlignment = StringAlignment.Near;

                    
                    int xTemp = frm.Size.Width;
                   Size porposSize = new Size(int.MaxValue,int.MaxValue);
                   SizeF siz = TextRenderer.MeasureText(frm.TextResult, frm.FontText, porposSize,TextFormatFlags.NoClipping);

                    SizeF sizt = new SizeF(0, 0);// (1 / 6F) * frm.FontText.Size;


                    try
                    {
                        using (GraphicsPath gp = new GraphicsPath())
                        {
                            gp.AddString(frm.TextResult, frm.FontText.FontFamily, (int)frm.Font.Style, frm.FontText.Size, new Point(0, 0), m_Formatdd);
                            siz = gp.GetBounds().Size;
                            siz = new SizeF(siz.Width * 2, siz.Height * 2);
                        }
                    }
                    catch (Exception)
                    {
                        
                       
                    }
                  
                   
                 
                   //using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
                   //{

                   //    sizt = g.MeasureString(frm.TextResult, frm.FontText, new PointF(10, 10), m_Formatdd);
                   //}

                    shape.Dimension = siz;// new SizeF(siz.Width * 2, siz.Height * 2);
                  
                  // FormattedText formattedText = new FormattedText(frm.TextResult,null,FlowDirection.RightToLeft,  )
                   
                     shape.Location = new PointF(shape.Location.X + xTemp - shape.Dimension.Width ,  shape.Location.Y);
                     //shape.Geometric
                   //  shape.Location.X =shape.Location.X + xTemp - shape.Dimension.Width;
                     //((Text)shape).Dimension.Height = siz.Height;
                     //((Text)shape).Dimension.Width = siz.Width;
                    ((Text)shape).Font = frm.FontText;
                    ((Text)shape).StringFormat = m_Formatdd;
                    ((Text)shape).DisplayedText = frm.TextResult;
                   
                }
               else
               {
                   document.Shapes.Remove(shape);
               }
               frm.Dispose();
                
            }

            base.MouseUp(document, e);
        }

        /// <summary>
        /// Mouse move function.
        /// </summary>
        /// <param name="document">Informations transferred from DrawingPanel.</param>
        /// <param name="e">MouseEventArgs.</param>
        public override void MouseMove(IDocument document, MouseEventArgs e)
        {

            UpdateCursor(document, document.Shapes, e.Location);


            if (!MousePressed)
                return;

            base.MouseMove(document, e);
            Ghost.MouseMove(document, e);


        }

        /// <summary>
        /// Paint function.
        /// </summary>
        /// <param name="document">Informations transferred from DrawingPanel.</param>
        /// <param name="e">PaintEventArgs.</param>
        public override void Paint(IDocument document, PaintEventArgs e)
        {
            Ghost.Paint(document, e);
        }

        public override bool UpdateCursor(IDocument document, ShapeCollection shapes, Point point)
        {

            document.ActiveCursor = Cursors.Cross;

            return base.UpdateCursor(document, shapes, point);
        }

        #endregion
    }
}
