using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;

using Sbn.FramWork.Drawing;
using Sbn.FramWork.Drawing.Serialization;

namespace Sbn.AdvancedControls.Imaging.SbnPaint
{
    /// <summary>
    /// Text shape.
    /// </summary>
    [XmlClassSerializable("text")]
    public class Text : Shape
    {
        #region Added properties to serialize

        float _fontSize = 0;
        [XmlFieldSerializable("fontSize")]
        float FontSize
        {
            get { return _font.Size; }
            set
            {
                _fontSize = value;
                UpdateAfterLoad();
            }
        }

        FontStyle _fontStyle = FontStyle.Regular;
        [XmlFieldSerializable("fontStyle")]
        int FontStyleEnum
        {
            get { return (int)_font.Style; }
            set
            {
                _fontStyle = (FontStyle)value;
                UpdateAfterLoad();
            }
        }

        GraphicsUnit _fontGraphicUnit = GraphicsUnit.Pixel;
        [XmlFieldSerializable("fontGraphicsUnit")]
        int FontGraphicUnitEnum
        {
            get { return (int)_font.Unit; }
            set
            {
                _fontGraphicUnit = (GraphicsUnit)value;
                UpdateAfterLoad();
            }
        }

        string _fontFamily = string.Empty;
        [XmlFieldSerializable("fontFamily")]
        string FontFamilyString
        {
            get { return _font.FontFamily.GetName(0); }
            set
            {
                _fontFamily = value;
                UpdateAfterLoad();
            }
        }

        /// <summary>
        /// Create the font after all fields of the font are ready.
        /// </summary>
        private void UpdateAfterLoad()
        {
            if (_fontSize > 0 && _fontFamily != string.Empty)
                _font = new Font(new FontFamily(_fontFamily), _fontSize, _fontStyle, _fontGraphicUnit);

            UpdateText();
        }

        #endregion

        #region Data Members

