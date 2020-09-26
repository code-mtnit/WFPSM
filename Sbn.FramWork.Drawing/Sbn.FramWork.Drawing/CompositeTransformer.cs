using System;
using System.Drawing;

namespace Sbn.FramWork.Drawing
{
	public class CompositeTransformer : Transformer
	{
		private CompositeShape _shape = null;

		public override event MovementHandler MovementOccurred;

		public override event TranslateHandler TranslateOccurred;

		public override event ScaleHandler ScaleOccurred;

		public override event RotateHandler RotateOccurred;

		public override event DeformHandler DeformOccurred;

		public override event MirrorHorizontalHandler MirrorHorizontalOccurred;

		public override event MirrorVerticalHandler MirrorVerticalOccurred;

		public CompositeTransformer(CompositeShape shape) : base(shape)
		{
			if (shape == null)
			{
				throw new ApplicationException();
			}
			this._shape = shape;
		}

		public override void Translate(float offsetX, float offsetY)
		{
			if (this._shape.Parent != null || (this._shape.Selected && !this._shape.Locked))
			{
				if (!this._shape.MovementContentBlocked)
				{
					foreach (IShape current in this._shape.Shapes)
					{
						current.Transformer.Translate(offsetX, offsetY);
					}
				}
				base.Translate(offsetX, offsetY);
				if (this.TranslateOccurred != null && (offsetX != 0f || offsetY != 0f))
				{
					if (this.MovementOccurred != null)
					{
						this.MovementOccurred(this);
					}
					this.TranslateOccurred(this, offsetX, offsetY);
				}
			}
		}

		public override void ForceTranslate(float offsetX, float offsetY)
		{
			if (!this._shape.MovementContentBlocked)
			{
				foreach (IShape current in this._shape.Shapes)
				{
					current.Transformer.Translate(offsetX, offsetY);
				}
			}
			base.ForceTranslate(offsetX, offsetY);
			if (this.TranslateOccurred != null && (offsetX != 0f || offsetY != 0f))
			{
				if (this.MovementOccurred != null)
				{
					this.MovementOccurred(this);
				}
				this.TranslateOccurred(this, offsetX, offsetY);
			}
		}

		public override void Scale(float scaleX, float scaleY, PointF point)
		{
			if (this._shape.Parent != null || !this._shape.Locked)
			{
				if (!this._shape.MovementContentBlocked)
				{
					foreach (IShape current in this._shape.Shapes)
					{
						current.Transformer.Scale(scaleX, scaleY, point);
					}
				}
				base.Scale(scaleX, scaleY, point);
				if (this.ScaleOccurred != null && (scaleX != 1f || scaleY != 1f))
				{
					if (this.MovementOccurred != null)
					{
						this.MovementOccurred(this);
					}
					this.ScaleOccurred(this, scaleX, scaleY, point);
				}
			}
		}

		public override void Rotate(float degree, PointF point)
		{
			if (this._shape.Parent != null || (this._shape.Selected && !this._shape.Locked))
			{
				if (!this._shape.MovementContentBlocked)
				{
					foreach (IShape current in this._shape.Shapes)
					{
						current.Transformer.Rotate(degree, point);
					}
				}
				base.Rotate(degree, point);
				if (this.RotateOccurred != null && degree != 0f)
				{
					if (this.MovementOccurred != null)
					{
						this.MovementOccurred(this);
					}
					this.RotateOccurred(this, degree, point);
				}
			}
		}

		public override void Deform(int indexPoint, PointF newPoint)
		{
			if (this._shape.Parent != null || (this._shape.Selected && !this._shape.Locked))
			{
				int num = 0;
				IShape shape = null;
				for (int i = 0; i < this._shape.Shapes.Count; i++)
				{
					shape = this._shape.Shapes[i];
					if (indexPoint < shape.Geometric.PointCount + num)
					{
						break;
					}
					num += shape.Geometric.PointCount;
				}
				if (shape != null && indexPoint != -1)
				{
					shape.Transformer.Deform(indexPoint - num, newPoint);
					PointF left = this._shape.Geometric.PathPoints[indexPoint];
					base.Deform(indexPoint, newPoint);
					if (this.DeformOccurred != null && left != newPoint)
					{
						if (this.MovementOccurred != null)
						{
							this.MovementOccurred(this);
						}
						this.DeformOccurred(this, indexPoint, newPoint);
					}
				}
			}
		}

		public override void MirrorHorizontal(float x)
		{
			if (this._shape.Parent != null || (this._shape.Selected && !this._shape.Locked))
			{
				foreach (IShape current in this._shape.Shapes)
				{
					current.Transformer.MirrorHorizontal(x);
				}
				this._shape.MovementContentBlocked = true;
				base.MirrorHorizontal(x);
				this._shape.MovementContentBlocked = false;
				if (this.MirrorHorizontalOccurred != null)
				{
					if (this.MovementOccurred != null)
					{
						this.MovementOccurred(this);
					}
					this.MirrorHorizontalOccurred(this, x);
				}
			}
		}

		public override void MirrorVertical(float y)
		{
			if (this._shape.Parent != null || (this._shape.Selected && !this._shape.Locked))
			{
				foreach (IShape current in this._shape.Shapes)
				{
					current.Transformer.MirrorVertical(y);
				}
				this._shape.MovementContentBlocked = true;
				base.MirrorVertical(y);
				this._shape.MovementContentBlocked = false;
				if (this.MirrorVerticalOccurred != null)
				{
					if (this.MovementOccurred != null)
					{
						this.MovementOccurred(this);
					}
					this.MirrorVerticalOccurred(this, y);
				}
			}
		}
	}
}
