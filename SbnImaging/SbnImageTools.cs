using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using Sbn.Controls.Imaging.EventArgsFolder;
using Sbn.Controls.Imaging.Graphic;
using Sbn.Controls.Imaging.ImagingObject;

namespace Sbn.Controls.Imaging
{
    public class SbnImageTools
    {
        [Category("Filmstrip events")]
        public event EventHandler<ImageEventArg> NeedImage;

        public void OnNeedImage(ImageEventArg e)
        {
            EventHandler<ImageEventArg> handler = NeedImage;
            if (handler != null) handler(this, e);
        }
        public ImageTools BaseTools = new ImageTools();

        public SbnImageTools()
        {
        }

        //public Bitmap GetWholeImage(ImageDocument img)
        //{
        
            
        //    if (img == null)
        //        return null;

        //    //      InitialImage(img);


        //  //  Bitmap bitmap = (Bitmap)img.Image;
        //    // BufferedGraphics bmyBuffer = null;
        //    try
        //    {
        //       // if (img.Image == null)
        //        if (img.Stream != null)
        //        {
        //            img.Image = BaseTools.GetImage(img.Stream);
        //        }

        //        Bitmap bmp = new System.Drawing.Bitmap((int)(img.Image.Width), (int)(img.Image.Height));

        //        //double widthZoomed = this.htfImageTool1.Width;
        //        //double heigthZoomed = this.htfImageTool1.Height;


        //        //    #endregion Added by rm
        //        Rectangle drawRect = new Rectangle(0, 0, img.Image.Width, img.Image.Height);



        //        Graphics g = Graphics.FromImage(bmp);
        //        //    // g.DrawImage(img.Image, this.panel1.DisplayRectangle, drawRect, GraphicsUnit.Pixel);

        //        g.DrawImage(img.Image, drawRect, drawRect, GraphicsUnit.Pixel);

        //        if (img != null)
        //        {

        //            if (img.layers != null)
        //            {
        //                foreach (Layer layer in img.layers)
        //                {
        //                    if (layer.elements != null)
        //                    {
        //                        foreach (Element el in layer.elements)
        //                        {

        //                            if ( el.Stream != null && el.Stream.Length > 10)
        //                            {
        //                            //    el.Tag = BaseTools.GetImage(el.Stream);
        //                            //}

        //                            //if (el.Tag != null && el.Tag is Image)
        //                            //{
        //                                Image TEmpimg = BaseTools.GetImage(el.Stream);
        //                                //      TEmpimg.Save("c:\\pppp.jpg");
        //                                //                            int x = 0;
        //                                //                            if (this.htfImageTool1.DisplayRectangle.Size.Width > img.Image.Width * Zoom)
        //                                //                                x = (int)((this.panel1.DisplayRectangle.Size.Width - img.Image.Width * Zoom) / 2);

        //                                //                            int y = 0;
        //                                //                            if (this.htfImageTool1.DisplayRectangle.Size.Height > img.Image.Height * Zoom)
        //                                //                                y = (int)((this.htfImageTool1.DisplayRectangle.Size.Height - img.Image.Height * Zoom) / 2);


        //                                GraphicsUnit gu = GraphicsUnit.Pixel;
        //                                var rec = TEmpimg.GetBounds(ref gu);
        //                                // g.DrawImage(TEmpimg, new Rectangle((int)(el.LocationX * htfImageTool1.Zoom) + x, (int)(el.LocationY * htfImageTool1.Zoom) + y, (int)(TEmpimg.Width * htfImageTool1.Zoom), (int)(TEmpimg.Height * htfImageTool1.Zoom)), TEmpimg.GetBounds(ref gu), GraphicsUnit.Pixel);
        //                                g.DrawImage(TEmpimg, new Rectangle((int)(el.LocationX), (int)(el.LocationY), (int)(TEmpimg.Width), (int)(TEmpimg.Height)), TEmpimg.GetBounds(ref gu), GraphicsUnit.Pixel);
        //                                //                        }
        //                                //                        else if (el.Stream != null)
        //                                //                        {

        //                                TEmpimg.Dispose();

        //                            }

        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        g.Dispose();
        //        //System.IO.MemoryStream ms1 = new System.IO.MemoryStream();
        //        //bmp.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        //ms1.Dispose();
        //        return bmp;
        //        // return bitmap;

