using Sbn.FramWork.Drawing.Core.Converters;
using Sbn.FramWork.Drawing.Serialization;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Sbn.FramWork.Drawing
{
	[XmlClassSerializable("appearance")]
	public abstract class Appearance : ICloneable
	{
		private IShape _shape = null;

		private int _markerDimension = 4;

		private Image _image = null;

		private Color _markerColor = Color.Black;

		private Pen _activePen = new Pen(Color.Black);

		private Color _borderColor = Color.Black;

		private float _borderWidth = 1f;

		private int _grabberDimension = 6;

		public virtual event AppearanceHandler AppearanceChanged;

		public virtual event MarkerDimensionHandler MarkerDimensionChanged;

		public virtual event MarkerColorHandler MarkerColorChanged;

		public virtual event BorderColorHandler BorderColorChanged;

		public virtual event BorderWidthHandler BorderWidthChanged;

		public virtual event GrabberDimensionHandler GrabberDimensionChanged;

		public virtual event ActivePenHandler ActivePenChanged;

		[XmlFieldSerializable("penWidth")]
		private float PenWidth
		{
			get
			{
				return this._activePen.Width;
			}
			set
			{
				this._activePen.Width = value;
			}
		}

		[XmlFieldSerializable("PenColorString")]
		private string PenColorString
		{
			get
			{
				return Sbn.FramWork.Drawing.Core.Converters.ColorConverter.StringFromColor(this._activePen.Color, ';');
			}
			set
			{
				this._activePen.Color = Sbn.FramWork.Drawing.Core.Converters.ColorConverter.ColorFromString(value, ';');
			}
		}

		[XmlFieldSerializable("borderColorString")]
		private string BorderColorString
		{
			get
			{
				return Sbn.FramWork.Drawing.Core.Converters.ColorConverter.StringFromColor(this._borderColor, ';');
			}
			set
			{
				this._borderColor = Sbn.FramWork.Drawing.Core.Converters.ColorConverter.ColorFromString(value, ';');
			}
		}

		[XmlFieldSerializable("markerColorString")]
		private string MarkerColorString
		{
			get
			{
				return Sbn.FramWork.Drawing.Core.Converters.ColorConverter.StringFromColor(this._markerColor, ';');
			}
			set
			{
				this._markerColor = Sbn.FramWork.Drawing.Core.Converters.ColorConverter.ColorFromString(value, ';');
			}
		}

		[Browsable(false)]
		public IShape Shape
		{
			get
			{
				return this._shape;
			}
			set
			{
				this._shape = value;
			}
		}

		[XmlFieldSerializable("markerDimension")]
		public int MarkerDimension
		{
			get
			{
				return this._markerDimension;
			}
			set
			{
				int markerDimension = this._markerDimension;
				this._markerDimension = value;
				if (this._markerDimension < 4)
				{
					this._markerDimension = 4;
				}
				if (this.MarkerDimensionChanged != null && markerDimension != this._markerDimension)
				{
					this.MarkerDimensionChanged(this, markerDimension, this._markerDimension);
				}
				if (this.AppearanceChanged != null && markerDimension != this._markerDimension)
				{
					this.AppearanceChanged(this);
				}
			}
		}

		public Image Image
		{
			get
			{
				return this._image;
			}
			set
			{
				this._image = value;
			}
		}

		public Color MarkerColor
		{
			get
			{
				return this._markerColor;
			}
			set
			{
				Color markerColor = this._markerColor;
				this._markerColor = value;
				if (this.MarkerColorChanged != null && markerColor != this._markerColor)
				{
					this.MarkerColorChanged(this, markerColor, this._markerColor);
				}
				if (this.AppearanceChanged != null && markerColor != this._markerColor)
				{
					this.AppearanceChanged(this);
				}
			}
		}

		[Browsable(false)]
		public Pen ActivePen
		{
			get
			{
				return this._activePen;
			}
			set
			{
				if (this._activePen == null)
				{
					throw new ApplicationException();
				}
				if (this.ActivePenChanged != null && this._activePen != value)
				{
					this.ActivePenChanged(this, this._activePen, value);
				}
				if (this.AppearanceChanged != null && this._activePen != value)
				{
					this.AppearanceChanged(this);
				}
				this._activePen = value;
			}
		}

		public Color BorderColor
		{
			get
			{
				return this._borderColor;
			}
			set
			{
				Color borderColor = this._borderColor;
				this._borderColor = value;
				if (this._activePen != null)
				{
					this._activePen.Color = value;
				}
				if (this.BorderColorChanged != null && borderColor != this._borderColor)
				{
					this.BorderColorChanged(this, borderColor, this._borderColor);
				}
				if (this.AppearanceChanged != null && borderColor != this._borderColor)
				{
					this.AppearanceChanged(this);
				}
			}
		}

		[XmlFieldSerializable("borderWidth")]
		public float BorderWidth
		{
			get
			{
				return this._borderWidth;
			}
			set
			{
				float borderWidth = this._borderWidth;
				this._borderWidth = value;
				if (this._activePen != null)
				{
					this._activePen.Width = value;
				}
				if (this.BorderWidthChanged != null && borderWidth != this._borderWidth)
				{
					this.BorderWidthChanged(this, borderWidth, this._borderWidth);
				}
				if (this.AppearanceChanged != null && borderWidth != this._borderWidth)
				{
					this.AppearanceChanged(this);
				}
			}
		}

		[XmlFieldSerializable("grabberDimension")]
		public int GrabberDimension
		{
			get
			{
				return this._grabberDimension;
			}
			set
			{
				int grabberDimension = this._grabberDimension;
				this._grabberDimension = value;
				if (this._grabberDimension < 3)
				{
					this._grabberDimension = 3;
				}
				if (this.GrabberDimensionChanged != null && grabberDimension != this._grabberDimension)
				{
					this.GrabberDimensionChanged(this, grabberDimension, this._grabberDimension);
				}
				if (this.AppearanceChanged != null && grabberDimension != this._grabberDimension)
				{
					this.AppearanceChanged(this);
				}
			}
		}

		public Appearance()
		{
			this._borderWidth = 2f;
		}

		public Appearance(Appearance appearance)
		{
			this._markerDimension = appearance._markerDimension;
			this._markerColor = appearance._markerColor;
			this._borderColor = appearance._borderColor;
			this._borderWidth = appearance._borderWidth;
			this._grabberDimension = appearance._grabberDimension;
			this._activePen = (appearance._activePen.Clone() as Pen);
		}

		public abstract object Clone();

		public void PiantFreeLine(Graphics g, PointF[] points, GraphicsPath path, byte[] PathType, Pen pen)
		{
			if (points.Length != 0)
			{
				Collection<PointF[]> collection = new Collection<PointF[]>();
				Collection<PointF> collection2 = new Collection<PointF>();
				pen.Color = Color.Blue;
				pen.MiterLimit = 1f;
				pen.EndCap = LineCap.Round;
				pen.StartCap = LineCap.Round;
				g.SmoothingMode = SmoothingMode.HighQuality;
				for (int i = 0; i < PathType.Length; i++)
				{
					if (PathType[i].ToString() != "0")
					{
						collection2.Add(points[i]);
					}
					else if (i == 0)
					{
						collection2.Add(points[i]);
					}
					else
					{
						collection.Add(this.ToPointF(collection2));
						collection2.Clear();
					}
				}
				collection.Add(this.ToPointF(collection2));
				if (collection.Count > 0)
				{
					foreach (PointF[] current in collection)
					{
						if (current != null && current.Length > 1)
						{
							g.DrawCurve(pen, current);
						}
					}
				}
			}
		}

		private byte[] getPathType(Collection<byte> collection)
		{
			byte[] result;
			if (collection == null || collection.Count == 0)
			{
				result = null;
			}
			else
			{
				byte[] array = new byte[collection.Count];
				collection.CopyTo(array, 0);
				result = array;
			}
			return result;
		}

		public virtual void Paint(IDocument document, PaintEventArgs e)
		{
			if (this._shape.Visible && this.IsValidGeometric(this._shape.Geometric))
			{
				float width = this._shape.Dimension.Width;
				float height = this._shape.Dimension.Height;
				this._activePen.StartCap = LineCap.Round;
				this._activePen.EndCap = LineCap.Round;
				if (this.Image != null)
				{
					try
					{
						e.Graphics.DrawImage(this.Image, this._shape.Location.X, this._shape.Location.Y, (float)((int)this._shape.Dimension.Width), (float)((int)this._shape.Dimension.Height));
					}
					catch
					{
					}
				}
				else
				{
					try
					{
						if (!(this._shape is CompositeShape))
						{
							e.Graphics.DrawPath(new Pen(this._shape.Appearance.BorderColor, this._shape.Appearance.BorderWidth), this._shape.Geometric);
						}
					}
					catch (Exception var_2_143)
					{
					}
				}
				this.DrawSelection(document, e);
				this.DrawMarkers(document, e);
			}
		}

		public Image GetImage(float ZoomRate)
		{
			Image result;
			if (this.Shape == null)
			{
				result = null;
			}
			else
			{
				Shape shape = this.Shape.Clone() as Shape;
				if (shape != null)
				{
					PointF grabberPoint = shape.GetGrabberPoint(HitPositions.BottomLeft);
					shape.Transformer.Scale(ZoomRate, ZoomRate, grabberPoint);
					shape.Transformer.ForceTranslate(-shape.Location.X, -shape.Location.Y);
					Bitmap bitmap = new Bitmap((int)(shape.Dimension.Width + this.BorderWidth), (int)(shape.Dimension.Height + this.BorderWidth));
					Graphics graphics = Graphics.FromImage(bitmap);
					if (this.Image != null)
					{
						graphics.DrawImage(this.Image, 0, 0, (int)shape.Dimension.Width, (int)shape.Dimension.Height);
					}
					else
					{
						graphics.SmoothingMode = SmoothingMode.HighQuality;
						if (shape is CompositeShape)
						{
							foreach (IShape current in ((CompositeShape)shape).Shapes)
							{
								graphics.DrawPath(new Pen(current.Appearance.BorderColor, current.Appearance.BorderWidth), current.Geometric);
								using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(current.Geometric.GetBounds(), ((PolygonAppearance)current.Appearance).BackgroundColor1, ((PolygonAppearance)current.Appearance).BackgroundColor2, ((PolygonAppearance)current.Appearance).GradientAngle, true))
								{
									graphics.FillPath(linearGradientBrush, current.Geometric);
								}
							}
						}
						else
						{
							graphics.DrawPath(new Pen(this.BorderColor, this.BorderWidth), shape.Geometric);
							using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(shape.Geometric.GetBounds(), ((PolygonAppearance)this).BackgroundColor1, ((PolygonAppearance)this).BackgroundColor2, ((PolygonAppearance)this).GradientAngle, true))
							{
								graphics.FillPath(linearGradientBrush, shape.Geometric);
							}
						}
					}
					graphics.Save();
					graphics.Dispose();
					result = bitmap;
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		protected PointF[] ToPointF(Collection<PointF> collection)
		{
			PointF[] result;
			if (collection == null || collection.Count == 0)
			{
				result = null;
			}
			else
			{
				PointF[] array = new PointF[collection.Count];
				collection.CopyTo(array, 0);
				result = array;
			}
			return result;
		}

		protected virtual void DrawSelection(IDocument document, PaintEventArgs e)
		{
			if (this._shape.Selected && this.IsValidGeometric(this._shape.Geometric))
			{
				Rectangle rectangle = Rectangle.Round(this._shape.Geometric.GetBounds());
				Rectangle insideRect = rectangle;
				rectangle.Inflate(this._grabberDimension / 2, this._grabberDimension / 2);
				insideRect.Inflate(-this._grabberDimension / 2, -this._grabberDimension / 2);
				ControlPaint.DrawSelectionFrame(e.Graphics, true, rectangle, insideRect, document.DrawingControl.BackColor);
				Color color = Color.Green;
				if (Select.LastSelectedShape == this._shape)
				{
					color = ControlPaint.LightLight(color);
				}
				using (SolidBrush solidBrush = new SolidBrush(color))
				{
					Rectangle[] grabbers = this._shape.GetGrabbers();
					Rectangle[] array = grabbers;
					for (int i = 0; i < array.Length; i++)
					{
						Rectangle rect = array[i];
						e.Graphics.FillRectangle(solidBrush, rect);
					}
				}
			}
		}

		protected virtual void DrawMarkers(IDocument document, PaintEventArgs e)
		{
			if (this._shape.Marked && this.IsValidGeometric(this._shape.Geometric))
			{
				PointF[] pathPoints = this._shape.Geometric.PathPoints;
				for (int i = 0; i < pathPoints.Length; i++)
				{
					PointF pointF = pathPoints[i];
					RectangleF value = new RectangleF(pointF.X - (float)(this.MarkerDimension / 2), pointF.Y - (float)(this.MarkerDimension / 2), (float)this.MarkerDimension, (float)this.MarkerDimension);
					using (Brush brush = new SolidBrush(this.MarkerColor))
					{
						e.Graphics.FillRectangle(brush, Rectangle.Round(value));
					}
				}
			}
		}

		protected bool IsValidGeometric(GraphicsPath geometric)
		{
			return geometric.GetBounds().Size.Width != 0f && geometric.GetBounds().Size.Height != 0f;
		}
	}
}