        float _degree = 0.0f;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Text()
        {
            Geometric.Reset();
            Geometric.AddLine(0,0,1,1);
            //Geometric.AddString(_displayedText, _font.FontFamily, (int)_font.Style, _font.Size, Geometric.GetBounds(), _stringFormat);
           // Geometric.FillMode = System.Drawing.Drawing2D.FillMode.Winding;
            this.Transformer.RotateOccurred += new RotateHandler(Transformer_RotateOccurred);
            ((PolygonAppearance) this.Appearance).BackgroundColor1 = Color.Black;
            ((PolygonAppearance)this.Appearance).BackgroundColor2 = Color.Black;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="text">Text to copy.</param>
        public Text(Text text)
            : base(text)
        {
            _displayedText = text.DisplayedText;
            _font = text.Font.Clone() as Font;
            _stringFormat = text.StringFormat.Clone() as StringFormat;
            _degree = text._degree;
           // Geometric.FillMode = System.Drawing.Drawing2D.FillMode.Winding;
            this.Transformer.RotateOccurred += new RotateHandler(Transformer_RotateOccurred);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="text">Text to view.</param>
        /// <param name="font">Text font.</param>
        /// <param name="stringFormat">String format text.</param>
        public Text(string text, Font font, StringFormat stringFormat)
        {
            if (text != string.Empty)
                _displayedText = text;
            this.Locked = true;
            _font = font;
            _stringFormat = stringFormat;

            Geometric.AddString(text, _font.FontFamily, (int)_font.Style, _font.Size, Geometric.GetBounds(), _stringFormat);
          //  Geometric.FillMode = System.Drawing.Drawing2D.FillMode.Winding;

            this.Transformer.RotateOccurred += new RotateHandler(Transformer_RotateOccurred);
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
            Text tx = new Text(this);
            tx.Tag = Tag;
            return tx;
           // return new Text(this);
        }

        #endregion

        #endregion

        #region Properties

        string _displayedText = "-";
        /// <summary>
        /// Gets or sets (protected) the displayed text.
        /// </summary>
        [XmlFieldSerializable("displayedText")]
        public string DisplayedText
        {
            get { return _displayedText; }
            
            set
            {
                _displayedText = value;
              //  this.Appearance.DisplayedText = value;
                UpdateText();
            }
        }

        Font _font = new Font(FontFamily.GenericSerif, 12);
        /// <summary>
        /// Gets or sets the text font.
        /// </summary>
        public Font Font
        {
            get { return _font; }
            
            set
            {
                _font = value;
                //this.Appearance.Font = value;
                UpdateText();
            }
        }

        StringFormat _stringFormat = new StringFormat(StringFormatFlags.NoWrap);
        /// <summary>
        /// Gets or sets the string format text.
        /// </summary>
        public StringFormat StringFormat
        {
            get { return _stringFormat; }
            
            set
            {
                _stringFormat = value;
                //this.Appearance.StringFormat = value;
                UpdateText();
            }
        }

        #endregion

        #region Protected Functions


        public override System.Drawing.Image GetImage(float ZoomFactor)
        {
            //  return base.GetImage(ZoomFactor);


            float tt = (1 / ZoomFactor);

            Text TempImage = this.Clone() as Text;
            if (TempImage != null)
            {
                TempImage.Selected = true;
                TempImage.Locked = false;

               
                TempImage.Transformer.Scale(tt,tt);
                TempImage.Transformer.Translate(-TempImage.Location.X, -TempImage.Location.Y);
                Bitmap bmpResult = new Bitmap((int)(TempImage.Dimension.Width ), (int)(TempImage.Dimension.Height ));//,  System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

                System.Drawing.Graphics gg = System.Drawing.Graphics.FromImage(bmpResult);
                gg.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                gg.DrawPath(new Pen(Color), TempImage.Geometric);
                //this.Geometric.FillMode = System.Drawing.Drawing2D.FillMode.Winding;
                
                gg.FillPath(Brushes.Black, TempImage.Geometric);
                gg.Save();

              


                gg.Dispose();

                //try
                //{

                  

                //    bmpResult.Save(@"D:\1.Png");
                //}
                //catch (Exception)
                //{


                //}

              
              
                return bmpResult;
            }

            

            bool selected = this.Selected;
            bool locked = this.Locked;
            PointF ShapeLocation = this.Location;
            

            this.Selected = true;
            this.Locked = false;

            this.Location = new PointF(0, 0);


            try
            {
                 this.Transformer.Scale(tt, tt);
            }
            catch
            {
            }

           

            Bitmap bmp = new Bitmap((int)(this.Dimension.Width + 2), (int)(this.Dimension.Height + 2));//,  System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
       
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
       
    
            //Brush bb = new System.Drawing.SolidBrush(this.Appearance.MarkerColor);
           
            //StringFormat m_Formatdd = new StringFormat();
            //m_Formatdd.Alignment = StringAlignment.Near;
            //m_Formatdd.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.DirectionRightToLeft;
            //m_Formatdd.LineAlignment = StringAlignment.Near;

            //Rectangle WFTitle = new Rectangle(0, 0, bmp.Width, bmp.Height);
            //Size ss = System.Windows.Forms.TextRenderer.MeasureText(this.DisplayedText, this.Font);
     
         //   g.DrawString(this.DisplayedText, this.Font, SystemBrushes.WindowText, WFTitle, this.StringFormat);// m_Formatdd);

            Transformer.Translate(-this.Location.X, -this.Location.Y);

            Pen pn = new Pen(Brushes.Black, 1);
            this.Appearance.ActivePen = pn;

            

            g.DrawPath(this.Appearance.ActivePen, this.Geometric);
            //this.Geometric.FillMode = System.Drawing.Drawing2D.FillMode.Winding;
            g.FillPath(Brushes.Black, this.Geometric);
            g.Dispose();
         //   bmp.Save("c:\\kkk.jpg");
            this.Location = ShapeLocation;
            this.Selected = selected;
            this.Locked = locked;
            return bmp;
        }

        virtual protected void UpdateText()
        {
           //var eee = Geometric.GetBounds();


            SizeF oldDimension = Dimension;
            PointF oldLocation = Location;
            float oldRotation = Rotation;

            Geometric.Reset();
            
         

           // Rectangle WFTitle = new Rectangle(0, 0, bmp.Width, bmp.Height);

             
           
        
           // Geometric.AddString(_displayedText, _font.FontFamily, (int)_font.Style, _font.Size, Geometric.GetBounds(), _stringFormat);
            //Geometric.AddString(_displayedText, this.Font.FontFamily, (int)this.Font.Style, this.Font.Size, Geometric.GetBounds(), _stringFormat);

            Geometric.AddString(_displayedText, this.Font.FontFamily, (int)this.Font.Style, this.Font.Size, new Point(0,0), _stringFormat);
            
          
            
            System.Drawing.Drawing2D.Matrix matrix = new System.Drawing.Drawing2D.Matrix();
            matrix.Rotate(_degree);
            Geometric.Transform(matrix);

            

            if (_degree != oldRotation)
                base.Rotation = _degree;

            base.Dimension = oldDimension;
            base.Location = oldLocation;
        }

        #endregion

        #region Private Functions

        void Transformer_RotateOccurred(Transformer transformer, float degree, PointF point)
        {
            _degree += degree;
        }

        #endregion
    }
}
