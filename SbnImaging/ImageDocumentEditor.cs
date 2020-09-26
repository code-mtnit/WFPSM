using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;


using System.Collections.ObjectModel;


using System.Collections;
using Microsoft.Ink;

using Sbn.AdvancedControls.Imaging.SbnPaint;
using Sbn.Controls.Imaging.ImagingObject;
using Image = System.Drawing.Image;


namespace Sbn.Controls.Imaging
{
    public partial class ImageDocumentEditor : UserControl
    {
        SbnImageTools CurrentTools = new SbnImageTools();
        public event EventHandler DeletedElement;
        public event EventHandler DeletedLayer;
        public event EventHandler OnApplay;
        public event EventHandler OnCancel;


        /// <summary>
        /// added by ghmhm for drawing free lines with tabletpc pen
        /// </summary>
        public InkCollector myInkCollector;

        public ImageDocumentEditor()
        {

            InitializeComponent();
            try
            {
                myInkCollector = new InkCollector(this.drawingPanel1);
            }
            catch
            {
            }

            drawingPanel1.CurrentPen = new Pen(Color.Black, 15);
            // this.drawingPanel1.EnableWheelZoom = false;
            // Cursor = new Cursor("Pencil.cur");

            //FormAddText.ApplayAddText += new EventHandler(FormAddText_ApplayAddText);
            //FormAddText.VisibleChanged += new EventHandler(FormAddText_VisibleChanged);
            //FormAddText.ChangedFont += new EventHandler(FormAddText_ChangedFont);
            DrawText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

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

                    drawingPanel1.ClearImage();//.Shapes.Clear();
                    Dock = DockStyle.Fill;

                    if (value.Stream != null && value.Stream.Length > 10)
                    {
                        drawingPanel1.ImageBody = CurrentTools.BaseTools.GetImage(value.Stream);
                    }
                    else if (Path.IsPathRooted(value.Description) && File.Exists(value.Description))
                    {
                        drawingPanel1.ImageBody = Image.FromFile(value.Description);
                    }

                    if (value.layers != null)
                    {
                        foreach (Layer ly in value.layers)
                        {
                            if (ly.elements != null)
                            {
                                foreach (Element el in ly.elements)
                                {

                                    //if ((el.Tag == null || !(el.Tag is Image)) && el.Stream != null)
                                    //{
                                    //    el.Tag = CurrentTools.BaseTools.GetImage(el.Stream);
                                    //}



                                    //if (el.Tag != null && el.Tag is Image)
                                    if (el.Stream != null && el.Stream.Length > 10)
                                    {
                                        var imgElmnt = CurrentTools.BaseTools.GetImage(el.Stream);

                                        var rec =
                                            new Rectangle((int)(el.LocationX + this.drawingPanel1.BackgroundLayer.Location.X),
                                                          (int)(el.LocationY + this.drawingPanel1.BackgroundLayer.Location.Y),
                                                          imgElmnt.Width, imgElmnt.Height);


                                        Sbn.AdvancedControls.Imaging.SbnPaint.Image img = new Sbn.AdvancedControls.Imaging.SbnPaint.Image((Bitmap)imgElmnt, rec);
                                        //img.Locked = false;
                                        //img.Selected = true;
                                        //img.Dimension = new SizeF(img.Bitmap.Width, img.Bitmap.Height);

                                        //img.Location = new PointF(el.LocationX + this.drawingPanel1.BackgroundLayer.Location.X, el.LocationY + this.drawingPanel1.BackgroundLayer.Location.Y);
                                        img.Tag = el;
                                        img.ShapeChanged += new Sbn.FramWork.Drawing.ShapeChangingHandler(img_ShapeChanged);
                                        img.ShapeMouseUp += new Sbn.FramWork.Drawing.MouseUpOnShape(img_ShapeMouseUp);
                                        img.EditedSahpe += new EventHandler(img_EditedSahpe);
                                        //img.Selected = false;
                                        this.drawingPanel1.Shapes.Add(img);
                                    }


                                }
                            }

                        }

                    }
                    //  drawingPanel1.FitToWidth();

                }
                else
                    drawingPanel1.ClearImage();
                Invalidate(true);


            }
        }

        void img_EditedSahpe(object sender, EventArgs e)
        {

        }

        void img_ShapeMouseUp(Sbn.FramWork.Drawing.IShape shape, Sbn.FramWork.Drawing.IDocument document, MouseEventArgs e)
        {

            try
            {
                //    if (shape is Sbn.AdvancedControls.Imaging.SbnPaint.Image)
                //    {
                //        Sbn.AdvancedControls.Imaging.SbnPaint.Image img = (Sbn.AdvancedControls.Imaging.SbnPaint.Image)shape;
                //        Element el = (Element)img.Tag;// (Element)img.Bitmap.Tag;

                //        Image img2;
                //        double ll = Math.Truncate(this.drawingPanel1.ZoomFactor * 100000);
                //        float tt = (float)(100000 / ll);


                //        if (shape is Sbn.AdvancedControls.Imaging.SbnPaint.Image)
                //        {
                //            img = (Sbn.AdvancedControls.Imaging.SbnPaint.Image)shape;
                //            img2 = img.Bitmap;
                //           // img2 = bmp;// shape.Appearance.Image;

                //        }
                //        else
                //        {
                //            img2 = img.getImageFromShape(img, this.drawingPanel1.ZoomFactor);
                //        }

                //        ((Bitmap)img2).MakeTransparent(Color.White);
                //        System.IO.MemoryStream ms = new MemoryStream();
                //        img2.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                //        el.Stream = new byte[ms.Length];
                //        el.Stream = ms.GetBuffer();
                //        //System.IO.MemoryStream ms2 = new System.IO.MemoryStream(strem);
                //        //System.Drawing.Image myImage = System.Drawing.Image.FromStream(ms2);
                //        //myImage.Save("c:\\temp.png", System.Drawing.Imaging.ImageFormat.Png);
                //        //Bitmap bm = new Bitmap(img2);
                //        int x = (int)(shape.Location.X - this.drawingPanel1.BackgroundLayer.Location.X);
                //        int y = (int)(shape.Location.Y - this.drawingPanel1.BackgroundLayer.Location.Y);
                //        el.LocationX = (long)(x * tt);// this.ucPaint1.drawingPanel1.HorizontalScroll.Value + film.Location.X;
                //        el.LocationY = (long)(y * tt); // this.ucPaint1.drawingPanel1.VerticalScroll.Value + film.Location.Y;
                //        el.Tag = img2;
                //        img2.Tag = el;
                //        ms.Close();
                //        ms.Dispose();

                // }
            }
            catch
            {

            }

        }

        void img_ShapeChanged(Sbn.FramWork.Drawing.IShape shape, object changing)
        {

        }

        public Sbn.AdvancedControls.Imaging.SbnPaint.DrawCurveLine DrawCurve = new Sbn.AdvancedControls.Imaging.SbnPaint.DrawCurveLine();
        public Sbn.AdvancedControls.Imaging.SbnPaint.Text DrawText = new Sbn.AdvancedControls.Imaging.SbnPaint.Text();
        public Sbn.AdvancedControls.Imaging.SbnPaint.DrawFreeLine DrawLine = new Sbn.AdvancedControls.Imaging.SbnPaint.DrawFreeLine();
        public Sbn.AdvancedControls.Imaging.SbnPaint.Draft DraftPen = new Sbn.AdvancedControls.Imaging.SbnPaint.Draft();
        public Sbn.AdvancedControls.Imaging.SbnPaint.RectangleBody RectanglePen = new Sbn.AdvancedControls.Imaging.SbnPaint.RectangleBody();

        public Font CurrentFont
        {
            get
            {
                return DrawText.Font;
            }
            set
            {

                DrawText.Font = value;
            }
        }


        private Pen _CurrentPen = new Pen(Color.Black, 10);
        public Pen CurrnetPen
        {
            get
            {
                return _CurrentPen;
            }
            set
            {
                _CurrentPen = value;

                try
                {
                    if (this.DraftPen != null)
                        this.DraftPen.CurrentPen.Width = value.Width;

                    if (this.RectanglePen != null)
                        RectanglePen.Appearance.BorderWidth = value.Width;
                }
                catch
                { }
            }
        }



        private Color _BackColorPaint = Color.White;
        public Color BackColorPaint
        {
            get
            {
                return this.drawingPanel1.BackColor; ;
            }
            set
            {
                this.drawingPanel1.BackColor = value;
            }
        }

        /// <summary>
        /// تمام لایحه یکی شده و تصویر را بر می گرداند
        /// </summary>
        /// <returns></returns>
        public Image GetMergedLayersImage()
        {

            try
            {
                var img = GetImage();
                var tool = new Sbn.Controls.Imaging.SbnImageTools();
                return tool.GetWholeImage((ImageDocument)img);
            }
            catch (Exception)
            {

                throw;
            }




            return null;
        }

        public ImageDocument GetImage()
        {
            //ApplaypActiveCurve();

            drawingPanel1.ApplaypActiveCurve();



            Layer ly = new Layer();
            Elements elms = new Elements();

            var bImage = drawingPanel1.BackgroundLayer;

            float zoomFactorTemp = bImage.Dimension.Width / bImage.Bitmap.Width;

            if (drawingPanel1.IsEditBackImage)
                CurrentImage.Stream = CurrentTools.BaseTools.GetStreamImage(bImage.Appearance.GetImage(1 / zoomFactorTemp), System.Drawing.Imaging.ImageFormat.Tiff);
            //Bitmap bmResult = new System.Drawing.Bitmap(bImage.Bitmap.Width, bImage.Bitmap.Height);
            //Graphics g = Graphics.FromImage(bmResult);
            //g.DrawImage(bImage.Bitmap, new Rectangle(0, 0, bImage.Bitmap.Width, bImage.Bitmap.Height));



            //g.Save();
            //g.Dispose();


            foreach (var film in drawingPanel1.Shapes)
            {
                if (!(film is BodyBackground))
                {
                    var el = (film as Sbn.FramWork.Drawing.Shape).Tag as Element;

                    try
                    {

                        // var tt = (1 / zoomFactorTemp);
                        int x = (int)(film.Location.X - bImage.Location.X);
                        int y = (int)(film.Location.Y - bImage.Location.Y);
                        var LocationX = (long)(x / zoomFactorTemp);
                        var LocationY = (long)(y / zoomFactorTemp);

                        if (film.Appearance.Shape == null)
                        {
                            film.Appearance.Shape = film;
                        }

                        var TEmpimg = film.Appearance.GetImage(1 / zoomFactorTemp);
                        GraphicsUnit gu = GraphicsUnit.Pixel;
                        // var rec = TEmpimg.GetBounds(ref gu);



                        if (el == null)
                        {
                            el = new Element();
                            elms.Add(el);
                        }

                        el.Stream = CurrentTools.BaseTools.GetStreamImage(TEmpimg,
                                                                          System.Drawing.Imaging.ImageFormat.Png);
                        // el.Tag = TEmpimg;
                        el.LocationX = LocationX;
                        el.LocationY = LocationY;



                        //try
                        //{
                        //    TEmpimg.Save(@"D:\2.Png");
                        //}
                        //catch (Exception)
                        //{
                        //}

                        TEmpimg.Dispose();
                        // g.DrawImage(TEmpimg, new Rectangle((int)(LocationX), (int)(LocationY), (int)(TEmpimg.Width), (int)(TEmpimg.Height)));//, TEmpimg.GetBounds(ref gu), GraphicsUnit.Pixel);
                    }
                    catch (Exception)
                    {


                    }
                }
                else
                {

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

                //if (ly.ID <= 0)
                //    ly.ID = -CurrentImage.layers.Count - 1;

                if (CurrentImage.layers == null)
                    CurrentImage.layers = new Layers();
                CurrentImage.layers.Add(ly);




            }

            //  ((BaseImage)this.CurrentImage).Image.Save("c:\\bb.jpg");


            // this.CurrentImage.layers = new Layers();
            // this.CurrentImage.layers =  getElements();
            return CurrentImage;
        }


        //        public void ApplaypActiveCurve()
        //        {

        //            try
        //            {

        //                if (myInkCollector == null || myInkCollector.Ink.Strokes.Count == 0)
        //                    return;


        //                myInkCollector.Enabled = false;
        //                System.IO.MemoryStream annms;
        //                Image AnnImg = null;
        //                try
        //                {

        //                    //save New Annotaion
        //                    var dd = myInkCollector.Ink.ClipboardCopy(InkClipboardFormats.Bitmap, InkClipboardModes.Default);
        //                    var ig = Clipboard.GetImage();
        //                    ig.Save("D:\\6.Png");
        //                    byte[] b = myInkCollector.Ink.Save(PersistenceFormat.Gif);
        //                    annms = new System.IO.MemoryStream(b);
        //                    AnnImg = Image.FromStream(annms);

        //                    annms.Close();

        //                    //try
        //                    //{
        //                    //    AnnImg.Save("C:\\hhhh.jpg" , System.Drawing.Imaging.ImageFormat.Gif);
        //                    //}
        //                    //catch
        //                    //{ 

        //                    //}

        //                    int letf = 0;
        //                    int right = 0;

        //                    Rectangle Rect = myInkCollector.Ink.Strokes[0].GetBoundingBox(Microsoft.Ink.BoundingBoxMode.Default);

        //                    foreach( Stroke strk in  myInkCollector.Ink.Strokes)
        //                    {

        //                        Rectangle recTemp = strk.GetBoundingBox(Microsoft.Ink.BoundingBoxMode.Default);
        //                        if (recTemp.X < Rect.X)
        //                        { 
        //                            Rect.X = recTemp.X;
        //                        }

        //                        if (recTemp.Y < Rect.Y)
        //                        {
        //                            Rect.Y = recTemp.Y;
        //                        }


        //                    }



        //                    myInkCollector.Ink.Strokes[0].DrawingAttributes.Color = Color.Blue;

        //                    System.Drawing.Point pointTopLeft = new System.Drawing.Point(Rect.Left, Rect.Top);
        //                    System.Drawing.Point pointBottomRight = new System.Drawing.Point(Rect.Left , Rect.Top );
        //                    pointBottomRight.Offset(Rect.Width, Rect.Height);
        //                    myInkCollector.Renderer.InkSpaceToPixel(this.CreateGraphics(),
        //                ref pointTopLeft);
        //                    myInkCollector.Renderer.InkSpaceToPixel(this.CreateGraphics(),
        //                ref pointBottomRight);


        //                    double ll = Math.Truncate(this.drawingPanel1.ZoomFactor * 100000);
        //                    float tt = (float)(100000 / ll);

        //                    int x = (int)(pointTopLeft.X - this.drawingPanel1.BackgroundLayer.Location.X);
        //                    int y = (int)(pointTopLeft.Y - this.drawingPanel1.BackgroundLayer.Location.Y);
        //                    //int LocationX = (int)(x * tt);
        //                    //int LocationY = (int)(y * tt);

        //         //           Rectangle convertedRect = new Rectangle(x,
        //         //y, pointBottomRight.X - pointTopLeft.X,
        //         //pointBottomRight.Y - pointTopLeft.Y);

        //                    Rectangle convertedRect = new Rectangle(pointTopLeft.X,
        //                pointTopLeft.Y, pointBottomRight.X - pointTopLeft.X,
        //                pointBottomRight.Y - pointTopLeft.Y);

        //                    //

        //                    Sbn.AdvancedControls.Imaging.SbnPaint.pActiveAnnotation pActiveSh1 = new Sbn.AdvancedControls.Imaging.SbnPaint.pActiveAnnotation((Bitmap)AnnImg, new PointF(convertedRect.X, convertedRect.Y));

        ////pActiveSh1.Dimension = new SizeF(new PointF(convertedRect.X, convertedRect.Y));
        //                    myInkCollector.Enabled = false;
        //                    this.drawingPanel1.Shapes.Add(pActiveSh1);
        //                    pActiveSh1.Selected = true;

        //                    Strokes strokesToDelete = myInkCollector.Ink.Strokes;
        //                    myInkCollector.Ink.DeleteStrokes(strokesToDelete);

        //                    // Check to ensure that the ink collector isn't currently
        //                    // in the middle of a stroke before clearing the ink.
        //                    // Deleting a stroke that is currently being collected
        //                    // will result in an error condition.

        //                }
        //                catch
        //                {

        //                }






        //                // myInkCollector = new InkCollector();
        //                //this.Invalidate(false);
        //            }

        //            catch
        //            { }

        //        }


        private void UpdateElement(Element el)
        {
            //foreach (Layer ly in CurrentImage.layers.m_Col)
            //{ 
            //    foreach(ele
            //}
        }


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

        private void tsmnuItmDelete_Click(object sender, EventArgs e)
        {
            this.drawingPanel1.Delete();
        }

        private void tsmnuItmRedo_Click(object sender, EventArgs e)
        {
            this.drawingPanel1.Redo();
        }

        private void tsmnuItmUndo_Click(object sender, EventArgs e)
        {
            this.drawingPanel1.Undo();
        }

        private void drawingPanel1_DeleteingShape(object sender, EventArgs e)
        {

            if (CurrentImage == null)
                return;




            int elementIndex = -1;
            int layerIndex = -1;
            Element removedElement = null;
            Layer removedLayer = null;
            if (CurrentImage.layers != null)
            {
                for (int i = 0; i < CurrentImage.layers.Count; i++)
                {
                    if (((Layer)((IList)CurrentImage.layers)[i]).elements != null)
                    {
                        for (int j = 0; j < ((Layer)((IList)CurrentImage.layers)[i]).elements.Count; j++)
                        {
                            Element el = ((Element)((IList)((Layer)((IList)CurrentImage.layers)[i]).elements)[j]);
                            if (el == (Element)((Sbn.FramWork.Drawing.Shape)sender).Tag)
                            {
                                elementIndex = j;
                                layerIndex = i;
                                removedElement = (Element)((IList)((Layer)((IList)CurrentImage.layers)[i]).elements)[j];
                                removedLayer = (Layer)((IList)CurrentImage.layers)[i];
                                break;
                            }
                        }
                        if (elementIndex != -1)
                            break;
                    }
                }


                if (elementIndex != -1)
                {
                    ((Layer)((IList)CurrentImage.layers)[layerIndex]).elements.RemoveAt(elementIndex);
                    if (DeletedElement != null)
                    {
                        DeletedElement(removedElement, e);
                    }

                    if (((Layer)((IList)CurrentImage.layers)[layerIndex]).elements.Count == 0)
                    {
                        CurrentImage.layers.RemoveAt(layerIndex);

                        if (DeletedLayer != null)
                        {
                            DeletedLayer(removedLayer, e);
                        }
                    }
                }
            }

        }

        private void btnShape_Click(object sender, EventArgs e)
        {
            //Sbn.FramWork.Drawing.PolygonAppearance pl = new Sbn.FramWork.Drawing.PolygonAppearance();
            //pl.BackgroundColor2 = Color.Yellow;
            //pl.BorderWidth = 1;
            //pl.BorderColor = Color.Yellow;
            //pl.GradientAngle = 90;



            //this.RectanglePen.Appearance = pl;
            //this.ActiveTool = ActiveTools.Rect;
            //this.ActiveTool = ActiveTools.Rect;
        }

        private void tsbtnApplay_Click(object sender, EventArgs e)
        {
            // ApplaypActiveCurve();
            if (OnApplay != null)
            {

                OnApplay(drawingPanel1.IsEditBackImage, e);

            }
            drawingPanel1.IsEditBackImage = false;
        }

        private void tsbtnCancel_Click(object sender, EventArgs e)
        {
            // ApplaypActiveCurve();
            if (OnCancel != null)
            {
                OnCancel(sender, e);
            }

        }

        public void Clear()
        {
            this.drawingPanel1.ClearImage();

            // DrawCurve = new Sbn.AdvancedControls.Imaging.SbnPaintDrawCurveLine();
            // ActiveTool = _ActiveTool;

        }


        private void btnBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // btnBackColor.ColorBase = colorDialog1.Color;

                // this.BackColorPaint = btnBackColor.ColorBase;
                if (this.DraftPen != null)
                    this.DraftPen.CurrentPen.Color = colorDialog1.Color;

            }
        }

        private void tsbtnRemoveLayer_Click(object sender, EventArgs e)
        {
            drawingPanel1.Delete();

            if (DrawLine != null)
            {
                DrawLine.group = new Sbn.FramWork.Drawing.CompositeShape();
            }
        }

        private void tsbtnZoomIn_Click(object sender, EventArgs e)
        {
            //this.ApplaypActiveCurve();
            this.drawingPanel1.Zoom = 1.1f;


        }

        private void tsbtnZoomOut_Click(object sender, EventArgs e)
        {
            // this.ApplaypActiveCurve();
            this.drawingPanel1.Zoom = 0.9f;

        }

        private void drawingPanel1_Scroll(object sender, ScrollEventArgs e)
        {
            // this.ApplaypActiveCurve();
        }


        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (penSelectorViewStrip1 == null)
                return;

            this.CurrnetPen.Width = this.penSelectorViewStrip1.PenSelector.SelectedPenWidth;
            this.CurrnetPen = this.CurrnetPen;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            var penSelectorViewStrip = this.penSelectorViewStrip1;
            if (penSelectorViewStrip != null)
                penSelectorViewStrip.PenSelector.SelectedPenWidth = this.CurrnetPen.Width;
        }

        private void tsddItmPen_DropDownOpening(object sender, EventArgs e)
        {
            var penSelectorViewStrip = this.penSelectorViewStrip3;
            if (penSelectorViewStrip != null)
                penSelectorViewStrip.PenSelector.SelectedPenWidth = this.CurrnetPen.Width;
        }

        private void tsddItmPen_DropDownClosed(object sender, EventArgs e)
        {

            this.CurrnetPen.Width = this.penSelectorViewStrip3.PenSelector.SelectedPenWidth;
            this.CurrnetPen = this.CurrnetPen;
        }


        public void SetImage(ImageDocument bimg)
        {
            //var img = new ImageDocument();
            //img.Stream = bimg.Stream;
            //img.ID = bimg.ID;
            //img.layers = bimg.layers;
            //img.Title = bimg.Title;
            //img.ThumbnailStream = bimg.ThumbnailStream;
            //img.OrderInDocument = bimg.OrderInDocument;



            CurrentImage = bimg;

            drawingPanel1.FitToWidth();


        }

        private void tsmnuItmCW_Click(object sender, EventArgs e)
        {
            // this.drawingPanel1.ActiveTool = new Rotate();
            this.drawingPanel1.BackgroundLayer.Locked = false;
            this.drawingPanel1.BackgroundLayer.Selected = true;

            this.drawingPanel1.BackgroundLayer.Bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
            this.drawingPanel1.BackgroundLayer.Rotation = 90;
            this.drawingPanel1.BackgroundLayer.Locked = true;
            this.drawingPanel1.BackgroundLayer.Selected = false;
            //drawingPanel1.Invalidate();
            drawingPanel1.FitToWidth();
            drawingPanel1.IsEditBackImage = true;
            //drawingPanel1.UpdateDrawPanelSize();

        }

        private void tsmnuItmCCW_Click(object sender, EventArgs e)
        {
            this.drawingPanel1.BackgroundLayer.Locked = false;
            this.drawingPanel1.BackgroundLayer.Selected = true;

            this.drawingPanel1.BackgroundLayer.Bitmap.RotateFlip(RotateFlipType.Rotate90FlipXY);
            this.drawingPanel1.BackgroundLayer.Rotation = -90;
            this.drawingPanel1.BackgroundLayer.Locked = true;
            this.drawingPanel1.BackgroundLayer.Selected = false;
            //drawingPanel1.Invalidate();
            drawingPanel1.FitToWidth();
            drawingPanel1.IsEditBackImage = true;
        }
    }
}
