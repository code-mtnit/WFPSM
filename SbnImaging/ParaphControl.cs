using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Ink;
using Sbn.AdvancedControls.Imaging.SbnPaint;
using Sbn.Controls.Imaging.ImagingObject;
using Image = System.Drawing.Image;
using Point = System.Drawing.Point;

namespace Sbn.Controls.Imaging
{
    public partial class ParaphControl : UserControl
    {

        public InkCollector myInkCollector;
        private const float MediumInkWidth = 100;

        public event EventHandler SavedImage;

        public void OnSavedImage(EventArgs e)
        {
            EventHandler handler = SavedImage;
            if (handler != null) handler(this, e);
        }

        Layers TempLayers = new Layers();

        private ImageDocument _CurrentImage;
        public ImageDocument CurrentImage
        {
            get
            {
                return _CurrentImage;

            }
            set
            {
                _CurrentImage = value;
                if (value != null)
                {
                    tsbtnPen.Enabled = true;
                    tsbtnZoomIn.Enabled = true;
                    tsbtnZoomOut.Enabled = true;
                    tsbtnItmWhole.Enabled = true;
                    tsbtnItmFitWidth.Enabled = true;
                    tsbtnItmActualSize.Enabled = true;
                    tsbtnCurser.Enabled = true;
                    tsbtnRemoveLayer.Enabled = true;

                    try
                    {
                        myInkCollector = new InkCollector(this.drawingPanel1);

                        this.drawingPanel1.ActiveTool = new pActiveCurve(1,Color.Black);
                        // tablet pc Code
                        // Create the pen used to draw the zoom rectangle
                        var blackPen = new Pen(Color.Black, 1);
                        // Create the ink collector and associate it with the form

                        // Set the pen width
                        myInkCollector.DefaultDrawingAttributes.Width = MediumInkWidth;
                        // Enable ink collection
                        myInkCollector.Enabled = true;
                    }
                    catch
                    {
                    }


                    TempLayers = value.layers;
                    this.drawingPanel1.Shapes.Clear();
                  


                    if (value.Stream != null && value.Stream.Length > 10)
                    {
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(value.Stream);
                        System.Drawing.Image myImage = System.Drawing.Image.FromStream(ms);
                        this.drawingPanel1.ImageBody = myImage;
                        ms.Dispose();
                    }

                    if (value.layers != null)
                    {
                        foreach (Layer ly in value.layers)
                        {
                            if (ly.elements != null)
                            {
                                foreach (Element el in ly.elements)
                                {

                                    if (el.Tag == null)
                                    {
                                        if (el.Stream != null && el.Stream.Length > 10)
                                        {
                                            System.IO.MemoryStream ms1 = new System.IO.MemoryStream(value.Stream);
                                            System.Drawing.Image myImage2 = System.Drawing.Image.FromStream(ms1);
                                            el.Tag = myImage2;


                                            ms1.Dispose();//900428
                                        }
                                    }

                                    if (el.Tag != null && el.Tag is Image)
                                    {
                                        Sbn.AdvancedControls.Imaging.SbnPaint.Image img = new Sbn.AdvancedControls.Imaging.SbnPaint.Image((Bitmap)el.Tag);
                                        img.Locked = false;
                                        img.Selected = true;
                                        img.Dimension = new SizeF(img.Bitmap.Width, img.Bitmap.Height);

                                        img.Location = new PointF(el.LocationX + this.drawingPanel1.BackgroundLayer.Location.X, el.LocationY + this.drawingPanel1.BackgroundLayer.Location.Y);
                                        img.Tag = el;
                                        img.ShapeChanged += new Sbn.FramWork.Drawing.ShapeChangingHandler(img_ShapeChanged);
                                        img.ShapeMouseUp += new Sbn.FramWork.Drawing.MouseUpOnShape(img_ShapeMouseUp);
                                        img.EditedSahpe += new EventHandler(img_EditedSahpe);
                                        img.Selected = false;
                                        this.drawingPanel1.Shapes.Add(img);
                                    }
                                    else
                                    {
                                       
                                    }



                                }
                            }

                        }

                    }


                }
                else
                {
                    tsbtnPen.Enabled = false;
                    tsbtnZoomIn.Enabled = false;
                    tsbtnZoomOut.Enabled = false;
                    tsbtnItmWhole.Enabled = false;
                    tsbtnItmFitWidth.Enabled = false;
                    tsbtnItmActualSize.Enabled = false;
                    tsbtnCurser.Enabled = false;
                    tsbtnRemoveLayer.Enabled = false;
                    drawingPanel1.ClearImage();
                }

            }
        }


