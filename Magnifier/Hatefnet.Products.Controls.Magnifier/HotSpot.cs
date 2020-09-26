using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hatefnet.Products.Controls.Magnifier
{
	internal class HotSpot
	{
		public delegate void MouseEventDelegate(object sender);

		private Rectangle mClientRectangle;

		public event HotSpot.MouseEventDelegate OnMouseDown
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.OnMouseDown = (HotSpot.MouseEventDelegate)Delegate.Combine(this.OnMouseDown, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.OnMouseDown = (HotSpot.MouseEventDelegate)Delegate.Remove(this.OnMouseDown, value);
			}
		}

		public event HotSpot.MouseEventDelegate OnMouseUp
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.OnMouseUp = (HotSpot.MouseEventDelegate)Delegate.Combine(this.OnMouseUp, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.OnMouseUp = (HotSpot.MouseEventDelegate)Delegate.Remove(this.OnMouseUp, value);
			}
		}

		public event HotSpot.MouseEventDelegate OnMouseMove
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.OnMouseMove = (HotSpot.MouseEventDelegate)Delegate.Combine(this.OnMouseMove, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.OnMouseMove = (HotSpot.MouseEventDelegate)Delegate.Remove(this.OnMouseMove, value);
			}
		}

		public HotSpot(Rectangle clientRectangle)
		{
			this.OnMouseDown = null;
			this.OnMouseUp = null;
			this.OnMouseMove = null;
			base..ctor();
			this.mClientRectangle = clientRectangle;
		}

		public bool ProcessMouseMove(MouseEventArgs e)
		{
			bool result;
			if (this.mClientRectangle.Contains(e.X, e.Y))
			{
				if (this.OnMouseMove != null)
				{
					this.OnMouseMove(this);
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public bool ProcessMouseDown(MouseEventArgs e)
		{
			bool result;
			if (this.mClientRectangle.Contains(e.X, e.Y))
			{
				if (this.OnMouseDown != null)
				{
					this.OnMouseDown(this);
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public bool ProcessMouseUp(MouseEventArgs e)
		{
			bool result;
			if (this.mClientRectangle.Contains(e.X, e.Y))
			{
				if (this.OnMouseUp != null)
				{
					this.OnMouseUp(this);
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
	}
}
