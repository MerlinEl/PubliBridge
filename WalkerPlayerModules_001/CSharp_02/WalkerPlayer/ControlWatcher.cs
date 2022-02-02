using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WalkerPlayer {
    //[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    internal class ControlWatcher : NativeWindow {

        private const int WM_RBUTTONDOWN = 0x204;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_MOUSEMOVE = 0x0200;
        public const int WM_LBUTTONUP = 0x202;

        public ControlWatcher(IntPtr Handle) {
            this.AssignHandle(Handle);
        }

        // Ignore window messages raised by the right mouse button.  
        //[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        [System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptions]
        protected override void WndProc(ref Message m) {

            switch (m.Msg) {

                // Disable flash controll right click.
                case WM_RBUTTONDOWN: return;

                
                // Let the user drag the form without top bar.
                case WM_MOUSEMOVE:
                    
                    // TODO addexception if is on slider, painting, etc (or give only some area to drag)
                    //var xPos = GET_X_LPARAM(lParam);
                    //var yPos = GET_Y_LPARAM(lParam);
// For now Turned OFF
                    //ReleaseCapture();
                    //IntPtr windowParent = GetWindowParent(Handle); // get ParentForm from flash controll
                    //SendMessage(windowParent, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                    break;
            }
            base.WndProc(ref m);
        }

        internal IntPtr GetWindowParent(IntPtr handle) {

            IntPtr windowParent = IntPtr.Zero;
            while (handle != IntPtr.Zero) {
                windowParent = handle;
                handle = GetParent(handle);
            }
            return windowParent;
        }


        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpString, int nMaxCount);
    }
}


/*
        // Drag Form around the screen
        //private const int WM_NCHITTEST = 0x84;
        //private const int HTCAPTION = 0x2;
        //protected override void WndProc(ref Message m) {
        //    if (m.Msg == WM_NCHITTEST)
        //        m.Result = new IntPtr(HTCAPTION);
        //    else
        //        base.WndProc(ref m);
        //}
 */