using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.ObjectModel;

using Sbn.FramWork.Drawing;
using Sbn.FramWork.Drawing.Core.Utilities;

namespace Sbn.AdvancedControls.Imaging.SbnPaint
{
    /// <summary>
    /// Moves selected shapes.
    /// </summary>
    public class Hand : Tool
    {
        Point _oldPoint = Point.Empty;

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Hand()
        {
            //this.Ghost = new GhostCollection();
        }

        #endregion

        #region IActions Interface

        /// <summary>
        /// Mouse down function.
        /// </summary>
        /// <param name="document">Informations transferred from DrawingPanel.</param>
        /// <param name="e">MouseEventArgs.</param>
        public override void MouseDown(IDocument document, MouseEventArgs e)
        {
            base.MouseDown(document, e);

            _oldPoint = e.Location;
            //(this.Ghost as GhostCollection).Ghosts = Select.GetSelectedShapes(document.Shapes);
            //(this.Ghost as GhostCollection).ShapeMouseUp += new MouseUpOnShape(Move_ShapeMouseUp);
            //this.Ghost.MouseDown(document, e);

            UpdateCursor(document, Select.GetSelectedShapes(document.Shapes), e.Location);
        }

        /// <summary>
        /// Mouse up function
        /// </summary>
        /// <param name="document">Informations transferred from DrawingPanel</param>
        /// <param name="e">MouseEventArgs</param>
        public override void MouseUp(IDocument document, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

           // Ghost.MouseUp(document, e);
            base.MouseUp(document, e);
        }

        /// <summary>
        /// Mouse move function.
        /// </summary>
        /// <param name="document">Informations transferred from DrawingPanel.</param>
        /// <param name="e">MouseEventArgs.</param>
        public override void MouseMove(Sbn.FramWork.Drawing.IDocument document, System.Windows.Forms.MouseEventArgs e)
        {
            base.MouseMove(document, e);

            if (!MousePressed)
                return;

           PointF point = document.GridManager.GetRoundedPoint(e.Location);


           var hChang = point.X - _oldPoint.X;
           var vChang = point.Y - _oldPoint.Y;



           if (! (document.DrawingControl as DrawingPanel).VerticalScroll.Visible)
               vChang = 0;
           else
           {
               if ( (document.DrawingControl as DrawingPanel).BackgroundLayer != null)
               {

                   if ( (document.DrawingControl as DrawingPanel).BackgroundLayer.Location.Y + vChang > 0)
                       vChang = 0;


                   if ( (document.DrawingControl as DrawingPanel).VerticalScroll.Value +  (document.DrawingControl as DrawingPanel).VerticalScroll.LargeChange - vChang >  (document.DrawingControl as DrawingPanel).VerticalScroll.Maximum)
                       vChang = 0;

               }
           }

           if (!(document.DrawingControl as DrawingPanel).HorizontalScroll.Visible)
               hChang = 0;
           else
           {
               if ((document.DrawingControl as DrawingPanel).BackgroundLayer != null)
               {

                   if ((document.DrawingControl as DrawingPanel).BackgroundLayer.Location.X + hChang > 0)
                       hChang = 0;


                   if ((document.DrawingControl as DrawingPanel).HorizontalScroll.Value + (document.DrawingControl as DrawingPanel).HorizontalScroll.LargeChange - hChang > (document.DrawingControl as DrawingPanel).HorizontalScroll.Maximum)
                       hChang = 0;

               }
           }

           bool historyIsActive = History<ShapeCollection>.IsActive;
           History<ShapeCollection>.IsActive = false;
           foreach (IShape shape in document.Shapes)
           {
               shape.Transformer.ForceTranslate(hChang, vChang);
           }
           History<ShapeCollection>.IsActive = historyIsActive;

           try
           {
               (document.DrawingControl as DrawingPanel).UpdateDrawPanelSize();
               //UpdateDrawPanelSize();
               //VerticalScroll.Value += vChang;
           }
           catch (Exception)
           {

               // throw;
           }

          // lastMouse = new Point(e.X, e.Y);


           //Ghost.Transformer.Translate(point.X - _oldPoint.X, point.Y - _oldPoint.Y);
           //Ghost.MouseMove(document, e);

            _oldPoint = Point.Round(point);
        }

        /// <summary>
        /// Paint function.
        /// </summary>
        /// <param name="document">Informations transferred from DrawingPanel.</param>
        /// <param name="e">PaintEventArgs.</param>
        public override void Paint(IDocument document, PaintEventArgs e)
        {
           // this.Ghost.Paint(document, e);
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Updates the cursor during the tool actions.
        /// </summary>
        /// <param name="document">Informations transferred from DrawingPanel.</param>
        /// <param name="shapes">Shapes to manage.</param>
        /// <param name="point">Mouse point.</param>
        /// <returns>True if it is updated.</returns>
        public override bool UpdateCursor(IDocument document, ShapeCollection shapes, Point point)
        {
            bool updated = false;

            foreach (IShape shape in shapes)
            {
               // if (shape.HitTest(MouseDownPoint) != HitPositions.None && shape.Selected && MousePressed)
                    updated = true;
                //else
                //    updated = false;
            }

            if (updated)
                if (MousePressed)
                {
                    document.ActiveCursor = Cursors.Hand;
                }
                else
                {
                    document.ActiveCursor = Cursors.SizeAll;
                }
            else
                document.ActiveCursor = Cursors.Default;

            return updated;
        }

        #endregion

        #region Protected Functions

        /// <summary>
        /// Gets ghostable shapes.
        /// </summary>
        /// <param name="shapes">Shape on drawing panel.</param>
        virtual protected ShapeCollection GetGhostableShapes(ShapeCollection shapes)
        {
            ShapeCollection ghostableShapes = new ShapeCollection();

            foreach (IShape shape in shapes)
            {
                if (shape.Selected && !shape.Locked)
                    ghostableShapes.Add(shape);
            }

            return ghostableShapes;
        }

        /// <summary>
        /// Manages ghost mouse up event.
        /// </summary>
        /// <param name="shape">Ghost to fire the event.</param>
        /// <param name="document">Reference document.</param>
        /// <param name="e">MouseEventArgs.</param>
        virtual protected void Move_ShapeMouseUp(IShape shape, IDocument document, MouseEventArgs e)
        {
            Ghost ghost = shape as Ghost;
            if (ghost == null)
                return;

            if (ghost is GhostCollection || ghost.ReferenceShape == null)
                return;

            ghost.ReferenceShape.Location = ghost.Location;
        }

        #endregion
    }
}
