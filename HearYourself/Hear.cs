using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using NAudio.Wave;

namespace HearYourself
{
    public partial class Hear : Form
    {
        public HearCode HcCode;
        // RED ee6055
        // GREEN 60d394
        public Hear()
        {
            InitializeComponent();
            HcCode = new HearCode();
            Guna2DragControl gg = new Guna2DragControl(topPanel);
            gg.UseTransparentDrag = false;
            foreach (Control c in topPanel.Controls)
            {
                Guna2DragControl g = new Guna2DragControl(c);
                g.UseTransparentDrag = false;
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Hear_Load(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            HcCode.Switch();
            guna2CircleButton1.Text = (HcCode.GetStatus() ? "ON" : "OFF");
            guna2CircleButton1.FillColor = (HcCode.GetStatus() ? ColorTranslator.FromHtml("#60d394") : ColorTranslator.FromHtml("#ee6055"));
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Process.Start("https://mrhamzaless.com");
        }
    }
}