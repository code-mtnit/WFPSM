using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sbn.FramWork.Drawing
{
	public abstract class Tool : IActions
	{
		public bool _AnnotationActive = false;

		private bool _mousePressed = false;

		private Point _mouseDownPoint = Point.Empty;

		private Point _mouseUpPoint = Point.Empty;

		private Ghost _ghost = new Ghost();

		public bool isAnnotationActive
		{
			get
			{
				return this._AnnotationActive;
			}
			protected set
			{
				this._AnnotationActive = value;
			}
		}

		public bool MousePressed
		{
			get
			{
				return this._mousePressed;
			}
			protected set
			{
				this._mousePressed = value;
			}
		}

		public Point MouseDownPoint
		{
			get
			{
				return this._mouseDownPoint;
			}
			set
			{
				this._mouseDownPoint = value;
			}
		}

		public Point MouseUpPoint
		{
			get
			{
				return this._mouseUpPoint;
			}
			set
			{
				this._mouseUpPoint = value;
			}
		}

		public Ghost Ghost
		{
			get
			{
				return this._ghost;
			}
			set
			{
				this._ghost = value;
			}
		}

		public Tool()
		{
		}

		public virtual void MouseDown(IDocument document, MouseEventArgs e)
		{
			this._mousePressed = true;
			this._mouseDownPoint = e.Location;
			foreach (IShape current in document.Shapes)
			{
				current.MouseDown(document, e);
			}
		}

		public virtual void MouseUp(IDocument document, MouseEventArgs e)
		{
			this._mousePressed = false;
			this._mouseUpPoint = e.Location;
			foreach (IShape current in document.Shapes)
			{
				current.MouseUp(document, e);
			}
		}

		public virtual void MouseClick(IDocument document, MouseEventArgs e)
		{
			foreach (IShape current in document.Shapes)
			{
				current.MouseClick(document, e);
			}
		}

		public virtual void MouseDoubleClick(IDocument document, MouseEventArgs e)
		{
			foreach (IShape current in document.Shapes)
			{
				current.MouseDoubleClick(document, e);
			}
		}

		public virtual void MouseMove(IDocument document, MouseEventArgs e)
		{
			this.UpdateCursor(document, document.Shapes, e.Location);
			foreach (IShape current in document.Shapes)
			{
				current.MouseMove(document, e);
			}
		}

		public virtual void MouseWheel(IDocument document, MouseEventArgs e)
		{
			foreach (IShape current in document.Shapes)
			{
				current.MouseWheel(document, e);
			}
		}

		public virtual void Paint(IDocument document, PaintEventArgs e)
		{
			foreach (IShape current in document.Shapes)
			{
				current.Paint(document, e);
			}
		}

		public virtual bool UpdateCursor(IDocument document, ShapeCollection shapes, Point point)
		{
			return false;
		}
	}
}
