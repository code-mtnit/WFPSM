using Sbn.FramWork.Drawing.Serialization;
using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace Sbn.FramWork.Drawing
{
	[XmlClassSerializable("shapes")]
	public class ShapeCollection : Collection<IShape>, ICollection, IEnumerable, ICloneable
	{
		public delegate void OnInsertedItem(IShape shape, int index);

		public delegate void OnRemovedItem(IShape shape, int index);

		public virtual event ShapeCollection.OnInsertedItem InsertedItem;

		public virtual event ShapeCollection.OnRemovedItem RemovedItem;

		public virtual event ShapeChangingHandler ShapeChanged;

		public virtual event MovementHandler ShapeMovementOccurred;

		public virtual event AppearanceHandler ShapeAppearanceChanged;

		public virtual object Clone()
		{
			ShapeCollection shapeCollection = new ShapeCollection();
			foreach (IShape current in this)
			{
				shapeCollection.Add(current.Clone() as IShape);
			}
			return shapeCollection;
		}

		public void AddRange(ShapeCollection shapes)
		{
			foreach (IShape current in shapes)
			{
				base.Add(current);
			}
		}

		public void BringToFront(IShape shape)
		{
			if (base.Remove(shape))
			{
				base.Add(shape);
			}
		}

		public void SendToBack(IShape shape)
		{
			if (base.Remove(shape))
			{
				base.Insert(0, shape);
			}
		}

		public static object[] ToObjects(ShapeCollection shapes)
		{
			object[] result;
			if (shapes.Count == 0)
			{
				result = null;
			}
			else
			{
				object[] array = new object[shapes.Count];
				for (int i = 0; i < shapes.Count; i++)
				{
					array[i] = shapes[i];
				}
				result = array;
			}
			return result;
		}

		protected override void InsertItem(int index, IShape item)
		{
			base.InsertItem(index, item);
			if (this.InsertedItem != null)
			{
				this.InsertedItem(item, index);
			}
			if (item != null)
			{
				item.ShapeChanged += new ShapeChangingHandler(this.item_ShapeChanged);
				item.Transformer.MovementOccurred += new MovementHandler(this.Transformer_MovementOccurred);
				item.Appearance.AppearanceChanged += new AppearanceHandler(this.Appearance_AppearanceOccurred);
			}
		}

		protected override void RemoveItem(int index)
		{
			IShape shape = base[index];
			base.RemoveItem(index);
			if (this.RemovedItem != null)
			{
				this.RemovedItem(shape, index);
			}
			shape.ShapeChanged -= new ShapeChangingHandler(this.item_ShapeChanged);
			shape.Transformer.MovementOccurred -= new MovementHandler(this.Transformer_MovementOccurred);
			shape.Appearance.AppearanceChanged -= new AppearanceHandler(this.Appearance_AppearanceOccurred);
		}

		private void item_ShapeChanged(IShape shape, object changing)
		{
			if (this.ShapeChanged != null)
			{
				this.ShapeChanged(shape, changing);
			}
		}

		private void Transformer_MovementOccurred(Transformer transformer)
		{
			try
			{
				if (this.ShapeMovementOccurred != null)
				{
					this.ShapeMovementOccurred(transformer);
				}
			}
			catch
			{
			}
		}

		private void Appearance_AppearanceOccurred(Appearance appearance)
		{
			if (this.ShapeAppearanceChanged != null)
			{
				this.ShapeAppearanceChanged(appearance);
			}
		}
	}
}
