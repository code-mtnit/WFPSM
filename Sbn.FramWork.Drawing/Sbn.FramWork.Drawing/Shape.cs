using Sbn.FramWork.Drawing.Serialization;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Sbn.FramWork.Drawing
{
	[XmlClassSerializable("shape")]
	public abstract class Shape : IShape, ICloneable, IActions
	{
		public object Tag;

		private PointF[] _geometricPoints = null;

		private byte[] _geometricTypes = null;

		internal float _rotation = 0f;

		private bool _visible = true;

		private bool _locked = false;

		private bool _selected = false;

		private GraphicsPath _geometric = new GraphicsPath();

		private Transformer _transformer = null;

		private Appearance _appearance = new PolygonAppearance();

		private bool _marked = false;

		private IShape _parent = null;

		private ContextMenuStrip _menu = null;

		private Color _Color = Color.Black;

		private bool _IsEdited = false;

		public event EventHandler EditedSahpe;

		public virtual event ShapeChangingHandler ShapeChanged;

		public virtual event MouseDownOnShape ShapeMouseDown;

		public virtual event MouseUpOnShape ShapeMouseUp;

		public virtual event MouseClickOnShape ShapeMouseClick;

		public virtual event MouseDoubleClickOnShape ShapeMouseDoubleClick;

		public virtual event MouseMoveOnShape ShapeMouseMove;

		public virtual event MouseWheel ShapeMouseWheel;

		public virtual event PaintOnShape ShapePaint;

		[XmlFieldSerializable("geometricPoints")]
		private PointF[] GeometricPoints
		{
			get
			{
				return this._geometric.PathPoints;
			}
			set
			{
				this._geometricPoints = value;
				if (this._geometricPoints != null && this._geometricTypes != null)
				{
					this._geometric = new GraphicsPath(this._geometricPoints, this._geometricTypes);
				}
			}
		}

		[XmlFieldSerializable("geometricTypes")]
		private byte[] GeometricTypes
		{
			get
			{
				return this._geometric.PathTypes;
			}
			set
			{
				this._geometricTypes = value;
				if (this._geometricPoints != null && this._geometricTypes != null)
				{
					this._geometric = new GraphicsPath(this._geometricPoints, this._geometricTypes);
				}
			}
		}

		[XmlFieldSerializable("locationX")]
		private float LocationX
		{
			get
			{
				return this.Location.X;
			}
			set
			{
				this.Location = new PointF(value, this.Location.Y);
			}
		}

		[XmlFieldSerializable("locationY")]
		private float LocationY
		{
			get
			{
				return this.Location.Y;
			}
			set
			{
				this.Location = new PointF(this.Location.X, value);
			}
		}

		[XmlFieldSerializable("width")]
		private float Width
		{
			get
			{
				return this.Dimension.Width;
			}
			set
			{
				this.Dimension = new SizeF(value, this.Dimension.Height);
			}
		}

		[XmlFieldSerializable("height")]
		private float Height
		{
			get
			{
				return this.Dimension.Height;
			}
			set
			{
				this.Dimension = new SizeF(this.Dimension.Width, value);
			}
		}

		[TypeConverter(typeof(PointFTypeConverter))]
		public PointF Location
		{
			get
			{
				return this._geometric.GetBounds().Location;
			}
			set
			{
				if (!value.IsEmpty)
				{
					if (!float.IsNaN(value.X) && !float.IsNaN(value.Y) && !float.IsInfinity(value.Y) && !float.IsInfinity(value.Y))
					{
						float offsetX = value.X - this.Location.X;
						float offsetY = value.Y - this.Location.Y;
						this._transformer.Translate(offsetX, offsetY);
					}
				}
			}
		}

		[TypeConverter(typeof(SizeFTypeConverter))]
		public SizeF Dimension
		{
			get
			{
				return this._geometric.GetBounds().Size;
			}
			set
			{
				if (!value.IsEmpty)
				{
					float scaleX = value.Width / this.Dimension.Width;
					float scaleY = value.Height / this.Dimension.Height;
					this._transformer.Scale(scaleX, scaleY);
				}
			}
		}

		[TypeConverter(typeof(PointFTypeConverter))]
		public PointF Center
		{
			get
			{
				float x = this.Location.X + this.Dimension.Width / 2f;
				float y = this.Location.Y + this.Dimension.Height / 2f;
				return new PointF(x, y);
			}
			set
			{
				float offsetX = value.X - this.Location.X - this.Dimension.Width / 2f;
				float offsetY = value.Y - this.Location.Y - this.Dimension.Height / 2f;
				this._transformer.Translate(offsetX, offsetY);
			}
		}

		[XmlFieldSerializable("rotation")]
		public float Rotation
		{
			get
			{
				return this._rotation;
			}
			set
			{
				this._rotation += value;
				this._transformer.Rotate(value);
			}
		}

		[XmlFieldSerializable("visible")]
		public virtual bool Visible
		{
			get
			{
				return this._visible;
			}
			set
			{
				this._visible = value;
				if (!value)
				{
				}
			}
		}

		public virtual bool Locked
		{
			get
			{
				return this._locked;
			}
			set
			{
				this._locked = value;
			}
		}

		public virtual bool Selected
		{
			get
			{
				return this._selected;
			}
			set
			{
				this._selected = value;
			}
		}

		[Browsable(false)]
		public GraphicsPath Geometric
		{
			get
			{
				return this._geometric;
			}
		}

		[Browsable(false)]
		public Transformer Transformer
		{
			get
			{
				return this._transformer;
			}
			set
			{
				this._transformer = value;
			}
		}

		[XmlFieldSerializable("Appearance"), TypeConverter(typeof(AppearanceTypeConverter))]
		public Appearance Appearance
		{
			get
			{
				return this._appearance;
			}
			set
			{
				this._appearance = value;
			}
		}

		[XmlFieldSerializable("marked")]
		public bool Marked
		{
			get
			{
				return this._marked;
			}
			set
			{
				bool marked = this._marked;
				this._marked = value;
				if (this.ShapeChanged != null && marked != this._marked)
				{
					this.ShapeChanged(this, this._marked);
				}
			}
		}

		[Browsable(false)]
		public IShape Parent
		{
			get
			{
				return this._parent;
			}
			internal set
			{
				this._parent = value;
			}
		}

		[Browsable(false)]
		public ContextMenuStrip Menu
		{
			get
			{
				return this._menu;
			}
			set
			{
				this._menu = value;
				if (this.ShapeChanged != null)
				{
					this.ShapeChanged(this, this._menu);
				}
			}
		}

		public Color Color
		{
			get
			{
				return this._Color;
			}
			set
			{
				this._Color = value;
				bool flag = 0 == 0;
			}
		}

		public virtual bool IsEdited
		{
			get
			{
				return this._IsEdited;
			}
			set
			{
				this._IsEdited = value;
			}
		}

		public void CommitEditShape()
		{
			if (this.EditedSahpe != null)
			{
				this.EditedSahpe(this, null);
			}
		}

		protected Shape()
		{
			this._transformer = new Transformer(this);
		}

		protected Shape(Shape shape)
		{
			this._geometric = (shape.Geometric.Clone() as GraphicsPath);
			this._transformer = new Transformer(this);
			this._appearance = (shape.Appearance.Clone() as Appearance);
			this._visible = shape.Visible;
			this._locked = shape.Locked;
			this._selected = shape.Selected;
			this._marked = shape.Marked;
			this._menu = shape.Menu;
		}

		protected Shape(GraphicsPath geometric)
		{
			this._transformer = new Transformer(this);
			this._geometric = (geometric.Clone() as GraphicsPath);
		}

		public abstract object Clone();

		public virtual void MouseDown(IDocument document, MouseEventArgs e)
		{
			if (this.ShapeMouseDown != null)
			{
				this.ShapeMouseDown(this, document, e);
			}
		}

		public virtual void MouseUp(IDocument document, MouseEventArgs e)
		{
			if (this.ShapeMouseUp != null)
			{
				this.ShapeMouseUp(this, document, e);
			}
		}

		public virtual void MouseClick(IDocument document, MouseEventArgs e)
		{
			if (this.ShapeMouseClick != null)
			{
				this.ShapeMouseClick(this, document, e);
			}
		}

		public virtual void MouseDoubleClick(IDocument document, MouseEventArgs e)
		{
			if (this.ShapeMouseDoubleClick != null)
			{
				this.ShapeMouseDoubleClick(this, document, e);
			}
		}

		public virtual void MouseMove(IDocument document, MouseEventArgs e)
		{
			if (this.ShapeMouseMove != null)
			{
				this.ShapeMouseMove(this, document, e);
			}
		}

		public virtual void MouseWheel(IDocument document, MouseEventArgs e)
		{
			if (this.ShapeMouseWheel != null)
			{
				this.ShapeMouseWheel(this, document, e);
			}
		}

		public virtual void Paint(IDocument document, PaintEventArgs e)
		{
			this._appearance.Shape = this;
			this._appearance.Paint(document, e);
			if (this.ShapePaint != null)
			{
				this.ShapePaint(this, document, e);
			}
		}

		public virtual HitPositions HitTest(Point point)
		{
			HitPositions result = HitPositions.None;
			Rectangle[] grabbers = this.GetGrabbers();
			if (grabbers[0].Contains(point))
			{
				result = HitPositions.TopLeft;
			}
			else if (grabbers[1].Contains(point))
			{
				result = HitPositions.Top;
			}
			else if (grabbers[2].Contains(point))
			{
				result = HitPositions.TopRight;
			}
			else if (grabbers[3].Contains(point))
			{
				result = HitPositions.Right;
			}
			else if (grabbers[4].Contains(point))
			{
				result = HitPositions.BottomRight;
			}
			else if (grabbers[5].Contains(point))
			{
				result = HitPositions.Bottom;
			}
			else if (grabbers[6].Contains(point))
			{
				result = HitPositions.BottomLeft;
			}
			else if (grabbers[7].Contains(point))
			{
				result = HitPositions.Left;
			}
			else if (this.Contains(point))
			{
				result = HitPositions.Center;
			}
			return result;
		}

		public bool Contains(Point point)
		{
			return this._geometric.GetBounds().Contains(point);
		}

		public bool Contains(IShape shape)
		{
			return this._geometric.GetBounds().Contains(shape.Geometric.GetBounds());
		}

		public RectangleF[] GetMarkers()
		{
			RectangleF[] result;
			if (this._geometric.PointCount == 0)
			{
				result = null;
			}
			else
			{
				RectangleF[] array = new RectangleF[this._geometric.PointCount];
				for (int i = 0; i < this._geometric.PointCount; i++)
				{
					array[i] = new RectangleF(this._geometric.PathPoints[i].X - (float)(this._appearance.MarkerDimension / 2), this._geometric.PathPoints[i].Y - (float)(this._appearance.MarkerDimension / 2), (float)this._appearance.MarkerDimension, (float)this._appearance.MarkerDimension);
				}
				result = array;
			}
			return result;
		}

		public virtual Rectangle[] GetGrabbers()
		{
			Rectangle rectangle = Rectangle.Round(this._geometric.GetBounds());
			Rectangle[] array = new Rectangle[8];
			array[0].X = rectangle.X - this._appearance.GrabberDimension / 2;
			array[0].Y = rectangle.Y - this._appearance.GrabberDimension / 2;
			array[0].Width = this._appearance.GrabberDimension;
			array[0].Height = this._appearance.GrabberDimension;
			array[1].X = rectangle.X + rectangle.Width / 2 - this._appearance.GrabberDimension / 2;
			array[1].Y = rectangle.Y - this._appearance.GrabberDimension / 2;
			array[1].Width = this._appearance.GrabberDimension;
			array[1].Height = this._appearance.GrabberDimension;
			array[2].X = rectangle.X + rectangle.Width - this._appearance.GrabberDimension / 2;
			array[2].Y = rectangle.Y - this._appearance.GrabberDimension / 2;
			array[2].Width = this._appearance.GrabberDimension;
			array[2].Height = this._appearance.GrabberDimension;
			array[3].X = rectangle.X + rectangle.Width - this._appearance.GrabberDimension / 2;
			array[3].Y = rectangle.Y + rectangle.Height / 2 - this._appearance.GrabberDimension / 2;
			array[3].Width = this._appearance.GrabberDimension;
			array[3].Height = this._appearance.GrabberDimension;
			array[4].X = rectangle.X + rectangle.Width - this._appearance.GrabberDimension / 2;
			array[4].Y = rectangle.Y + rectangle.Height - this._appearance.GrabberDimension / 2;
			array[4].Width = this._appearance.GrabberDimension;
			array[4].Height = this._appearance.GrabberDimension;
			array[5].X = rectangle.X + rectangle.Width / 2 - this._appearance.GrabberDimension / 2;
			array[5].Y = rectangle.Y + rectangle.Height - this._appearance.GrabberDimension / 2;
			array[5].Width = this._appearance.GrabberDimension;
			array[5].Height = this._appearance.GrabberDimension;
			array[6].X = rectangle.X - this._appearance.GrabberDimension / 2;
			array[6].Y = rectangle.Y + rectangle.Height - this._appearance.GrabberDimension / 2;
			array[6].Width = this._appearance.GrabberDimension;
			array[6].Height = this._appearance.GrabberDimension;
			array[7].X = rectangle.X - this._appearance.GrabberDimension / 2;
			array[7].Y = rectangle.Y + rectangle.Height / 2 - this._appearance.GrabberDimension / 2;
			array[7].Width = this._appearance.GrabberDimension;
			array[7].Height = this._appearance.GrabberDimension;
			return array;
		}

		public int GetMarkerIndex(PointF point)
		{
			RectangleF[] markers = this.GetMarkers();
			int result;
			if (markers == null)
			{
				result = -1;
			}
			else
			{
				for (int i = 0; i < markers.Length; i++)
				{
					if (markers[i].Contains(point))
					{
						result = i;
						return result;
					}
				}
				result = -1;
			}
			return result;
		}

		public virtual PointF GetGrabberPoint(HitPositions hitPosition)
		{
			PointF result;
			if (hitPosition == HitPositions.Right || hitPosition == HitPositions.BottomRight || hitPosition == HitPositions.Bottom)
			{
				result = new PointF(this.Location.X, this.Location.Y);
			}
			else if (hitPosition == HitPositions.BottomLeft || hitPosition == HitPositions.Left)
			{
				result = new PointF(this.Location.X + this.Dimension.Width, this.Location.Y);
			}
			else if (hitPosition == HitPositions.TopLeft || hitPosition == HitPositions.Top || hitPosition == HitPositions.Left)
			{
				result = new PointF(this.Location.X + this.Dimension.Width, this.Location.Y + this.Dimension.Height);
			}
			else if (hitPosition == HitPositions.TopRight)
			{
				result = new PointF(this.Location.X, this.Location.Y + this.Dimension.Height);
			}
			else
			{
				result = new PointF(0f, 0f);
			}
			return result;
		}

		public virtual Image GetImage(float ZoomFactor)
		{
			return null;
		}

		public virtual void OnEditedImage()
		{
		}
	}
}
