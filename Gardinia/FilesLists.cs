using ExcelDataReader;
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
    public partial class FilesLists : Form
    {
        public FilesLists(DataTable dt)
        {
            InitializeComponent();

            metroComboBox1.Visible =false;
            metroGrid1.Visible = false;
            metroLabel1.Visible = false;
            
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem listViewItem = new ListViewItem();
                if (dt.TableName == "ProjectReports" || dt.TableName == "ProjectImages") { 
                listBox1.Items.Add(dr[0].ToString());
                
                } else if (dt.TableName == "AsBuiltTable")
                {
                    listBox1.Items.Add(dr[1].ToString());
                }
                else if (dt.TableName == "BuildsMainTable")
                {
                    

                    Excel(dr[0].ToString());
        
                }
            }


        }
        DataSet result;
        string[] ExcelExe = { ".csv", ".xlsx", "..xls" };

        public void Excel(string text)
        {
                if (ExcelExe.Contains(Path.GetExtension(listBox1.SelectedItem.ToString())))
            {
                metroComboBox1.Visible = true;
                metroGrid1.Visible = true;
                metroLabel1.Visible = true;
                //// axAcroPDF1.Visible = false;

                pictureBox1.Visible = false;

                FileStream fileStream = File.Open(text, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelDataReader = ExcelReaderFactory.CreateReader(fileStream);
                //excelDataReader.IsFirstRowAsColumnNames = true;
                result = excelDataReader.AsDataSet();
                metroComboBox1.Items.Clear();
                foreach (DataTable dt in result.Tables)
                {
                    metroComboBox1.Items.Add(dt.TableName);
                    excelDataReader.Close();
                }
            }
            else { }
            }



        private void FilesLists_Load(object sender, EventArgs e)
        {

        }
        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] imagesExe = { ".jpg", ".png", ".tif", ".gif", ".jpeg" };

            if (listBox1.SelectedItem != null && !String.IsNullOrEmpty(listBox1.SelectedItem.ToString()))
            {
                if (Path.GetExtension(listBox1.SelectedItem.ToString()).ToLower() == ".pdf")
                {
                    pdfViewer1.LoadFromFile(listBox1.SelectedItem.ToString().ToLower());
                    //// axAcroPDF1.src = listBox1.SelectedItem.ToString().ToLower();
                    pdfViewer1.Dock = DockStyle.Fill;
                    
                    pdfViewer1.Visible = true;
                    
                    pdfViewer1.SetViewerMode(Spire.PdfViewer.Forms.PdfViewerMode.PdfViewerMode.Auto); 
                    //PictureBox p;
                    
                    //Process.Start(listBox1.SelectedItem.ToString().ToLower());

                    metroComboBox1.Visible = false;
                    metroGrid1.Visible = false;
                    metroLabel1.Visible = false;
                    pictureBox1.Visible = false;
                }
                else if (imagesExe.Contains(Path.GetExtension(listBox1.SelectedItem.ToString()).ToLower()))
                {

                    pictureBox1.Image = new Bitmap(listBox1.SelectedItem.ToString());
                    pictureBox1.Dock = DockStyle.Fill;
                    pictureBox1.Visible = true;
                    pdfViewer1.Visible = false;
                    metroComboBox1.Visible = false;
                    metroGrid1.Visible = false;
                    metroLabel1.Visible = false;
                }
                else {
                    MessageBox.Show("ليس ملف");
                }
            }
        }
    }
}
