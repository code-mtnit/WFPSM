using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Sbn.FramWork.Windows.Forms.Ribbon
{
    public class RibbonCommandButton : Button
    {
        #region About Constructor
        public RibbonCommandButton()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                          ControlStyles.UserPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.Opaque, false);
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = Color.Transparent;
            this.TextImageRelation = TextImageRelation.ImageAboveText;
            this.Text = "";
            this.Size = new Size(25, 25);
            _command = new mycommands();
            _state = new mystates();
            _state = mystates.Out;
        }
        #endregion

        #region The Commands
        public enum mycommands
        {
            Maximize, Minimize, Close, Try
        }
        public mycommands Command
        {
            get { return _command; }
            set
            {
                _command = value;
            }
        }
        private mycommands _command;
        #endregion

        #region Command States
        public enum mystates
        {
            Out, On, OnClick
        }
        private mystates _state;
        #endregion

        #region Colors
        private Color _baseColor = Color.FromArgb(122, 141, 167);
        private Color _blackColor = Color.FromArgb(101, 101, 101);
        private Color _whiteColor = Color.FromArgb(248, 249, 250);
        private Color _onColor = Color.FromArgb(237, 245, 255);
        private Color _pressColor = Color.FromArgb(155, 192, 228);

        public Color ColorBase
        {
            get { return _baseColor; }
            set
            {
                _baseColor = value;
            }
        }
        public Color ColorBlack
        {
            get { return _blackColor; }
            set { _blackColor = value; }
        }
        public Color ColorWhite
        {
            get { return _whiteColor; }
            set { _whiteColor = value; }
        }
        public Color ColorOn
        {
            get { return _onColor; }
            set { _onColor = value; }
        }
        public Color ColorPress
        {
            get { return _pressColor; }
            set { _pressColor = value; }
        }
        public Color GetColor(Color _color, int r, int g, int b)
        {
            int tr, tb, tg;
            if (r + _color.R > 255)
                tr = 255;
            else if (r + _color.R < 0)
                tr = 0;
            else
                tr = r + _color.R;

            if (g + _color.G > 255)
                tg = 255;
            else if (g + _color.G < 0)
                tg = 0;
            else
                tg = g + _color.G;

            if (b + _color.B > 255)
                tb = 255;
            else if (b + _color.B < 0)
                tb = 0;
            else
                tb = b + _color.B;

            return Color.FromArgb(_color.A, tr, tg, tb);

        }
        #endregion

        protected override void OnPaint(PaintEventArgs pevent)
        {
            #region Variables & Conf
            Graphics g = pevent.Graphics;
            Rectangle r = new Rectangle(new Point(-1, -1), new Size(this.Width + _radius, this.Height + _radius));
            g.SmoothingMode = SmoothingMode.Default;
            #endregion

            #region Transform to SmoothRectangle Region
            if (this.Size != null)
            {
                GraphicsPath pathregion = new GraphicsPath();
                DrawArc(r, pathregion);
                this.Region = new Region(pathregion);
            }
            #endregion

            switch (_state)
            {

                case mystates.On:
                    #region Show Lateral & Central Gradients
                    Rectangle ri = new Rectangle(1, 1, this.Width / 2, this.Height - 1);
                    Color C0i = SetTransparency(_whiteColor, 255);
                    Color CFi = SetTransparency(GetColor(_onColor, -27, -17, 0), 200);
                    LinearGradientBrush b = new LinearGradientBrush(ri, C0i, CFi, LinearGradientMode.BackwardDiagonal);
                    g.FillRectangle(b, 1, 1, ri.Width - 1, ri.Height - 1);
                    ri = new Rectangle(this.Width / 2, 0, this.Width / 2, this.Height);
                    b = new LinearGradientBrush(ri, C0i, CFi, LinearGradientMode.ForwardDiagonal);
                    g.FillRectangle(b, this.Width / 2, 1, ri.Width, ri.Height - 2);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(100, _whiteColor)), 1, 1, this.Width - 2, this.Height / 2);
                    #endregion
                    #region Draw Borders
                    GraphicsPath path = new GraphicsPath();
                    Rectangle rp = new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1));
                    DrawArc(rp, path);
                    g.DrawPath(new Pen(Color.FromArgb(100, _baseColor)), path);
                    path = new GraphicsPath();
                    rp = new Rectangle(new Point(1, 1), new Size(this.Width - 2, this.Height - 2));
                    DrawArc(rp, path);
                    g.DrawPath(new Pen(_whiteColor), path);
                    #endregion
                    break;
                case mystates.OnClick:
                    #region Show Lateral & Central Gradients
                    ri = new Rectangle(1, 1, this.Width / 2, this.Height - 1);
                    C0i = SetTransparency(_whiteColor, 255);
                    CFi = SetTransparency(GetColor(_onColor, -27, -17, 0), 200);
                    b = new LinearGradientBrush(ri, C0i, CFi, LinearGradientMode.BackwardDiagonal);
                    g.FillRectangle(b, 1, 1, ri.Width - 1, ri.Height - 1);
                    ri = new Rectangle(this.Width / 2, 0, this.Width / 2, this.Height);
                    b = new LinearGradientBrush(ri, C0i, CFi, LinearGradientMode.ForwardDiagonal);
                    g.FillRectangle(b, this.Width / 2, 1, ri.Width - 1, ri.Height - 2);
                    #endregion
                    #region Draw Borders
                    path = new GraphicsPath();
                    rp = new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1));
                    DrawArc(rp, path);
                    g.DrawPath(new Pen(Color.FromArgb(100, _baseColor)), path);
                    path = new GraphicsPath();
                    rp = new Rectangle(new Point(1, 1), new Size(this.Width - 2, this.Height - 2));
                    DrawArc(rp, path);
                    g.DrawPath(new Pen(_whiteColor), path);
                    #endregion
                    #region Glasses
                    g.FillRectangle(new SolidBrush(Color.FromArgb(100, _pressColor)), 1, 1, this.Width - 2, this.Height / 2 - 1);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(150, _pressColor)), 1, this.Height / 2, this.Width - 2, this.Height / 2 - 1);
                    #endregion
                    break;
            }
            #region Show Icons
            try
            {

                Pen pencil; Point startpen; Point endpen; int j; int i; int d = 6; LinearGradientBrush sbrush;
                r = new Rectangle(new Point(0, 0), this.Size);

                switch (_command)
                {
                    case mycommands.Minimize:

                        #region Create Minimize Icon
                        j = 9;
                        pencil = new Pen(_blackColor, 1);
                        startpen = new Point(7, r.Height - j);
                        endpen = new Point(r.Width - 9, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        j--;
                        pencil = new Pen(_baseColor, 1);
                        startpen = new Point(7, r.Height - j);
                        endpen = new Point(r.Width - 9, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        j--;
                        pencil = new Pen(_whiteColor, 1);
                        startpen = new Point(7, r.Height - j);
                        endpen = new Point(r.Width - 9, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        #endregion
                        break;
                    case mycommands.Try:

                        #region Create Minimize Icon
                        j = 7;
                        pencil = new Pen(_blackColor, 1);
                        startpen = new Point(7, r.Height - j);
                        endpen = new Point(r.Width - 6, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        j--;
                        pencil = new Pen(_baseColor, 1);
                        startpen = new Point(7, r.Height - j);
                        endpen = new Point(r.Width - 6, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        j--;
                        pencil = new Pen(_whiteColor, 1);
                        startpen = new Point(7, r.Height - j);
                        endpen = new Point(r.Width - 6, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        #endregion
                        break;
                    case mycommands.Maximize:
                        #region Create Maximize Icon
                        j = 14;
                        pencil = new Pen(_baseColor, 1);
                        startpen = new Point(7, r.Height - j);
                        endpen = new Point(r.Width - 9, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        j--;
                        startpen = new Point(7, r.Height - j);
                        Rectangle rect = new Rectangle(startpen, new Size(r.Width - 15, 6));
                        sbrush = new LinearGradientBrush(rect, _baseColor, _baseColor, LinearGradientMode.Vertical);
                        g.FillRectangle(sbrush, rect);
                        j = 7;
                        pencil = new Pen(_whiteColor, 1);
                        startpen = new Point(7, r.Height - j);
                        endpen = new Point(r.Width - 9, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        j = 11;
                        pencil = new Pen(_whiteColor, 1);
                        startpen = new Point(8, r.Height - j);
                        endpen = new Point(r.Width - 10, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        j--;
                        pencil = new Pen(_onColor, 1);
                        startpen = new Point(8, r.Height - j);
                        endpen = new Point(r.Width - 10, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        j--;
                        pencil = new Pen(_onColor, 1);
                        startpen = new Point(8, r.Height - j);
                        endpen = new Point(r.Width - 10, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        #endregion
                        break;

                    case mycommands.Close:

                        #region Black shadow
                        j = 14; i = 8;
                        pencil = new Pen(_blackColor, 1);
                        startpen = new Point(i, r.Height - j);
                        endpen = new Point(i + 2, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        startpen = new Point(i + d, r.Height - j);
                        endpen = new Point(i + 2 + d, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        j--; i++; d = 4;
                        pencil = new Pen(_blackColor, 1);
                        startpen = new Point(i, r.Height - j);
                        endpen = new Point(i + 2, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        startpen = new Point(i + d, r.Height - j);
                        endpen = new Point(i + 2 + d, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        j--; i++; d = 2;
                        pencil = new Pen(_blackColor, 1);
                        startpen = new Point(i, r.Height - j);
                        endpen = new Point(i + 2, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        startpen = new Point(i + d, r.Height - j);
                        endpen = new Point(i + 2 + d, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        #endregion

                        #region White shadow
                        j = 6; i = 7; d = 7;
                        pencil = new Pen(_whiteColor, 1);
                        startpen = new Point(i, r.Height - j);
                        endpen = new Point(i + 3, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        startpen = new Point(i + d, r.Height - j);
                        endpen = new Point(i + 3 + d, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        j++; i++; d = 5;
                        pencil = new Pen(_whiteColor, 1);
                        startpen = new Point(i, r.Height - j);
                        endpen = new Point(i + 3, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        startpen = new Point(i + d, r.Height - j);
                        endpen = new Point(i + 3 + d, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        j++; i++; d = 3;
                        pencil = new Pen(_whiteColor, 1);
                        startpen = new Point(i, r.Height - j);
                        endpen = new Point(i + 3, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        startpen = new Point(i + d, r.Height - j);
                        endpen = new Point(i + 3 + d, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        #endregion

                        #region Blue Cross
                        Color SBlue = Color.FromArgb(_baseColor.R, _baseColor.G, _baseColor.B);
                        j = 13; i = 9; d = 5;
                        pencil = new Pen(SBlue, 1);
                        startpen = new Point(i, r.Height - j);
                        endpen = new Point(i + 1, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        startpen = new Point(i + d, r.Height - j);
                        endpen = new Point(i + 1 + d, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        j--; i++; d = 3;
                        SBlue = Color.FromArgb(SBlue.R, SBlue.G, SBlue.B);
                        pencil = new Pen(SBlue, 1);
                        startpen = new Point(i, r.Height - j);
                        endpen = new Point(i + 1, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        startpen = new Point(i + d, r.Height - j);
                        endpen = new Point(i + 1 + d, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        j--; i++; d = 1;
                        SBlue = Color.FromArgb(SBlue.R, SBlue.G, SBlue.B);
                        pencil = new Pen(SBlue, 1);
                        startpen = new Point(i, r.Height - j);
                        endpen = new Point(i + 1, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        startpen = new Point(i + d, r.Height - j);
                        endpen = new Point(i + 1 + d, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        j--; d = 1;
                        SBlue = Color.FromArgb(SBlue.R, SBlue.G, SBlue.B);
                        pencil = new Pen(SBlue, 1);
                        startpen = new Point(i, r.Height - j);
                        endpen = new Point(i + 1, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        startpen = new Point(i + d, r.Height - j);
                        endpen = new Point(i + 1 + d, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        j--; i--; d = 2;
                        SBlue = Color.FromArgb(SBlue.R, SBlue.G, SBlue.B);
                        pencil = new Pen(SBlue, 1);
                        startpen = new Point(i, r.Height - j);
                        endpen = new Point(i + 2, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        startpen = new Point(i + d, r.Height - j);
                        endpen = new Point(i + 2 + d, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        j--; i--; d = 4;
                        SBlue = Color.FromArgb(SBlue.R, SBlue.G, SBlue.B);
                        pencil = new Pen(SBlue, 1);
                        startpen = new Point(i, r.Height - j);
                        endpen = new Point(i + 2, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        startpen = new Point(i + d, r.Height - j);
                        endpen = new Point(i + 2 + d, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        j--; i--; d = 6;
                        SBlue = Color.FromArgb(SBlue.R, SBlue.G, SBlue.B);
                        pencil = new Pen(SBlue, 1);
                        startpen = new Point(i, r.Height - j);
                        endpen = new Point(i + 2, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        startpen = new Point(i + d, r.Height - j);
                        endpen = new Point(i + 2 + d, r.Height - j);
                        g.DrawLine(pencil, startpen, endpen);
                        break;
                        #endregion

                    default:
                        g.FillRectangle(new SolidBrush(Color.AliceBlue), r); break;

                }
            }
            catch { }
            #endregion

        }

        #region Paint Methods
        private int _radius = 6;
        public void DrawArc(Rectangle re, GraphicsPath pa)
        {
            pa.AddArc(re.X, re.Y, _radius, _radius, 180, 90);
            pa.AddArc(re.Width - _radius, re.Y, _radius, _radius, 270, 90);
            pa.AddArc(re.Width - _radius, re.Height - _radius, _radius, _radius, 0, 90);
            pa.AddArc(re.X, re.Height - _radius, _radius, _radius, 90, 90);
            pa.CloseFigure();
        }
        public Color SetTransparency(Color color, int transparency)
        {
            if (transparency >= 0 & transparency <= 255)
            {
                return Color.FromArgb(transparency, color.R, color.G, color.B);
            }
            else if (transparency > 255)
            {
                return Color.FromArgb(255, color.R, color.G, color.B);
            }
            else
            {
                return Color.FromArgb(0, color.R, color.G, color.B);
            }
        }

        #endregion

        #region Mouse Events
        protected override void OnMouseEnter(EventArgs e)
        {
            this._state = mystates.On;
            this.Cursor = Cursors.Arrow;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this._state = mystates.Out;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            this._state = mystates.OnClick;
            base.OnMouseDown(mevent);

        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            this._state = mystates.On;
            base.OnMouseUp(mevent);
        }

        #endregion

    }
}
