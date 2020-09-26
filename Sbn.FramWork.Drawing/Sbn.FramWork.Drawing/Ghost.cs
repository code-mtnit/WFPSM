using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sbn.FramWork.Drawing
{
	public class Ghost : Shape
	{
		public IShape _memoryShape = null;

		private IShape _shape = null;

		private IShape _referenceShape = null;

		private PointF _mirrorPoint = PointF.Empty;

		private HorizontalVersors _horizontalVersor = HorizontalVersors.LeftRight;

		private VerticalVersors _verticalVersor = VerticalVersors.TopBottom;

		private bool _horizontalMirror = true;

		private bool _verticalMirror = true;

		public override bool Selected
		{
			get
			{
				return base.Selected;
			}
			set
			{
				base.Selected = value;
				if (this._shape != null)
				{
					this._shape.Selected = value;
				}
			}
		}

		public override bool Visible
		{
			get
			{
				return base.Visible;
			}
			set
			{
				base.Visible = value;
				if (this._shape != null)
				{
					this._shape.Visible = value;
				}
			}
		}

		public virtual IShape Shape
		{
			get
			{
				return this._shape;
			}
			set
			{
				if (value != null)
				{
					this._referenceShape = value;
					this._memoryShape = (value.Clone() as IShape);
					this._shape = (this._memoryShape.Clone() as IShape);
					base.Geometric.Reset();
					base.Geometric.AddPath(value.Geometric, false);
					this.Selected = false;
					this.Visible = false;
				}
			}
		}

		public IShape ReferenceShape
		{
			get
			{
				return this._referenceShape;
			}
		}

		public PointF MirrorPoint
		{
			get
			{
				return this._mirrorPoint;
			}
			set
			{
				if (this._mirrorPoint == PointF.Empty)
				{
					this._mirrorPoint = value;
				}
			}
		}

		public HorizontalVersors HorizontalVersor
		{
			get
			{
				return this._horizontalVersor;
			}
			set
			{
				this._horizontalVersor = value;
			}
		}

		public VerticalVersors VerticalVersor
		{
			get
			{
				return this._verticalVersor;
			}
			set
			{
				this._verticalVersor = value;
			}
		}

		protected bool HorizontalMirror
		{
			get
			{
				return this._horizontalMirror;
			}
			set
			{
				this._horizontalMirror = value;
			}
		}

		protected bool VerticalMirror
		{
			get
			{
				return this._verticalMirror;
			}
			set
			{
				this._verticalMirror = value;
			}
		}

		public Ghost()
		{
			base.Transformer.MirrorHorizontalOccurred += new MirrorHorizontalHandler(this.Transformer_MirrorHorizontalOccurred);
			base.Transformer.MirrorVerticalOccurred += new MirrorVerticalHandler(this.Transformer_MirrorVerticalOccurred);
			base.Appearance = new GhostAppearance();
		}

		public Ghost(IShape shape)
		{
			this._referenceShape = shape;
			this._memoryShape = (shape.Clone() as IShape);
			this._shape = (this._memoryShape.Clone() as IShape);
			base.Geometric.Reset();
			base.Geometric.AddPath(shape.Geometric, false);
			this.Selected = false;
			this.Visible = false;
			base.Transformer.MirrorHorizontalOccurred += new MirrorHorizontalHandler(this.Transformer_MirrorHorizontalOccurred);
			base.Transformer.MirrorVerticalOccurred += new MirrorVerticalHandler(this.Transformer_MirrorVerticalOccurred);
			base.Appearance = new GhostAppearance();
		}

		public Ghost(Ghost ghost) : base(ghost)
		{
			this._referenceShape = ghost.Shape;
			this._memoryShape = (ghost.Shape.Clone() as IShape);
			this._shape = (this._memoryShape.Clone() as IShape);
			base.Geometric.Reset();
			base.Geometric.AddPath(ghost.Shape.Geometric, false);
			ghost.Selected = false;
			ghost.Visible = false;
			base.Transformer.MirrorHorizontalOccurred += new MirrorHorizontalHandler(this.Transformer_MirrorHorizontalOccurred);
			base.Transformer.MirrorVerticalOccurred += new MirrorVerticalHandler(this.Transformer_MirrorVerticalOccurred);
			base.Appearance = new GhostAppearance();
		}

		public override object Clone()
		{
			return new Ghost(this);
		}

		public override void MouseDown(IDocument document, MouseEventArgs e)
		{
			this._shape = (this._memoryShape.Clone() as IShape);
			if (!(this._shape is CompositeShape))
			{
				base.Geometric.Reset();
				base.Geometric.AddPath(this._shape.Geometric, false);
			}
			this.InitializeVersors(this._shape.HitTest(e.Location));
			base.MouseDown(document, e);
		}

		public override void MouseUp(IDocument document, MouseEventArgs e)
		{
			base.MouseUp(document, e);
			this.Visible = false;
			this._mirrorPoint = Point.Empty;
			this._horizontalVersor = HorizontalVersors.LeftRight;
			this._verticalVersor = VerticalVersors.TopBottom;
		}

		public override void MouseMove(IDocument document, MouseEventArgs e)
		{
			base.MouseMove(document, e);
			this.Visible = true;
			this.Selected = true;
			this.UpdateVersors(this._mirrorPoint, e.Location);
			this._shape.Location = base.Location;
			this._shape.Dimension = base.Dimension;
			document.DrawingControl.Invalidate();
		}

		public virtual void UpdateVersors(PointF mirrorPoint, Point currentPoint)
		{
			if (!(this._mirrorPoint == PointF.Empty))
			{
				HorizontalVersors horizontalVersor = this.GetHorizontalVersor(currentPoint);
				VerticalVersors verticalVersor = this.GetVerticalVersor(currentPoint);
				if (this._horizontalVersor != horizontalVersor && horizontalVersor != HorizontalVersors.Undefined && this._horizontalMirror)
				{
					base.Transformer.MirrorHorizontal(mirrorPoint.X);
					this._horizontalVersor = horizontalVersor;
				}
				if (this._verticalVersor != verticalVersor && verticalVersor != VerticalVersors.Undefined && this._verticalMirror)
				{
					base.Transformer.MirrorVertical(mirrorPoint.Y);
					this._verticalVersor = verticalVersor;
				}
			}
		}

		protected HorizontalVersors GetHorizontalVersor(Point point)
		{
			HorizontalVersors result;
			if ((float)point.X < this._mirrorPoint.X)
			{
				result = HorizontalVersors.RightLeft;
			}
			else if ((float)point.X > this._mirrorPoint.X)
			{
				result = HorizontalVersors.LeftRight;
			}
			else
			{
				result = HorizontalVersors.Undefined;
			}
			return result;
		}

		protected VerticalVersors GetVerticalVersor(Point point)
		{
			VerticalVersors result;
			if ((float)point.Y < this._mirrorPoint.Y)
			{
				result = VerticalVersors.BottomTop;
			}
			else if ((float)point.Y > this._mirrorPoint.Y)
			{
				result = VerticalVersors.TopBottom;
			}
			else
			{
				result = VerticalVersors.Undefined;
			}
			return result;
		}

		public void InitializeVersors(HitPositions hitPosition)
		{
			this._horizontalMirror = true;
			this._verticalMirror = true;
			switch (hitPosition)
			{
			case HitPositions.TopLeft:
				this._horizontalVersor = HorizontalVersors.RightLeft;
				this._verticalVersor = VerticalVersors.BottomTop;
				break;
			case HitPositions.Top:
				this._horizontalVersor = HorizontalVersors.LeftRight;
				this._verticalVersor = VerticalVersors.BottomTop;
				this._horizontalMirror = false;
				break;
			case HitPositions.TopRight:
				this._horizontalVersor = HorizontalVersors.LeftRight;
				this._verticalVersor = VerticalVersors.BottomTop;
				break;
			case HitPositions.Right:
				this._horizontalVersor = HorizontalVersors.LeftRight;
				this._verticalVersor = VerticalVersors.TopBottom;
				this._verticalMirror = false;
				break;
			case HitPositions.BottomRight:
				this._horizontalVersor = HorizontalVersors.LeftRight;
				this._verticalVersor = VerticalVersors.TopBottom;
				break;
			case HitPositions.Bottom:
				this._horizontalVersor = HorizontalVersors.LeftRight;
				this._verticalVersor = VerticalVersors.TopBottom;
				this._horizontalMirror = false;
				break;
			case HitPositions.BottomLeft:
				this._horizontalVersor = HorizontalVersors.RightLeft;
				this._verticalVersor = VerticalVersors.TopBottom;
				break;
			case HitPositions.Left:
				this._horizontalVersor = HorizontalVersors.RightLeft;
				this._verticalVersor = VerticalVersors.TopBottom;
				this._verticalMirror = false;
				break;
			}
		}

		private void Transformer_MirrorHorizontalOccurred(Transformer transformer, float x)
		{
			if (this._shape != null)
			{
				this._shape.Transformer.MirrorHorizontal(x);
			}
		}

		private void Transformer_MirrorVerticalOccurred(Transformer transformer, float y)
		{
			if (this._shape != null)
			{
				this._shape.Transformer.MirrorVertical(y);
			}
		}
	}
}
