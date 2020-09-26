using Sbn.FramWork.Drawing.Serialization;
using System;
using System.Drawing.Drawing2D;

namespace Sbn.FramWork.Drawing
{
	[XmlClassSerializable("customShape")]
	public class CustomShape : Shape
	{
		public CustomShape()
		{
		}

		public CustomShape(CustomShape customShape) : base(customShape)
		{
		}

		public CustomShape(GraphicsPath geometric) : base(geometric)
		{
		}

		public override object Clone()
		{
			return new CustomShape(this);
		}
	}
}