        public ParaphControl()
        {
            InitializeComponent();


           
        }


        void img_EditedSahpe(object sender, EventArgs e)
        {

        }

        void img_ShapeMouseUp(Sbn.FramWork.Drawing.IShape shape, Sbn.FramWork.Drawing.IDocument document, MouseEventArgs e)
        {

            try
            {
                if (shape is Sbn.AdvancedControls.Imaging.SbnPaint.Image)
                {
                    Sbn.AdvancedControls.Imaging.SbnPaint.Image img = (Sbn.AdvancedControls.Imaging.SbnPaint.Image)shape;
                    Element el = (Element)img.Tag;// (Element)img.Bitmap.Tag;

                    Image img2;
                    double ll = Math.Truncate(this.drawingPanel1.ZoomFactor * 100000);
                    float tt = (float)(100000 / ll);


                    //Bitmap bmp = new Bitmap((int)shape.Dimension.Width, (int)shape.Dimension.Height);

                    //System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
                    //RectangleF rect = new RectangleF(0, 0, bmp.Width, bmp.Height);
                    //GraphicsUnit ff = GraphicsUnit.Pixel;
                    //RectangleF Destrect;
                    //if (img.Bitmap != null)
                    //{
                    //    Destrect = img.Bitmap.GetBounds(ref ff);
                    //    g.DrawImage(img.Bitmap, Destrect);
                    //}
                    //else
                    //{
                    //   // Destrect = selectedShape.Geometric.GetBounds();
                    //    // g.DrawImage(selectedShape.Appearance.Image, rect);
                    //}





                    if (shape is Sbn.AdvancedControls.Imaging.SbnPaint.Image)
                    {
                        img = (Sbn.AdvancedControls.Imaging.SbnPaint.Image)shape;
                        img2 = img.Bitmap;
                        // img2 = bmp;// shape.Appearance.Image;

                    }
                    else
                    {
                        img2 = img.getImageFromShape(img, this.drawingPanel1.ZoomFactor);
                    }

                    ((Bitmap)img2).MakeTransparent(Color.White);
                    System.IO.MemoryStream ms = new MemoryStream();
                    img2.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    el.Stream = new byte[ms.Length];
                    el.Stream = ms.GetBuffer();
                    //System.IO.MemoryStream ms2 = new System.IO.MemoryStream(strem);
                    //System.Drawing.Image myImage = System.Drawing.Image.FromStream(ms2);
                    //myImage.Save("c:\\temp.png", System.Drawing.Imaging.ImageFormat.Png);
                    //Bitmap bm = new Bitmap(img2);
                    int x = (int)(shape.Location.X - this.drawingPanel1.BackgroundLayer.Location.X);
                    int y = (int)(shape.Location.Y - this.drawingPanel1.BackgroundLayer.Location.Y);
                    el.LocationX = (long)(x * tt);// this.ucPaint1.drawingPanel1.HorizontalScroll.Value + film.Location.X;
                    el.LocationY = (long)(y * tt); // this.ucPaint1.drawingPanel1.VerticalScroll.Value + film.Location.Y;
                    el.Tag = img2;
                    img2.Tag = el;
                    ms.Close();
                    ms.Dispose();

                }
            }
            catch
            {

            }

        }

        void img_ShapeChanged(Sbn.FramWork.Drawing.IShape shape, object changing)
        {

        }


        /// <summary>
        /// این متد تمام لایه یکی کرده و در یک تصویر واحد بر می گرداند
        /// </summary>
        /// <returns></returns>
        public Bitmap CreateImage()
        {
            try
            {
                var img = ApplayImage();
                var tool = new Sbn.Controls.Imaging.SbnImageTools();
                return tool.GetWholeImage(img);
            }
            catch 
            {
                
            }
            


            return null;
        }

