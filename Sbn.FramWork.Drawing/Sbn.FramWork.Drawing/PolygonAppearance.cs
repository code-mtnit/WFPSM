using Sbn.FramWork.Drawing.Core.Converters;
using Sbn.FramWork.Drawing.Serialization;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Sbn.FramWork.Drawing
{
	[XmlClassSerializable("polygonAppearance")]
	public class PolygonAppearance : Appearance
	{
		private Color _backgroundColor1 = Color.Transparent;

		private Color _backgroundColor2 = Color.Transparent;

		private float _gradientAngle = 0f;

		public override event AppearanceHandler AppearanceChanged;

		public virtual event BackgroundColor1Handler BackgroundColor1Changed;

		public virtual event BackgroundColor2Handler BackgroundColor2Changed;

		public virtual event GradientAngleHandler GradientAngleChanged;

		[XmlFieldSerializable("backgroundColor1String")]
		private string BackGroundColor1String
		{
			get
			{
				return Sbn.FramWork.Drawing.Core.Converters.ColorConverter.StringFromColor(this._backgroundColor1, ';');
			}
			set
			{
				this._backgroundColor1 = Sbn.FramWork.Drawing.Core.Converters.ColorConverter.ColorFromString(value, ';');
			}
		}

		[XmlFieldSerializable("backgroundColor2String")]
		private string BackGroundColor2String
		{
			get
			{
				return Sbn.FramWork.Drawing.Core.Converters.ColorConverter.StringFromColor(this._backgroundColor2, ';');
			}
			set
			{
				this._backgroundColor2 = Sbn.FramWork.Drawing.Core.Converters.ColorConverter.ColorFromString(value, ';');
			}
		}

		public Color BackgroundColor1
		{
			get
			{
				return this._backgroundColor1;
			}
			set
			{
				Color backgroundColor = this._backgroundColor1;
				this._backgroundColor1 = value;
				if (this.BackgroundColor1Changed != null && backgroundColor != this._backgroundColor1)
				{
					this.BackgroundColor1Changed(this, backgroundColor, this._backgroundColor1);
				}
				if (this.AppearanceChanged != null && backgroundColor != this._backgroundColor1)
				{
					this.AppearanceChanged(this);
				}
			}
		}

		public Color BackgroundColor2
		{
			get
			{
				return this._backgroundColor2;
			}
			set
			{
				Color backgroundColor = this._backgroundColor2;
				this._backgroundColor2 = value;
				if (this.BackgroundColor2Changed != null && backgroundColor != this._backgroundColor2)
				{
					this.BackgroundColor2Changed(this, backgroundColor, this._backgroundColor2);
				}
				if (this.AppearanceChanged != null && backgroundColor != this._backgroundColor2)
				{
					this.AppearanceChanged(this);
				}
			}
		}

		[XmlFieldSerializable("gradientAngle")]
		public float GradientAngle
		{
			get
			{
				return this._gradientAngle;
			}
			set
			{
				float gradientAngle = this._gradientAngle;
				this._gradientAngle = value;
				if (this.GradientAngleChanged != null && gradientAngle != this._gradientAngle)
				{
					this.GradientAngleChanged(this, gradientAngle, this._gradientAngle);
				}
				if (this.AppearanceChanged != null && gradientAngle != this._gradientAngle)
				{
					this.AppearanceChanged(this);
				}
			}
		}

		public PolygonAppearance()
		{
		}

		public PolygonAppearance(PolygonAppearance polygonAppearance) : base(polygonAppearance)
		{
			this._backgroundColor1 = polygonAppearance._backgroundColor1;
			this._backgroundColor2 = polygonAppearance._backgroundColor2;
			this._gradientAngle = polygonAppearance._gradientAngle;
		}

		public override object Clone()
		{
			return new PolygonAppearance(this);
		}

		public override void Paint(IDocument document, PaintEventArgs e)
		{
			base.Paint(document, e);
			this.DrawBackground(document, e);
		}

		protected virtual void DrawBackground(IDocument document, PaintEventArgs e)
		{
			if (base.Image == null && base.IsValidGeometric(base.Shape.Geometric))
			{
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(base.Shape.Geometric.GetBounds(), this._backgroundColor1, this._backgroundColor2, this._gradientAngle, true))
				{
					e.Graphics.FillPath(linearGradientBrush, base.Shape.Geometric);
				}
			}
		}
	}
}
