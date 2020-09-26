using Sbn.FramWork.Drawing.Serialization;
using System;

namespace Sbn.FramWork.Drawing
{
	[XmlClassSerializable("lineAppearance")]
	public class LineAppearance : Appearance
	{
		public LineAppearance()
		{
		}

		public LineAppearance(LineAppearance lineAppearance) : base(lineAppearance)
		{
		}

		public override object Clone()
		{
			return new LineAppearance(this);
		}
	}
}
