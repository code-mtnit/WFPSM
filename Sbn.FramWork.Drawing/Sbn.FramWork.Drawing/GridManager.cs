using System;
using System.Drawing;

namespace Sbn.FramWork.Drawing
{
	public class GridManager
	{
		public delegate void ResolutionChangedHandler(GridManager sender, SizeF oldValue, SizeF newValue);

		private SizeF _resolution = new SizeF(0f, 0f);

		public virtual event GridManager.ResolutionChangedHandler ResolutionChanged;

		public SizeF Resolution
		{
			get
			{
				return this._resolution;
			}
			set
			{
				SizeF resolution = this._resolution;
				this._resolution = value;
				if (this.ResolutionChanged != null && (resolution.Width != this._resolution.Width || resolution.Height != this._resolution.Height))
				{
					this.ResolutionChanged(this, resolution, this._resolution);
				}
			}
		}

		public void SnapToGrid(ShapeCollection shapes)
		{
			foreach (IShape current in shapes)
			{
				bool selected = current.Selected;
				bool locked = current.Locked;
				current.Selected = true;
				current.Locked = false;
				current.Location = this.GetRoundedPoint(current.Location);
				current.Dimension = this.GetRoundedSize(current.Dimension);
				current.Selected = selected;
				current.Locked = locked;
			}
		}

		public float GetRoundedValue(float value, float resolution)
		{
			float num = (float)Math.Round((double)(value + resolution / 2f));
			if (resolution != 0f)
			{
				num -= num % resolution;
			}
			return num;
		}

		public PointF GetRoundedPoint(PointF point)
		{
			PointF result = new PointF((float)Math.Round((double)(point.X + this._resolution.Width / 2f)), (float)Math.Round((double)(point.Y + this._resolution.Height / 2f)));
			if (this._resolution.Height != 0f)
			{
				result = new PointF(result.X, result.Y - result.Y % this._resolution.Height);
			}
			if (this._resolution.Width != 0f)
			{
				result = new PointF(result.X - result.X % this._resolution.Width, result.Y);
			}
			return result;
		}

		public SizeF GetRoundedSize(SizeF size)
		{
			SizeF result = new SizeF((float)Math.Round((double)(size.Width + this._resolution.Width / 2f)), (float)Math.Round((double)(size.Height + this._resolution.Height / 2f)));
			if (this._resolution.Height != 0f)
			{
				result = new SizeF(result.Width, result.Height - result.Height % this._resolution.Height);
			}
			if (this._resolution.Width != 0f)
			{
				result = new SizeF(result.Width - result.Width % this._resolution.Width, result.Height);
			}
			return result;
		}
	}
}