        private void tsbtnItmWhole_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnItmActualSize_Click(object sender, EventArgs e)
        {
            
        }

        private void tsbtnItmFitWidth_Click(object sender, EventArgs e)
        {
            drawingPanel1.FitToWidth();
        }

        private void tsbtnZoomIn_Click(object sender, EventArgs e)
        {
            drawingPanel1.ZoomToCurserPosition = false;
            this.ApplaypActiveCurve();
            this.drawingPanel1.Zoom = 1.1f;
        }

        private void tsbtnZoomOut_Click(object sender, EventArgs e)
        {
            this.ApplaypActiveCurve();
            this.drawingPanel1.Zoom = 0.9f;
        }

        private void tsbtnRemoveLayer_Click(object sender, EventArgs e)
        {
            drawingPanel1.Delete();
        }

        private void tsbtnCurser_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnPen_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnCurser_CheckedChanged(object sender, EventArgs e)
        {
           tsbtnPen.Checked = !tsbtnCurser.Checked;
        }

        private void tsbtnPen_CheckedChanged(object sender, EventArgs e)
        {
            ApplaypActiveCurve();
            tsbtnCurser.Checked = !tsbtnPen.Checked;

            if (tsbtnPen.Checked)
            {
                try
                {
                    if (myInkCollector != null)
                    {
                        this.drawingPanel1.ActiveTool = new pActiveCurve();
                        // tablet pc Code
                        // Create the pen used to draw the zoom rectangle
                        var blackPen = new Pen(Color.Black, 1);
                        // Create the ink collector and associate it with the form


                        // Set the pen width
                        myInkCollector.DefaultDrawingAttributes.Width = MediumInkWidth;
                        // Enable ink collection
                        myInkCollector.Enabled = true;
                        //this.drawingPanel1.ActiveTool.isAnnotationActive = true;

                       
                    }
                    else
                    {
                        this.drawingPanel1.ActiveTool = new DrawCurveLine();
                    }



                }
                catch
                {

                }
            }
            else
            {
               // ApplaypActiveCurve();
                if (myInkCollector != null)
                    myInkCollector.Enabled = false;
                this.drawingPanel1.ActiveTool = new Pointer();
            }

        }


