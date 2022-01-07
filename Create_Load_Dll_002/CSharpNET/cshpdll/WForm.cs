using System;
using System.IO;
using System.Windows.Forms;
/**
    Introduction:
        Maybe sometimes you want to play a shockwave flash file (.swf format) in your C# or VB Visual Studio form. 
        There are many ways to do it, but the easiest way is using its component which is available for use. 
        In this tip for beginners, we will review how to play a shockwave file (.SWF) in our Visual Studio 
        form with the easiest and fastest way by using Shockwave flash object component.
        This component is located at %systemroot%\system32\macromed\flash9c.ocx and if you can't find it, 
        you must install the latest version of Adobe Macromedia Flash Player. 
        With this component, you can play all .swf files in order to show them in your projects and not reference 
        which kind of flash file you use (a flash game, a flash banner or something else).

    Using the Code:
        So for doing what we want, we must follow the steps given below:
        Add Shockwave flash object to Toolbox (with brief explanation): 
        At first, we need to add Shockwave flash object component to our Toolbox. 
        Generally, for adding a component to toolbox, we can right-click on Toolbox window and then click on choose items.
        Next in Choose toolbox items window, we can find and add each component we want and in this tip, 
        we must go to Com components tab and add Shockwave flash object from there to toolbox. 
        Now, you can see that component in your toolbox.
        Add to form: Now you must Drag & Drop the component to your form.
        Tip: One of the famous errors which you can be forced into is error in importing your component to your Visual Studio form. 
        If you are forced to “Failed to import the ActiveX control. 
        Please ensure it is properly registered” error, rebuilding project can help you. 
        This error usually happens when you drag and drop the ActiveX component to a form and rebuilding the project will help you to remove this error. 
        But, I found a solution here for solving this problem forever. Also, if you need a way for registering it manually, this link which I found can help you.

    Setting address of swf file to your object
        axShockwaveFlash1.Movie = Application.StartupPath + @"\sample.swf";  

    Some simple commands of this component are:
        Playing Flash: AxShockwaveFlash.Play()
        Pausing Flash: AxShockwaveFlash.Stop()
        URL Source of Flash file: AxShockwaveFlash.Movie = FilePath & "\FileName.swf" 
    
    Other commands properties of this component are:
        Loop: which in "True" mode helps to playing flash file continuously
        Quality: which in default value shows your flash file in its best quality
        Menu: which you can disable right click menu of flash object (settings) by it
        Framenum: by this, you can choose your start frame of your swf file
        EmbedMovie: make your flash file source embed to your solution
        BGColor: background color of your file when it starts to play
        AlignMode, AllowFullscreen, CTLScale, SAlign, WMode are used for positioning and setting view mode
 */
namespace cshpdll {
    public partial class SWF_Form : Form {
        public SWF_Form() {
            InitializeComponent();
        }

        private void Btn_Play_Click(object sender, EventArgs e) {
            axShockwaveFlash1.Playing = true;
        }

        private void Btn_Pause_Click(object sender, EventArgs e) {
            axShockwaveFlash1.Playing = false;
        }

        private void Btn_Load_Click(object sender, EventArgs e) {

            //String path = Application.StartupPath +@"\"+ Tbx_Swf_Path.Text;
            String path = Tbx_Swf_Path.Text;
            if (!File.Exists(path)) throw new FileNotFoundException("This file was not found.\n" + path);
            axShockwaveFlash1.Movie = path;
            axShockwaveFlash1.Playing = false;
        }

        private void AxShockwaveFlash1_Enter(object sender, EventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
