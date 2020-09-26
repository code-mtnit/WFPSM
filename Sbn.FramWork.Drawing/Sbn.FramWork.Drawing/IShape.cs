using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Sbn.FramWork.Drawing
{
	public interface IShape : ICloneable, IActions
	{
		event ShapeChangingHandler ShapeChanged;

		event MouseDownOnShape ShapeMouseDown;

		event MouseUpOnShape ShapeMouseUp;

		event MouseClickOnShape ShapeMouseClick;

		event MouseDoubleClickOnShape ShapeMouseDoubleClick;

		event MouseMoveOnShape ShapeMouseMove;

		event MouseWheel ShapeMouseWheel;

		event PaintOnShape ShapePaint;

		event EventHandler EditedSahpe;

		PointF Location
		{
			get;
			set;
		}

		bool IsEdited
		{
			get;
			set;
		}

		SizeF Dimension
		{
			get;
			set;
		}

		PointF Center
		{
			get;
			set;
		}

		float Rotation
		{
			get;
			set;
		}

		bool Visible
		{
			get;
			set;
		}

		bool Locked
		{
			get;
			set;
		}

		bool Selected
		{
			get;
			set;
		}

		GraphicsPath Geometric
		{
			get;
		}

		Transformer Transformer
		{
			get;
			set;
		}

		Appearance Appearance
		{
			get;
			set;
		}

		bool Marked
		{
			get;
			set;
		}

		IShape Parent
		{
			get;
		}

		ContextMenuStrip Menu
		{
			get;
			set;
		}

		Color Color
		{
			get;
			set;
		}

		HitPositions HitTest(Point point);

		bool Contains(Point point);

		void OnEditedImage();

		bool Contains(IShape shape);

		RectangleF[] GetMarkers();

		Rectangle[] GetGrabbers();

		int GetMarkerIndex(PointF point);

		PointF GetGrabberPoint(HitPositions hitPosition);

		Image GetImage(float ZoomFactor);
	}
}
