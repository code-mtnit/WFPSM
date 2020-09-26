using System;
using System.Collections.Generic;
using System.Text;


using System.Drawing;

namespace Sbn.AdvancedControls.Imaging.SbnPaint
{
    public class BodyBackground : Image 
    {
        
       // public override void Paint(IDocument document, System.Windows.Forms.PaintEventArgs e)
       //{
       //     //if (_bitmap != null)
       //     //    e.Graphics.DrawImage(_bitmap, Location.X, Location.Y, Dimension.Width, Dimension.Height);
       //}


        #region Properties

        Bitmap _bitmap = null;
        /// <summary>
        /// Gets or sets the bitmap image.
        /// </summary>
        public Bitmap Bitmap
        {
            get { return _bitmap; }
            set
            {

                //if (value != null)
                //{

                //    value.RotateFlip(RotateFlipType.Rotate90FlipNone);
                //    value.RotateFlip(RotateFlipType.Rotate90FlipXY);
                //}
                _bitmap = value;
            }
        }

        #endregion
      

        #region Constructors

           /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="bitmap">Reference bitmap.</param>
        public BodyBackground(Bitmap bitmap , PointF location)
        {
           // Geometric.AddLine(new Point(0, 0), new Point(1, 1));
           // Geometric.AddRectangle(new System.Drawing.Rectangle(0, 0, 1, 1));
           // bitmap.Save("D:\\4545.jpg");
            if (bitmap != null)
            {
                Selected = false;
                Locked = true;
              // if (Dimension.Width == 1 && Dimension.Height == 1)
                if (Dimension.IsEmpty)
                    Geometric.AddRectangle(new System.Drawing.RectangleF(location.X, location.Y, bitmap.Width, bitmap.Height));

                
               // Dimension = new SizeF(bitmap.Width, bitmap.Height);
               // var rec = Geometric.GetBounds();

                //bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                //bitmap.RotateFlip(RotateFlipType.Rotate90FlipXY);
                _bitmap = bitmap;//.Clone() as Bitmap;
                this.Appearance.Image = bitmap;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BodyBackground()
        {
           // Geometric.AddRectangle(new System.Drawing.Rectangle(0, 0, 1, 1));
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="rectangle">Rectangle to copy.</param>
        public BodyBackground(BodyBackground rectangle)
            : base(rectangle)
        {
        }

        #endregion



        public override object Clone()
        {
            var NewBgImage = new BodyBackground();

            if (Bitmap != null)
            {
              

               // if (Dimension.Width == 1 && Dimension.Height == 1)
                if (Dimension.IsEmpty)
                   NewBgImage.Geometric.AddRectangle(new System.Drawing.Rectangle(0, 0, Bitmap.Width, Bitmap.Height));
                else
                {
                  //  var rec = Geometric.GetBounds();
                    NewBgImage.Geometric.AddRectangle(Geometric.GetBounds()); 
                }

              
                // Dimension = new SizeF(bitmap.Width, bitmap.Height);
                NewBgImage.Location = Location;
                NewBgImage.Locked = Locked;
                NewBgImage.Selected = Selected;
                NewBgImage.Rotation = Rotation;
                NewBgImage.Tag = Tag;
                NewBgImage.Visible = Visible;
               // Bitmap.Save("d:\\4545.jpg");

                // اگر دوخط زیر را حذف کنیم هنگام چرخاندن یا ذخیره نمودن تصویر پیغام خطا ظاهر خواهد شد مانند 5 خط پایین تر که سعی می شود در آن تصویر چرخانده شود

             //  Bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                //Bitmap.RotateFlip(RotateFlipType.Rotate90FlipXY);
               
                NewBgImage.Bitmap = Bitmap.Clone() as Bitmap;
               
                try
                {
                   // Bitmap.Save("d:\\4545.jpg");
                  // Bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                  //  NewBgImage.Bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);    
                }
                catch (Exception)
                {
                    
                    
                }
                
                NewBgImage.Appearance.Image = NewBgImage.Bitmap;
            }
            return NewBgImage;
        }
    }
}
