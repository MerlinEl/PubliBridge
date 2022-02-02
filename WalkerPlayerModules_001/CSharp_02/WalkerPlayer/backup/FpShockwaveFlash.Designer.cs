
using AxShockwaveFlashObjects;
using System.ComponentModel;
using System.Drawing;

namespace WalkerPlayer {
    partial class FpShockwaveFlash : AxShockwaveFlash {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public FpShockwaveFlash(IContainer components) {
            this.components = components;

        }
        //Management of mouse drag and drop
        #region Menu and Mouse
        private bool mouseDown;
        private Point lastLocation;

        /// <summary>
        /// To enable control to be moved around with mouse
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        public void moveItselfWithMouse<T>(this T this) where T : this {
            this.MouseDown += (o, e) => { mouseDown = true; lastLocation = e.Location; };
            this.MouseMove += (o, e) =>
            {
                if (mouseDown) {
                    this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                    this.Update();
                }
            };
            this.MouseUp += (o, e) => { mouseDown = false; };
        }


        public void moveOtherWithMouse<T>(this T this, this movedObject) where T : this {
            this.MouseDown += (o, e) => { mouseDown = true; lastLocation = e.Location; };
            this.MouseMove += (o, e) =>
            {
                if (mouseDown) {
                    movedObject.Location = new Point((movedObject.Location.X - lastLocation.X) + e.X, (movedObject.Location.Y - lastLocation.Y) + e.Y);
                    movedObject.Update();
                }
            };
            this.MouseUp += (o, e) => { mouseDown = false; };
        }

        #endregion
    }
}
}
