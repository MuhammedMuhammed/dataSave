using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gardinia
{
    public partial class pdf : Form
    {
        string[] imagesExe = {".jpg", ".png", ".TIF", ".GIF", ".jpeg" };
        public pdf(String FileSrc)
        {
            InitializeComponent();
            if (Path.GetExtension(FileSrc).ToLower() == ".pdf")
            {
                axAcroPDF1.src = FileSrc.ToLower();
                axAcroPDF1.Dock = DockStyle.Fill;
                //axAcroPDF1.BeginInit();
                //axAcroPDF1.LoadFile(FileSrc);
                //axAcroPDF1.EndInit();
                
                Process.Start(FileSrc.ToLower());
                pictureBox1.Visible = false;
            }
            else if (imagesExe.Contains(Path.GetExtension(FileSrc)))
            {

                pictureBox1.Image = new Bitmap(FileSrc);
                pictureBox1.Dock = DockStyle.Fill;
                axAcroPDF1.Visible = false;
            }
            }

        private void pdf_Load(object sender, EventArgs e)
        {

        }
    }
}
