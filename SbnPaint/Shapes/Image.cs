using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Sbn.FramWork.Drawing;
using Sbn.FramWork.Drawing.Serialization;
using System.Runtime.InteropServices;

namespace Sbn.AdvancedControls.Imaging.SbnPaint
{
    /// <summary>
    /// Image shape.
    /// </summary>
    [XmlClassSerializable("image")]
    public class Image : Shape
    {
        #region Added properties to serialize


        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hWnd);

        [XmlFieldSerializable("imageBytes")]
        byte[] ImageBytes
        {
            get { return Sbn.FramWork.Drawing.Core.Converters.BitmapConverter.BytesFromBitmap(_bitmap); }
            set { _bitmap = Sbn.FramWork.Drawing.Core.Converters.BitmapConverter.BitmapFromBytes(value); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Image()
        {
          //  Geometric.AddLine(new Point(0, 0), new Point(1, 1));
        }

        bool _IsEdited = false;
        public override bool IsEdited
        {
            get
            {
                return _IsEdited;
            }
            set
            {
                _IsEdited = value;
                base.IsEdited = value;
            }
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="image">Image to copy.</param>
        public Image(Image image) : base(image)
        {
            if (image._bitmap != null)
            {
                _bitmap = image._bitmap.Clone() as Bitmap;
                this.Appearance.Image = _bitmap;
            }

            EditedSahpe += new EventHandler(Image_EditedSahpe);
        }

        void Image_EditedSahpe(object sender, EventArgs e)
        {
            
            
        }


        public override void OnEditedImage()
        {

            try
            {
                //Bitmap bmp = new Bitmap((int)this.Dimension.Width, (int)this.Dimension.Height);
                //System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
                //g.Clear(Color.White);

                //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //g.DrawImage(this.Appearance.Image, new Rectangle(new System.Drawing.Point(0, 0), bmp.Size));
                ////bmp.MakeTransparent(Color.White);
                ////this.Image = bmp;
                ////  bmp.Save("C:\\base.jpeg");
                //g.Save();
                //g.Dispose();

                //System.IO.MemoryStream ms = new System.IO.MemoryStream();
                //bmp.MakeTransparent(Color.White);
                //bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                //this.Appearance.Image = System.Drawing.Image.FromStream(ms);

                //ms.Dispose();


                //   this.Appearance.Image.Save("C:\\adad.jpeg");
                IsEdited = true;
            }
            catch
            {
            }

        }
        
        
        
      

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="bitmap">Reference bitmap.</param>
        public Image(Bitmap bitmap)
        {
          //  Geometric.AddLine(new Point(0, 0), new Point(1, 1));

            _bitmap = bitmap.Clone() as Bitmap;
            this.Appearance.Image = bitmap;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="bitmap">Reference bitmap.</param>
        public Image(Bitmap bitmap , RectangleF rec)
        {
           // Geometric.AddLine(new Point(0, 0), new Point(1, 1));
            Geometric.AddRectangle(rec);
            
            _bitmap = bitmap.Clone() as Bitmap;
            this.Appearance.Image = bitmap;
        }

       


        public override bool Visible
        {
            get
            {
                return base.Visible;
            }
            set
            {
                if (value == false)
                { 
                    
                }
                base.Visible = value;
            }
        }

        public System.Drawing.Image getImageFromShape(Shape shape, float ZoomFactor)
        {
            System.Drawing.Image img = null;



            double ll = Math.Truncate(ZoomFactor * 100000);
            float tt = (float)(100000 / ll);

            bool selected = shape.Selected;
            bool locked = shape.Locked;
            PointF ShapeLocation = shape.Location;

            shape.Selected = true;
            shape.Locked = false;

            shape.Location = new PointF(0, 0);


            try
            {
                shape.Transformer.Scale(tt, tt);
            }
            catch
            {
            }



            Pen pen = new Pen(shape.Appearance.ActivePen.Color, shape.Appearance.BorderWidth * tt);

            pen.MiterLimit = 1;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;

            Bitmap bmp = new Bitmap((int)(shape.Dimension.Width + 1), (int)(shape.Dimension.Height + 1));
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);

            g.Clear(Color.White);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.DrawPath(pen, shape.Geometric);
            long i = 0;


            if (shape is Sbn.AdvancedControls.Imaging.SbnPaint.Text)
            {
                //Sbn.AdvancedControls.Imaging.SbnPaint.Text ttext = new Text();
                //ttext = (Sbn.AdvancedControls.Imaging.SbnPaint.Text)shape;
                //Brush bb = new System.Drawing.SolidBrush(ttext.Appearance.MarkerColor);


                //StringFormat m_Formatdd = new StringFormat();
                //m_Formatdd.Alignment = StringAlignment.Near;
                //m_Formatdd.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.DirectionRightToLeft;
                //m_Formatdd.LineAlignment = StringAlignment.Near;

                //Rectangle WFTitle = new Rectangle(0, 0, bmp.Width, bmp.Height);

                //// using (Font fntDayDate = new Font("Tahoma", 10, FontStyle.Regular))
                //g.DrawString(ttext.DisplayedText, ttext.Font, SystemBrushes.WindowText, WFTitle, m_Formatdd);




                // g.DrawString(ttext.DisplayedText, ttext.Font, bb, new PointF(0, 0) , sf);
            }

            if (shape is Sbn.AdvancedControls.Imaging.SbnPaint.RectangleBody)
            {
                //Pen pen = new Pen(shape.Appearance.ActivePen.Color, shape.Appearance.BorderWidth * tt);

                //pen.MiterLimit = 1;
                //pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                //pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;

                g.DrawRectangle(pen, 0, 0, shape.Dimension.Width, shape.Dimension.Height);
            }


            //if (shape is pActiveAnnotation)
            //{

            //    g.DrawImage(((pActiveAnnotation)shape).Bitmap, 0, 0, shape.Dimension.Width, shape.Dimension.Height);
            //}

            g.Dispose();

            bmp.MakeTransparent(Color.White);

            Bitmap bmpp = new Bitmap(bmp.Width, bmp.Height, System.Drawing.Imaging.PixelFormat.Format4bppIndexed);

            bmp.Palette = bmpp.Palette;
            // bmp.Save("c:\\www2.png");
            pen.Dispose();
            shape.Location = ShapeLocation;
            shape.Selected = selected;
            shape.Locked = locked;

            // Image img2 = (System.Drawing.Image)bmp;
            bmp.MakeTransparent(Color.White);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            return (System.Drawing.Image)bmp;

        }

        //public  System.Drawing.Image getImageFromShape(Shape shape, float ZoomFactor)
        //{
        //    System.Drawing.Image img = null;



        //    double ll = Math.Truncate(ZoomFactor * 100000);
        //    float tt = (float)(100000 / ll);

        //    bool selected = shape.Selected;
        //    bool locked = shape.Locked;
        //    PointF ShapeLocation = shape.Location;

        //    shape.Selected = true;
        //    shape.Locked = false;

        //    shape.Location = new PointF(2, 2);


        //    try
        //    {
        //        shape.Transformer.Scale(tt, tt);
        //    }
        //    catch
        //    {
        //    }

           

        //    Pen pen = new Pen(shape.Appearance.ActivePen.Color, shape.Appearance.BorderWidth * tt);

        //    pen.MiterLimit = 1;
        //    pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        //    pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;

        //    Bitmap bmp = new Bitmap((int)(shape.Dimension.Width + 5), (int)(shape.Dimension.Height + 5));
        //    System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);

        //    g.Clear(Color.White);

        //    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //    g.DrawPath(pen, shape.Geometric);
        //    long i = 0;


        //    if (shape is Sbn.AdvancedControls.Imaging.SbnPaint.Text)
        //    {
        //        Sbn.AdvancedControls.Imaging.SbnPaint.Text ttext = new Text();
        //        ttext = (Sbn.AdvancedControls.Imaging.SbnPaint.Text)shape;
        //        Brush bb = new System.Drawing.SolidBrush(ttext.Appearance.MarkerColor);


        //        StringFormat m_Formatdd = new StringFormat();
        //        m_Formatdd.Alignment = StringAlignment.Near;
        //        m_Formatdd.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.DirectionRightToLeft;
        //        m_Formatdd.LineAlignment = StringAlignment.Near;

        //        Rectangle WFTitle = new Rectangle(0, 0, bmp.Width, bmp.Height);

        //        // using (Font fntDayDate = new Font("Tahoma", 10, FontStyle.Regular))
        //        g.DrawString(ttext.DisplayedText, ttext.Font, SystemBrushes.WindowText, WFTitle, m_Formatdd);




        //        // g.DrawString(ttext.DisplayedText, ttext.Font, bb, new PointF(0, 0) , sf);
        //    }

        //    if (shape is Sbn.AdvancedControls.Imaging.SbnPaint.RectangleBody)
        //    {
        //        //Pen pen = new Pen(shape.Appearance.ActivePen.Color, shape.Appearance.BorderWidth * tt);

        //        //pen.MiterLimit = 1;
        //        //pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        //        //pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;

        //        g.DrawRectangle(pen, 0, 0, shape.Dimension.Width, shape.Dimension.Height);
        //    }

        //    g.Dispose();

        //    bmp.MakeTransparent(Color.White);

        //    Bitmap bmpp = new Bitmap(bmp.Width, bmp.Height, System.Drawing.Imaging.PixelFormat.Format4bppIndexed);

        //    bmp.Palette = bmpp.Palette;
        //    bmp.Save("c:\\www2.jpg");
        //    pen.Dispose();
        //    shape.Location = ShapeLocation;
        //    shape.Selected = selected;
        //    shape.Locked = locked;

          
        //    //bmp.MakeTransparent(Color.White);
        //    //System.IO.MemoryStream ms = new System.IO.MemoryStream();
        //    //bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

        //    return (System.Drawing.Image)bmp;

        //}


        public System.Drawing.Image getImageFromShapeOld(Shape shape , float ZoomFactor )
        {
            System.Drawing.Image img = null;

           

            double ll = Math.Truncate(ZoomFactor * 100000);
            float tt = (float)(100000 / ll);

            bool selected = shape.Selected;
            bool locked = shape.Locked;

            shape.Selected = true;
            shape.Locked = false;

            try
            {
                shape.Transformer.Scale(tt, tt);
            }
            catch
            {
            }

            shape.Selected = selected;
            shape.Locked = locked;

            Bitmap bmp = new Bitmap((int)(shape.Dimension.Width + 5), (int)(shape.Dimension.Height + 5));
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
           
            g.Clear(Color.White);
           
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            
            long i = 0;

            if (shape is Sbn.FramWork.Drawing.CompositeShape)
            {

                foreach (Shape sh in ((Sbn.FramWork.Drawing.CompositeShape)shape).Shapes)
                {
                    PointF[] pf = new PointF[sh.Geometric.PathPoints.Length];

                    long j = 0;
                    foreach (PointF point in sh.Geometric.PathPoints)
                    {
                        if (i < shape.Geometric.PathPoints.Length)
                        {
                            pf[j].X = shape.Geometric.PathPoints[i].X - shape.Location.X  + 2;
                            pf[j].Y = shape.Geometric.PathPoints[i].Y  - shape.Location.Y  + 2;
                            i++;
                            if (j == sh.Geometric.PointCount - 1)
                                break;
                            j++;
                        }
                    }

                    Pen pen = new Pen(sh.Appearance.ActivePen.Color, sh.Appearance.BorderWidth * tt);

                    pen.MiterLimit = 1;
                    pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;

                    System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath(pf, sh.Geometric.PathTypes);


                    g.DrawPath(pen, gp);

                    pen.Dispose();
                }
            }


            if (shape is Sbn.AdvancedControls.Imaging.SbnPaint.Text)
            {
                Sbn.AdvancedControls.Imaging.SbnPaint.Text ttext = new Text();
                ttext = (Sbn.AdvancedControls.Imaging.SbnPaint.Text)shape;
                Brush bb = new System.Drawing.SolidBrush(ttext.Appearance.MarkerColor);


                StringFormat m_Formatdd = new StringFormat();
                m_Formatdd.Alignment = StringAlignment.Near;
                m_Formatdd.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.DirectionRightToLeft ;
                m_Formatdd.LineAlignment = StringAlignment.Near;

                Rectangle WFTitle = new Rectangle(0, 0, bmp.Width, bmp.Height);

               // using (Font fntDayDate = new Font("Tahoma", 10, FontStyle.Regular))
                g.DrawString(ttext.DisplayedText, ttext.Font, SystemBrushes.WindowText, WFTitle, m_Formatdd);



                
               // g.DrawString(ttext.DisplayedText, ttext.Font, bb, new PointF(0, 0) , sf);
            }

            if (shape is Sbn.AdvancedControls.Imaging.SbnPaint.RectangleBody)
            {
                Pen pen = new Pen(shape.Appearance.ActivePen.Color, shape.Appearance.BorderWidth * tt);

                pen.MiterLimit = 1;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;

                g.DrawRectangle(pen, 0, 0, shape.Dimension.Width , shape.Dimension.Height );
            }

            g.Dispose();
            
            bmp.MakeTransparent(Color.White);

            Bitmap bmpp = new Bitmap(bmp.Width,bmp.Height , System.Drawing.Imaging.PixelFormat.Format4bppIndexed );

            bmp.Palette = bmpp.Palette;
            bmp.Save("c:\\www.jpg");

            return (System.Drawing.Image )bmp;

        }

        #endregion

        #region IShape Interface

        #region ICloneable Interface

        /// <summary>
        /// Clones the shape.
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var img = new Image();
            img.Bitmap = this.Bitmap.Clone() as Bitmap;
            img.Selected = Selected;
            img.Locked = Locked;
            img.Geometric.AddRectangle(Geometric.GetBounds());
            img.IsEdited = IsEdited;
            img.Visible = Visible;
            img.Appearance.Image = img.Bitmap;
            img.Tag = Tag;
            return img;
        }

        #endregion

        #region IActions Interface

        ///// <summary>
        ///// Paint function
        ///// </summary>
        ///// <param name="document">Informations transferred from DrawingPanel</param>
        ///// <param name="e">PaintEventArgs</param>
        //public override void Paint(IDocument document, System.Windows.Forms.PaintEventArgs e)
        //{
        //    if (this.Visible)
        //        e.Graphics.DrawImage(_bitmap, Location.X, Location.Y, Dimension.Width, Dimension.Height);


        //    this.Appearance.Shape = this;


        //    //if (!_shape.Selected || !IsValidGeometric(_shape.Geometric))
        //    //    return;

        //    Rectangle outside = Rectangle.Round(this.Geometric.GetBounds());
        //    Rectangle inside = outside;

        //    outside.Inflate(this.Appearance.GrabberDimension / 2, this.Appearance.GrabberDimension / 2);
        //    inside.Inflate(-this.Appearance.GrabberDimension / 2, -this.Appearance.GrabberDimension / 2);

        //    System.Windows.Forms.ControlPaint.DrawSelectionFrame(e.Graphics, true, outside, inside, document.DrawingControl.BackColor);

        //    Color color = Color.Green;
        //    if (Sbn.FramWork.Drawing.Select.LastSelectedShape == this)
        //        color = System.Windows.Forms.ControlPaint.LightLight(color);

        //    using (SolidBrush solidBrush = new SolidBrush(color))
        //    {
        //        Rectangle[] grabbers = this.GetGrabbers();

        //        foreach (Rectangle grabber in grabbers)
        //            e.Graphics.FillRectangle(solidBrush, grabber);
        //    }
        //}

        #endregion

        #endregion

        #region Properties

        Bitmap _bitmap = null;
        /// <summary>
        /// Gets or sets the bitmap image.
        /// </summary>
        public Bitmap Bitmap
        {
            get 
            {
               // return (Bitmap)this.Appearance.Image;

               return _bitmap; 

            }
            set
            {
                _bitmap = value;
               // this.Appearance.Image = value;
            }
        }

        #endregion
    }
}
