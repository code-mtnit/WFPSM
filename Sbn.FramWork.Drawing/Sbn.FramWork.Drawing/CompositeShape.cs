using Sbn.FramWork.Drawing.Serialization;
using System;
using System.Windows.Forms;

namespace Sbn.FramWork.Drawing
{
	[XmlClassSerializable("compositeShape")]
	public class CompositeShape : Shape
	{
		private ShapeCollection _shapes = new ShapeCollection();

		private bool _movementContentBlocked = false;

		[XmlFieldSerializable("shapes")]
		public ShapeCollection Shapes
		{
			get
			{
				return this._shapes;
			}
			private set
			{
				if (value != null)
				{
					this._shapes.AddRange(value);
				}
			}
		}

		[XmlFieldSerializable("movementContentBlocked")]
		public bool MovementContentBlocked
		{
			get
			{
				return this._movementContentBlocked;
			}
			set
			{
				this._movementContentBlocked = value;
			}
		}

		public CompositeShape()
		{
			base.Transformer = new CompositeTransformer(this);
			this._shapes.InsertedItem += new ShapeCollection.OnInsertedItem(this._shapes_InsertedItem);
			this._shapes.RemovedItem += new ShapeCollection.OnRemovedItem(this._shapes_RemovedItem);
		}

		public CompositeShape(CompositeShape compositeShape) : base(compositeShape)
		{
			base.Transformer = new CompositeTransformer(this);
			this._shapes.InsertedItem += new ShapeCollection.OnInsertedItem(this._shapes_InsertedItem);
			this._shapes.RemovedItem += new ShapeCollection.OnRemovedItem(this._shapes_RemovedItem);
			base.Transformer.MovementOccurred += new MovementHandler(this.Transformer_MovementOccurred);
			base.Geometric.Reset();
			foreach (IShape current in compositeShape.Shapes)
			{
				this._shapes.Add(current.Clone() as IShape);
			}
		}

		private void Transformer_MovementOccurred(Transformer transformer)
		{
		}

		public override object Clone()
		{
			return new CompositeShape(this);
		}

		public override void Paint(IDocument document, PaintEventArgs e)
		{
			foreach (IShape current in this._shapes)
			{
				current.Appearance.Shape = current;
				current.Appearance.Paint(document, e);
			}
			base.Appearance.Shape = this;
			base.Appearance.Paint(document, e);
		}

		private void _shapes_InsertedItem(IShape shape, int index)
		{
			(shape as Shape).Parent = this;
			if (shape.Geometric.PointCount > 1)
			{
				base.Geometric.AddPath(shape.Geometric, false);
			}
		}

		private void _shapes_RemovedItem(IShape shape, int index)
		{
			(shape as Shape).Parent = null;
			base.Geometric.Reset();
			foreach (IShape current in this._shapes)
			{
				base.Geometric.AddPath(current.Geometric, false);
			}
		}
	}
}
