using Sbn.FramWork.Drawing.Serialization;
using System;
using System.Drawing;

namespace Sbn.FramWork.Drawing
{
	[XmlClassSerializable("shapes")]
	public class ShapeCollectionEx : ShapeCollection
	{
		public virtual event TranslateHandler ShapeTranslateOccurred;

		public virtual event ScaleHandler ShapeScaleOccurred;

		public virtual event RotateHandler ShapeRotateOccurred;

		public virtual event DeformHandler ShapeDeformOccurred;

		public virtual event MirrorHorizontalHandler ShapeMirrorHorizontalOccurred;

		public virtual event MirrorVerticalHandler ShapeMirrorVerticalOccurred;

		public override object Clone()
		{
			ShapeCollectionEx shapeCollectionEx = new ShapeCollectionEx();
			foreach (IShape current in this)
			{
				shapeCollectionEx.Add(current.Clone() as IShape);
			}
			return shapeCollectionEx;
		}

		protected override void InsertItem(int index, IShape item)
		{
			base.InsertItem(index, item);
			item.Transformer.TranslateOccurred += new TranslateHandler(this.Transformer_TranslateOccurred);
			item.Transformer.ScaleOccurred += new ScaleHandler(this.Transformer_ScaleOccurred);
			item.Transformer.RotateOccurred += new RotateHandler(this.Transformer_RotateOccurred);
			item.Transformer.DeformOccurred += new DeformHandler(this.Transformer_DeformOccurred);
			item.Transformer.MirrorHorizontalOccurred += new MirrorHorizontalHandler(this.Transformer_MirrorHorizontalOccurred);
			item.Transformer.MirrorVerticalOccurred += new MirrorVerticalHandler(this.Transformer_MirrorVerticalOccurred);
		}

		protected override void RemoveItem(int index)
		{
			IShape shape = base[index];
			base.RemoveItem(index);
			shape.Transformer.TranslateOccurred -= new TranslateHandler(this.Transformer_TranslateOccurred);
			shape.Transformer.ScaleOccurred -= new ScaleHandler(this.Transformer_ScaleOccurred);
			shape.Transformer.RotateOccurred -= new RotateHandler(this.Transformer_RotateOccurred);
			shape.Transformer.DeformOccurred -= new DeformHandler(this.Transformer_DeformOccurred);
			shape.Transformer.MirrorHorizontalOccurred -= new MirrorHorizontalHandler(this.Transformer_MirrorHorizontalOccurred);
			shape.Transformer.MirrorVerticalOccurred -= new MirrorVerticalHandler(this.Transformer_MirrorVerticalOccurred);
		}

		private void Transformer_TranslateOccurred(Transformer transformer, float offsetX, float offsetY)
		{
			if (this.ShapeTranslateOccurred != null)
			{
				this.ShapeTranslateOccurred(transformer, offsetX, offsetY);
			}
		}

		private void Transformer_ScaleOccurred(Transformer transformer, float scaleX, float scaleY, PointF point)
		{
			if (this.ShapeScaleOccurred != null)
			{
				this.ShapeScaleOccurred(transformer, scaleX, scaleY, point);
			}
		}

		private void Transformer_RotateOccurred(Transformer transformer, float degree, PointF point)
		{
			if (this.ShapeRotateOccurred != null)
			{
				this.ShapeRotateOccurred(transformer, degree, point);
			}
		}

		private void Transformer_DeformOccurred(Transformer transformer, int indexPoint, PointF newPoint)
		{
			if (this.ShapeDeformOccurred != null)
			{
				this.ShapeDeformOccurred(transformer, indexPoint, newPoint);
			}
		}

		private void Transformer_MirrorHorizontalOccurred(Transformer transformer, float x)
		{
			if (this.ShapeMirrorHorizontalOccurred != null)
			{
				this.ShapeMirrorHorizontalOccurred(transformer, x);
			}
		}

		private void Transformer_MirrorVerticalOccurred(Transformer transformer, float y)
		{
			if (this.ShapeMirrorVerticalOccurred != null)
			{
				this.ShapeMirrorVerticalOccurred(transformer, y);
			}
		}
	}
}
