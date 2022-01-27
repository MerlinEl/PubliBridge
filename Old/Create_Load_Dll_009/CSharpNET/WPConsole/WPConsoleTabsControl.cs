using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WalkerPlayerConsole {
    class WPConsoleTabsControl : TabControl {
        private Color nonactive_color1 = Color.LightGreen;
        private Color nonactive_color2 = Color.DarkBlue;
        private Color active_color1 = Color.Yellow;
        private Color active_color2 = Color.DarkOrange;
        public Color forecolor = Color.Navy;
        private int color1Transparent = 150;
        private int color2Transparent = 150;
        private int angle = 90;
        private Color closebuttoncolor = Color.Red;
        //Create Properties to read values
        public Color ActiveTabStartColor {
            get { return active_color1; }
            set { active_color1 = value; Invalidate(); }
        }
        public Color ActiveTabEndColor {
            get { return active_color2; }
            set { active_color2 = value; Invalidate(); }
        }
        public Color NonActiveTabStartColor {
            get { return nonactive_color1; }
            set { nonactive_color1 = value; Invalidate(); }
        }
        public Color NonActiveTabEndColor {
            get { return nonactive_color2; }
            set { nonactive_color2 = value; Invalidate(); }
        }
        public int Transparent1 {
            get { return color1Transparent; }
            set {
                color1Transparent = value;
                if ( color1Transparent > 255 ) {
                    color1Transparent = 255;
                    Invalidate();
                } else
                    Invalidate();
            }
        }
        public int Transparent2 {
            get { return color2Transparent; }
            set {
                color2Transparent = value;
                if ( color2Transparent > 255 ) {
                    color2Transparent = 255;
                    Invalidate();
                } else
                    Invalidate();
            }
        }
        public int GradientAngle {
            get { return angle; }
            set { angle = value; Invalidate(); }
        }
        public Color TextColor {
            get { return forecolor; }
            set { forecolor = value; Invalidate(); }
        }
        public Color CloseButtonColor {
            get { return closebuttoncolor; }
            set { closebuttoncolor = value; Invalidate(); }
        }
        public WPConsoleTabsControl() {
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.Padding = new System.Drawing.Point(22, 4);
        }
        protected override void OnPaint(PaintEventArgs pe) {
            base.OnPaint(pe);
        }
        //method for drawing tab items 
        protected override void OnDrawItem(DrawItemEventArgs e) {
            base.OnDrawItem(e);
            TabPage page = TabPages[e.Index];
            Rectangle rc = GetTabRect(e.Index);
            //if tab is selected
            if ( this.SelectedTab == page ) {
                Color c1 = Color.FromArgb(color1Transparent, active_color1);
                Color c2 = Color.FromArgb(color2Transparent, active_color2);
                using ( LinearGradientBrush br = new LinearGradientBrush(rc, c1, c2, angle) ) {
                    e.Graphics.FillRectangle(br, rc);
                }
            } else {
                Color c1 = Color.FromArgb(color1Transparent, nonactive_color1);
                Color c2 = Color.FromArgb(color2Transparent, nonactive_color2);
                using ( LinearGradientBrush br = new LinearGradientBrush(rc, c1, c2, angle) ) {
                    e.Graphics.FillRectangle(br, rc);
                }
            }
            page.BorderStyle = BorderStyle.FixedSingle;
            page.ForeColor = SystemColors.ControlText;

            Rectangle paddedBounds = e.Bounds;
            int yOffset = ( e.State == DrawItemState.Selected ) ? -2 : 2;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, e.Font, paddedBounds, page.ForeColor);
        }
    }
}

