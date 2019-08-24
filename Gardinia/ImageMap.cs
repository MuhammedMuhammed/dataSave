using EasyTabs;
using Gardinia.GardModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
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
    public partial class ImageMap : Form
    {
        static string myconnecting = "Provider=Microsoft.ACE.OleDb.12.0;Data Source="+Directory.GetCurrentDirectory()+"\\ArchDB.accdb;Persist Security Info=false";
        string[] imagesExe = { ".jpg", ".png", ".TIF", ".GIF", ".jpeg" };
        DataSet ds;
        string imagebitmap;
        protected TitleBarTabs parenttabs {
            get {
                return (ParentForm as TitleBarTabs);
            }
        }
        string sqlReports = "";
        string sql = "";
        string sqlNotes="";
        string projectCoDe;
        Dictionary<String, String> Buttonstxts = new Dictionary<string, string>();
        
        //string percentageOfImplementationDetails;
        //string metroButton1;
        //string DurationProgram;
        //string notices;
        //string projectIndexation;
        //string metroButton4;
        //string receiptOfTheSite;
        //string locationOfCheckingDrillingBottom;
        //string projectNotes;
        //string Button10;
        //string Button11;


        public ImageMap(string ProjectCode)
        {
            
            InitializeComponent();
            Buttonstxts.Add("percentageOfImplementationDetails",percentageOfImplementationDetails.Text);
            Buttonstxts.Add("metroButton1", metroButton1.Text);
            Buttonstxts.Add("DurationProgram", DurationProgram.Text);
            Buttonstxts.Add("notices", notices.Text);
            Buttonstxts.Add("projectIndexation", projectIndexation.Text);
            Buttonstxts.Add("metroButton4", metroButton4.Text);
            Buttonstxts.Add("receiptOfTheSite", receiptOfTheSite.Text);
            Buttonstxts.Add("locationOfCheckingDrillingBottom", locationOfCheckingDrillingBottom.Text);
            Buttonstxts.Add("projectNotes", projectNotes.Text);
            
            this.projectCoDe = ProjectCode;
            //tabControl1.SelectTab();
            OleDbConnection conn = new OleDbConnection(myconnecting);

            try
            {
                sqlReports = "select * From ProjectReports where ContractCode='" + ProjectCode + "'";
                sql = "select * From BuildsMainTable where ContractCode='" + ProjectCode + "'";

                tabControl1.SelectedIndex = 0;

            
                // Builds Table
                OleDbCommand sqlcmd = new OleDbCommand(sql, conn);
                //DataTable dt = new DataTable();
                OleDbDataAdapter OleDbDataAdapter = new OleDbDataAdapter(sqlcmd);

                ds = new DataSet();
                conn.Open();
                OleDbDataAdapter.Fill(ds, "GardiniaProjects");
                if (ds.Tables["GardiniaProjects"].Rows.Count > 0)

                {
                    string imagebytes = ds.Tables["GardiniaProjects"].Rows[0]["Image"].ToString();
                    //   byte[] imagebytes1 = System.Text.Encoding.Unicode.GetBytes();
                    //MemoryStream ms = new MemoryStream(imagebytes);
                    //this.pictureBox1.Image = Image.FromStream(ms);
                    Console.Write(imagebytes);
                    label2.Text = ProjectCode;
                    MessageBox.Show(" " + ProjectCode);
                    //textBox24.Text = ds.Tables["GardiniaProjects"].Rows[0]["ContractCode"].ToString();
                    textBox5.Text = ds.Tables["GardiniaProjects"].Rows[0]["projectOwner"].ToString();
                    textBox8.Text = ds.Tables["GardiniaProjects"].Rows[0]["implementerCompany"].ToString();
                    textBox4.Text = ds.Tables["GardiniaProjects"].Rows[0]["projectConsultative"].ToString();
                    textBox9.Text = ds.Tables["GardiniaProjects"].Rows[0]["projectName"].ToString();
                    metroDateTime1.Text = ds.Tables["GardiniaProjects"].Rows[0]["startingProjectDate"].ToString();
                    textBox12.Text = ds.Tables["GardiniaProjects"].Rows[0]["periodToImplementProject"].ToString();
                    metroDateTime3.Text = ds.Tables["GardiniaProjects"].Rows[0]["EndingOfContractorDate"].ToString();
                    metroDateTime4.Text = ds.Tables["GardiniaProjects"].Rows[0]["LastTimeForEndingProject"].ToString();
                    textBox1.Text = ds.Tables["GardiniaProjects"].Rows[0]["AddedPeriodToProject"].ToString();
                    textBox11.Text = ds.Tables["GardiniaProjects"].Rows[0]["percentageOfImplementation"].ToString();
                    textBox2.Text = ds.Tables["GardiniaProjects"].Rows[0]["AddedPeriodToProject"].ToString();
                    textBox25.Text = ds.Tables["GardiniaProjects"].Rows[0]["contractValue"].ToString();
                    textBox27.Text = ds.Tables["GardiniaProjects"].Rows[0]["FinalClosing"].ToString();
                    textBox26.Text = ds.Tables["GardiniaProjects"].Rows[0]["lastExactract"].ToString();
                    textBox30.Text = ds.Tables["GardiniaProjects"].Rows[0]["Division"].ToString();
                    textBox28.Text = ds.Tables["GardiniaProjects"].Rows[0]["savingsValue"].ToString();

                    pictureBox1.ImageLocation = imagebytes;
                    //if (Path.GetExtension(ds.Tables["GardiniaProjects"].Rows[0]["receiptOfTheSite"].ToString()) == ".pdf")
                    //{

                    //    // axAcroPDF1.src = ds.Tables["GardiniaProjects"].Rows[0]["receiptOfTheSite"].ToString();
                    //    // axAcroPDF1.Dock = DockStyle.Fill;
                    //    pictureBox5.Visible = false;
                    //} else if (imagesExe.Contains(Path.GetExtension(ds.Tables["GardiniaProjects"].Rows[0]["receiptOfTheSite"].ToString())))
                    //{
                    //    pictureBox5.ImageLocation = ds.Tables["GardiniaProjects"].Rows[0]["receiptOfTheSite"].ToString();
                    //    // axAcroPDF1.Visible = false;
                    //    pictureBox5.Dock = DockStyle.Fill;

                    //}
                    //if (Path.GetExtension(ds.Tables["GardiniaProjects"].Rows[0]["projectNotes"].ToString()) == ".pdf")
                    //{
                    //    axAcroPDF2.src = ds.Tables["GardiniaProjects"].Rows[0]["projectNotes"].ToString();
                    //    axAcroPDF2.Dock = DockStyle.Fill;
                    //    pictureBox6.Visible = false;
                    //}
                    //else if (imagesExe.Contains(Path.GetExtension(ds.Tables["GardiniaProjects"].Rows[0]["projectNotes"].ToString())))
                    //{
                    //    pictureBox6.ImageLocation = ds.Tables["GardiniaProjects"].Rows[0]["projectNotes"].ToString();
                    //    pictureBox6.Dock = DockStyle.Fill;
                    //    axAcroPDF2.Visible = false;
                    //}

                    MultiData(ProjectCode);

                }
                conn.Close();
            }
            catch (Exception ex) {
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(st.FrameCount - 1);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                MessageBox.Show(ex.Message);
            }

            //imagebitmap = imagebytes;
            //await bot.sendPhotoAsync(u.Message.Chat.Id, ms).ConfigureAwait;
            

            //Reports Tables
            OleDbCommand sqlRcmd = new OleDbCommand (sqlReports, conn);
            //DataTable dt = new DataTable();
            OleDbDataAdapter sqlRDataAdapter = new OleDbDataAdapter(sqlRcmd);

            DataSet dsR = new DataSet();
            try { 
            conn.Open();
                //    sqlDataReader = sqlRcmd.ExecuteReader();
                //while (sqlDataReader.Read()) { 
                ////string dustreport =sqlDataReader.GetString("dustReport")
                //        listViewItem.SubItems.Add(sqlDataReader["dustReport"].ToString());
                //        listViewItem.SubItems.Add(sqlDataReader["recordingdateOnDB"].ToString());
                //        metroListView1.Items.Add(listViewItem);

                //OleDbDataAdapter.Fill(dsR, "GardiniaProjectsDustReports");
                DataTable dt = new DataTable();
                sqlRDataAdapter.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem listViewItem = new ListViewItem(dr["recordingdateOnDB"].ToString());

                    listViewItem.SubItems.Add(dr["dustReport"].ToString());
                    listViewItem.SubItems.Add(dr["ContractCode"].ToString());
                    //metroListView1.Items.Add(listViewItem);


                }
            }
            catch(Exception ex) {
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(st.FrameCount - 1);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                MessageBox.Show(ex.Message);
            }
            //if (ds.Tables["GardiniaProjects"].Rows.Count > 0)

            //{
            //    byte[] imagebytes = (byte[])ds.Tables["GardiniaProjects"].Rows[0]["Image"];
            //    //   byte[] imagebytes1 = System.Text.Encoding.Unicode.GetBytes();
            //    MemoryStream ms = new MemoryStream(imagebytes);
            //    //this.pictureBox1.Image = Image.FromStream(ms);
            //    Console.Write(imagebytes);
            //    label2.Text = ProjectCode;
            //    MessageBox.Show(" " + ProjectCode);
            //    pictureBox1.Image = new Bitmap(ms);
            //}


            if (Sessions.SessionData.isAdmin != "True")
            {
                foreach (TabPage tabPage in tabControl1.TabPages) {
                    foreach (Control ctrl in tabPage.Controls)
                    {
                    
                            ctrl.Enabled = false;
                    
                    }
                }
            }
            }
        GroupBox GBSPI;
        PictureBox PBSPI;
        private void MultiData(string projectCode)
        {
            
            string query = "select Image from ProjectImages WHERE ContractCode='" + projectCode + "'";
            
OleDbConnection SSPI = new OleDbConnection(myconnecting);
            OleDbCommand SCSPI = new OleDbCommand (query, SSPI);
            SSPI.Open();
            int rows = SCSPI.ExecuteNonQuery();
            try
            {
                //if (rows > 0)
                //{
                    OleDbDataAdapter SDASPI = new OleDbDataAdapter(SCSPI);
                    DataSet DSSPI = new DataSet();
                    SDASPI.Fill(DSSPI,"ImagesFilespaths");
                    
                    //flowLayoutPanel1.Controls.Clear();
                int a = 0;
                MessageBox.Show(DSSPI.Tables["ImagesFilespaths"].Rows.Count.ToString());
                //foreach (DataRow DRSPI in DSSPI.Tables["ImagesFilespaths"].Rows)
                //    {
                            
                //        if (imagesExe.Contains(Path.GetExtension(DRSPI["Image"].ToString()).ToLower()))
                //        {
                //        GBSPI = new GroupBox();
                //            PBSPI = new PictureBox();
                //            PBSPI.SizeMode = PictureBoxSizeMode.StretchImage;
                //            PBSPI.Dock = DockStyle.Bottom;
                //            PBSPI.Name = a.ToString();
                //            PBSPI.ImageLocation = DRSPI["Image"].ToString();
                //            GBSPI.Top = a * 48;
                //            GBSPI.Left = 10;
                //            GBSPI.Width = 100;
                //            GBSPI.Height = 100;
                //            GBSPI.Font = new Font("Segeo UI", 15);
                //            GBSPI.FlatStyle = FlatStyle.Standard;
                //            GBSPI.Controls.Add(PBSPI);

                //            //flowLayoutPanel1.Controls.Add(GBSPI);
                        
                //        SDASPI.Dispose();
                //    }
                //    else
                //        {
                //            MessageBox.Show("not images");

                //        }
                //    a++;

                //}

                MessageBox.Show("Reached DataBase");
                SSPI.Close();
                //}
            }
            catch (
            
            Exception ex) {
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(st.FrameCount - 1);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                SSPI.Close();

                MessageBox.Show(ex.Message);
            }
        }
        // Fi
        public DataTable List(string ProjectUniqueCode ,String SqlQuery,string TableName)
            {
            OleDbConnection conn = new OleDbConnection(myconnecting);

            OleDbCommand sqlRcmd = new OleDbCommand (SqlQuery, conn);
            //DataTable dt = new DataTable();
            OleDbDataAdapter sqlRDataAdapter = new OleDbDataAdapter(sqlRcmd);
            //OleDbDataReader sqlDataReader;

                
                DataSet dsR = new DataSet();
                DataTable dt = new DataTable();
            dt.TableName = TableName;
            try
            {
                conn.Open();
                //    sqlDataReader = sqlRcmd.ExecuteReader();
                //while (sqlDataReader.Read()) { 
                ////string dustreport =sqlDataReader.GetString("dustReport")
                //        listViewItem.SubItems.Add(sqlDataReader["dustReport"].ToString());
                //        listViewItem.SubItems.Add(sqlDataReader["recordingdateOnDB"].ToString());
                //        metroListView1.Items.Add(listViewItem);

                //OleDbDataAdapter.Fill(dsR, "GardiniaProjectsDustReports");
                sqlRDataAdapter.Fill(dt);
                conn.Close();

            }
            catch (Exception ex)
            {
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(st.FrameCount - 1);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                MessageBox.Show(ex.Message);
                conn.Close();

            }
            finally {
        
            }
            return dt;
        }
        private void pictureBox1_MouseMove(object sender, EventArgs e)
        {
            int X = pictureBox1.PointToClient(Cursor.Position).X;
            int Y = pictureBox1.PointToClient(Cursor.Position).Y;

        }

        private void ImageMap_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 232, 232);
            //System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            //byte[] imagebytes1 = System.Text.Encoding.Unicode.GetBytes(imagebitmap.ToString());
            //MemoryStream ms = new MemoryStream(imagebytes1);
            //this.pictureBox1.Image = new Bitmap(ms);
            Deductions();
            AddDataToDropDownList();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DataView dv = new DataView();
                dv.Show();
        }

        private void metroListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rowIndex = e.ToString();
        }

        private void axAcroPDF2_OnError(object sender, EventArgs e)
        {

        }

        private void metroListView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

            
        }
        
        private void metroListView1_ItemActivate(object sender, EventArgs e)
        {
            //ListViewItem listViewItem = metroListView1.SelectedItems[0];
            //string Filepath = listViewItem.SubItems[1].Text;
            //axAcroPDF3.src = Filepath;
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            string queries = "Select * from deductionTable Where ContractCode='"+ label2.Text + "'";
            OleDbConnection SelectdeductionsConn = new OleDbConnection(myconnecting);
            OleDbCommand SelectDeductionsCommand = new OleDbCommand (queries,SelectdeductionsConn);
            OleDbDataAdapter SelectDeductionsAdapter = new OleDbDataAdapter(SelectDeductionsCommand);
            SelectdeductionsConn.Open();
            DataSet SelectDeductionDS = new DataSet();
            SelectDeductionsAdapter.Fill(SelectDeductionDS);
            foreach (DataRow SDDR in SelectDeductionDS.Tables[0].Rows)
            {
                metroGrid1.Rows.Add(SDDR["type"]);
                metroGrid1.Rows.Add(SDDR["PricePerUnit"]);
                metroGrid1.Rows.Add(SDDR["Importer"]);
                metroGrid1.Rows.Add(SDDR["amount"]);
                metroGrid1.Rows.Add(SDDR["totalValue"]);
                metroGrid1.Rows.Add(SDDR["Deduction"]);
                metroGrid1.Rows.Add(SDDR["validDeduction"]);
                metroGrid1.Rows.Add(SDDR["confirmedDeductionVal"]);
                metroGrid1.Rows.Add(SDDR["DeductionPrice"]);
                metroGrid1.Rows.Add(SDDR["notes"]);

            }

        }
        public void Deductions() {
            string queries = "Select * from deductionTable Where ProjectCode='" + label2.Text + "'";
            OleDbConnection SelectdeductionsConn = new OleDbConnection(myconnecting);
            OleDbCommand SelectDeductionsCommand = new OleDbCommand (queries, SelectdeductionsConn);
            OleDbDataAdapter SelectDeductionsAdapter = new OleDbDataAdapter(SelectDeductionsCommand);
            SelectdeductionsConn.Open();
            DataSet SelectDeductionDS = new DataSet();
            SelectDeductionsAdapter.Fill(SelectDeductionDS);
            SelectdeductionsConn.Close();
            foreach (DataRow SDDR in SelectDeductionDS.Tables[0].Rows)
            {
                metroGrid1.Rows.Add(SDDR["type"], SDDR["PricePerUnit"], SDDR["Importer"], SDDR["amount"], SDDR["totalValue"], SDDR["Deduction"], SDDR["validDeduction"], SDDR["confirmedDeductionVal"], SDDR["DeductionPrice"], SDDR["notes"]);
           
                metroGrid1.Rows.Add();
                metroGrid1.Rows.Add();
                metroGrid1.Rows.Add();

            }
        }

        private void metroButton27_Click(object sender, EventArgs e)
        {
            //OpenFileDialog PDFUPLOADS = new OpenFileDialog()
            //{
            //    Filter = "Excel Work Book 97-2003|*.xls; *.xlsx; *.csv",
            //    ValidateNames = true
            //};
            //DialogResult result = PDFUPLOADS.ShowDialog();

            //if (result == DialogResult.OK)
            //{
            //    string file = PDFUPLOADS.FileName;
            //    string[] f = file.Split('\\');
            //    string fn = f[(f.Length) - 1];
            //    string path = String.Format(@"C:\Users\dell\source\repos\Gardinia\Gardinia\pdfs\{0}", fn);
            //    MessageBox.Show(f + ",,,,," + fn);
            //    File.Copy(file, path, true);
            //    pdfloc = path;
            //    metroButton1.Text = path;

            //}
            try {
                if (!(sender as Button).Text.Equals("تقرير التربة") && !(sender as Button).Text.Equals("صور المشروع") && !(sender as Button).Text.Equals("لوحات المشروع + Asbuilt") && !(sender as Button).Text.Equals("حصر المشروع"))
                {
                    if (ds.Tables["GardiniaProjects"].Rows.Count > 0)

                    {
                        if (!ds.Tables["GardiniaProjects"].Rows[0][(sender as Button).Name.ToString()].Equals(null))
                        {
                            pdf PDF = new pdf(ds.Tables["GardiniaProjects"].Rows[0][(sender as Button).Name.ToString()].ToString());
                            PDF.ShowDialog();
                        }
                    }
                }
                else if ((sender as Button).Text.Equals("تقرير التربة"))
                {
                    sqlReports = "select [*] From [ProjectReports] where [ContractCode]='" + projectCoDe + "'";
                    List(projectCoDe, sqlReports, "ProjectReports");
                    FilesLists FLS = new FilesLists(List(projectCoDe, sqlReports, "ProjectReports"));
                    FLS.Text = projectCoDe;
                    FLS.ShowDialog();

                }
                else if ((sender as Button).Text.Equals("صور المشروع"))
                {
                    sqlReports = "select * From ProjectImages where ContractCode='" + projectCoDe + "'";
                    List(projectCoDe, sqlReports, "ProjectImages");
                    FilesLists FLS = new FilesLists(List(projectCoDe, sqlReports, "ProjectImages"));
                    FLS.Text = projectCoDe;
                    FLS.ShowDialog();
                }
                else if ((sender as Button).Text.Equals("لوحات المشروع + Asbuilt"))
                {
                    sqlReports = "select * From AsBuiltTable where ContractCode='" + projectCoDe + "'";
                    List(projectCoDe, sqlReports, "AsBuiltTable");
                    FilesLists FLS = new FilesLists(List(projectCoDe, sqlReports, "AsBuiltTable"));
                    FLS.Text = projectCoDe;
                    
                    FLS.ShowDialog();
                    FLS.MaximizeBox=true;
                }
                else
                {
                    sqlReports = "select [BuildReport] From [BuildsMainTable] where [ContractCode]='"+projectCoDe+"'";
                    List(projectCoDe, sqlReports, "BuildsMainTable");
                    FilesLists FLS = new FilesLists(List(projectCoDe, sqlReports, "BuildsMainTable"));
                    FLS.Text = projectCoDe;
                    FLS.ShowDialog();
                    FLS.MaximizeBox = true;

                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        bool datechanged = false;
        BuildData bd = new BuildData();
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bd.ContractCode = String.IsNullOrEmpty(label2.Text) ? null : label2.Text;
                bd.projectName = String.IsNullOrEmpty(textBox9.Text) ? null : textBox9.Text;
                bd.projectOwner = String.IsNullOrEmpty(textBox5.Text) ? null : textBox5.Text; ;
                bd.projectrecordingDate = DateTime.Now;
                bd.implementerCompany = String.IsNullOrEmpty(textBox8.Text) ? null : textBox8.Text; /*textBox4.Text*/;
                bd.projectConsultative = String.IsNullOrEmpty(textBox4.Text) ? null : textBox4.Text;
                bd.startingProjectDate = datechanged ? (DateTime?)metroDateTime1.Value.Date : null;
                bd.EndingOfContractorDate = datechanged ? (DateTime?)metroDateTime3.Value.Date : null;
                bd.LastTimeForEndingProject = datechanged ? (DateTime?)metroDateTime4.Value.Date : null;

                //bd.Sandreport = textBox5.Text;
                bd.periodToImplementProject = String.IsNullOrEmpty(textBox12.Text) ? null : textBox12.Text;
                bd.projectPhrase = String.IsNullOrEmpty(BuildPhrases.Text) ? null : BuildPhrases.Text;
                bd.BuildUnitsFrom = textBox3.Text == "" ? null : (int?)int.Parse(textBox3.Text);
                bd.BuildUnitsTo = String.IsNullOrEmpty(textBox13.Text) ? null : (int?)int.Parse(textBox13.Text);

                ////bd.Sandreport = textBox5.Text;
                //bd.periodToImplementProject = textBox12.Text;
                ////bd.projectPhrase = BuildPhrases.Text;
                //bd.BuildUnitsFrom = textBox3.Text == "" ? null : (int?)int.Parse(textBox3.Text);
                //bd.BuildUnitsTo = int.Parse(textBox13.Text);
                ////bd.BUildedDateAndTime = DateTime.Now;

                bd.Image = null;// label6.Text == "صورة المشروع" || label6.Text == "" ? null : label6.Text;
                                //bd.DurationProgram = DurationProgram.Text == "البرنامج الزمني" || DurationProgram.Text == "" ? null : DurationProgram.Text;
                                //bd.projectName =String.IsNullOrEmpty(textBox9.Text) ? null : textBox9.Text;
                                //bd.projectIndexation = projectIndexation.Text == "مقايسة المشروع" || projectIndexation.Text == "" ? null : projectIndexation.Text /*textBox4.Text*/;
                                //bd.locationOfCheckingDrillingBottom = locationOfCheckingDrillingBottom.Text == "مجضر معاينة قاع الحفر " || locationOfCheckingDrillingBottom.Text == "" ? null : locationOfCheckingDrillingBottom.Text;
                                //bd.receiptOfTheSite = receiptOfTheSite.Text == "محضر استلام الموقع" || receiptOfTheSite.Text == "" ? null : receiptOfTheSite.Text;
                                //bd.projectNotes = projectNotes.Text == "ملاحظات المشروع" || projectNotes.Text == "" ? null : projectNotes.Text;
                                //bd.BuildReport = metroButton1.Text == "حصر المشروع" || metroButton1.Text == "" ? null : metroButton1.Text;
                                //bd.notices = notices.Text == "الاخطار" || notices.Text == "" ? null : notices.Text;
                bd.contractValue = textBox25.Text == "" ? null : (double?)double.Parse(textBox25.Text);
                bd.FinalClosing = textBox27.Text == "" ? null : (double?)double.Parse(textBox27.Text);
                bd.lastExactract = textBox26.Text == "" ? null : (double?)double.Parse(textBox26.Text);
                bd.Division = textBox30.Text == "" ? null : (double?)double.Parse(textBox30.Text);
                bd.savingsValue = textBox28.Text == "" ? null : (double?)double.Parse(textBox28.Text);

                bd.contractValueFile = contractValueFile.Text == "القيمة التعاقدية" || browsecontractValueFile.Text == "" ? null : browsecontractValueFile.Text;
                bd.FinalClosingFile = FinalClosingFile.Text == "الختامي المنتظر" || browseFinalClosingFile.Text == "" ? null : browseFinalClosingFile.Text;
                bd.lastExactractFile =browselastExactractFile.Text == "اخرمستخلص" || browselastExactractFile.Text == "" ? null : browselastExactractFile.Text;
                bd.Savings = browseSavings.Text == "الوفر" || browseSavings.Text == "" ? null : browseSavings.Text;
                bd.Receipts = browseReceipts.Text == "طلبات الاستلام" || browseReceipts.Text == "" ? null : browseReceipts.Text;
                bd.Appropriations = BrowseAppropriations.Text == "الاعتمادات المخصصة" || BrowseAppropriations.Text == "" ? null : BrowseAppropriations.Text;
                bd.SiteOrders = BrowseSiteOrders.Text == "اوامر الموقع" || BrowseSiteOrders.Text == "" ? null : BrowseSiteOrders.Text;
                bd.ManagementMails = browseManagementMails.Text == "جوابات الادارة" || browseManagementMails.Text == "" ? null : browseManagementMails.Text;
                bd.Netbudget = browseNetbudget.Text == "الميزانية الشبكية" || browseNetbudget.Text == "" ? null : browseNetbudget.Text;
                bd.ConstructionSafetyReport = browseConstructionSafetyReport.Text == "تقرير السلامة الانشائية" || browseConstructionSafetyReport.Text == "" ? null : browseConstructionSafetyReport.Text;
                bd.ExploitationReductionandCancellationNotes = browseExploitationReductionandCancellationNotes.Text == "مذكرات التجاوز و المخفض و الملغى" || browseExploitationReductionandCancellationNotes.Text == "" ? null : browseExploitationReductionandCancellationNotes.Text;
                bd.ProjectDataTypes = metroComboBox1.Text == "" ? null : metroComboBox1.Text;
                bd.projectImages = browsemetroButton11.Text == "صور المشروع" || browsemetroButton11.Text == "" ? null : browsemetroButton11.Text;
                bd.TotalDeductionsValues = textBox24.Text == "" || textBox24.Text == null ? 0.0 : (double?)double.Parse(textBox24.Text);
                bd.percentageOfImplementationDetails = String.IsNullOrEmpty(BrowsepercentageOfImplementationDetails.Text) ? null : BrowsepercentageOfImplementationDetails.Text;
                bd.BuildReport = String.IsNullOrEmpty(BrowsemetroButton1.Text) ? null : BrowsemetroButton1.Text;
                bd.DurationProgram = string.IsNullOrEmpty(BrowseDurationProgram.Text) ? null : BrowseDurationProgram.Text;
                bd.notices = string.IsNullOrEmpty(Browsnotices.Text) ? null : Browsnotices.Text;
                bd.projectIndexation = string.IsNullOrEmpty(BrowseprojectIndexation.Text) ? null : BrowseprojectIndexation.Text;
                bd.receiptOfTheSite = string.IsNullOrEmpty(BrowsereceiptOfTheSite.Text) ? null : BrowsereceiptOfTheSite.Text;
                bd.locationOfCheckingDrillingBottom = string.IsNullOrEmpty(BroselocationOfCheckingDrillingBottom.Text) ? null : BroselocationOfCheckingDrillingBottom.Text;
                bd.projectNotes = string.IsNullOrEmpty(BroseprojectNotes.Text) ? null : BroseprojectNotes.Text;
                bd.PhraseID = String.IsNullOrEmpty(BuildPhrases.Text) ? null :(int?) PT.selectID(Sessions.SessionData.megaProjectName, BuildPhrases.Text);

                bool success = bd.Update(bd);
                if (success == true)
                {

                    MessageBox.Show("data updated");
                    DataTable dt = bd.Select();
                    //dataGridView1.DataSource = dt;

                }
                else
                {
                    MessageBox.Show("Failed to update data. Try again");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        PhraseTable PT = new PhraseTable();
        public void AddDataToDropDownList()
        {
            PT.megaProjName = Sessions.SessionData.megaProjectName;
            MessageBox.Show(Sessions.SessionData.megaProjectName);
            DataSet DSPT = PT.selectData(PT);
            MessageBox.Show(DSPT.ToString());
            BuildPhrases.Items.Clear();
            foreach (DataRow DRPT in DSPT.Tables[0].Rows)
            {
                //MessageBox.Show(DRPT["phrasesName"].ToString());
                BuildPhrases.Items.Add(DRPT["phrasesName"]);

            }

            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void BrowsepercentageOfImplementationDetails_Click(object sender, EventArgs e)
        {

        }
        DataView dv = new DataView();
        private void BrowseFiles(object sender, EventArgs e)
        {
            if ((sender as Button).Name == browsemetroButton11.Name || (sender as Button).Name == browsemetroButton54.Name)
            {
                OpenFileDialog ofdMultiselect = new OpenFileDialog();
                ofdMultiselect.Multiselect = true;
                ofdMultiselect.Filter = "select needed Files |*.jpg; *.png; *.pdf";
                ofdMultiselect.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (ofdMultiselect.ShowDialog() == DialogResult.OK)
                {
                    string sqlInsertingQuery = "";

                    MultiSelect((sender as Button), (sender as Button).Text, ((sender as Button).Name == browsemetroButton11.Name ? "صور المشروع" : "لوحات المشروع + Asbuilt"), ofdMultiselect, ((sender as Button).Name == browsemetroButton11.Name ? "ProjectImages":"AsBuiltTable"), sqlInsertingQuery);

                }

            }
            else { 
            try
            {
                FileUpload((sender as Button), (sender as Button).Text, (sender as Button).Text, false);
            }
            catch (Exception ex) {
                    
                }
            }
        }
        public static readonly List<string> ImageExtensions = new List<string> { ".jpg", ".jpe",".jpeg", ".bmp", ".gif", ".png" };
        public static readonly List<string> ExcelExtensions = new List<string> { ".xls", ".xlsx", ".csv" };

        bool uploaddone;
        private string report3loc;

        //internal void FileUpload(Button metroButtons, string btnText, string FolderName, bool done)
        //{
        //    OpenFileDialog PDFUPLOADS = new OpenFileDialog()
        //    {
        //        Filter = "PDF|*.pdf|Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png|Excel Work Book 97-2003|*.xls; *.xlsx; *.csv",
        //        ValidateNames = true
        //    };

        //    DialogResult result = PDFUPLOADS.ShowDialog();

        //    if (result == DialogResult.OK)
        //    {
        //        string file = PDFUPLOADS.FileName;


        //        string[] f = file.Split('\\');
        //        string fn = f[(f.Length) - 1];
        //        string path = "";
        //        //@"C:\Users\dell\source\repos\Gardinia\Gardinia
        //        //string subPdfFolder = Directory.GetCurrentDirectory() + "\\pdfsFolder\\";
        //        //string subdirpdf = Directory.GetCurrentDirectory() + "\\pdfsFolder\\" + FolderName;
        //        //string imagesSubFol = Directory.GetCurrentDirectory() + "\\images\\";
        //        //string imagesSubDir = Directory.GetCurrentDirectory() + "\\images\\" + FolderName;
        //        string subPdfFolder = ".\\pdfsFolder\\";
        //        string subdirpdf = ".\\pdfsFolder\\" + FolderName;
        //        string imagesSubFol = ".\\images\\";
        //        string imagesSubDir = ".\\images\\" + FolderName;
        //        string ExcelParentFolder = ".\\Excel\\";
        //        string ExcelSubFolder = ".\\Excel\\" + FolderName;

        //        try
        //        {
        //            if (Path.GetExtension(fn).ToLower() == ".pdf")
        //            {

        //                if (!Directory.Exists(subPdfFolder))
        //                {
        //                    Directory.CreateDirectory(subPdfFolder);
        //                }

        //                if (!Directory.Exists(subdirpdf))
        //                {
        //                    Directory.CreateDirectory(subdirpdf);
        //                }

        //                if (Directory.GetFiles(subdirpdf, fn, SearchOption.AllDirectories).FirstOrDefault() != null)
        //                {
        //                    MessageBox.Show(file);
        //                    MessageBox.Show(fn);

        //                    path = String.Format(subPdfFolder + FolderName + "\\{0}", string.Format(Path.GetFileNameWithoutExtension(file) + DateTime.Now.ToString("MM_dd_yyyy HH_mm_ss") + Path.GetExtension(fn)));
        //                }
        //                else
        //                {
        //                    path = String.Format(subPdfFolder + FolderName + "\\{0}", fn);
        //                }
        //                MessageBox.Show(f + ",,,,," + fn);
        //                File.Copy(file, path, true);

        //                metroButtons.Text = path;
        //                done = true;
        //                metroButtons.BackgroundImage = Properties.Resources.like_symbol_for_interface_of_black_hand_shape_with_thumb_up;
        //                this.Refresh();
        //            }
        //            else if (ImageExtensions.Contains(Path.GetExtension(fn).ToLower()) || ImageExtensions.Contains(Path.GetExtension(fn).ToUpper()))
        //            {
        //                if (!Directory.Exists(imagesSubFol))
        //                {
        //                    Directory.CreateDirectory(imagesSubFol);
        //                }

        //                if (!Directory.Exists(imagesSubDir))
        //                {
        //                    Directory.CreateDirectory(imagesSubDir);
        //                }
        //                if (Directory.GetFiles(imagesSubDir, fn, SearchOption.AllDirectories).FirstOrDefault() != null)
        //                {
        //                    //MessageBox.Show(file);
        //                    path = String.Format(imagesSubFol + FolderName + "\\{0}", (string.Format(Path.GetFileNameWithoutExtension(file) + DateTime.Now.ToString("MM_dd_yyyy HH_mm_ss") + Path.GetExtension(fn))));
        //                }
        //                else
        //                {
        //                    path = String.Format(imagesSubFol + FolderName + "\\{0}", fn);
        //                }
        //                //MessageBox.Show(f + ",,,,," + fn);
        //                File.Copy(file, path, true);

        //                metroButtons.Text = path;
        //                done = true;
        //                metroButtons.BackgroundImage = Properties.Resources.like_symbol_for_interface_of_black_hand_shape_with_thumb_up;
        //                this.Refresh();

        //            }
        //            else if (ExcelExtensions.Contains(Path.GetExtension(fn).ToLower()))
        //            {
        //                if (!Directory.Exists(ExcelParentFolder))
        //                {
        //                    Directory.CreateDirectory(ExcelParentFolder);
        //                }

        //                if (!Directory.Exists(ExcelSubFolder))
        //                {
        //                    Directory.CreateDirectory(ExcelSubFolder);
        //                }
        //                if (Directory.GetFiles(ExcelSubFolder, fn, SearchOption.AllDirectories).FirstOrDefault() != null)
        //                {
        //                    //MessageBox.Show(file);
        //                    path = String.Format(imagesSubFol + FolderName + "\\{0}", (string.Format(Path.GetFileNameWithoutExtension(file) + DateTime.Now.ToString("dddd_MM_dd_yyyy HH_mm_ss") + Path.GetExtension(fn))));
        //                }
        //                else
        //                {
        //                    path = String.Format(imagesSubFol + FolderName + "\\{0}", fn);
        //                }
        //                //MessageBox.Show(f + ",,,,," + fn);
        //                File.Copy(file, path, true);

        //                metroButtons.Text = path;
        //                done = true;
        //                metroButtons.BackgroundImage = Properties.Resources.like_symbol_for_interface_of_black_hand_shape_with_thumb_up;
        //                this.Refresh();

        //            }
        //            else
        //            {
        //                MessageBox.Show("يجب رفع صورة او بي دي اف او اكسل");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            var st = new StackTrace(ex, true);
        //            // Get the top stack frame
        //            var frame = st.GetFrame(st.FrameCount - 1);
        //            // Get the line number from the stack frame
        //            var line = frame.GetFileLineNumber();
        //            MessageBox.Show(ex.Message);
        //        }
        //    }

        //}
        internal void FileUpload(Button metroButtons, string btnText, string FolderName,bool done)
        {
            OpenFileDialog PDFUPLOADS = new OpenFileDialog()
            {
                Filter = "PDF|*.pdf|Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png|Excel Work Book 97-2003|*.xls; *.xlsx; *.csv",
                ValidateNames = true
            };

            DialogResult result = PDFUPLOADS.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (!(String.IsNullOrEmpty(label2.Text) || String.IsNullOrWhiteSpace(label2.Text)))
                {
                    string file = PDFUPLOADS.FileName;


                    string[] f = file.Split('\\');
                    string fn = f[(f.Length) - 1];
                    string path = "";
                    //@"C:\Users\dell\source\repos\Gardinia\Gardinia
                    //string subPdfFolder = Directory.GetCurrentDirectory() + "\\pdfsFolder\\";
                    //string subdirpdf = Directory.GetCurrentDirectory() + "\\pdfsFolder\\" + FolderName;
                    //string imagesSubFol = Directory.GetCurrentDirectory() + "\\images\\";
                    //string imagesSubDir = Directory.GetCurrentDirectory() + "\\images\\" + FolderName;
                    string subPdfFolder = ".\\pdfsFolder\\";
                    string subdirpdf = ".\\pdfsFolder\\" + FolderName;
                    string PDFSContractFolder = ".\\pdfsFolder\\" + FolderName + "\\" + label2.Text;

                    string imagesSubFol = ".\\images\\";
                    string imagesSubDir = ".\\images\\" + FolderName;
                    string imagesContractFolder = ".\\images\\" + FolderName + "\\" + label2.Text;

                    string ExcelParentFolder = ".\\Excel\\";
                    string ExcelSubFolder = ".\\Excel\\" + FolderName;
                    string excelsContractFolder = ".\\Excel\\" + FolderName + "\\" + label2.Text;

                    try
                    {
                        if (Path.GetExtension(fn).ToLower() == ".pdf" || Path.GetExtension(fn).ToUpper() == ".pdf")
                        {

                            if (!Directory.Exists(subPdfFolder))
                            {
                                Directory.CreateDirectory(subPdfFolder);
                            }

                            if (!Directory.Exists(subdirpdf))
                            {
                                Directory.CreateDirectory(subdirpdf);
                            }
                            if (!Directory.Exists(PDFSContractFolder))
                            {
                                Directory.CreateDirectory(PDFSContractFolder);
                            }


                            if (Directory.GetFiles(PDFSContractFolder, fn, SearchOption.AllDirectories).FirstOrDefault() != null)
                            {
                                MessageBox.Show(file);
                                MessageBox.Show(fn);

                                path = String.Format(subPdfFolder + FolderName + "\\" + label2.Text + "\\{0}", string.Format(Path.GetFileNameWithoutExtension(file) + DateTime.Now.ToString("MM_dd_yyyy HH_mm_ss") + Path.GetExtension(fn)));
                            }
                            else
                            {
                                path = String.Format(subPdfFolder + FolderName + "\\" + label2.Text + "\\{0}", fn);
                            }
                            MessageBox.Show(f + "سيتم رفع الفايل" + fn);
                            File.Copy(file, path, true);
                            done = true;
                            report3loc = path;
                            metroButtons.Text = path;
                        }
                        else if (ImageExtensions.Contains(Path.GetExtension(fn).ToLower()) || ImageExtensions.Contains(Path.GetExtension(fn).ToUpper()))
                        {
                            if (!Directory.Exists(imagesSubFol))
                            {
                                Directory.CreateDirectory(imagesSubFol);
                            }

                            if (!Directory.Exists(imagesSubDir))
                            {
                                Directory.CreateDirectory(imagesSubDir);
                            }
                            if (!Directory.Exists(imagesContractFolder))
                            {
                                Directory.CreateDirectory(imagesContractFolder);
                            }
                            if (Directory.GetFiles(imagesContractFolder, fn, SearchOption.AllDirectories).FirstOrDefault() != null)
                            {
                                MessageBox.Show(file);
                                path = String.Format(imagesSubFol + FolderName + "\\" + label2.Text + "\\{0}", (string.Format(Path.GetFileNameWithoutExtension(file) + DateTime.Now.ToString("MM_dd_yyyy HH_mm_ss") + Path.GetExtension(fn))));
                            }
                            else
                            {
                                path = String.Format(imagesSubFol + FolderName + "\\" + label2.Text + "\\{0}", fn);
                            }
                            MessageBox.Show(f + "سيتم رفع الفايل" + fn);

                            File.Copy(file, path, true);
                            done = true;
                            report3loc = path;
                            metroButtons.Text = path;
                        }
                        else if (ExcelExtensions.Contains(Path.GetExtension(fn).ToLower()) || ExcelExtensions.Contains(Path.GetExtension(fn).ToUpper()))
                        {
                            if (!Directory.Exists(ExcelParentFolder))
                            {
                                Directory.CreateDirectory(ExcelParentFolder);
                            }

                            if (!Directory.Exists(ExcelSubFolder))
                            {
                                Directory.CreateDirectory(ExcelSubFolder);
                            }
                            if (!Directory.Exists(excelsContractFolder))
                            {
                                Directory.CreateDirectory(excelsContractFolder);
                            }
                            if (Directory.GetFiles(excelsContractFolder, fn, SearchOption.AllDirectories).FirstOrDefault() != null)
                            {
                                MessageBox.Show(file);
                                path = String.Format(ExcelParentFolder + FolderName + "\\" + label2.Text + "\\{0}", (string.Format(Path.GetFileNameWithoutExtension(file) + DateTime.Now.ToString("dddd_MM_dd_yyyy HH_mm_ss") + Path.GetExtension(fn))));
                            }
                            else
                            {
                                path = String.Format(ExcelParentFolder + FolderName + "\\" + label2.Text + "\\{0}", fn);
                            }
                            MessageBox.Show(f + "سيتم رفع الفايل" + fn);
                            File.Copy(file, path, true);
                            done = true;
                            report3loc = path;
                            metroButtons.Text = path;
                        }
                        else
                        {
                            MessageBox.Show("يجب رفع صورة او بي دي اف او اكسل");
                        }

                    }
                    catch (Exception ex)
                    {
                        var st = new StackTrace(ex, true);
                        // Get the top stack frame
                        var frame = st.GetFrame(st.FrameCount - 1);
                        // Get the line number from the stack frame
                        var line = frame.GetFileLineNumber();
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("ادخل رقم العقد");
                }
            }

        }
        public void MultiSelect(Button metroButtonsMulti, string buttonText, string FolderName, OpenFileDialog ofdMultiselect, string TblName, string sqlInsertingQuery)
        {
            int a = 0;

            //string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (!String.IsNullOrEmpty(label2.Text))
            {
                foreach (string file in ofdMultiselect.FileNames)
                {
                   if(metroButtonsMulti.Text != "صور المشروع" || metroButtonsMulti.Text != "لوحات المشروع + Asbuilt") {  
                    if (metroButtonsMulti.Name == browsemetroButton54.Name)
                    {
                        sqlInsertingQuery = "Insert Into " + "AsBuiltTable" + "(AsBuiltFiles,ContractCode)Values('" + browsemetroButton54.Text + "','" + label2.Text + "')";
                           
                        }
                    else
                    {
                        sqlInsertingQuery = "Insert Into " + "ProjectImages" + "([Image],[ContractCode])Values('" + browsemetroButton11.Text + "','" + label2.Text + "')";

                    }
                    
                    a += 1;
                    if (a >= ofdMultiselect.FileNames.Count())
                    {
                        MessageBox.Show(Convert.ToString(a+" File Uploaded"));
                    }
                    string[] f = file.Split('\\');
                    string fn = f[(f.Length) - 1];
                    string path = "";
                    //@"C:\Users\dell\source\repos\Gardinia\Gardinia
                    string subPdfFolder = Directory.GetCurrentDirectory() + "\\pdfsFolder\\";
                    string subdirpdf = Directory.GetCurrentDirectory() + "\\pdfsFolder\\" + FolderName;
                    string imagesSubFol = Directory.GetCurrentDirectory() + "\\images\\";
                    string imagesSubDir = Directory.GetCurrentDirectory() + "\\images\\" + FolderName;

                    if (Path.GetExtension(fn).ToLower() == ".pdf")
                    {

                        if (!Directory.Exists(subPdfFolder))
                        {
                            Directory.CreateDirectory(subPdfFolder);
                        }

                        if (!Directory.Exists(subdirpdf))
                        {
                            Directory.CreateDirectory(subdirpdf);
                        }
                        if (Directory.GetFiles(subdirpdf, fn, SearchOption.AllDirectories).FirstOrDefault() != null)
                        {
                            path = String.Format(subPdfFolder + FolderName + "\\{0}", string.Format(Path.GetFileNameWithoutExtension(file) + DateTime.Now.ToString("MM_dd_yyyy HH_mm_ss") + Path.GetExtension(fn)));
                        }
                        else
                        {
                            path = String.Format(subPdfFolder + FolderName + "\\{0}", fn);
                        }

                        //MessageBox.Show(f + ",,,,," + fn);
                        File.Copy(file, path, true);
                        metroButtonsMulti.Text = path;
                        insertMultiData(TblName, metroButtonsMulti.Text, sqlInsertingQuery);
                        report3loc = path;
                    }
                    else if (ImageExtensions.Contains(Path.GetExtension(fn).ToLower()) || ImageExtensions.Contains(Path.GetExtension(fn).ToUpper()))
                    {
                        if (!Directory.Exists(imagesSubFol))
                        {
                            Directory.CreateDirectory(imagesSubFol);
                        }

                        if (!Directory.Exists(imagesSubDir))
                        {
                            Directory.CreateDirectory(imagesSubDir);
                        }
                        if (Directory.GetFiles(imagesSubDir, fn, SearchOption.AllDirectories).FirstOrDefault() != null)
                        {
                            path = String.Format(imagesSubFol + FolderName + "\\{0}", string.Format(Path.GetFileNameWithoutExtension(file) + DateTime.Now.ToString("MM_dd_yyyy HH_mm_ss") + Path.GetExtension(fn)));
                        }
                        else
                        {
                            path = String.Format(imagesSubFol + FolderName + "\\{0}", fn);
                        }

                        path = String.Format(imagesSubFol + FolderName + "\\{0}", fn);
                        //MessageBox.Show(f + ",,,,," + fn);
                        File.Copy(file, path, true);
                        metroButtonsMulti.Text = path;
                        insertMultiData(TblName, metroButtonsMulti.Text, sqlInsertingQuery);
                        report3loc = path;
                    }
                    else
                    {
                        MessageBox.Show("يجب رفع صورة او بي دي اف");
                    }
                }
                }
            }
            else
            {
                MessageBox.Show("ادخل رقم العقد");

            }
        }
        public void insertMultiData(string tblName, string text, string sqlInsertingQuery)
        {
            string inserting = sqlInsertingQuery;
            /*"Insert Into "+ tblName+ "(AsbuiltFiles,ContractCode)Values('" + text + "','" + label2.Text + "')"*/
            try
            {
                string selectInBT = "Select COUNT(*) from BuildsMainTable where ContractCode Like'" + label2.Text + "'";
                OleDbConnection conn = new OleDbConnection(myconnecting);

                DataTable dt32 = new DataTable();
                OleDbCommand OleDbCommandBT = new OleDbCommand(selectInBT, conn);

                OleDbDataAdapter OleDbDataAdapterBT = new OleDbDataAdapter(OleDbCommandBT);

                conn.Open();
                int rowsBT = (int)OleDbCommandBT.ExecuteScalar();

                if (rowsBT > 0)
                {

                    //bd.implementerCompany = "8";

                    //bd.Sandreport = textBox5.Text;

                    //bool successPR = PR.Insert(PR);
                    OleDbCommand OleDbCommandInsertProjectImages = new OleDbCommand(inserting, conn);
                    OleDbDataAdapter OleDbDataAdapterBTPI = new OleDbDataAdapter(OleDbCommandInsertProjectImages);
                    //MessageBox.Show(OleDbCommandInsertProjectImages.CommandText.ToString());
                    int SCIPI = OleDbCommandInsertProjectImages.ExecuteNonQuery();

                    if (SCIPI > 0)
                    {
                        MessageBox.Show("New File Added");

                    }
                    else
                    {
                        MessageBox.Show("Failed to add this File. Try again");
                    }
                    //DataTable dt = bd.Select();
                    //dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("العقد غير صحيح او غير مسجل");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                ////MessageBoxIcon.Error();
                //var st = new StackTrace(ex, true);
                //// Get the top stack frame
                //var frame = st.GetFrame(st.FrameCount - 1);
                //// Get the line number from the stack frame
                //var line = frame.GetFileLineNumber();
                //MessageBox.Show(ex.Message, line.ToString());
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
