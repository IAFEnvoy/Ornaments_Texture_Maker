using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ornaments_Texture_Maker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.png|*.png";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            Image input = Image.FromFile(ofd.FileName);
            int scale = 1;
            while (input.Width >= 20 * scale && input.Height >= 20 * scale) scale += 1;
            scale -= 1;
            if (scale == 0) return;
            Bitmap output = new Bitmap(64 * scale, 64 * scale);
            Graphics g = Graphics.FromImage(output);
            g.Clear(Color.FromArgb(50, 50, 50));
            g.DrawImage(input, scale + 1, scale + 1, scale * 20, scale * 40);
            g.Save();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.png|*.png";
            sfd.FileName = ofd.FileName;
            if (sfd.ShowDialog() != DialogResult.OK) return;
            output.Save(sfd.FileName);
            Application.Exit();
        }
    }
}