        //    }
        //    catch (Exception ex)
        //    {
        //        //    if (bmyBuffer != null)
        //        //        bmyBuffer.Dispose();
        //        return (Bitmap)img.Image;
        //        //return null;
        //    }


        //}


        public Bitmap GetWholeImage(ImageDocument imgDoc)
        {
            if (imgDoc == null)
                return null;


            InitialImage(imgDoc);
            //  Bitmap bitmap = (Bitmap)img.Image;
            // BufferedGraphics bmyBuffer = null;
            try
            {
                // if (img.Image == null)
                if (imgDoc.Stream == null)
                {
                    return null;
                    //img.Image = BaseTools.GetImage(imgDoc.Stream);
                }


                using (Image img = BaseTools.GetImage(imgDoc.Stream))
                {
                    Bitmap bmp =  new System.Drawing.Bitmap((int)(img.Width), (int)(img.Height));

                    Rectangle drawRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                    Graphics g = Graphics.FromImage(bmp);
                     g.DrawImage(img, drawRect, drawRect, GraphicsUnit.Pixel);
                   // img.Save(@"D:\ui.tif");
                    if (imgDoc != null)
                    {
                        if (imgDoc.layers != null)
                        {
                            foreach (Layer layer in imgDoc.layers)
                            {
                                if (layer.elements != null)
                                {
                                    foreach (Element el in layer.elements)
                                    {

                                        if (el.Stream != null && el.Stream.Length > 10)
                                        {
                                            Image TEmpimg = BaseTools.GetImage(el.Stream);

                                            GraphicsUnit gu = GraphicsUnit.Pixel;
                                            var rec = TEmpimg.GetBounds(ref gu);
                                            // g.DrawImage(TEmpimg, new Rectangle((int)(el.LocationX * htfImageTool1.Zoom) + x, (int)(el.LocationY * htfImageTool1.Zoom) + y, (int)(TEmpimg.Width * htfImageTool1.Zoom), (int)(TEmpimg.Height * htfImageTool1.Zoom)), TEmpimg.GetBounds(ref gu), GraphicsUnit.Pixel);
                                            g.DrawImage(TEmpimg, new Rectangle((int)(el.LocationX), (int)(el.LocationY), (int)(TEmpimg.Width), (int)(TEmpimg.Height)), TEmpimg.GetBounds(ref gu), GraphicsUnit.Pixel);
                                            //                        }
                                            //                        else if (el.Stream != null)
                                            //                        {

                                            TEmpimg.Dispose();

                                        }

                                    }
                                }
                            }
                        }
                    }

                    g.Dispose();
                    //System.IO.MemoryStream ms1 = new System.IO.MemoryStream();
                    //bmp.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //ms1.Dispose();
                    return bmp;
                    // return bitmap;
                }



            

            }
            catch (Exception ex)
            {
                //    if (bmyBuffer != null)
                //        bmyBuffer.Dispose();
                return null;
                //return null;
            }


        }



        public ImageDocument InitialImage(ImageDocument img)
        {
            //try
            //{
            //    img.Image.Save("c:\\aeae.jpeg");
            //}
            //catch
            //{ }

            try
            {
                if (img.Stream == null || img.Stream.Length < 10)
                {
                    
                    if (Path.IsPathRooted(img.Description) && File.Exists(img.Description))
                    {
                        img.Stream = File.ReadAllBytes(img.Description);
                        //using (Image image = Image.FromFile(img.Description))
                        //{
                        //    img.Stream = BaseTools.GetStreamImage(image, System.Drawing.Imaging.ImageFormat.Tiff);
                        //}
                    }
                    else
                    {
                        OnNeedImage(new ImageEventArg(img));
                    }
                }
                return img;
            }
            catch
            { }

            return null;
        }





        public byte[] GetThumbnailStream(byte[] stream , int width , int height , double scaleRatio)
        {
            byte[] resuly = null;
            using (var img = BaseTools.GetImage(stream))
            {
                if (img != null)
                {
                    using (var imgScaled = BaseTools.ScaleImage(img,width,height,scaleRatio))
                    {
                        if (imgScaled != null)
                        {
                            resuly = BaseTools.GetStreamImage(imgScaled, System.Drawing.Imaging.ImageFormat.Tiff);

                        }
                    }
                }
            }


            return resuly;
        }
       
    }
}
