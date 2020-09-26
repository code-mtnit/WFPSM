using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Sbn.FramWork.Drawing
{
	public class Transformer
	{
		private IShape _shape = null;

		public virtual event MovementHandler MovementOccurred;

		public virtual event TranslateHandler TranslateOccurred;

		public virtual event ScaleHandler ScaleOccurred;

		public virtual event RotateHandler RotateOccurred;

		public virtual event DeformHandler DeformOccurred;

		public virtual event MirrorHorizontalHandler MirrorHorizontalOccurred;

		public virtual event MirrorVerticalHandler MirrorVerticalOccurred;

		[Browsable(false)]
		public IShape Shape
		{
			get
			{
				return this._shape;
			}
		}

		public Transformer(IShape shape)
		{
			if (shape == null)
			{
				throw new ApplicationException();
			}
			this._shape = shape;
		}

		public virtual void Translate(float offsetX, float offsetY)
		{
			if (this._shape.Parent != null || (this._shape.Selected && !this._shape.Locked))
			{
				using (Matrix matrix = new Matrix())
				{
					matrix.Translate(offsetX, offsetY);
					this._shape.Geometric.Transform(matrix);
				}
				if (this.TranslateOccurred != null && (offsetX != 0f || offsetY != 0f))
				{
					this.TranslateOccurred(this, offsetX, offsetY);
				}
				if (this.MovementOccurred != null && (offsetX != 0f || offsetY != 0f))
				{
					this.MovementOccurred(this);
				}
			}
		}

		public virtual void ForceTranslate(float offsetX, float offsetY)
		{
			using (Matrix matrix = new Matrix())
			{
				matrix.Translate(offsetX, offsetY);
				this._shape.Geometric.Transform(matrix);
			}
			if (this.TranslateOccurred != null && (offsetX != 0f || offsetY != 0f))
			{
				this.TranslateOccurred(this, offsetX, offsetY);
			}
			if (this.MovementOccurred != null && (offsetX != 0f || offsetY != 0f))
			{
				this.MovementOccurred(this);
			}
		}

		public void Scale(float scaleX, float scaleY)
		{
			this.Scale(scaleX, scaleY, HitPositions.BottomRight);
		}

		public void Scale(float scaleX, float scaleY, HitPositions reference)
		{
			if (this._shape.Parent != null || (this._shape.Selected && !this._shape.Locked))
			{
				if (reference != HitPositions.None && reference != HitPositions.Center)
				{
					PointF grabberPoint = this._shape.GetGrabberPoint(reference);
					this.Scale(scaleX, scaleY, grabberPoint);
				}
			}
		}

		public virtual void Scale(float scaleX, float scaleY, PointF point)
		{
			if ((double)scaleX > 0.1 && !float.IsNaN(scaleX) && !float.IsInfinity(scaleX))
			{
				if ((double)scaleY > 0.1 && !float.IsNaN(scaleY) && !float.IsInfinity(scaleY))
				{
					using (Matrix matrix = new Matrix())
					{
						matrix.Translate(-point.X, -point.Y, MatrixOrder.Append);
						matrix.Scale(scaleX, scaleY, MatrixOrder.Append);
						matrix.Translate(point.X, point.Y, MatrixOrder.Append);
						this._shape.Geometric.Transform(matrix);
					}
					if (this.ScaleOccurred != null)
					{
						this.ScaleOccurred(this, scaleX, scaleY, point);
					}
					if (this.MovementOccurred != null)
					{
						this.MovementOccurred(this);
					}
				}
			}
		}

		public void Rotate(float degree)
		{
			PointF point = new PointF(this._shape.Location.X + this._shape.Dimension.Width / 2f, this._shape.Location.Y + this._shape.Dimension.Height / 2f);
			this.Rotate(degree, point);
		}

		public virtual void Rotate(float degree, PointF point)
		{
			if (this._shape.Parent != null || (this._shape.Selected && !this._shape.Locked))
			{
				using (Matrix matrix = new Matrix())
				{
					matrix.RotateAt(degree, point);
					this._shape.Geometric.Transform(matrix);
				}
				if (this.RotateOccurred != null && degree != 0f)
				{
					this.RotateOccurred(this, degree, point);
				}
				if (this.MovementOccurred != null && degree != 0f)
				{
					this.MovementOccurred(this);
				}
			}
		}

		public virtual void Deform(int indexPoint, PointF newPoint)
		{
			if (this._shape.Parent != null || (this._shape.Selected && !this._shape.Locked))
			{
				if (indexPoint != -1 && this._shape.Geometric.PathData.Points.Length != 0)
				{
					PointF[] array = new PointF[this._shape.Geometric.PathData.Points.Length];
					this._shape.Geometric.PathData.Points.CopyTo(array, 0);
					PointF left = array[indexPoint];
					array[indexPoint] = newPoint;
					GraphicsPath addingPath = new GraphicsPath(array, this._shape.Geometric.PathTypes);
					this._shape.Geometric.Reset();
					this._shape.Geometric.AddPath(addingPath, false);
					if (this.DeformOccurred != null && left != newPoint)
					{
						this.DeformOccurred(this, indexPoint, newPoint);
					}
					if (this.MovementOccurred != null && left != newPoint)
					{
						this.MovementOccurred(this);
					}
				}
			}
		}

		public virtual void CopyPoint(int indexPoint, bool before, PointF newPoint, byte pointType)
		{
		}

		public virtual void MirrorHorizontal(float x)
		{
			if (this._shape.Parent != null || (this._shape.Selected && !this._shape.Locked))
			{
				float x2 = 2f * x - this._shape.Location.X - this._shape.Dimension.Width;
				PointF pointF = new PointF(x2, this._shape.Location.Y);
				using (Matrix matrix = new Matrix(-1f, 0f, 0f, 1f, 0f, 0f))
				{
					this._shape.Geometric.Transform(matrix);
				}
				float offsetX = pointF.X - this._shape.Location.X;
				float offsetY = pointF.Y - this._shape.Location.Y;
				this.Translate(offsetX, offsetY);
				if (this.MirrorHorizontalOccurred != null)
				{
					this.MirrorHorizontalOccurred(this, x);
				}
				if (this.MovementOccurred != null)
				{
					this.MovementOccurred(this);
				}
			}
		}

		public void MirrorHorizontal()
		{
			this.MirrorHorizontal(this._shape.Center.X);
		}

		public virtual void MirrorVertical(float y)
		{
			if (this._shape.Parent != null || (this._shape.Selected && !this._shape.Locked))
			{
				float y2 = 2f * y - this._shape.Location.Y - this._shape.Dimension.Height;
				PointF pointF = new PointF(this._shape.Location.X, y2);
				using (Matrix matrix = new Matrix(1f, 0f, 0f, -1f, 0f, 0f))
				{
					this._shape.Geometric.Transform(matrix);
				}
				float offsetX = pointF.X - this._shape.Location.X;
				float offsetY = pointF.Y - this._shape.Location.Y;
				this.Translate(offsetX, offsetY);
				if (this.MirrorVerticalOccurred != null)
				{
					this.MirrorVerticalOccurred(this, y);
				}
				if (this.MovementOccurred != null)
				{
					this.MovementOccurred(this);
				}
			}
		}

		public void MirrorVertical()
		{
			this.MirrorVertical(this._shape.Center.Y);
		}
	}
}
