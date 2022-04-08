using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace not_a_virus
{
    public partial class ScreenScreenshotter : Form
    {
        public ScreenScreenshotter()
        {
            InitializeComponent();
        }

        private void ScreenScreenshotter_Load(object sender, EventArgs e)
        {

        }

        public void LoadOnScreen(Screen screen)
        {
            this.Size = new Size(1, 1);

            pictureBox1.Image = MakeScreenshot(screen);

            this.Size = screen.Bounds.Size;
            pictureBox1.Size = screen.Bounds.Size;
            this.Location = screen.WorkingArea.Location;
        }

        private Bitmap MakeScreenshot(Screen screen)
        {
            var bmpScreenshot = new Bitmap(screen.Bounds.Width, screen.Bounds.Height, PixelFormat.Format32bppArgb);

            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CopyFromScreen(screen.WorkingArea.X, screen.WorkingArea.Y, 0, 0, screen.Bounds.Size, CopyPixelOperation.SourceCopy);

            return bmpScreenshot;
        }

        private void ScreenScreenshotter_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.TaskManagerClosing);
        }
    }
}
