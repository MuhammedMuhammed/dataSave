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
using Spire.Pdf;
using Spire.PdfViewer;

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
                
                //PdfDocument pdfViewer = new PdfDocument();
                //pdfViewer.LoadFromFile(FileSrc);
                pdfViewer1.Dock = DockStyle.Fill;
                pdfViewer1.LoadFromFile(FileSrc);
                //webBrowser1.Visible = true;
                Uri uri;
                //FileSrc = "http://".Trim() + FileSrc.Trim();
                //if (!Uri.TryCreate(FileSrc, UriKind.Absolute, out uri))
                //{
                //    webBrowser1.Navigate(new Uri(FileSrc));

                //    webBrowser1.Dock = DockStyle.Fill;
                //    MessageBox.Show("Success");

                //    //Bad bad bad!
                //}
                //ShowNavigationControls();
                //// axAcroPDF1.src = FileSrc.ToLower();
                //// axAcroPDF1.Dock = DockStyle.Fill;
                //// axAcroPDF1.BeginInit();
                //// axAcroPDF1.LoadFile(FileSrc);
                //// axAcroPDF1.EndInit();

                Process.Start(FileSrc.ToLower());
                pictureBox1.Visible = false;
            }
            else if (imagesExe.Contains(Path.GetExtension(FileSrc)))
            {

                pictureBox1.Image = new Bitmap(FileSrc);
                pictureBox1.Dock = DockStyle.Fill;
                //// axAcroPDF1.Visible = false;
            }
            }

        private void pdf_Load(object sender, EventArgs e)
        {
            //webBrowser1.Visible = false;
        }
    }
}
