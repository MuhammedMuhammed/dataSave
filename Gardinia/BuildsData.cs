using Gardinia.GardModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    public partial class BuildsData : Form
    {
        string projType;
        public BuildsData(string text)
        {
            this.projType = text;
            InitializeComponent();
        }
        GroupBox GB;
        PictureBox pictureBox;
        Label ContractCode;
        string names = "";
        string labelname = "";
        int OnePage = 10;
        
        BuildData bd = new BuildData();
         
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }
        static string myconnecting = "Provider=Microsoft.ACE.OleDb.12.0;Data Source="+Directory.GetCurrentDirectory()+"\\ArchDB.accdb;Persist Security Info=false";
        int a = 1;
        string projectTypeSelection;
        private void BuildsData_Load(object sender, EventArgs e)
        {
            MessageBox.Show(Sessions.SessionData.megaProjectName);

            OleDbConnection conn = new OleDbConnection(myconnecting);
            this.projectTypeSelection = projType;
            string sql = "select * From BuildsMainTable where ProjectDataTypes='"+projType+ "' AND megaProjectName Like'" + Sessions.SessionData.megaProjectName + "'";
            OleDbCommand sqlcmd = new OleDbCommand (sql, conn);
            //DataTable dt = new DataTable();
            OleDbDataAdapter OleDbDataAdapter = new OleDbDataAdapter(sqlcmd);
            DataSet ds = new DataSet();
            conn.Open();
            OleDbDataAdapter.Fill(ds,"GardiniaProjects");
            //if (ds.Tables["GardiniaProjects"].Rows.Count > 0)

            //{
               
            //    MemoryStream ms = new MemoryStream((byte[])ds.Tables["GardiniaProjects"].Rows[0]["Image"]);

            //    pictureBox1.Image = new Bitmap(ms);
            //}
            if (ds.Tables[0].Rows.Count > 0)

            {
                flowLayoutPanel1.Controls.Clear();
                foreach (DataRow row in ds.Tables["GardiniaProjects"].Rows)
            {       GB = new GroupBox();
                    pictureBox = new PictureBox();
                    ContractCode = new Label();
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    //Image newImage = Image.FromFile(row["Image"].ToString());

                    Console.WriteLine(row["Image"].ToString());
                    string img = row["Image"].ToString();
                    //pictureBox.Image = ByteToImage(img);
                    //pictureBox.Height = 150;
                    //pictureBox.Width = 150;
                    pictureBox.Dock = DockStyle.Fill;
                    pictureBox.Name= row["ContractCode"].ToString();
                    names = pictureBox.Name;
                    ContractCode.Name = row["ContractCode"].ToString();
                    labelname = ContractCode.Name;
                    ContractCode.Text = row["ContractCode"].ToString();

                    //MemoryStream mStream = new MemoryStream(img);
                    pictureBox.ImageLocation = img;
                    GB.Top = a * 48;
                    GB.Left = 10;
                    GB.Height = 100;
                    GB.Width = 100;
                    GB.Location = new Point(20,20);
                    GB.Font = new Font("Segeo UI",15);
                    GB.FlatStyle = FlatStyle.Standard;
                    GB.Controls.Add(ContractCode);

                    //pictureBox.Top = ((GB.Height - (40 * 4)) / 2)+ 25;
                    //pictureBox.Left = ((GB.Width - 25 * 4) / 2);

                    //GB.Location = new Point(5, 5);
                    pictureBox.Font = new Font("Segeo UI", 1);
                    GB.FlatStyle = FlatStyle.Standard;
                    GB.Controls.Add(pictureBox);
                    //GB.MouseClick += pb_Click;
                    ContractCode.MouseClick += pb_Click;
                    pictureBox.MouseClick += pb_Click;
                    flowLayoutPanel1.Controls.Add(GB);
                   
                    OleDbDataAdapter.Dispose();
                    a++;
                }
                
            }
            conn.Close();
        }
        void getdataInPages() {
            OleDbConnection conn = new OleDbConnection(myconnecting);
            MessageBox.Show(Sessions.SessionData.megaProjectName);
            string sql = "select * From BuildsMainTable where megaProjectName ='" + Sessions.SessionData.megaProjectName + "'";
            OleDbCommand sqlcmd = new OleDbCommand (sql, conn);
            //DataTable dt = new DataTable();
            OleDbDataAdapter OleDbDataAdapter = new OleDbDataAdapter(sqlcmd);
            DataSet ds = new DataSet();
            conn.Open();
            OleDbDataAdapter.Fill(ds, "GardiniaProjects");
            //if (ds.Tables["GardiniaProjects"].Rows.Count > 0)

            //{

            //    MemoryStream ms = new MemoryStream((byte[])ds.Tables["GardiniaProjects"].Rows[0]["Image"]);

            //    pictureBox1.Image = new Bitmap(ms);
            //}
            if (ds.Tables[0].Rows.Count > 0)

            {
                flowLayoutPanel1.Controls.Clear();
                foreach (DataRow row in ds.Tables["GardiniaProjects"].Rows)
                {
                    GB = new GroupBox();
                    pictureBox = new PictureBox();
                    ContractCode = new Label();
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    //Image newImage = Image.FromFile(row["Image"].ToString());

                    Console.WriteLine(row["Image"].ToString());
                    string img = row["Image"].ToString();
                    //pictureBox.Image = ByteToImage(img);
                    //pictureBox.Height = 150;
                    //pictureBox.Width = 150;
                    pictureBox.Dock = DockStyle.Fill;
                    pictureBox.Name = row["ContractCode"].ToString();
                    names = pictureBox.Name;
                    ContractCode.Name = row["ContractCode"].ToString();
                    labelname = ContractCode.Name;
                    ContractCode.Text = row["ContractCode"].ToString();

                    //MemoryStream mStream = new MemoryStream(img);
                    pictureBox.ImageLocation = img;
                    GB.Top = a * 48;
                    GB.Left = 10;
                    GB.Height = 100;
                    GB.Width = 100;
                    GB.Location = new Point(10, 10);
                    GB.Font = new Font("Segeo UI", 15);
                    GB.FlatStyle = FlatStyle.Standard;
                    GB.Controls.Add(ContractCode);

                    //pictureBox.Top = ((GB.Height - (40 * 4)) / 2)+ 25;
                    //pictureBox.Left = ((GB.Width - 25 * 4) / 2);

                    //GB.Location = new Point(5, 5);
                    pictureBox.Font = new Font("Segeo UI", 1);
                    GB.FlatStyle = FlatStyle.Standard;
                    GB.Controls.Add(pictureBox);
                    //GB.MouseClick += pb_Click;
                    ContractCode.MouseClick += pb_Click;
                    pictureBox.MouseClick += pb_Click;
                    flowLayoutPanel1.Controls.Add(GB);

                    OleDbDataAdapter.Dispose();
                    a++;
                }

            }
            conn.Close();
        }
        private void pb_Click(object sender,EventArgs e)
        {
            //string msgStr = string.Format("Your monthly payment will be {0}", payment());
            //MessageBox.Show(msgStr);
            var pictureBox2 = GB.Controls.OfType<PictureBox>().FirstOrDefault(b => b.Name.Equals(this.Name));
            var ContractCode = GB.Controls.OfType<Label>().FirstOrDefault(b => b.Name.Equals(this.Name));
            ContractCode = sender as Label;
            pictureBox2 = sender as PictureBox;
            //ContractCode.Text = "clicked";
            //string imgbyte =pictureBox.Image.ToString();
            string contractcode = (sender == ContractCode as Label) ? ContractCode.Name : pictureBox2.Name;
            ImageMap IM = new ImageMap(contractcode);
            IM.Location = this.Location;
            IM.StartPosition = FormStartPosition.Manual;
            IM.FormClosing += delegate { this.Show(); };
            IM.Show();
            this.Hide();
        }
        
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        private void filldata()
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DataView DV = new DataView();
            DV.Show();
        }
        

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Select(textBox6.Text);
        }
        public void Select(String Keyword)
        {
               OleDbConnection conn = new OleDbConnection(myconnecting);
            string sql = "select * From BuildsMainTable where ((ContractCode LIKE '%" + Keyword + "%'or projectName LIKE '%" + Keyword + "%' or implementerCompany LIKE '%" + Keyword + "%' or (projectOwner LIKE '%" + Keyword + "%')) And ((ProjectDataTypes Like'" + projectTypeSelection + "') And (megaProjectName Like'" + Sessions.SessionData.megaProjectName + "')))";
            OleDbDataAdapter SA = new OleDbDataAdapter(sql, conn);
            DataSet dt = new DataSet();
            SA.Fill(dt, "ProjectsFilter");
            //if (ds.Tables["GardiniaProjects"].Rows.Count > 0)

            //{

            //    MemoryStream ms = new MemoryStream((byte[])ds.Tables["GardiniaProjects"].Rows[0]["Image"]);

            //    pictureBox1.Image = new Bitmap(ms);
            //}
            if (dt.Tables["ProjectsFilter"].Rows.Count > 0)

            {
                flowLayoutPanel1.Controls.Clear();
                foreach (DataRow row in dt.Tables["ProjectsFilter"].Rows)
                {
                    GB = new GroupBox();
                    pictureBox = new PictureBox();
                    ContractCode = new Label();
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    //Image newImage = Image.FromFile(row["Image"].ToString());

                    Console.WriteLine(row["Image"].ToString());
                    string img = row["Image"].ToString();
                    //pictureBox.Image = ByteToImage(img);
                    pictureBox.Height = 150;
                    pictureBox.Width = 150;
                    pictureBox.Name = row["ContractCode"].ToString();
                    names = pictureBox.Name;
                    ContractCode.Name = row["ContractCode"].ToString();
                    labelname = ContractCode.Name;
                    ContractCode.Text = row["ContractCode"].ToString();

                    //MemoryStream mStream = new MemoryStream(img);
                    pictureBox.ImageLocation = img;
                    GB.Top = a * 48;
                    GB.Left = 10;
                    GB.Height = 200;
                    GB.Width = 200;
                    GB.Location = new Point(20, 20);
                    GB.Font = new Font("Segeo UI", 15);
                    GB.FlatStyle = FlatStyle.Standard;
                    GB.Controls.Add(ContractCode);

                    pictureBox.Top = ((GB.Height - (40 * 4)) / 2) + 25;
                    pictureBox.Left = ((GB.Width - 25 * 4) / 2);

                    //GB.Location = new Point(5, 5);
                    pictureBox.Font = new Font("Segeo UI", 1);
                    GB.FlatStyle = FlatStyle.Standard;
                    GB.Controls.Add(pictureBox);
                    //GB.MouseClick += pb_Click;
                    ContractCode.MouseClick += pb_Click;
                    pictureBox.MouseClick += pb_Click;
                    flowLayoutPanel1.Controls.Add(GB);

                    SA.Dispose();
                    a++;
                }

            }
            conn.Close();


            //dataGridView1.DataSource = dt;
            //metroGrid2.DataSource = dtPD;
            //metroGrid1.DataSource = dtPR;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
