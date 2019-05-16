using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gardinia
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }
        static string myconnecting = "Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Directory.GetCurrentDirectory() + "\\ArchDB.accdb;Persist Security Info=false";
    
        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(myconnecting);

            try
            {
                string query = "select * from [users] where [UserName]='" + textBox1.Text + "'";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataRow dr = ds.Tables[0].Rows[0];
                string isAdmin = String.IsNullOrEmpty(dr["Admin"].ToString()) ? null : dr["Admin"].ToString();

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (dr["Password"].ToString() == textBox2.Text)
                    {
                        Sessions.SessionData.isAdmin = isAdmin;

                        Sessions.SessionData.UserName = textBox1.Text;
                        MessageBox.Show("Login Successful");
                        MessageBox.Show(isAdmin);
                        MessageBox.Show(Sessions.SessionData.UserName);

                        home h = new home();
                        this.Hide();
                        h.Show();

                    }
                    else
                    {
                        MessageBox.Show("ادخل كلمة المرور الصحيحة");

                    }
                }
                else
                {

                    MessageBox.Show("يوجد خطا في اسم المستخدم");

                }
            }
            catch (Exception ex)
            {
                //var st = new StackTrace(ex, true);
                //// Get the top stack frame
                //var frame = st.GetFrame(st.FrameCount - 1);
                //// Get the line number from the stack frame
                //var line = frame.GetFileLineNumber();
                //MessageBox.Show(ex.Message, line.ToString());
            }
            finally {
                conn.Close();
            }

        }
        KeyEventArgs keyEventArgs;
        private void loginForm_Load(object sender, EventArgs e)
        {
            
           
        }

        private void loginForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void loginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
    }
}
