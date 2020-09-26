using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sbn.FramWork.Drawing
{
	public class Select : Tool
	{
		public delegate void OnSelectedShapes(Tool tool, ShapeCollection shapes);

		private static IShape _lastSelectedShape = null;

		public event Select.OnSelectedShapes SelectedShapes;

		public static IShape LastSelectedShape
		{
			get
			{
				return Select._lastSelectedShape;
			}
			set
			{
				Select._lastSelectedShape = value;
			}
		}

		public override void MouseDown(IDocument document, MouseEventArgs e)
		{
			base.MouseDown(document, e);
			if (this.SelectShape(document.Shapes, e.Location) == HitPositions.None)
			{
				Select.UnselectAll(document.Shapes);
			}
			if (this.SelectedShapes != null)
			{
				this.SelectedShapes(this, Select.GetSelectedShapes(document.Shapes));
			}
			document.GridManager.SnapToGrid(Select.GetSelectedShapes(document.Shapes));
		}

		public override void MouseUp(IDocument document, MouseEventArgs e)
		{
			base.MouseUp(document, e);
			document.ActiveCursor = Cursors.Default;
		}

		public static void SelectAll(ShapeCollection shapes)
		{
			foreach (IShape current in shapes)
			{
				current.Selected = true;
			}
		}

		public static void UnselectAll(ShapeCollection shapes)
		{
			foreach (IShape current in shapes)
			{
				current.Selected = false;
			}
		}

		public static ShapeCollection GetSelectedShapes(ShapeCollection shapes)
		{
			ShapeCollection shapeCollection = new ShapeCollection();
			foreach (IShape current in shapes)
			{
				if (current.Selected)
				{
					shapeCollection.Add(current);
				}
			}
			return shapeCollection;
		}

		protected HitPositions SelectShape(ShapeCollection shapes, Point point)
		{
			if (Control.ModifierKeys != Keys.Control)
			{
				Select.UnselectAll(shapes);
			}
			HitPositions result;
			for (int i = shapes.Count - 1; i >= 0; i--)
			{
				IShape shape = shapes[i];
				HitPositions hitPositions = shape.HitTest(point);
				if (hitPositions != HitPositions.None)
				{
					if (!shape.Locked)
					{
						shapes.BringToFront(shape);
						shape.Selected = true;
						Select._lastSelectedShape = shape;
					}
					result = hitPositions;
					return result;
				}
			}
			result = HitPositions.None;
			return result;
		}
	}
}
