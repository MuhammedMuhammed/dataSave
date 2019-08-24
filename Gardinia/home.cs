using Gardinia.GardModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gardinia
{
    public partial class home : Form
    {

        public home()
        {
            
            InitializeComponent();
            if(Sessions.SessionData.isAdmin != "True")
            {
                Add.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }
        static string connector = @"Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Directory.GetCurrentDirectory() + "\\ArchDB.accdb;Persist Security Info=false";
        megaProj mP = new megaProj();

        private void home_Load(object sender, EventArgs e)
        {
            try {
                DataSet ADSOMPs = mP.GetAllmegaProjData();
                foreach (DataRow ADROMPs in ADSOMPs.Tables[0].Rows) {
                    listBox1.Items.Add(ADROMPs["megaProjectName"].ToString());
                }
            }
            catch (Exception ex) { }
        }
        //""Provider=Microsoft.ACE.OleDb.12.0;Data Source="+Directory.GetCurrentDirectory()+"\\ArchDB.accdb;Persist Security Info=false"";  

        
        private void Add_Click(object sender, EventArgs e)
        {
            try {
                if (!String.IsNullOrEmpty(megaProjectName.Text))
                {


                            mP.megaProjectName = megaProjectName.Text;
                            mP.megaProjectFundemental = String.IsNullOrEmpty(megaProjectFundemental.Text) || String.IsNullOrWhiteSpace(megaProjectFundemental.Text) ? 0.0 : (double?)double.Parse(megaProjectFundemental.Text);
                            mP.noOfPhrases = String.IsNullOrEmpty(noOfPhrases.Text) || String.IsNullOrWhiteSpace(noOfPhrases.Text) ? 0 : int.Parse(noOfPhrases.Text);
                            bool success = mP.insertData(mP);
                            if (success)
                            {
                                Sessions.SessionData.megaProjectName = megaProjectName.Text;
                                DataView DV = new DataView();
                                DV.Show();
                                this.Hide();
                            }
                            else {
                                MessageBox.Show("Failed To Add Data");
                            }
                    


                }
                else
                {
                    MessageBox.Show("ادخل اسم المشروع");
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void bid_Click(object sender, EventArgs e)
        {

            //if (!String.IsNullOrEmpty(megaProjectName.Text))
            //{
                bool succeed = mP.selectDataCount(listBox1.SelectedItem.ToString());
                if (succeed) 
                {
                    Sessions.SessionData.megaProjectName = listBox1.SelectedItem.ToString();
                    DataView DV = new DataView();
                    DV.Show();
                    this.Hide();
                }
                else {
                    MessageBox.Show("المشروع غير متواجد");
                }


            //}
            //else
            //{
            //    MessageBox.Show("ادخل اسم المشروع");
            //}
        }
        DataView DV = new DataView();
        private void MegaProjComponents_Click(object sender, EventArgs e)
        {
            DV.FileUpload(MegaProjComponents, "مكونات المشروع", String.Format("المراحل"));
        }

        private void MegaProjTimeStrategy_Click(object sender, EventArgs e)
        {
            DV.FileUpload(MegaProjTimeStrategy, "رفع البرنامج الزمني للمشروع", String.Format("مشروع" + listBox1.SelectedItem.ToString()));
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                mP.megaProjectName = listBox1.SelectedItem.ToString();
                mP.DeleteData(mP);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
          
        }

        private void home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
