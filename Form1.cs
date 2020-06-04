using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win10TrayClock
{
    public partial class Form1 : Form
    {
        //private System.Windows.Forms.NotifyIcon notifyIcon1;
        //private System.Windows.Forms.NotifyIcon notifyIcon2;
        
        DateTime thisDay = DateTime.Today;

        //main colors
        Color cWhite = Color.White;
        Color cRed = Color.Red;
        Color cGreen = Color.DarkGreen;
        Color cCyan = Color.DarkCyan;

        public Form1()
        {
            InitializeComponent();
            
            // Create the NotifyIcon.
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon2 = new System.Windows.Forms.NotifyIcon(this.components);
            CreateTextIcon(thisDay.ToString("dd") + ".", notifyIcon1, cCyan, 13, -2);
            CreateTextIcon(thisDay.ToString("MM") + ".", notifyIcon2, cRed, 13, -3);
        }


        // Create tray icon: text + Nicon to use, fontsize, xOffset
        public void CreateTextIcon(string str, System.Windows.Forms.NotifyIcon nIco, Color fCol, int fontSize = 13, int xOffset = -2)
        {
            Font fontToUse = new Font("Microsoft Sans Serif", fontSize, FontStyle.Regular, GraphicsUnit.Pixel);
            Brush brushToUse = new SolidBrush(fCol);
            Bitmap bitmapText = new Bitmap(16, 16);
            Graphics g = System.Drawing.Graphics.FromImage(bitmapText);

            IntPtr hIcon;

            g.Clear(Color.Transparent);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            g.DrawString(str, fontToUse, brushToUse, xOffset, -2);
            hIcon = (bitmapText.GetHicon());
            nIco.Icon = System.Drawing.Icon.FromHandle(hIcon);
            nIco.Visible = true;
            //DestroyIcon(hIcon.ToInt32);
        }

    }
}
