using System;
using System.Windows.Forms;

namespace cshpdll {
    internal class ControlWatcher : NativeWindow {

        private const int WM_RBUTTONDOWN = 0x204;
        public ControlWatcher(IntPtr Handle) {
            this.AssignHandle(Handle);
        }

        // Ignore window messages raised by the right mouse button.  
        protected override void WndProc(ref Message m) {
            if (!(m.Msg == WM_RBUTTONDOWN)) base.WndProc(ref m);
        }
    }
}