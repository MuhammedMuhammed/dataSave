using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gardinia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        static string myconnecting = "Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Directory.GetCurrentDirectory() + "\\ArchDB.accdb;Persist Security Info=false";

        private void button1_Click(object sender, EventArgs e)
        {
            //bool isAdmin;
            //if (checkBox1.Checked) {
            //    isAdmin = true;
            //}

            //if ()
                string query = "insert into users ([UserName],[Password],[Admin],[Name])values('" + textBox2.Text + "','" + textBox3.Text + "'," + checkBox1.Checked + ",'" + textBox1.Text+ "')";
            OleDbConnection conn = new OleDbConnection(myconnecting);
            try
            {
                OleDbCommand cmd = new OleDbCommand(query, conn);
                conn.Open();

                int reader = cmd.ExecuteNonQuery();
                if (reader>0)
                {
                        
                        MessageBox.Show("تم تسجيل المستخدم بنجاح");
                       
                        home h = new home();
                        this.Hide();
                    
                   
                }
                else
                {

                    MessageBox.Show(" اسم المستخدم موجود ارجو ادخال اسم اخر");

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
    }
}
