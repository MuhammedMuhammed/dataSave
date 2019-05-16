using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gardinia.GardModels
{
    class megaProj
    {
        public string megaProjectName { get; set;}
        public double? megaProjectFundemental { get; set; }
        public int? noOfPhrases { get; set; }
        public string MegaProjTimeStrategy { get; set; }
        public string MegaProjComponents { get; set; }
        public double? MegaProjFinancialStatement { get; set; }
        public double? MegaProjRequiredDependency { get; set; }
        public double? MegaProjPaid { get; set; }
        public double? MegaProjrestOfMoneySpecified { get; set; }
        public double? MegaProjshortage { get; set; }
        public double? MegaProjSavings { get; set; }
        public float? MegaProjExchangeRate { get; set; }
        public double? MegaProjAllContractedValue { get; set; }
        public float? MegaProjImplementedRate { get; set; }
        public float? MegaProjImplementedRateAccordingToFinancialStat { get; set; }


        static string connector = "Provider=Microsoft.ACE.OleDb.12.0;Data Source="+Directory.GetCurrentDirectory()+"\\ArchDB.accdb;Persist Security Info=false";

        public bool selectDataCount(string megaProjectName)
        {
            bool isSuccess = false;
            string PhraseName = "''";
            DataSet DS = new DataSet();

            
                string querySelectSums = "Select count(*) from megaProject where megaProjectName='" + megaProjectName + "'";
                OleDbConnection OleDbConnection = new OleDbConnection(connector);
                OleDbCommand OleDbCommand = new OleDbCommand (querySelectSums, OleDbConnection);
                OleDbConnection.Open();
                int scalar = (int)OleDbCommand .ExecuteScalar();
                if (scalar > 0)
                {
                    isSuccess = true;
                OleDbConnection.Close();

            }
            else { isSuccess = false;
                OleDbConnection.Close();
            }

            return isSuccess;
        }
        public DataSet selectOneMegaProjData(megaProj mPS)
        {
            DataSet DS = new DataSet();

            try
            {

                string querySelector = "Select * from megaProject where megaProjectName Like'%" + mPS.megaProjectName+ "%'";
                OleDbConnection OleDbConnection = new OleDbConnection(connector);
                OleDbCommand OleDbCommand = new OleDbCommand (querySelector, OleDbConnection);
                OleDbDataAdapter OleDbDataAdapter = new OleDbDataAdapter(OleDbCommand );
                OleDbConnection.Open();

                OleDbDataAdapter.Fill(DS);

                OleDbConnection.Close();


            }
            catch (Exception ex)
            {
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(st.FrameCount - 1);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                MessageBox.Show(ex.Message, line.ToString());

                MessageBox.Show(ex.Message);
            }
            return DS;
        }

        public DataSet GetAllmegaProjData()
        {
            string PhraseName = "''";
            DataSet DS = new DataSet();

            try
            {
                string querySelectSums = "Select * from megaProject";
                OleDbConnection OleDbConnection = new OleDbConnection(connector);
                OleDbCommand OleDbCommand = new OleDbCommand (querySelectSums, OleDbConnection);
                OleDbDataAdapter OleDbDataAdapter = new OleDbDataAdapter(OleDbCommand );
                OleDbConnection.Open();
                OleDbDataAdapter.Fill(DS);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return DS;
        }

        public DataSet selectData(megaProj PD)
        {
            string PhraseName="''";
            DataSet DS = new DataSet();

            try
            {
                string querySelectSums = "Select sum(lastExactract) from BuildsMainTable where PhraseName='" + PhraseName + "'";
                OleDbConnection OleDbConnection = new OleDbConnection(connector);
                OleDbCommand OleDbCommand = new OleDbCommand (querySelectSums, OleDbConnection);
                OleDbDataAdapter OleDbDataAdapter = new OleDbDataAdapter(OleDbCommand );
                OleDbConnection.Open();
                OleDbDataAdapter.Fill(DS);

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
                    return DS;
        }
        public bool insertData(megaProj PDS)
        {
            bool isSuccess = false;
            try
            {
                string queryInsert = "Insert Into [megaProject] ([megaProjectName],[megaProjectFundemental],[noOfPhrases])Values('" + PDS.megaProjectName + "','" + PDS.megaProjectFundemental + "','" + PDS.noOfPhrases + "')";
                OleDbConnection OleDbConnection = new OleDbConnection(connector);
                OleDbCommand OleDbCommand = new OleDbCommand (queryInsert, OleDbConnection);
                OleDbDataAdapter OleDbDataAdapter = new OleDbDataAdapter(OleDbCommand );
                OleDbConnection.Open();
                int exec = OleDbCommand .ExecuteNonQuery();
                if (exec > 0)
                {
                    isSuccess = true;
                    MessageBox.Show("Data Added");

                }
                else
                {
                    isSuccess = false;
                    MessageBox.Show("there are missed data");

                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return isSuccess;
        }
        public bool updateData(megaProj PD)
        {
            bool isSuccess = false;
            OleDbConnection OleDbConnection = new OleDbConnection(connector);

            try
            { 
            string queryUpdating = "Update megaProject set megaProjectName= IIF(IsNull(@megaProjectName),megaProjectName,@megaProjectName), megaProjectFundemental=" +
                "IIF(IsNull(@megaProjectFundemental),megaProjectFundemental,@megaProjectFundemental), noOfPhrases= IIF(IsNull(@noOfPhrases),noOfPhrases,@noOfPhrases) where megaProjectName='" + PD.megaProjectName+ "'";

              OleDbCommand oleDbCommand = new OleDbCommand (queryUpdating, OleDbConnection);
                oleDbCommand.Parameters.Add("@megaProjectName", OleDbType.VarWChar).Value = (object)PD.megaProjectName?? DBNull.Value;
                oleDbCommand.Parameters.Add("@megaProjectFundemental", OleDbType.Double).Value = ((object)PD.megaProjectFundemental) ?? DBNull.Value;
                oleDbCommand.Parameters.Add("@noOfPhrases", OleDbType.Integer).Value = ((object)PD.noOfPhrases) ?? DBNull.Value;

                OleDbDataAdapter OleDbDataAdapter = new OleDbDataAdapter(oleDbCommand);
            OleDbConnection.Open();
            int exec = oleDbCommand .ExecuteNonQuery();
            if (exec > 0)
            {
                isSuccess = true;
                    MessageBox.Show("تم زيادة عدد المراحل");

                }
                else
            {
                isSuccess = false;
                MessageBox.Show("لم يتم زيادة عدد المراحل");


            }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                OleDbConnection.Close();                
            }
            return isSuccess;
        }
        //public bool DeleteData(megaProj PD)
        //{
        //    bool isSuccess = false;
        //    string querySelectSums = "Select sum(lastExactract) from BuildsMainTable where PhraseName='" + "'";

        //    return isSuccess;
        //}
        public bool DeleteData(megaProj PD)
        {
            bool isSuccess = false;
            try { 
            string queryDeleteSums = "Delete from BuildsMainTable where megaProjectName='" + PD.megaProjectName + "'";
            OleDbConnection DOC = new OleDbConnection(connector);
            OleDbCommand DEOC = new OleDbCommand(queryDeleteSums, DOC);
                DOC.Open();
                int i = DEOC.ExecuteNonQuery();
            if (i > 0)
            {
                
                Bitmap myicon = Properties.Resources.like_symbol_for_interface_of_black_hand_shape_with_thumb_up;
                MessageBox.Show("ProjectDeleted","", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    home h = new home();
                    
                }
            else {
                MessageBox.Show("Project NOT Deleted");
            }
                DOC.Close();
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return isSuccess;
        }
    }
    
}
