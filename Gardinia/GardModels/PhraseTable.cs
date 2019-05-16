using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gardinia.GardModels
{
    class PhraseTable
    {
        public string megaProjName { get; set; }
        public string phrasesName { get; set; }
        public int? phrasesNum { get; set; }
        public string TimeStrategy { get; set; }
        public string phraseComponents { get; set; }
        public double? PhraseFinancialStatement { get; set; }
        public double? PhraseRequiredDependency { get; set; }
        public double? PhrasePaid { get; set; }
        public double? PhraserestOfMoneySpecified { get; set; }
        public double? Phraseshortage { get; set; }
        public double? PhraseSavings { get; set; }
        public float? PhraseExchangeRate { get; set; }
        public double? PhrasesAllContractedValue { get; set; }
        public float? PhraseImplementedRate { get; set; }
        public float? PhraseImplementedRateAccordingToFinancialStat { get; set; }


        static string connector = "Provider=Microsoft.ACE.OleDb.12.0;Data Source="+Directory.GetCurrentDirectory()+"\\ArchDB.accdb;Persist Security Info=false";
        public DataTable SelectSums(TextBox Paid, TextBox restOfMoneySpecified, TextBox savings, TextBox shortage, TextBox financialStatement, TextBox exchangeRate, TextBox rateOfImplementation, TextBox megaProjAllContractedValue, string MeGaPrOjEcTName)
        {
            OleDbConnection conn = new OleDbConnection(connector);
            DataTable dt = new DataTable();
            try
            {
                string sql = "select Sum(PhraseFinancialStatement), Sum(PhraseRequiredDependency),  Sum(PhrasePaid),Sum(PhraserestOfMoneySpecified),Sum(PhraseSavings),Sum(PhraseImplementedRate),count(PhraseImplementedRate),Sum(PhrasesAllContractedValue) From PhrasesTablle where megaProjName='" + MeGaPrOjEcTName + "'";
                OleDbCommand sqlcmd = new OleDbCommand (sql, conn);
                OleDbDataAdapter OleDbDataAdapter = new OleDbDataAdapter(sqlcmd);
                conn.Open();
                OleDbDataAdapter.Fill(dt);
                DataRow dr = dt.Rows[0];
                string contractValue = dr[0].ToString();
                string FinalClosing = dr[1].ToString();
                string lastExactract = dr[2].ToString();
                string Divisionv = dr[3].ToString();
                string Savingvnv = dr[4].ToString();
                string percentOfImplement = dr[5].ToString();
                string percentOfImplementcount = dr[6].ToString();
                string AllContractVals = dr[7].ToString();

                int percentOfImplementcountv = int.Parse(percentOfImplementcount);

                double percentOfImplementv = String.IsNullOrEmpty(percentOfImplement) ? 0.0 : Convert.ToDouble(percentOfImplement);
                double Savingvnvv = String.IsNullOrEmpty(Savingvnv) ? 0.0 : Convert.ToDouble(Savingvnv);
                double contractValued = String.IsNullOrEmpty(contractValue) ? 0.0 : Convert.ToDouble(contractValue);
                double FinalClosingd = String.IsNullOrEmpty(FinalClosing) ? 0.0 : Convert.ToDouble(FinalClosing);
                double lastExactractd = String.IsNullOrEmpty(lastExactract) ? 0.0 : Convert.ToDouble(lastExactract);
                double Divisionvd = String.IsNullOrEmpty(Divisionv) ? 0.0 : Convert.ToDouble(Divisionv);

                //MessageBox.Show(contractValue + ' '+ FinalClosing + ' '+ lastExactract+ ' ' + contractValued +' ' + lastExactractd +' '+ FinalClosingd);
                // Gardinia الاولى
                //(double.Parse (dr[0])+double.Parse(dr[1].ToString()) + double.Parse(dr[2].ToString())
                megaProjAllContractedValue.Text = AllContractVals;
                Paid.Text = lastExactractd.ToString();

                //+ (dr[1] as string == null ? 0.0 : double.Parse(dr[1] as string)) + (dr[2] as string == null ? 0.0 : double.Parse(dr[2] as string))).ToString("0.#######");
                restOfMoneySpecified.Text = dr[3].ToString();

                if (Divisionvd > 0)
                {
                    savings.Text = dr[4].ToString();
                    shortage.Text = "0.0";

                }
                else if (Divisionvd < 0)
                {
                    shortage.Text = dr[4].ToString();
                    savings.Text = "0.0";

                }
                else
                {
                    shortage.Text = "0.0";
                    savings.Text = "0.0";

                }
                //string Paids = convert.ToString(float.Parse(Paid.Text));
                rateOfImplementation.Text = ((float.Parse(percentOfImplementv.ToString()) / float.Parse(percentOfImplementcountv.ToString())) * 10 / 100).ToString("0.######");
                exchangeRate.Text = ((lastExactractd / contractValued) * 100).ToString();
            }
            catch (Exception ex)
            {
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(st.FrameCount - 1);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                MessageBox.Show(ex.Message, line.ToString());
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public int selectID(string megaProjectName, string phraseNameindex)
        {
            bool isSuccess = false;
            DataTable Cdt = new DataTable();
            string chCount = "Select [ID] from PhrasesTablle where ([megaProjName]='" + megaProjectName + "') AND ([phrasesName]='" + phraseNameindex + "')";
            OleDbConnection OleDbConnection = new OleDbConnection(connector);
            OleDbCommand OleDbCommander = new OleDbCommand(chCount, OleDbConnection);
            OleDbDataAdapter SDAC = new OleDbDataAdapter(OleDbCommander);
            OleDbConnection.Open();
            SDAC.Fill(Cdt);
            DataRow Cdr = Cdt.Rows[0];

            return int.Parse(Cdr[0].ToString());
        }
        public int checkCount(string megaProjectName)
        {
            bool isSuccess = false;
            DataTable Cdt = new DataTable(); 
            string chCount = "Select [noOfPhrases] from megaProject where [megaProjectName]='" + megaProjectName + "'";
            OleDbConnection OleDbConnection = new OleDbConnection(connector);
            OleDbCommand OleDbCommander = new OleDbCommand (chCount, OleDbConnection);
            OleDbDataAdapter SDAC = new OleDbDataAdapter(OleDbCommander);
            OleDbConnection.Open();
            SDAC.Fill(Cdt);
            DataRow Cdr = Cdt.Rows[0];

            return int.Parse(Cdr[0].ToString());
        }
        public bool selectDataCount(string megaProjectName)
        {
            bool isSuccess = false;
            string PhraseName = "''";
            DataSet DS = new DataSet();

            int counter= checkCount(megaProjectName);

            string querySelectSums = "Select count(*) from PhrasesTablle where megaProjName='" + megaProjectName + "'";
            OleDbConnection OleDbConnection = new OleDbConnection(connector);
            DataTable Gdt = new DataTable();
            OleDbCommand OleDbCommand = new OleDbCommand (querySelectSums, OleDbConnection);
            OleDbDataAdapter OleDbDataAdapter = new OleDbDataAdapter(OleDbCommand );
            OleDbConnection.Open();
            OleDbDataAdapter.Fill(Gdt);
            DataRow GDR = Gdt.Rows[0];
            int GDRVal = int.Parse(GDR[0].ToString());
            MessageBox.Show(counter.ToString()+' '+ GDRVal);
           
                if (GDRVal < counter) { 
                isSuccess = true;
                OleDbConnection.Close();
                }
                else
                {
                    MessageBox.Show("عدد المراحل اقل من المحدد");
                    OleDbConnection.Close();
                isSuccess = false;

            }
            //}
            //else
            //{
            //    isSuccess = false;
            //    OleDbConnection.Close();
            //}

            return isSuccess;
        }
        public DataSet selectOnePhraseData(PhraseTable PTS)
        {
            DataSet DS = new DataSet();

            try
            {
                
                string querySelector = "Select * from PhrasesTablle where phrasesName Like'%" + PTS.phrasesName + "%'";
                OleDbConnection OleDbConnection = new OleDbConnection(connector);
                OleDbCommand OleDbCommand = new OleDbCommand (querySelector, OleDbConnection);
                OleDbDataAdapter OleDbDataAdapter = new OleDbDataAdapter(OleDbCommand );
                OleDbConnection.Open();

                OleDbDataAdapter.Fill(DS);

                OleDbConnection.Close();


            }
            catch (Exception ex)
            {
                //var st = new StackTrace(ex, true);
                //// Get the top stack frame
                //var frame = st.GetFrame(st.FrameCount - 1);
                //// Get the line number from the stack frame
                //var line = frame.GetFileLineNumber();
                //MessageBox.Show(ex.Message, line.ToString());

                //MessageBox.Show(ex.Message);
            }
            return DS;
        }

        public DataSet selectData(PhraseTable PTS)
        {
            DataSet DS = new DataSet();
             
            try
            {
                string querySelector = "Select * from PhrasesTablle where megaProjName='" + Sessions.SessionData.megaProjectName + "'";
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
        public bool insertData(PhraseTable PTD)
        {
            bool isSuccess = false;
            bool succeed = selectDataCount(PTD.megaProjName);
            try { 
            string queryInsert = "Insert Into PhrasesTablle ([megaProjName],[phrasesName],[phrasesNum],[TimeStrategy],[phraseCom" +
                "ponents],[PhraseFinancialStatement],[PhraseRequiredDependency],[PhrasePaid]" +
                ",[PhraserestOfMoneySpecified],[Phraseshortage],[PhraseSavings],[PhraseExchangeRate],[PhrasesAllContractedValue]" +
                ",[PhraseImplementedRate],[PhraseImplementedRateAccordingToFinancialStat] )Values('" + PTD.megaProjName+ "','" + PTD.phrasesName+ "','" + PTD.phrasesNum+ "','"+ 
                PTD.TimeStrategy + "','"+ PTD.phraseComponents + "','"+ (PTD.PhraseFinancialStatement==null? 0 : PTD.PhraseFinancialStatement) + "','" +
                (PTD.PhraseRequiredDependency == null ? 0 : PTD.PhraseRequiredDependency) + "','" + (PTD.PhrasePaid == null ? 0 : PTD.PhrasePaid) + "','" +
                (PTD.PhraserestOfMoneySpecified == null ? 0 : PTD.PhraserestOfMoneySpecified) + "'" +
                ",'" + (PTD.Phraseshortage == null ? 0 : PTD.Phraseshortage) + "','" +
                (PTD.PhraseSavings == null ? 0 : PTD.PhraseSavings) + "','" +
                (PTD.PhraseExchangeRate == null ? 0 : PTD.PhraseExchangeRate) + "'," +
                "'" + (PTD.PhrasesAllContractedValue == null ? 0 : PTD.PhrasesAllContractedValue) + "','" +
                (PTD.PhraseImplementedRate == null ? 0 : PTD.PhraseImplementedRate) + "','" +
                (PTD.PhraseImplementedRateAccordingToFinancialStat == null ? 0 : PTD.PhraseImplementedRateAccordingToFinancialStat) + "')";
            OleDbConnection OleDbConnection = new OleDbConnection(connector);

            if (succeed)
            {
                OleDbCommand OleDbCommand = new OleDbCommand (queryInsert, OleDbConnection);
                OleDbDataAdapter OleDbDataAdapter = new OleDbDataAdapter(OleDbCommand );


                OleDbConnection.Open();
            int exec = OleDbCommand .ExecuteNonQuery();
            if (exec > 0)
            {
                isSuccess = true;
                    MessageBox.Show("تم اضافة المرحلة");

                }
                else
            {
                isSuccess = false;
                MessageBox.Show("there are missed data");

            }
            }
            else {
                
                MessageBox.Show("عدد المراحل مكتمل");
            }
            }
            catch (Exception ex) {}
            return isSuccess;
        }
        public bool updateDataForAccess(PhraseTable PD)
        {

            bool isSuccess = false;
            try { 
            string queryUpdates = "Update [PhrasesTablle] set [phrasesName]=IIF(IsNull(@phrasesName),[phrasesName],@phrasesName)" +
                ",[TimeStrategy]= IIF(IsNull(@TimeStrategy),[TimeStrategy],@TimeStrategy)" +
                ",[phraseComponents]= IIF(IsNull(@phraseComponents),[phraseComponents],@phraseComponents) " +
                ",[PhraseFinancialStatement]= IIF(IsNull(@PhraseFinancialStatement),[PhraseFinancialStatement],@PhraseFinancialStatement)" +
                ",[PhraseRequiredDependency]= IIF(IsNull(@PhraseRequiredDependency),[PhraseRequiredDependency],@PhraseRequiredDependency)" +
                ",[PhrasePaid]= IIF(IsNull(@PhrasePaid),[PhrasePaid],@PhrasePaid)" +
                ",[PhraserestOfMoneySpecified]= IIF(IsNull(@PhraserestOfMoneySpecified),[PhraserestOfMoneySpecified],@PhraserestOfMoneySpecified)" +
                ",[Phraseshortage]= IIF(IsNull(@Phraseshortage),[Phraseshortage],@Phraseshortage)" +
                ",[PhraseSavings]= IIF(IsNull(@PhraseSavings),[PhraseSavings],@PhraseSavings)" +
                ",[PhraseExchangeRate]= IIF(IsNull(@PhraseExchangeRate),[PhraseExchangeRate],@PhraseExchangeRate)" +
                ",[PhrasesAllContractedValue]= IIF(IsNull(@PhrasesAllContractedValue),[PhrasesAllContractedValue],@PhrasesAllContractedValue)" +
                ",[PhraseImplementedRate]= IIF(IsNull(@PhraseImplementedRate),[PhraseImplementedRate],@PhraseImplementedRate)" +
                ",[PhraseImplementedRateAccordingToFinancialStat]= IIF(IsNull(PhraseImplementedRateAccordingToFinancialStat),[PhraseImplementedRateAccordingToFinancialStat],PhraseImplementedRateAccordingToFinancialStat)" +
                " where [phrasesName]='" + PD.phrasesName + "' And [megaProjName]='" + PD.megaProjName + "'";
                //Or[phrasesNum] = IIF(IsNull('"+ PD.phrasesNum + "'),[phrasesNum], '" + PD.phrasesNum + "')
                OleDbConnection oleDbConnection = new OleDbConnection(connector);
                OleDbCommand oleDbCommand = new OleDbCommand(queryUpdates, oleDbConnection);
                oleDbCommand.Parameters.Add("@phrasesName", OleDbType.VarWChar).Value= (object)PD.phrasesName ?? DBNull.Value;
                oleDbCommand.Parameters.Add("@TimeStrategy", OleDbType.VarWChar).Value = ((object)PD.TimeStrategy) ?? DBNull.Value;
                oleDbCommand.Parameters.Add("@phraseComponents", OleDbType.VarWChar).Value = ((object)PD.phraseComponents) ?? DBNull.Value;
                oleDbCommand.Parameters.Add("@PhraseFinancialStatement", OleDbType.Double).Value = ((object)PD.PhraseFinancialStatement) ?? DBNull.Value;
                oleDbCommand.Parameters.Add("@PhraseRequiredDependency", OleDbType.Double).Value = (object)PD.PhraseRequiredDependency ?? DBNull.Value;
                oleDbCommand.Parameters.Add("@PhrasePaid", OleDbType.Double).Value = ((object)PD.PhrasePaid) ?? DBNull.Value;
                oleDbCommand.Parameters.Add("@PhraserestOfMoneySpecified", OleDbType.Double).Value= (object)PD.PhraserestOfMoneySpecified ?? DBNull.Value;
                oleDbCommand.Parameters.Add("@Phraseshortage", OleDbType.Double).Value = (object)PD.Phraseshortage ?? DBNull.Value;
                oleDbCommand.Parameters.Add("@PhraseSavings", OleDbType.Double).Value = (object)PD.PhraseSavings ?? DBNull.Value;
                oleDbCommand.Parameters.Add("@PhraseExchangeRate", OleDbType.Double).Value = (object)PD.PhraseExchangeRate?? DBNull.Value;
                oleDbCommand.Parameters.Add("@PhrasesAllContractedValue", OleDbType.Double).Value = ((object)PD.PhrasesAllContractedValue) ?? DBNull.Value;
                oleDbCommand.Parameters.Add("@PhraseImplementedRate", OleDbType.Single).Value = (object)PD.PhraseImplementedRate ?? DBNull.Value;

                oleDbCommand.Parameters.Add("@PhraseImplementedRateAccordingToFinancialStat", OleDbType.Single).Value = ((object)PD.PhraseImplementedRateAccordingToFinancialStat) ?? DBNull.Value;
                
                //oleDbCommand.Parameters.Add("@phrasesNum", OleDbType.Integer).Value = PD.phrasesNum;

                //oleDbCommand.Parameters.Add("@Param12", OleDbType.Double).Value = (object)PD.PhraseImplementedRate ?? DBNull.Value;
                //oleDbCommand.Parameters.Add("@Param12", OleDbType.Double).Value = (object)PD.PhraseImplementedRate ?? DBNull.Value;

                //oleDbCommand.Parameters.AddWithValue("@Param12", (object)PD.PhraseImplementedRate ?? DBNull.Value);
                //oleDbCommand.Parameters.AddWithValue("@Param13", (object)PD.PhraseImplementedRateAccordingToFinancialStat ?? DBNull.Value);
                //oleDbCommand.Parameters.AddWithValue("@FinalClosing", (object)PD.FinalClosing ?? DBNull.Value);
                //oleDbCommand.Parameters.AddWithValue("@contractValueFile", (object)PD.contractValueFile ?? DBNull.Value);
                //oleDbCommand.Parameters.AddWithValue("@FinalClosingFile", (object)PD.FinalClosingFile ?? DBNull.Value);
                //oleDbCommand.Parameters.AddWithValue("@lastExactractFile", (object)PD.lastExactractFile ?? DBNull.Value);
                //oleDbCommand.Parameters.AddWithValue("@Savings", (object)PD.Savings ?? DBNull.Value);
                //oleDbCommand.Parameters.AddWithValue("@Receipts", (object)PD.Receipts ?? DBNull.Value);
                //oleDbCommand.Parameters.AddWithValue("@Appropriations", (object)PD.Appropriations ?? DBNull.Value);
                //oleDbCommand.Parameters.AddWithValue("@SiteOrders", (object)PD.SiteOrders ?? DBNull.Value);
                //oleDbCommand.Parameters.AddWithValue("@ManagementMails", (object)PD.ManagementMails ?? DBNull.Value);
                //oleDbCommand.Parameters.AddWithValue("@Netbudget", (object)PD.Netbudget ?? DBNull.Value);
                //oleDbCommand.Parameters.AddWithValue("@ConstructionSafetyReport", (object)PD.ConstructionSafetyReport ?? DBNull.Value);
                //oleDbCommand.Parameters.AddWithValue("@ExploitationReductionandCancellationNotes", (object)PD.ExploitationReductionandCancellationNotes ?? DBNull.Value);

                //OleDbDataAdapter OleDbDataAdapter = new OleDbDataAdapter(oleDbCommand);


                oleDbConnection.Open();
            int exec = oleDbCommand.ExecuteNonQuery();
            if (exec > 0)
            {
                isSuccess = true;
            }
            else
            {
                isSuccess = false;
                MessageBox.Show("لم يتم تعديل المرحلة");
                }
            }catch(Exception ex)
            {
                var st = new StackTrace(ex, true);

                // Get the top stack frame
                var frame = st.GetFrame(st.FrameCount - 1);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                MessageBox.Show(ex.Message, line.ToString());

            }
            return isSuccess;
        }
        public bool updateData(PhraseTable PD)
        {
            
            bool isSuccess = false;
            string queryUpdates= "Update PhrasesTablle set [phrasesName]=" +
                "IIF(IsNull(@phrasesName),[phrasesName],@phrasesName)," +
                " [TimeStrategy]= IIF(IsNull(@TimeStrategy),[TimeStrategy],@TimeStrategy) , " +
                "[phraseComponents]= IIF(IsNull(@phraseComponents),[phraseComponents],@phraseComponents)" +/*'" + , [PhraseFinancialStatement] = IIF(IsNull('" +
*/                //(object)PD.PhraseFinancialStatement ?? DBNull.Value + "'),[PhraseFinancialStatement],'" +
                //(object)PD.PhraseFinancialStatement ?? DBNull.Value + "'),[PhraseRequiredDependency]= IIF(IsNull('" +
                //(object)PD.PhraseRequiredDependency ?? DBNull.Value + "'),[PhraseRequiredDependency],'" +
                //(object)PD.PhraseRequiredDependency ?? DBNull.Value + "'),[PhrasePaid]= IIF(IsNull('" +
                //(object)PD.PhrasePaid ?? DBNull.Value + "'),[PhrasePaid],'" +
                //(object)PD.PhrasePaid ?? DBNull.Value + "'),[PhraserestOfMoneySpecified]= IIF(IsNull('" +
                //(object)PD.PhraserestOfMoneySpecified ?? DBNull.Value + "'),[PhraserestOfMoneySpecified],'" +
                //(object)PD.PhraserestOfMoneySpecified ?? DBNull.Value + "'),[Phraseshortage]= IIF(IsNull('" +
                //(object)PD.Phraseshortage ?? DBNull.Value + "'),[Phraseshortage],'" +
                //(object)PD.Phraseshortage ?? DBNull.Value + "'),[PhraseSavings]= IIF(IsNull('" +
                //(object)PD.PhraseSavings ?? DBNull.Value + "'),[PhraseSavings],'" +
                //(object)PD.PhraseSavings ?? DBNull.Value + "'),[PhraseExchangeRate]= IIF(IsNull('" +
                //(object)PD.PhraseExchangeRate ?? DBNull.Value + "'),[PhraseExchangeRate],'" +
                //(object)PD.PhraseExchangeRate ?? DBNull.Value + "'),[PhrasesAllContractedValue]= IIF(IsNull('" +
                //(object)PD.PhrasesAllContractedValue ?? DBNull.Value + "'),[PhrasesAllContractedValue],'" +
                //(object)PD.PhrasesAllContractedValue ?? DBNull.Value + "'),[PhraseImplementedRate]= IIF(IsNull('" +
                //(object)PD.PhraseImplementedRate ?? DBNull.Value + "'),[PhraseImplementedRate],'" +
                //(object)PD.PhraseImplementedRate ?? DBNull.Value + "'),[PhraseImplementedRateAccordingToFinancialStat]= IIF(IsNull('" +
                //(object)PD.PhraseImplementedRateAccordingToFinancialStat ?? DBNull.Value + "'),[PhraseImplementedRateAccordingToFinancialStat],'" +
                /*(object)PD.PhraseImplementedRateAccordingToFinancialStat ?? DBNull.Value + "')*/" where [phrasesName]='" + PD.phrasesName + "' or [phrasesNum]" +
                "=IIF(IsNull(@phrasesNum),0,@phrasesNum) And [megaProjName]='" + PD.megaProjName + "'";

                OleDbConnection OleDbConnection = new OleDbConnection(connector);
                OleDbCommand OleDbCommand = new OleDbCommand (queryUpdates, OleDbConnection);
                OleDbCommand.Parameters.AddWithValue("@phrasesName",PD.phrasesName);
                //OleDbCommand.Parameters.AddWithValue("@TimeStrategy", PD.TimeStrategy);
            OleDbCommand.Parameters.Add("@TimeStrategy", OleDbType.VarWChar).Value = (object)PD.TimeStrategy ?? DBNull.Value;
            OleDbCommand.Parameters.Add("@phraseComponents", OleDbType.VarWChar).Value= (object)PD.phraseComponents ?? DBNull.Value;
                OleDbCommand.Parameters.AddWithValue("@phrasesNum", PD.phrasesNum);


            OleDbDataAdapter OleDbDataAdapter = new OleDbDataAdapter(OleDbCommand );


                OleDbConnection.Open();
                int exec = OleDbCommand .ExecuteNonQuery();
                if (exec > 0)
                {
                    isSuccess = true;
                
                }
                else
                {
                    isSuccess = false;
                    MessageBox.Show("لم يتم تعديل المرحلة");

                }

            return isSuccess;
        }
        //public bool DeleteData(megaProj PD)
        //{
        //    bool isSuccess = false;
        //    string querySelectSums = "Select sum(lastExactract) from BuildsMainTable where PhraseName='" + "'";

        //    return isSuccess;
        //}
        //public bool DeleteData(megaProj PD)
        //{
        //    bool isSuccess = false;
        //    string querySelectSums = "Select sum(lastExactract) from BuildsMainTable where PhraseName='" + "'";

        //    return isSuccess;
        //}
    }
}
