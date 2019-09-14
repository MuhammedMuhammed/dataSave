using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gardinia.GardModels
{
    class BuildData
    { 
        
       
        //public string implementerCompany { get; set;}
//        public string BuildViewUri { set; get; }
        public Nullable<Int64> BuildUnitsFrom { get; set; }
        public Nullable<Int64> BuildUnitsTo { get; set; }
        //public DateTime contractualDate { get; set; }
        public string BuildReport { get; set; }
        public string ContractCode { get; set; }
        public string Image { get; set; }
        public string projectPhrase { get; set; }
        public string projectName { get; set; }
        public string periodToImplementProject { get; set; }
        //public DateTime contractualDate { get; set; }
        public string projectConsultative { get; set; }
        public string implementerCompany { get; set; }
        public string projectOwner { get; set; }
        public Nullable<DateTime> projectrecordingDate { get; set; }
        public Nullable<DateTime> startingProjectDate { get; set; }
        public string projectIndexation{get; set;}
        public string receiptOfTheSite { get; set; }
        public string locationOfCheckingDrillingBottom { get; set; }
        public string projectNotes { get; set; }
        public string DurationProgram { get; set; }
        public Nullable<double> percentageOfImplementation { get; set; }
        public string percentageOfImplementationDetails { get; set; }
        public string notices { get; internal set; }
        public Nullable<double> contractValue { get; internal set; }
        public Nullable<double> FinalClosing { get; internal set; }
        public string contractValueFile { get; internal set; }
        public string FinalClosingFile { get; internal set; }
        public string lastExactractFile { get; internal set; }
        public string Savings { get; internal set; }
        public string Receipts { get; internal set; }
        public string Appropriations { get; internal set; }
        public string SiteOrders { get; internal set; }
        public string ManagementMails { get; internal set; }
        public string Netbudget { get; internal set; }
        public string ConstructionSafetyReport { get; internal set; }
        public string ExploitationReductionandCancellationNotes { get; internal set; }
        public Nullable<DateTime> EndingOfContractorDate { get; internal set; }
        public string AddedPeriodToProject { get; internal set; }
        public Nullable<DateTime> LastTimeForEndingProject { get; internal set; }
        long total= 0;
        public Nullable<long> Total{get; set;}
        public string megaProjectName { get; internal set; }
        public string ProjectDataTypes { get; internal set; }
        public double? lastExactract { get; internal set; }
        public double? Division { get; internal set; }
        public double? savingsValue { get; internal set; }
        public string projectImages { get; internal set; }
        public double? percentageOfImplementationAccordingToFinancialStatement { get; internal set; }
        public double? percentageOfImplementationAccordingToPhrase{ get; internal set; }
        public double? TotalDeductionsValues { get; internal set; }

        public string BuildType { get; private set; }
        public int? PhraseID { get; set; }

        //public string owner { get; set; }

        static string myconnecting = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Directory.GetCurrentDirectory() + "\\ArchDB.accdb;Persist Security Info=false"/*"Data Source=MSSQLSERVER;Initial Catalog=" + Directory.GetCurrentDirectory() + "/GARDINIATABLES.MDF;Initial Catalog=GardiniaTables;Integrated Security=True"*/;

        public DataTable SelectSums(TextBox Paid, TextBox restOfMoneySpecified, TextBox savings,TextBox shortage, TextBox financialStatement, TextBox exchangeRate, TextBox rateOfImplementation, TextBox allContractedValue, string projectPhraseName)
        {
            OleDbConnection conn = new OleDbConnection(myconnecting);
            DataTable dt = new DataTable();
            try
            {
                string sql = "select Sum(contractValue), Sum(FinalClosing),  Sum(lastExactract),Sum(Division),Sum(savingsValue),Sum(percentageOfImplementation),count(percentageOfImplementation),sum(percentageOfImplementationAccordingToFinancialStatement), count(*) From BuildsMainTable where projectPhrase = '" + projectPhraseName + "'";
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
                string percentageOfImplementationAccordingToFinancialStatement = dr[7].ToString();
                string percentageOfImplementationAccordingToFinancialStatementcount = dr[8].ToString();

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
                allContractedValue.Text = contractValued.ToString();
                Paid.Text = lastExactractd.ToString();

                //+ (dr[1] as string == null ? 0.0 : double.Parse(dr[1] as string)) + (dr[2] as string == null ? 0.0 : double.Parse(dr[2] as string))).ToString("0.#######");
                restOfMoneySpecified.Text = dr[3].ToString();

                if (Divisionvd > 0)
                {
                    savings.Text = dr[4].ToString();
                    shortage.Text = "0.0";

                }
                else if (Divisionvd < 0) {
                    shortage.Text = dr[4].ToString();
                    savings.Text = "0.0";

                }
                else {
                    shortage.Text = "0.0";
                    savings.Text = "0.0";

                }
                //string Paids = convert.ToString(float.Parse(Paid.Text));
                rateOfImplementation.Text = ((float.Parse(percentOfImplementv.ToString()) / float.Parse(percentOfImplementcountv.ToString()))*10/100).ToString("0.######");
                exchangeRate.Text = ((lastExactractd/contractValued)*100).ToString();
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
        public DataTable SelectPartsSums(TextBox Paid, TextBox restOfMoneySpecified, TextBox savings, TextBox shortage, TextBox financialStatement, TextBox exchangeRate, TextBox rateOfImplementation, TextBox allContractedValue, string projectPhraseName, string ProjectPartitionName)
        {
            OleDbConnection conn = new OleDbConnection(myconnecting);
            DataTable dt = new DataTable();
            try
            {
                string sql = "select Sum(contractValue), Sum(FinalClosing),  Sum(lastExactract),Sum(Division),Sum(savingsValue),Sum(percentageOfImplementation),count(percentageOfImplementation),sum(percentageOfImplementationAccordingToFinancialStatement), count(*) From BuildsMainTable where projectPhrase = '" + projectPhraseName + "' And ProjectDataTypes ='" + ProjectPartitionName + "'";
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
                string percentageOfImplementationAccordingToFinancialStatement = dr[7].ToString();
                string percentageOfImplementationAccordingToFinancialStatementcount = dr[8].ToString();

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
                allContractedValue.Text = contractValued.ToString();
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
        public DataTable SelectOneColumn()
        {
            OleDbConnection conn = new OleDbConnection(myconnecting);
            DataTable dt = new DataTable();
            try
            {
                string sql = "select DurationProgram From BuildsMainTable";
                OleDbCommand sqlcmd = new OleDbCommand (sql, conn);
                OleDbDataAdapter OleDbDataAdapter = new OleDbDataAdapter(sqlcmd);

                conn.Open();
                OleDbDataAdapter.Fill(dt);
                DataRow dr = dt.Rows[0];

            }
            catch (Exception ex)
            { }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public DataTable Select() {
            OleDbConnection conn = new OleDbConnection(myconnecting);
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * From BuildsMainTable";
                OleDbCommand sqlcmd = new OleDbCommand (sql,conn);
                OleDbDataAdapter OleDbDataAdapter = new OleDbDataAdapter(sqlcmd);
              
                conn.Open();
                OleDbDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            { }
            finally
            {
                conn.Close();  
            }
            return dt;
        }
        public bool Insert(BuildData bd)
        {
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(myconnecting);
            try
            {
                /*[BuildUnitsFrom],*/
                string sql = "INSERT INTO BuildsMainTable( [BuildUnitsFrom]," +
                        "[BuildUnitsTo]," +
                    "[BuildReport]," +
                " [ContractCode]," +
                    "[image]," +
                "[projectPhrase]," +
                "[projectName]," +
                "[periodToImplementProject]," +
                "[implementerCompany]," +
                "[projectOwner]," +
                "[projectrecordingDate]," +
                "[startingProjectDate]," +
                "[projectConsultative]," +
                "[receiptOfTheSite]," +
                "[locationOfCheckingDrillingBottom]," +
                "[projectIndexation]," +
                "[projectNotes]," +
                "[DurationProgram]," +
                "[percentageOfImplementation]," +
                "[percentageOfImplementationDetails]," +
            "[notices]," +
            "[contractValue]," +
            "[FinalClosing]," +
            "[contractValueFile]," +
            "[FinalClosingFile]," +
            "[lastExactractFile]," +
            "[Savings]," +
            "[Receipts]," +
            "[Appropriations]," +
            "[SiteOrders]," +
            "[ManagementMails]," +
            "[Netbudget]," +
            "[ConstructionSafetyReport]," +
            "[ExploitationReductionandCancellationNotes]," +
            "[EndingOfContractorDate]," +
            "[addedperiodtoproject]," +
            "[LastTimeForEndingProject]," +
            "[ProjectDataTypes]," +
            "[lastExactract]," +
            "[Division]," +
            "[savingsValue]," +
            "[percentageOfImplementationAccordingToFinancialStatement]," +
            "[megaProjectName]," +
            "[percentageOfImplementationAccordingToPhrase]," +
            "[TotalDeductionsValues]," +
            "[PhraseID]) VALUES (" +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?," +
            "?)";
            //"[contractValueFile]," +
            //"[FinalClosingFile]," +
            //"[lastExactractFile]," +
            //"[Savings]," +
            //"[Receipts]," +
            //"[Appropriations]," +
            //"[SiteOrders]" +
            //",[ManagementMails]," +
            //"[Netbudget]," +
            //"[ConstructionSafetyReport]," +
            //"[ExploitationReductionandCancellationNotes]," +
            //"[EndingOfContractorDate]," +
            //"[AddedPeriodToProject]," +
            //"[LastTimeForEndingProject]," +
            //"[ProjectDataTypes]," +
            //"[lastExactract]," +
            //"[Division]," +
            //"[savingsValue]," +
            //"[percentageOfImplementationAccordingToFinancialStatement]," +
            //"[megaProjectName])
            //string sql = "INSERT INTO BuildsMainTable(  [ContractCode],[projectPhrase],[projectName],[megaProjectName]) VALUES (?,?,?,?)";
            OleDbCommand OleDbCommand = new OleDbCommand(sql, conn);
                OleDbCommand.Parameters.Add("@Param1", OleDbType.BigInt).Value = bd.BuildUnitsFrom;
                OleDbCommand.Parameters.Add("@Param2", OleDbType.BigInt).Value = bd.BuildUnitsTo;
                OleDbCommand.Parameters.Add("@Param3", OleDbType.VarWChar).Value = bd.BuildReport;
                OleDbCommand.Parameters.Add("@Param4", OleDbType.VarWChar).Value = bd.ContractCode;
                OleDbCommand.Parameters.Add("@Param5", OleDbType.VarWChar).Value = bd.Image;
                OleDbCommand.Parameters.Add("@Param6", OleDbType.VarWChar).Value = bd.projectPhrase;
                OleDbCommand.Parameters.Add("@Param7", OleDbType.VarWChar).Value = bd.projectName;
                OleDbCommand.Parameters.Add("@Param8", OleDbType.VarWChar).Value = bd.periodToImplementProject;
                OleDbCommand.Parameters.Add("@Param9", OleDbType.VarWChar).Value = bd.implementerCompany;
                OleDbCommand.Parameters.Add("@Param10", OleDbType.VarWChar).Value = bd.projectOwner;
                OleDbCommand.Parameters.Add("@Param11", OleDbType.Date).Value = bd.projectrecordingDate;
                OleDbCommand.Parameters.Add("@Param12", OleDbType.Date).Value = bd.startingProjectDate;
                OleDbCommand.Parameters.Add("@Param13", OleDbType.VarWChar).Value = bd.projectConsultative;
                OleDbCommand.Parameters.Add("@Param14", OleDbType.VarWChar).Value = bd.receiptOfTheSite;
                OleDbCommand.Parameters.Add("@Param15", OleDbType.VarWChar).Value = bd.locationOfCheckingDrillingBottom;
                OleDbCommand.Parameters.Add("@Param16", OleDbType.VarWChar).Value = bd.projectIndexation;
                OleDbCommand.Parameters.Add("@Param17", OleDbType.VarWChar).Value = bd.projectNotes;
                OleDbCommand.Parameters.Add("@Param18", OleDbType.VarWChar).Value = bd.DurationProgram;
                OleDbCommand.Parameters.Add("@Param19", OleDbType.Double).Value = bd.percentageOfImplementation;
                OleDbCommand.Parameters.Add("@Param20", OleDbType.VarWChar).Value = bd.percentageOfImplementationDetails;
                OleDbCommand.Parameters.Add("@Param21", OleDbType.VarWChar).Value = bd.notices;
                OleDbCommand.Parameters.Add("@Param22", OleDbType.Double).Value = bd.contractValue;
                OleDbCommand.Parameters.Add("@Param23", OleDbType.Double).Value = bd.FinalClosing;
                OleDbCommand.Parameters.Add("@Param24", OleDbType.VarWChar).Value = bd.contractValueFile;
                OleDbCommand.Parameters.Add("@Param25", OleDbType.VarWChar).Value = bd.FinalClosingFile;

                OleDbCommand.Parameters.Add("@Param26", OleDbType.VarWChar).Value = bd.lastExactractFile;
                OleDbCommand.Parameters.Add("@Param27", OleDbType.VarWChar).Value = bd.Savings;
                OleDbCommand.Parameters.Add("@Param28", OleDbType.VarWChar).Value = bd.Receipts;
                OleDbCommand.Parameters.Add("@Param29", OleDbType.VarWChar).Value = bd.Appropriations;
                OleDbCommand.Parameters.Add("@Param30", OleDbType.VarWChar).Value = bd.SiteOrders;
                OleDbCommand.Parameters.Add("@Param31", OleDbType.VarWChar).Value = bd.ManagementMails;
                OleDbCommand.Parameters.Add("@Param32", OleDbType.VarWChar).Value = bd.Netbudget;
                OleDbCommand.Parameters.Add("@Param33", OleDbType.VarWChar).Value = bd.ConstructionSafetyReport;
                OleDbCommand.Parameters.Add("@Param34", OleDbType.VarWChar).Value = bd.ExploitationReductionandCancellationNotes;
                OleDbCommand.Parameters.Add("@Param35", OleDbType.Date).Value = bd.EndingOfContractorDate;
                OleDbCommand.Parameters.Add("@Param36", OleDbType.VarWChar).Value = bd.AddedPeriodToProject;
                OleDbCommand.Parameters.Add("@Param37", OleDbType.Date).Value = bd.LastTimeForEndingProject;
                OleDbCommand.Parameters.Add("@Param38", OleDbType.VarWChar).Value = bd.ProjectDataTypes;
                OleDbCommand.Parameters.Add("@Param39", OleDbType.Double).Value = bd.lastExactract;
                OleDbCommand.Parameters.Add("@Param40", OleDbType.Double).Value = bd.Division;
                OleDbCommand.Parameters.Add("@Param41", OleDbType.Double).Value = bd.savingsValue;
                OleDbCommand.Parameters.Add("@Param42", OleDbType.Double).Value = bd.percentageOfImplementationAccordingToFinancialStatement;
                OleDbCommand.Parameters.Add("@Param43", OleDbType.VarWChar).Value = bd.megaProjectName;
                OleDbCommand.Parameters.Add("@Param44", OleDbType.Double).Value = bd.percentageOfImplementationAccordingToPhrase;
                OleDbCommand.Parameters.Add("@Param45", OleDbType.Double).Value = bd.TotalDeductionsValues;
                OleDbCommand.Parameters.Add("@Param46", OleDbType.BigInt).Value = bd.PhraseID;

                //",[notices],[contractValue],[FinalClosing],[contractValueFile],[FinalClosingFile]," +
                //"[lastExactractFile],[Savings],[Receipts],[Appropriations],[SiteOrders]" +
                //",[ManagementMails],[Netbudget],[ConstructionSafetyReport],[ExploitationReductionandCancellationNotes]," +
                //"[EndingOfContractorDate],[AddedPeriodToProject],[LastTimeForEndingProject]," +
                //"[ProjectDataTypes],[lastExactract],[Division],[savingsValue],[percentageOfImplementationAccordingToFinancialStatement]," +
                //"[megaProjectName]

                //OleDbCommand.Parameters.AddWithValue("@implementerCompany", bd.implementerCompany);
                ////OleDbCommand.Parameters.AddWithValue("@[BuildViewUri ]", bd.BuildViewUri);
                //OleDbCommand.Parameters.AddWithValue("@BuildUnitsFrom", bd.BuildUnitsFrom).Value = 0;
                //OleDbCommand.Parameters.AddWithValue("@BuildUnitsTo", bd.BuildUnitsTo).Value = 0;
                //OleDbCommand.Parameters.AddWithValue("@projectNotes", bd.projectNotes).Value = null;

                ////OleDbCommand.Parameters.AddWithValue("@contractualDate", bd.contractualDate);
                //OleDbCommand.Parameters.AddWithValue("@BuildReport", bd.BuildReport ).Value = ((object)bd.BuildReport) ?? DBNull.Value;
                //OleDbCommand.Parameters.AddWithValue("@ContractCode", bd.ContractCode).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@Image", bd.Image).Value = null;
                ////SqlParameter imageParameter = new SqlParameter("@Image", bd.Image);
                ////imageParameter.Value = DBNull.Value;
                ////OleDbCommand.Parameters.Add(imageParameter);
                //OleDbCommand.Parameters.AddWithValue("@projectPhrase", bd.projectPhrase).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@projectName", bd.projectName).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@periodToImplementProject", bd.periodToImplementProject).Value = null;
                ////OleDbCommand.Parameters.AddWithValue("@contractualDate", bd.contractualDate);
                //OleDbCommand.Parameters.AddWithValue("@projectOwner", bd.projectOwner).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@implementerCompany", bd.implementerCompany).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@startingProjectDate", bd.startingProjectDate).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@projectrecordingDate", bd.projectrecordingDate).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@projectConsultative", bd.projectConsultative).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@receiptOfTheSite", bd.receiptOfTheSite).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@locationOfCheckingDrillingBottom", bd.locationOfCheckingDrillingBottom).Value = null;
                ////OleDbCommand.Parameters.Add("@projectID", SqlDbType.Int).Value = bd.projectID;
                //OleDbCommand.Parameters.AddWithValue("@projectIndexation", bd.projectIndexation).Value = null;

                //OleDbCommand.Parameters.AddWithValue("@DurationProgram", bd.DurationProgram);
                //OleDbCommand.Parameters.AddWithValue("@percentageOfImplementation", bd.percentageOfImplementation).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@DurationProgram", bd.DurationProgram).Value = null;

                //OleDbCommand.Parameters.AddWithValue("@percentageOfImplementationDetails", bd.percentageOfImplementationDetails).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@notices", bd.notices).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@contractValue", bd.contractValue).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@FinalClosing", bd.FinalClosing).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@contractValueFile", bd.contractValueFile).Value = null;

                //OleDbCommand.Parameters.AddWithValue("@FinalClosingFile", bd.FinalClosingFile).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@lastExactractFile", bd.lastExactractFile).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@Savings", bd.Savings).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@Receipts", bd.Receipts).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@Appropriations", bd.Appropriations).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@SiteOrders", bd.SiteOrders).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@ManagementMails", bd.ManagementMails).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@Netbudget", bd.Netbudget).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@ConstructionSafetyReport", bd.ConstructionSafetyReport).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@ExploitationReductionandCancellationNotes", bd.ExploitationReductionandCancellationNotes).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@LastTimeForEndingProject", bd.LastTimeForEndingProject).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@AddedPeriodToProject", bd.AddedPeriodToProject).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@EndingOfContractorDate", bd.EndingOfContractorDate).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@Total", bd.Total).Value = "";
                //OleDbCommand.Parameters.AddWithValue("@ProjectDataTypes", bd.ProjectDataTypes).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@lastExactract", bd.lastExactract).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@Division", bd.Division).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@savingsValue", bd.savingsValue).Value = null;
                //OleDbCommand.Parameters.AddWithValue("@projectImages", bd.projectImages);
                ////percentageOfImplementationAccordingToFinancialStatement
                //OleDbCommand.Parameters.AddWithValue("@percentageOfImplementationAccordingToFinancialStatement", bd.percentageOfImplementationAccordingToFinancialStatement).Value = null;



                conn.Open();

            int rows = OleDbCommand.ExecuteNonQuery();
            if (rows > 0)
            {
                isSuccess = true;
            }
            else
            {
                isSuccess = false;
            }
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
            return isSuccess;
        }


        //public bool Insert(BuildData bd) {
        //    bool isSuccess = false;
        //    OleDbConnection conn = new OleDbConnection(myconnecting);
        //    //try
        //    //{
        //        string sql = "INSERT INTO BuildsMainTable( [BuildUnitsFrom],[BuildUnitsTo],  [BuildReport], [ContractCode],[Image],[projectPhrase],[projectName],[periodToImplementProject],[implementerCompany],[projectOwner],[projectrecordingDate],[startingProjectDate],[projectConsultative],[receiptOfTheSite],[locationOfCheckingDrillingBottom],[projectIndexation],[projectNotes],[DurationProgram],[percentageOfImplementation],[percentageOfImplementationDetails]" +
        //        ",[notices],[contractValue],[FinalClosing],[contractValueFile],[FinalClosingFile],[lastExactractFile],[Savings],[Receipts],[Appropriations],[SiteOrders]" +
        //        ",[ManagementMails],[Netbudget],[ConstructionSafetyReport],[ExploitationReductionandCancellationNotes],[EndingOfContractorDate],[AddedPeriodToProject],[LastTimeForEndingProject],[ProjectDataTypes],[lastExactract],[Division],[savingsValue],[percentageOfImplementationAccordingToFinancialStatement]) VALUES ('"+bd.BuildUnitsFrom+"','"+bd.BuildUnitsTo+"'," +
        //        "'"+ bd.BuildReport +"','"+ bd.ContractCode +"','"+ bd.Image +"',  '"+ bd.projectPhrase +"','"+ bd.projectName +"','"+
        //        bd.periodToImplementProject +"','"+ bd.implementerCompany +"','"+ bd.projectOwner +"','"+
        //        bd.projectrecordingDate +"'," +
        //        "'"+ bd.startingProjectDate +"','"+ bd.projectConsultative +"','"+ bd.receiptOfTheSite +"','"+ bd.locationOfCheckingDrillingBottom 
        //        +"','"+ bd.projectIndexation +"','"+ bd.projectNotes +"','"+ bd.DurationProgram +"'," +
        //        "'"+ bd.percentageOfImplementation +"','"+ bd.percentageOfImplementationDetails +"','"+ bd.notices +"','"+ bd.contractValue +"','"+ bd.FinalClosing +"','"+ bd.contractValueFile +"','"+ 
        //        bd.FinalClosingFile +"','"+ bd.lastExactractFile +"'," +
        //        "'"+ bd.Savings +"','"+ bd.Receipts + "','" + bd.Appropriations + "','" + bd.SiteOrders + "','" + bd.ManagementMails + "','" + bd.Netbudget + "','" + bd.ConstructionSafetyReport + "','" + bd.ExploitationReductionandCancellationNotes +"'" +
        //        ",'"+ bd.EndingOfContractorDate + "','" + bd.AddedPeriodToProject + "','" + bd.LastTimeForEndingProject + "','" + bd.ProjectDataTypes + "','" + bd.lastExactract + "','" + bd.Division + "','"
        //        + bd.savingsValue + "','" + bd.percentageOfImplementationAccordingToFinancialStatement +"')";
                
        //        OleDbCommand OleDbCommand = new OleDbCommand (sql, conn);
        //        //OleDbCommand .Parameters.AddWithValue("@implementerCompany", bd.implementerCompany);
        //        //OleDbCommand .Parameters.AddWithValue("@[BuildViewUri ]", bd.BuildViewUri);
        //        //OleDbCommand .Parameters.AddWithValue("@BuildUnitsFrom", bd.BuildUnitsFrom).Value = 0;
        //        //OleDbCommand .Parameters.AddWithValue("@BuildUnitsTo", bd.BuildUnitsTo).Value = 0;
        //        //OleDbCommand .Parameters.AddWithValue("@projectNotes", bd.projectNotes).Value = null;

        //        //OleDbCommand .Parameters.AddWithValue("@contractualDate", bd.contractualDate);
        //        //OleDbCommand .Parameters.AddWithValue("@BuildReport", ).Value = ((object)bd.BuildReport) ?? DBNull.Value;
        //        //OleDbCommand .Parameters.AddWithValue("@ContractCode", bd.ContractCode).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@Image", bd.Image).Value = null;
        //        //SqlParameter imageParameter = new SqlParameter("@Image", bd.Image);
        //        //imageParameter.Value = DBNull.Value;
        //        //OleDbCommand .Parameters.Add(imageParameter);
        //        //OleDbCommand .Parameters.AddWithValue("@projectPhrase", bd.projectPhrase).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@projectName", bd.projectName).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@periodToImplementProject", bd.periodToImplementProject).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@contractualDate", bd.contractualDate);
        //        //OleDbCommand .Parameters.AddWithValue("@projectOwner", bd.projectOwner).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@implementerCompany", bd.implementerCompany).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@startingProjectDate", bd.startingProjectDate).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@projectrecordingDate", bd.projectrecordingDate).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@projectConsultative", bd.projectConsultative).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@receiptOfTheSite", bd.receiptOfTheSite).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@locationOfCheckingDrillingBottom", bd.locationOfCheckingDrillingBottom).Value = null;
        //        //OleDbCommand .Parameters.Add("@projectID", SqlDbType.Int).Value = bd.projectID;
        //        //OleDbCommand .Parameters.AddWithValue("@projectIndexation", bd.projectIndexation).Value = null;

        //        //OleDbCommand .Parameters.AddWithValue("@DurationProgram", bd.DurationProgram);
        //        //OleDbCommand .Parameters.AddWithValue("@percentageOfImplementation", bd.percentageOfImplementation).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@DurationProgram", bd.DurationProgram).Value = null;

        //        //OleDbCommand .Parameters.AddWithValue("@percentageOfImplementationDetails", bd.percentageOfImplementationDetails).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@notices", bd.notices).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@contractValue", bd.contractValue).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@FinalClosing", bd.FinalClosing).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@contractValueFile", bd.contractValueFile).Value = null;

        //        //OleDbCommand .Parameters.AddWithValue("@FinalClosingFile", bd.FinalClosingFile).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@lastExactractFile", bd.lastExactractFile).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@Savings", bd.Savings).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@Receipts", bd.Receipts).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@Appropriations", bd.Appropriations).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@SiteOrders", bd.SiteOrders).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@ManagementMails", bd.ManagementMails).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@Netbudget", bd.Netbudget).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@ConstructionSafetyReport", bd.ConstructionSafetyReport).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@ExploitationReductionandCancellationNotes", bd.ExploitationReductionandCancellationNotes).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@LastTimeForEndingProject", bd.LastTimeForEndingProject).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@AddedPeriodToProject", bd.AddedPeriodToProject).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@EndingOfContractorDate", bd.EndingOfContractorDate).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@Total", bd.Total).Value = "";
        //        //OleDbCommand .Parameters.AddWithValue("@ProjectDataTypes", bd.ProjectDataTypes).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@lastExactract", bd.lastExactract).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@Division", bd.Division).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@savingsValue", bd.savingsValue).Value = null;
        //        //OleDbCommand .Parameters.AddWithValue("@projectImages", bd.projectImages);
        //        //percentageOfImplementationAccordingToFinancialStatement
        //        //OleDbCommand .Parameters.AddWithValue("@percentageOfImplementationAccordingToFinancialStatement", bd.percentageOfImplementationAccordingToFinancialStatement).Value = null;

                
                
        //        conn.Open();

        //        int rows = OleDbCommand .ExecuteNonQuery();
        //        if (rows > 0)
        //        {
        //            isSuccess = true;
        //        }
        //        else
        //        {
        //            isSuccess = false;
        //        }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    var st = new StackTrace(ex, true);
        //    //    // Get the top stack frame
        //    //    var frame = st.GetFrame(st.FrameCount - 1);
        //    //    // Get the line number from the stack frame
        //    //    var line = frame.GetFileLineNumber();
        //    //    MessageBox.Show(ex.Message, line.ToString());

        //    //}
        //    //finally
        //    //{

        //        conn.Close();
        //    //}
        //    return isSuccess;
        //}
        //public void Updates(Bui)
        public bool Update(BuildData bd) {
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(myconnecting);
            try
            {
                string sql = "Update BuildsMainTable SET [BuildUnitsFrom]=IIF(IsNull(@BuildUnitsFrom),[BuildUnitsFrom],@BuildUnitsFrom) " +
                    ",[BuildUnitsTo]= IIF(IsNull(@BuildUnitsTo),[BuildUnitsTo],@BuildUnitsTo)" +
                    ",[BuildReport]=IIF(IsNull(@BuildReport),[BuildReport],@BuildReport)" +
                    ",[Image]= IIF(IsNull(@Image),[Image],@Image) " +
                    ",[projectPhrase]= IIF(IsNull(@projectPhrase),[projectPhrase],@projectPhrase)" +
                    ",[periodToImplementProject]= IIF(IsNull(@periodToImplementProject),[periodToImplementProject],@periodToImplementProject)" +
                    ",[projectConsultative]= IIF(IsNull(@projectConsultative),[projectConsultative],@projectConsultative)," +
                    " [projectName]= IIF(IsNull(@projectName),[projectName],@projectName)," +
                    " [projectOwner]=IIF(IsNull(@projectOwner),[projectOwner],@projectOwner)" +
                    ",[startingProjectDate]= IIF(IsNull(@startingProjectDate),[startingProjectDate],@startingProjectDate)" +
                    ",[projectrecordingDate]=IIF(IsNull(@projectrecordingDate),[projectrecordingDate],@projectrecordingDate)" +
                    ",[receiptOfTheSite]=IIF(IsNull(@receiptOfTheSite),[receiptOfTheSite],@receiptOfTheSite)" +
                    ",[projectNotes]=IIF(IsNull(@projectNotes),[projectNotes],@projectNotes)" +
                    ",[notices]=IIF(IsNull(@notices),[notices],@notices)," +
                    "[contractValue]= IIF(IsNull(@contractValue),[contractValue],@contractValue)" +
                    ",[FinalClosing]= IIF(IsNull(@FinalClosing),[FinalClosing],@FinalClosing)" +
                    ",[contractValueFile]=IIF(IsNull(@contractValueFile),[contractValueFile],@contractValueFile)" +
                    ",[FinalClosingFile]=IIF(IsNull(@FinalClosingFile),[FinalClosingFile],@FinalClosingFile)" +
                    ",[lastExactractFile]=IIF(IsNull(@lastExactractFile),[lastExactractFile],@lastExactractFile)" +
                    ",[Savings]=IIF(IsNull(@Savings),[Savings],@Savings)" +
                    ",[Receipts]=IIF(IsNull(@Receipts),[Receipts],@Receipts)" +
                    ",[Appropriations]=IIF(IsNull(@Appropriations),[Appropriations],@Appropriations)," +
                    "[SiteOrders]=IIF(IsNull(@SiteOrders),[SiteOrders],@SiteOrders)" +
                    ",[ManagementMails]=IIF(IsNull(@ManagementMails),[ManagementMails],@ManagementMails)" +
                    ",[Netbudget]=IIF(IsNull(@Netbudget),[Netbudget],@Netbudget)" +
                    ",[ConstructionSafetyReport]=IIF(IsNull(@ConstructionSafetyReport),[ConstructionSafetyReport],@ConstructionSafetyReport)" +
                    ",[exploitationreductionandcancellationnotes]=iif(isnull(@exploitationreductionandcancellationnotes),[exploitationreductionandcancellationnotes],@exploitationreductionandcancellationnotes)" +
                    ",[projectdatatypes]=iif(isnull(@projectdatatypes),[projectdatatypes],@projectdatatypes)," +
                    "[percentageofimplementationaccordingtofinancialstatement]=iif(IsNull(@percentageofimplementationaccordingtofinancialstatement),[percentageofimplementationaccordingtofinancialstatement],@percentageofimplementationaccordingtofinancialstatement)" +
                    ",[lastexactract]=iif(isnull(@lastexactract),[lastexactract],@lastexactract)" +
                    ",[division]=iif(isnull(@division),[division],@division)," +
                    "[percentageOfImplementationAccordingToPhrase]=iif(isnull(@percentageOfImplementationAccordingToPhrase),[percentageOfImplementationAccordingToPhrase],@percentageOfImplementationAccordingToPhrase)" +
                    ",[savingsvalue]=iif(isnull(@savingsvalue),[savingsvalue],@savingsvalue)" +
                     ",[projectImages]=IIF(IsNull(@projectImages), [projectImages], @projectImages)"
                     + ",[TotalDeductionsValues]=IIF(IsNull(@TotalDeductionsValues), [TotalDeductionsValues], @TotalDeductionsValues)" +
                     ",[DurationProgram]=IIF(IsNull(@DurationProgram),[DurationProgram], @DurationProgram)" +
                     ",[PhraseID]=IIF(IsNull(@PhraseID),[PhraseID], @PhraseID)"

                        + " where ContractCode='" + bd.ContractCode + "'";
                
                //percentageOfImplementationAccordingToPhrase
                 OleDbCommand OleDbCommand = new OleDbCommand (sql, conn);
                OleDbCommand.Parameters.AddWithValue("@BuildUnitsFrom", (object)bd.BuildUnitsFrom ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@BuildUnitsTo", (object)bd.BuildUnitsTo ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@BuildReport", (object)bd.BuildReport ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@Image", (object)bd.Image ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@projectPhrase", (object)bd.projectPhrase ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@periodToImplementProject", (object)bd.periodToImplementProject ?? DBNull.Value );
                OleDbCommand.Parameters.AddWithValue("@projectConsultative", (object)bd.projectConsultative ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@projectName", (object)bd.projectName ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@projectOwner", (object)bd.projectOwner ?? DBNull.Value);
                OleDbCommand.Parameters.Add("@startingprojectdate", OleDbType.Date).Value= (object)bd.startingProjectDate ?? DBNull.Value;
                OleDbCommand.Parameters.Add("@projectrecordingDate", OleDbType.Date).Value = (object)bd.projectrecordingDate ?? DBNull.Value;
                OleDbCommand.Parameters.AddWithValue("@receiptOfTheSite", (object)bd.receiptOfTheSite ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@projectNotes", (object)bd.projectNotes ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@notices", (object)bd.notices ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@contractValue", (object)bd.contractValue ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@FinalClosing", (object)bd.FinalClosing ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@contractValueFile", (object)bd.contractValueFile ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@FinalClosingFile", (object)bd.FinalClosingFile ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@lastExactractFile", (object)bd.lastExactractFile ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@Savings", (object)bd.Savings ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@Receipts", (object)bd.Receipts ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@Appropriations", (object)bd.Appropriations ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@SiteOrders", (object)bd.SiteOrders ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@ManagementMails", (object)bd.ManagementMails ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@Netbudget", (object)bd.Netbudget ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@ConstructionSafetyReport", (object)bd.ConstructionSafetyReport ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@ExploitationReductionandCancellationNotes", (object)bd.ExploitationReductionandCancellationNotes ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@ProjectDataTypes", (object)bd.ProjectDataTypes ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@percentageOfImplementationAccordingToFinancialStatement", (object)bd.percentageOfImplementationAccordingToFinancialStatement ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@lastExactract", (object)bd.lastExactract ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@Division", (object)bd.Division ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@savingsValue", (object)bd.savingsValue ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@percentageOfImplementationAccordingToPhrase", (object)bd.percentageOfImplementationAccordingToPhrase ?? DBNull.Value);

                OleDbCommand.Parameters.AddWithValue("@projectImages", (object)bd.projectImages ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@TotalDeductionsValues", (object)bd.TotalDeductionsValues ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@DurationProgram", (object)bd.DurationProgram ?? DBNull.Value);
                OleDbCommand.Parameters.AddWithValue("@PhraseID", (object)bd.PhraseID ?? DBNull.Value);

                //percentageOfImplementationAccordingToPhrase
                //percentageOfImplementationAccordingToFinancialStatement

                //OleDbCommand .Parameters.AddWithValue("@Image", bd.Image);
                conn.Open();
                int rows = OleDbCommand .ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
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
            return isSuccess;
        }
        public bool Delete(BuildData bd)
        {
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(myconnecting);
            try
            {
                string sql = "DELETE FROM BuildsMainTable where ContractCode=@ContractCode";
                OleDbCommand OleDbCommand = new OleDbCommand (sql, conn);
                OleDbCommand.Parameters.AddWithValue("@ContractCode", bd.ContractCode);

                conn.Open();
                int rows = OleDbCommand .ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
    }
}
