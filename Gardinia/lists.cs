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
            Update.Enabled = false;
            Delete.Enabled = false;
        }
        bool datechanged = false;

        bool dataChanged = false;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) { 
                dataChanged = true;
                //datechanged = true;
            }
        }
        BuildData bd = new BuildData();

        private void Update_Click(object sender, EventArgs e)
        {
                try { 
                foreach (DataGridViewRow DGVR in dataGridView1.Rows) {
            bd.ContractCode = String.IsNullOrEmpty(DGVR.Cells["ContractCode"].Value.ToString()) ? null : DGVR.Cells["ContractCode"].Value.ToString();
            bd.projectName = String.IsNullOrEmpty(DGVR.Cells["projectName"].Value.ToString()) ? null : DGVR.Cells["projectName"].Value.ToString();
            bd.projectOwner = String.IsNullOrEmpty(DGVR.Cells["projectOwner"].Value.ToString()) ? null : DGVR.Cells["projectOwner"].Value.ToString();
            bd.projectrecordingDate = null;
            bd.implementerCompany = String.IsNullOrEmpty(DGVR.Cells["implementerCompany"].Value.ToString()) ? null : DGVR.Cells["implementerCompany"].Value.ToString(); /*textBox4.Text*/;
            bd.projectConsultative = String.IsNullOrEmpty(DGVR.Cells["projectConsultative"].Value.ToString()) ? null : DGVR.Cells["projectConsultative"].Value.ToString();
            bd.startingProjectDate = datechanged ? (DateTime?) DGVR.Cells["startingProjectDate"].Value : null;
            bd.EndingOfContractorDate = datechanged ? (DateTime?)DGVR.Cells["EndingOfContractorDate"].Value : null;
            bd.LastTimeForEndingProject = datechanged ? (DateTime?)DGVR.Cells["LastTimeForEndingProject"].Value : null;

            //bd.Sandreport = textBox5.Text;
            bd.periodToImplementProject = String.IsNullOrEmpty(DGVR.Cells["periodToImplementProject"].Value.ToString()) ? null : DGVR.Cells["periodToImplementProject"].Value.ToString();
            bd.projectPhrase = String.IsNullOrEmpty(DGVR.Cells["projectPhrase"].Value.ToString()) ? null : DGVR.Cells["projectPhrase"].Value.ToString();
            bd.BuildUnitsFrom = String.IsNullOrEmpty(DGVR.Cells["BuildUnitsFrom"].Value.ToString()) || DGVR.Cells["BuildUnitsFrom"].Value.ToString() == "0" ? null : (int?)int.Parse(DGVR.Cells["BuildUnitsFrom"].Value.ToString());
            bd.BuildUnitsTo = String.IsNullOrEmpty(DGVR.Cells["BuildUnitsTo"].Value.ToString()) || DGVR.Cells["BuildUnitsTo"].Value.ToString() == "0" ? null : (int?)int.Parse(DGVR.Cells["BuildUnitsTo"].Value.ToString());
            //bd.BUildedDateAndTime = DateTime.Now;
            bd.Image = DGVR.Cells["Image"].Value.ToString() == "صورة المشروع" || DGVR.Cells["Image"].Value.ToString() == "" ? null : DGVR.Cells["Image"].Value.ToString();
            bd.DurationProgram = DGVR.Cells["DurationProgram"].Value.ToString() == "البرنامج الزمني" || DGVR.Cells["DurationProgram"].Value.ToString() == "" ? null : DGVR.Cells["DurationProgram"].Value.ToString();
            bd.projectIndexation = DGVR.Cells["projectIndexation"].Value.ToString() == "مقايسة المشروع" || DGVR.Cells["projectIndexation"].Value.ToString() == "" ? null : DGVR.Cells["projectIndexation"].Value.ToString() /*textBox4.Text*/;
            bd.locationOfCheckingDrillingBottom = DGVR.Cells["locationOfCheckingDrillingBottom"].Value.ToString() == "مجضر معاينة قاع الحفر " || DGVR.Cells["locationOfCheckingDrillingBottom"].Value.ToString() == "" ? null : DGVR.Cells["locationOfCheckingDrillingBottom"].Value.ToString();
            bd.receiptOfTheSite = DGVR.Cells["receiptOfTheSite"].Value.ToString() == "محضر استلام الموقع" || DGVR.Cells["receiptOfTheSite"].Value.ToString() == "" ? null : DGVR.Cells["receiptOfTheSite"].Value.ToString();
            bd.projectNotes = DGVR.Cells["projectNotes"].Value.ToString() == "ملاحظات المشروع" || DGVR.Cells["projectNotes"].Value.ToString() == "" ? null : DGVR.Cells["projectNotes"].Value.ToString();
            bd.BuildReport = DGVR.Cells["BuildReport"].Value.ToString() == "حصر المشروع" || DGVR.Cells["BuildReport"].Value.ToString() == "" ? null : DGVR.Cells["BuildReport"].Value.ToString();
            bd.notices = DGVR.Cells["notices"].Value.ToString() == "الاخطار" || DGVR.Cells["notices"].Value.ToString() == "" ? null : DGVR.Cells["notices"].Value.ToString();
            bd.contractValue = DGVR.Cells["contractValue"].Value.ToString() == "" ? null : (double?)double.Parse(DGVR.Cells["contractValue"].Value.ToString());
            bd.FinalClosing = DGVR.Cells["FinalClosing"].Value.ToString() == "" ? null : (double?)double.Parse(DGVR.Cells["FinalClosing"].Value.ToString());
            bd.lastExactract = DGVR.Cells["lastExactract"].Value.ToString() == "" ? null : (double?)double.Parse(DGVR.Cells["lastExactract"].Value.ToString());
            bd.Division = DGVR.Cells["Division"].Value.ToString() == "" ? null : (double?)double.Parse(DGVR.Cells["Division"].Value.ToString());
            bd.savingsValue = DGVR.Cells["savingsValue"].Value.ToString() == "" ? null : (double?)double.Parse(DGVR.Cells["savingsValue"].Value.ToString());

            bd.contractValueFile = DGVR.Cells["contractValueFile"].Value.ToString() == "القيمة التعاقدية" || DGVR.Cells["contractValueFile"].Value.ToString() == "" ? null : DGVR.Cells["contractValueFile"].Value.ToString();
            bd.FinalClosingFile = DGVR.Cells["FinalClosingFile"].Value.ToString() == "الختامي المنتظر" || DGVR.Cells["FinalClosingFile"].Value.ToString() == "" ? null : DGVR.Cells["FinalClosingFile"].Value.ToString();
            bd.lastExactractFile = DGVR.Cells["lastExactractFile"].Value.ToString() == "اخر مستخلص" || DGVR.Cells["lastExactractFile"].Value.ToString() == "" ? null : DGVR.Cells["lastExactractFile"].Value.ToString();
            bd.Savings = DGVR.Cells["Savings"].Value.ToString() == "الوفر" || DGVR.Cells["Savings"].Value.ToString() == "" ? null : DGVR.Cells["Savings"].Value.ToString();
            bd.Receipts = DGVR.Cells["Receipts"].Value.ToString() == "طلبات الاستلام" || DGVR.Cells["Receipts"].Value.ToString() == "" ? null : DGVR.Cells["Receipts"].Value.ToString();
            bd.Appropriations = DGVR.Cells["Appropriations"].Value.ToString() == "الاعتمادات المخصصة" || DGVR.Cells["Appropriations"].Value.ToString() == "" ? null : DGVR.Cells["Appropriations"].Value.ToString();
            bd.SiteOrders = DGVR.Cells["SiteOrders"].Value.ToString() == "اوامر الموقع" || DGVR.Cells["SiteOrders"].Value.ToString() == "" ? null : DGVR.Cells["SiteOrders"].Value.ToString();
            bd.ManagementMails = DGVR.Cells["ManagementMails"].Value.ToString() == "جوابات الادارة" || DGVR.Cells["ManagementMails"].Value.ToString() == "" ? null : DGVR.Cells["ManagementMails"].Value.ToString();
            bd.Netbudget = DGVR.Cells["Netbudget"].Value.ToString() == "الميزانية الشبكية" || DGVR.Cells["Netbudget"].Value.ToString() == "" ? null : DGVR.Cells["Netbudget"].Value.ToString();
            bd.ConstructionSafetyReport = DGVR.Cells["ConstructionSafetyReport"].Value.ToString() == "تقرير السلامة الانشائية" || DGVR.Cells["ConstructionSafetyReport"].Value.ToString() == "" ? null : DGVR.Cells["ConstructionSafetyReport"].Value.ToString();
            bd.ExploitationReductionandCancellationNotes = DGVR.Cells["ExploitationReductionandCancellationNotes"].Value.ToString() == "مذكرات التجاوز و المخفض و الملغى" || DGVR.Cells["ExploitationReductionandCancellationNotes"].Value.ToString() == "" ? null : DGVR.Cells["ExploitationReductionandCancellationNotes"].Value.ToString();
            bd.ProjectDataTypes = DGVR.Cells["ProjectDataTypes"].Value.ToString() == "" ? null : DGVR.Cells["ProjectDataTypes"].Value.ToString();
            bd.projectImages = DGVR.Cells["projectImages"].Value.ToString() == "صور المشروع" || DGVR.Cells["projectImages"].Value.ToString() == "" ? null : DGVR.Cells["projectImages"].Value.ToString();
            bd.TotalDeductionsValues = DGVR.Cells["TotalDeductionsValues"].Value.ToString() == "" || DGVR.Cells["TotalDeductionsValues"].Value.ToString() == null ? 0.0 : (double?)double.Parse(DGVR.Cells["TotalDeductionsValues"].Value.ToString());

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
                }catch(Exception ex)
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
    }
}