        public ImageDocument ApplayImage()
        {
            ApplaypActiveCurve();

            var tools = new Sbn.Controls.Imaging.SbnImageTools();

            


            Layer ly = new Layer();
            Elements elms = new Elements();


            foreach (Sbn.FramWork.Drawing.Shape film in this.drawingPanel1.Shapes)
            {
                if (!(film is Sbn.AdvancedControls.Imaging.SbnPaint.BodyBackground) && !(film is Sbn.AdvancedControls.Imaging.SbnPaint.Image))
                {
                    Element el = new Element();
                    Sbn.AdvancedControls.Imaging.SbnPaint.Image img = new Sbn.AdvancedControls.Imaging.SbnPaint.Image();
                    Image img2;
                    double ll = Math.Truncate(this.drawingPanel1.ZoomFactor * 100000);
                    float tt = (float)(100000 / ll);

                    if (film is Sbn.AdvancedControls.Imaging.SbnPaint.Image)
                    {
                        img = (Sbn.AdvancedControls.Imaging.SbnPaint.Image)film;
                        img2 = img.Bitmap;
                    }
                    else
                    {
                        img2 = film.GetImage(this.drawingPanel1.Zoom);// img.getImageFromShape(film, this.drawingPanel1.ZoomFactor);
                    }

                    ((Bitmap)img2).MakeTransparent(Color.White);
                    System.IO.MemoryStream ms = new MemoryStream();
                    //   img2.Save("C:\\as.jpg");
                    img2.Save(ms, System.Drawing.Imaging.ImageFormat.Png);


                    el.Stream = new byte[ms.Length];

                    el.Stream = ms.GetBuffer();

                    int x = (int)(film.Location.X - this.drawingPanel1.BackgroundLayer.Location.X);
                    int y = (int)(film.Location.Y - this.drawingPanel1.BackgroundLayer.Location.Y);
                    el.LocationX = (long)(x * tt);
                    el.LocationY = (long)(y * tt);
                    el.Tag = img2;
                    //    img2.Save("C:\\aa.jpg");
                    // el.ID = -(elms.Count + 1);
                    ms.Close();
                    ms.Dispose();

                    if (el.ID <= 0)
                        el.ID = -elms.Count - 1;
                    if (!elms.Contains(el))
                        elms.Add(el);
                    else
                    {

                    }

                }
                else
                {
                    // film.Appearance.Image.Save("C:\\aa.jpg");

                    if (film is Sbn.AdvancedControls.Imaging.SbnPaint.BodyBackground)
                    {
                        //((FilmstripImage)this.CurrentImage).Image = film.Appearance.Image;


                        try
                        {


                            Bitmap result = new Bitmap(film.Appearance.Image.Width, film.Appearance.Image.Height);

                            Graphics gg = Graphics.FromImage(result);

                            gg.DrawImage(film.Appearance.Image, new Rectangle(0, 0, film.Appearance.Image.Width, film.Appearance.Image.Height));

                            gg.Save();

                            gg.Dispose();


                            using (Image imageToExport = result)
                            {
                                MemoryStream ms = new MemoryStream();
                                // ((FilmstripImage)this.CurrentImage).Image.Save(ms, System.Drawing.Imaging.ImageFormat.Tiff);
                                imageToExport.Save(ms, System.Drawing.Imaging.ImageFormat.Tiff);
                                this.CurrentImage.Stream = ms.GetBuffer();



                                ms.Dispose();
                            }

                            result.Dispose();
                            result = null;


                        }
                        catch
                        {

                        }

                    }
                    else
                    {
                        double ll = Math.Truncate(this.drawingPanel1.ZoomFactor * 100000);
                        float tt = (float)(100000 / ll);
                        int x = (int)(film.Location.X - this.drawingPanel1.BackgroundLayer.Location.X);
                        int y = (int)(film.Location.Y - this.drawingPanel1.BackgroundLayer.Location.Y);
                       

                        //((Element)film.Tag).LocationX = (long)film.Location.X ;
                        //((Element)film.Tag).LocationY = (long)film.Location.Y;


                        if (film.Tag is Element)
                        {
                            try
                            {
                                ((Element)film.Tag).LocationX = (long)(x * tt);
                                ((Element)film.Tag).LocationY = (long)(y * tt);
                                Image iig = film.Appearance.Image;

                                //  iig.Save("C:\\dddd.jpeg");

                                if (film.IsEdited)
                                {
                                    Bitmap bmp = new Bitmap((int)(iig.Width), (int)(iig.Height));
                                    bmp = new Bitmap((int)(iig.Width * tt), (int)(iig.Height * tt));

                                    System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
                                    g.Clear(Color.White);

                                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                    g.DrawImage(iig, new Rectangle(new System.Drawing.Point(0, 0), bmp.Size));
                                    bmp.MakeTransparent(Color.White);
                                    //this.Image = bmp;

                                    g.Dispose();

                                    MemoryStream ms = new MemoryStream();
                                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    if (((Element)film.Tag).Stream.Length != ms.GetBuffer().Length)
                                    {
                                        ((Element)film.Tag).Stream = ms.GetBuffer();
                                        ((Element)film.Tag).Tag = bmp;
                                        ((Element)film.Tag).Title += "Edited";
                                    }
                                    ms.Dispose();
                                }


                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            try
                            {
                                var newElm = new Element();

                                newElm.LocationX = (long)(x * tt);
                                newElm.LocationY = (long)(y * tt);


                                Image iig = film.Appearance.Image;

                                Bitmap bmp = new Bitmap((int)(iig.Width), (int)(iig.Height));
                                bmp = new Bitmap((int)(iig.Width * tt), (int)(iig.Height * tt));

                                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
                                g.Clear(Color.White);

                                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                g.DrawImage(iig, new Rectangle(new System.Drawing.Point(0, 0), bmp.Size));
                                bmp.MakeTransparent(Color.White);
                                //this.Image = bmp;

                                g.Dispose();

                                MemoryStream ms = new MemoryStream();
                                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                newElm.Stream = ms.GetBuffer();
                                newElm.Tag = bmp;
                                //newElm.Title += "Edited";
                                ms.Dispose();
                                elms.Add(newElm);

                            }
                            catch
                            {

                            }

                        }



                    }

                }

            }

            if (elms.Count > 0)
            {
                ly.elements = elms;
                if (CurrentImage == null)
                {
                    CurrentImage = new ImageDocument();
                    CurrentImage.layers = new Layers();
                }

                if (CurrentImage.layers == null)
                    CurrentImage.layers = new Layers();

                if (ly.ID <= 0)
                    ly.ID = -CurrentImage.layers.Count - 1;
                CurrentImage.layers.Add(ly);




            }

            //  ((FilmstripImage)this.CurrentImage).Image.Save("c:\\bb.jpg");


            // this.CurrentImage.layers = new Layers();
            // this.CurrentImage.layers =  getElements();
            return CurrentImage;
        }


        public void ApplaypActiveCurve()
        {

            try
            {

                if (myInkCollector == null || myInkCollector.Ink.Strokes.Count == 0)
                    return;


                myInkCollector.Enabled = false;
                System.IO.MemoryStream annms;
                Image AnnImg = null;
                try
                {

                    //save New Annotaion
                    byte[] b = myInkCollector.Ink.Save(PersistenceFormat.Gif);
                    annms = new System.IO.MemoryStream(b);
                    AnnImg = Image.FromStream(annms);

                    annms.Close();

                    //try
                    //{
                    //    AnnImg.Save("C:\\hhhh.jpg" , System.Drawing.Imaging.ImageFormat.Gif);
                    //}
                    //catch
                    //{ 

                    //}

                    int letf = 0;
                    int right = 0;

                    Rectangle Rect = myInkCollector.Ink.Strokes[0].GetBoundingBox(Microsoft.Ink.BoundingBoxMode.Default);

                    foreach (Stroke strk in myInkCollector.Ink.Strokes)
                    {

                        Rectangle recTemp = strk.GetBoundingBox(Microsoft.Ink.BoundingBoxMode.Default);
                        if (recTemp.X < Rect.X)
                        {
                            Rect.X = recTemp.X;
                        }

                        if (recTemp.Y < Rect.Y)
                        {
                            Rect.Y = recTemp.Y;
                        }


                    }



                    myInkCollector.Ink.Strokes[0].DrawingAttributes.Color = Color.Blue;

                    System.Drawing.Point pointTopLeft = new System.Drawing.Point(Rect.Left, Rect.Top);
                    System.Drawing.Point pointBottomRight = new System.Drawing.Point(Rect.Left, Rect.Top);
                    pointBottomRight.Offset(Rect.Width, Rect.Height);
                    myInkCollector.Renderer.InkSpaceToPixel(this.CreateGraphics(),
                ref pointTopLeft);
                    myInkCollector.Renderer.InkSpaceToPixel(this.CreateGraphics(),
                ref pointBottomRight);


                    double ll = Math.Truncate(this.drawingPanel1.ZoomFactor * 100000);
                    float tt = (float)(100000 / ll);

                    int x = (int)(pointTopLeft.X - this.drawingPanel1.BackgroundLayer.Location.X);
                    int y = (int)(pointTopLeft.Y - this.drawingPanel1.BackgroundLayer.Location.Y);
                    //int LocationX = (int)(x * tt);
                    //int LocationY = (int)(y * tt);

                    //           Rectangle convertedRect = new Rectangle(x,
                    //y, pointBottomRight.X - pointTopLeft.X,
                    //pointBottomRight.Y - pointTopLeft.Y);

                    Rectangle convertedRect = new Rectangle(pointTopLeft.X,
                pointTopLeft.Y, pointBottomRight.X - pointTopLeft.X,
                pointBottomRight.Y - pointTopLeft.Y);

                    //

                    Sbn.AdvancedControls.Imaging.SbnPaint.pActiveAnnotation pActiveSh1 = new Sbn.AdvancedControls.Imaging.SbnPaint.pActiveAnnotation((Bitmap)AnnImg, new PointF(convertedRect.X, convertedRect.Y));

                    //pActiveSh1.Dimension = new SizeF(new PointF(convertedRect.X, convertedRect.Y));
                    myInkCollector.Enabled = false;
                    this.drawingPanel1.Shapes.Add(pActiveSh1);
                    pActiveSh1.Selected = true;

                    Strokes strokesToDelete = myInkCollector.Ink.Strokes;
                    myInkCollector.Ink.DeleteStrokes(strokesToDelete);

                    // Check to ensure that the ink collector isn't currently
                    // in the middle of a stroke before clearing the ink.
                    // Deleting a stroke that is currently being collected
                    // will result in an error condition.

                }
                catch
                {

                }






                // myInkCollector = new InkCollector();
                //this.Invalidate(false);
            }

            catch
            { }

           // tsbtnCurser.Checked = true;

        }


        //private void UpdateElement(Element el)
        //{
        //    //foreach (Layer ly in CurrentImage.layers.m_Col)
        //    //{ 
        //    //    foreach(ele
        //    //}
        //}

        //public void AddImage(System.Drawing.Image img, Point location)
        //{
        //   drawingPanel1.AddImage(img , location);

         
        //    tsbtnCurser.Checked = true;
           
        //}


        //public void AddText(string text, Point location)
        //{

        //}

        public Layers getElements()
        {
            Layers lys = new Layers();

            if (this.CurrentImage.layers != null && this.CurrentImage.layers.Count > 1)
            {
                foreach (Layer ly in this.CurrentImage.layers)
                {

                }
            }
            else
            {
                Layer ly = new Layer();
                Elements elms = new Elements();

                foreach (Sbn.FramWork.Drawing.Shape film in this.drawingPanel1.Shapes)
                {
                    if (!(film is Sbn.AdvancedControls.Imaging.SbnPaint.BodyBackground))
                    {
                        Element el = new Element();
                        Sbn.AdvancedControls.Imaging.SbnPaint.Image img = new Sbn.AdvancedControls.Imaging.SbnPaint.Image();
                        Image img2;
                        double ll = Math.Truncate(this.drawingPanel1.ZoomFactor * 100000);
                        float tt = (float)(100000 / ll);

                        if (film is Sbn.AdvancedControls.Imaging.SbnPaint.Image)
                        {
                            img = (Sbn.AdvancedControls.Imaging.SbnPaint.Image)film;
                            img2 = img.Bitmap;
                        }
                        else
                        {
                            img2 = img.getImageFromShape(film, this.drawingPanel1.ZoomFactor);
                        }

                        ((Bitmap)img2).MakeTransparent(Color.White);
                        System.IO.MemoryStream ms = new MemoryStream();
                        img2.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        el.Stream = new byte[ms.Length];
                        el.Stream = ms.GetBuffer();
                        //System.IO.MemoryStream ms2 = new System.IO.MemoryStream(strem);
                        //System.Drawing.Image myImage = System.Drawing.Image.FromStream(ms2);
                        //myImage.Save("c:\\temp.png", System.Drawing.Imaging.ImageFormat.Png);
                        //Bitmap bm = new Bitmap(img2);
                        int x = (int)(film.Location.X - this.drawingPanel1.BackgroundLayer.Location.X);
                        int y = (int)(film.Location.Y - this.drawingPanel1.BackgroundLayer.Location.Y);
                        el.LocationX = (long)(x * tt);// this.ucPaint1.drawingPanel1.HorizontalScroll.Value + film.Location.X;
                        el.LocationY = (long)(y * tt); // this.ucPaint1.drawingPanel1.VerticalScroll.Value + film.Location.Y;
                        el.Tag = img2;

                        ms.Close();
                        ms.Dispose();

                        elms.Add(el);
                    }

                }

                ly.elements = elms;
                lys.Add(ly);

            }







            return lys;
        }

        private void drawingPanel1_Scroll(object sender, ScrollEventArgs e)
        {
           // ApplaypActiveCurve();
        }
    }
}
