using System;

namespace Hatefnet.Products.Controls.Magnifier
{
	public class Configuration
	{
		private float mZoomFactor = Configuration.ZOOM_FACTOR_DEFAULT;

		private float mSpeedFactor = Configuration.SPEED_FACTOR_DEFAULT;

		public int LocationX = -1;

		public int LocationY = -1;

		public bool CloseOnMouseUp = true;

		public bool DoubleBuffered = true;

		public bool HideMouseCursor = true;

		public bool RememberLastPoint = true;

		public bool ReturnToOrigin = true;

		public bool ShowInTaskbar = false;

		public bool TopMostWindow = true;

		public int MagnifierWidth = 150;

		public int MagnifierHeight = 150;

		public static readonly float ZOOM_FACTOR_MAX = 10f;

		public static readonly float ZOOM_FACTOR_MIN = 1f;

		public static readonly float ZOOM_FACTOR_DEFAULT = 3f;

		public static readonly float SPEED_FACTOR_MAX = 1f;

		public static readonly float SPEED_FACTOR_MIN = 0.05f;

		public static readonly float SPEED_FACTOR_DEFAULT = 0.35f;

		public float ZoomFactor
		{
			get
			{
				return this.mZoomFactor;
			}
			set
			{
				if (value > Configuration.ZOOM_FACTOR_MAX)
				{
					this.mZoomFactor = Configuration.ZOOM_FACTOR_MAX;
				}
				else if (value < Configuration.ZOOM_FACTOR_MIN)
				{
					this.mZoomFactor = Configuration.ZOOM_FACTOR_MIN;
				}
				else
				{
					this.mZoomFactor = value;
				}
			}
		}

		public float SpeedFactor
		{
			get
			{
				return this.mSpeedFactor;
			}
			set
			{
				if (value > Configuration.SPEED_FACTOR_MAX)
				{
					this.mSpeedFactor = Configuration.SPEED_FACTOR_MAX;
				}
				else if (value < Configuration.SPEED_FACTOR_MIN)
				{
					this.mSpeedFactor = Configuration.SPEED_FACTOR_MIN;
				}
				else
				{
					this.mSpeedFactor = value;
				}
			}
		}
	}
}
