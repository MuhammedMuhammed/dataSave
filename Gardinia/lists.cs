using Gardinia.GardModels;
using System;
using System.Collections.Generic; 
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gardinia
{
    public partial class lists : Form
    {
        public lists(DataTable dt)
        {
            InitializeComponent();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Frozen = true;
            dataGridView1.Columns[1].Frozen = true;
            //dataGridView1.Columns[2].Frozen = true;
            if (Sessions.SessionData.isAdmin != "True") { 
            Update.Enabled = false;
            Delete.Enabled = false;
            }
        }
        bool datechanged = false;
        //int a[];
        bool dataChanged = false;
        //int[] DGVRCHANGED= { };
        List<int> DGVRCHANGED=new List<int>();
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        BuildData bd = new BuildData();

        private void Update_Click(object sender, EventArgs e)
        {

            try
            {
                for(int i= 0;i< DGVRCHANGED.Count;i++) {
                    MessageBox.Show("any");

                    //foreach (DataGridViewRow DGVR in dataGridView1.Rows) {
                    DataGridViewRowCollection DGVR = dataGridView1.Rows;
                    //if()
                    bd.ContractCode = String.IsNullOrEmpty(DGVR[i].Cells["ContractCode"].Value.ToString()) ? null : DGVR[i].Cells["ContractCode"].Value.ToString();
                bd.projectName = String.IsNullOrEmpty(DGVR[i].Cells["projectName"].Value.ToString()) ? null : DGVR[i].Cells["projectName"].Value.ToString();
                bd.projectOwner = String.IsNullOrEmpty(DGVR[i].Cells["projectOwner"].Value.ToString()) ? null : DGVR[i].Cells["projectOwner"].Value.ToString();
                bd.projectrecordingDate = null;
                bd.implementerCompany = String.IsNullOrEmpty(DGVR[i].Cells["implementerCompany"].Value.ToString()) ? null : DGVR[i].Cells["implementerCompany"].Value.ToString(); /*textBox4.Text*/;
                bd.projectConsultative = String.IsNullOrEmpty(DGVR[i].Cells["projectConsultative"].Value.ToString()) ? null : DGVR[i].Cells["projectConsultative"].Value.ToString();
                bd.startingProjectDate = datechanged ? (DateTime?) DGVR[i].Cells["startingProjectDate"].Value : null;
                bd.EndingOfContractorDate = datechanged ? (DateTime?)DGVR[i].Cells["EndingOfContractorDate"].Value : null;
                bd.LastTimeForEndingProject = datechanged ? (DateTime?)DGVR[i].Cells["LastTimeForEndingProject"].Value : null;

                //bd.Sandreport = textBox5.Text;
                bd.periodToImplementProject = String.IsNullOrEmpty(DGVR[i].Cells["periodToImplementProject"].Value.ToString()) ? null : DGVR[i].Cells["periodToImplementProject"].Value.ToString();
                bd.projectPhrase = String.IsNullOrEmpty(DGVR[i].Cells["projectPhrase"].Value.ToString()) ? null : DGVR[i].Cells["projectPhrase"].Value.ToString();
                bd.BuildUnitsFrom = String.IsNullOrEmpty(DGVR[i].Cells["BuildUnitsFrom"].Value.ToString()) || DGVR[i].Cells["BuildUnitsFrom"].Value.ToString() == "0" ? null : (int?)int.Parse(DGVR[i].Cells["BuildUnitsFrom"].Value.ToString());
                bd.BuildUnitsTo = String.IsNullOrEmpty(DGVR[i].Cells["BuildUnitsTo"].Value.ToString()) || DGVR[i].Cells["BuildUnitsTo"].Value.ToString() == "0" ? null : (int?)int.Parse(DGVR[i].Cells["BuildUnitsTo"].Value.ToString());
                //bd.BUildedDateAndTime = DateTime.Now;
                bd.Image = DGVR[i].Cells["Image"].Value.ToString() == "صورة المشروع" || DGVR[i].Cells["Image"].Value.ToString() == "" ? null : DGVR[i].Cells["Image"].Value.ToString();
                bd.DurationProgram = DGVR[i].Cells["DurationProgram"].Value.ToString() == "البرنامج الزمني" || DGVR[i].Cells["DurationProgram"].Value.ToString() == "" ? null : DGVR[i].Cells["DurationProgram"].Value.ToString();
                bd.projectIndexation = DGVR[i].Cells["projectIndexation"].Value.ToString() == "مقايسة المشروع" || DGVR[i].Cells["projectIndexation"].Value.ToString() == "" ? null : DGVR[i].Cells["projectIndexation"].Value.ToString() /*textBox4.Text*/;
                bd.locationOfCheckingDrillingBottom = DGVR[i].Cells["locationOfCheckingDrillingBottom"].Value.ToString() == "مجضر معاينة قاع الحفر " || DGVR[i].Cells["locationOfCheckingDrillingBottom"].Value.ToString() == "" ? null : DGVR[i].Cells["locationOfCheckingDrillingBottom"].Value.ToString();
                bd.receiptOfTheSite = DGVR[i].Cells["receiptOfTheSite"].Value.ToString() == "محضر استلام الموقع" || DGVR[i].Cells["receiptOfTheSite"].Value.ToString() == "" ? null : DGVR[i].Cells["receiptOfTheSite"].Value.ToString();
                bd.projectNotes = DGVR[i].Cells["projectNotes"].Value.ToString() == "ملاحظات المشروع" || DGVR[i].Cells["projectNotes"].Value.ToString() == "" ? null : DGVR[i].Cells["projectNotes"].Value.ToString();
                bd.BuildReport = DGVR[i].Cells["BuildReport"].Value.ToString() == "حصر المشروع" || DGVR[i].Cells["BuildReport"].Value.ToString() == "" ? null : DGVR[i].Cells["BuildReport"].Value.ToString();
                bd.notices = DGVR[i].Cells["notices"].Value.ToString() == "الاخطار" || DGVR[i].Cells["notices"].Value.ToString() == "" ? null : DGVR[i].Cells["notices"].Value.ToString();
                bd.contractValue = DGVR[i].Cells["contractValue"].Value.ToString() == "" ? null : (double?)double.Parse(DGVR[i].Cells["contractValue"].Value.ToString());
                bd.FinalClosing = DGVR[i].Cells["FinalClosing"].Value.ToString() == "" ? null : (double?)double.Parse(DGVR[i].Cells["FinalClosing"].Value.ToString());
                bd.lastExactract = DGVR[i].Cells["lastExactract"].Value.ToString() == "" ? null : (double?)double.Parse(DGVR[i].Cells["lastExactract"].Value.ToString());
                bd.Division = DGVR[i].Cells["Division"].Value.ToString() == "" ? null : (double?)double.Parse(DGVR[i].Cells["Division"].Value.ToString());
                bd.savingsValue = DGVR[i].Cells["savingsValue"].Value.ToString() == "" ? null : (double?)double.Parse(DGVR[i].Cells["savingsValue"].Value.ToString());

                bd.contractValueFile = DGVR[i].Cells["contractValueFile"].Value.ToString() == "القيمة التعاقدية" || DGVR[i].Cells["contractValueFile"].Value.ToString() == "" ? null : DGVR[i].Cells["contractValueFile"].Value.ToString();
                bd.FinalClosingFile = DGVR[i].Cells["FinalClosingFile"].Value.ToString() == "الختامي المنتظر" || DGVR[i].Cells["FinalClosingFile"].Value.ToString() == "" ? null : DGVR[i].Cells["FinalClosingFile"].Value.ToString();
                bd.lastExactractFile = DGVR[i].Cells["lastExactractFile"].Value.ToString() == "اخر مستخلص" || DGVR[i].Cells["lastExactractFile"].Value.ToString() == "" ? null : DGVR[i].Cells["lastExactractFile"].Value.ToString();
                bd.Savings = DGVR[i].Cells["Savings"].Value.ToString() == "الوفر" || DGVR[i].Cells["Savings"].Value.ToString() == "" ? null : DGVR[i].Cells["Savings"].Value.ToString();
                bd.Receipts = DGVR[i].Cells["Receipts"].Value.ToString() == "طلبات الاستلام" || DGVR[i].Cells["Receipts"].Value.ToString() == "" ? null : DGVR[i].Cells["Receipts"].Value.ToString();
                bd.Appropriations = DGVR[i].Cells["Appropriations"].Value.ToString() == "الاعتمادات المخصصة" || DGVR[i].Cells["Appropriations"].Value.ToString() == "" ? null : DGVR[i].Cells["Appropriations"].Value.ToString();
                bd.SiteOrders = DGVR[i].Cells["SiteOrders"].Value.ToString() == "اوامر الموقع" || DGVR[i].Cells["SiteOrders"].Value.ToString() == "" ? null : DGVR[i].Cells["SiteOrders"].Value.ToString();
                bd.ManagementMails = DGVR[i].Cells["ManagementMails"].Value.ToString() == "جوابات الادارة" || DGVR[i].Cells["ManagementMails"].Value.ToString() == "" ? null : DGVR[i].Cells["ManagementMails"].Value.ToString();
                bd.Netbudget = DGVR[i].Cells["Netbudget"].Value.ToString() == "الميزانية الشبكية" || DGVR[i].Cells["Netbudget"].Value.ToString() == "" ? null : DGVR[i].Cells["Netbudget"].Value.ToString();
                bd.ConstructionSafetyReport = DGVR[i].Cells["ConstructionSafetyReport"].Value.ToString() == "تقرير السلامة الانشائية" || DGVR[i].Cells["ConstructionSafetyReport"].Value.ToString() == "" ? null : DGVR[i].Cells["ConstructionSafetyReport"].Value.ToString();
                bd.ExploitationReductionandCancellationNotes = DGVR[i].Cells["ExploitationReductionandCancellationNotes"].Value.ToString() == "مذكرات التجاوز و المخفض و الملغى" || DGVR[i].Cells["ExploitationReductionandCancellationNotes"].Value.ToString() == "" ? null : DGVR[i].Cells["ExploitationReductionandCancellationNotes"].Value.ToString();
                bd.ProjectDataTypes = DGVR[i].Cells["ProjectDataTypes"].Value.ToString() == "" ? null : DGVR[i].Cells["ProjectDataTypes"].Value.ToString();
                bd.projectImages = DGVR[i].Cells["projectImages"].Value.ToString() == "صور المشروع" || DGVR[i].Cells["projectImages"].Value.ToString() == "" ? null : DGVR[i].Cells["projectImages"].Value.ToString();
                bd.TotalDeductionsValues = DGVR[i].Cells["TotalDeductionsValues"].Value.ToString() == "" || DGVR[i].Cells["TotalDeductionsValues"].Value.ToString() == null ? 0.0 : (double?)double.Parse(DGVR[i].Cells["TotalDeductionsValues"].Value.ToString());

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
                DGVRCHANGED.Clear();

            }
            catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            bd.ContractCode = dataGridView1.SelectedRows[0].Cells["ContractCode"].Value.ToString();
            bool success = bd.Delete(bd);
            if (success == true)
            {
                MessageBox.Show("Build data Deleted");
                DataTable dt = bd.Select();
                //dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to add new Build. Try again");
            }


        }

        private void lists_Load(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                
                //a += e.RowIndex;
                dataChanged = true;
                //datechanged = true;
                DGVRCHANGED.Add(e.RowIndex);
                for (int i = 0; i < DGVRCHANGED.Count; i++)
                {
                    MessageBox.Show(DGVRCHANGED[i].ToString());

                }
            }

        }
    }
}
