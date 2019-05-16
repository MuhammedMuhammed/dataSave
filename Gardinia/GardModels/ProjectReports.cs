using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gardinia.GardModels
{
    class ProjectReports
    {
        public string projectIndexation
        {
            get;
            set;


        }
        //public string implementerCompany { get; set;}
        //        public string BuildViewUri { set; get; }
        public string dustReport { get; set; }
        public DateTime recordingdateOnDB { get; set; }
        public string receiptOfTheSite { get; set; }
        public string projectName { get; set; }
        public byte[] Image { get; set; }
        public string locationOfCheckingDrillingBottom { get; set; }
        public string ContractCode { get; set; }

        //public string owner { get; set; }
        static string myconnecting = "Provider=Microsoft.ACE.OleDb.12.0;Data Source="+Directory.GetCurrentDirectory()+"\\ArchDB.accdb;Persist Security Info=false";

        public DataTable Select()
        {
            OleDbConnection conn = new OleDbConnection(myconnecting);
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * From ProjectReports";
                OleDbCommand sqlcmd = new OleDbCommand (sql, conn);
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
        public bool Insert(ProjectReports bd)
        {
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(myconnecting);
            try
            {
                string sql = "INSERT INTO ProjectReports( dustReport,recordingdateOnDB,ContractCode) VALUES (@dustReport,@recordingdateOnDB,@ContractCode)";
                OleDbCommand OleDbCommand = new OleDbCommand (sql, conn);
                //OleDbCommand .Parameters.AddWithValue("@implementerCompany", bd.implementerCompany);
                OleDbCommand .Parameters.AddWithValue("@recordingdateOnDB", bd.recordingdateOnDB);
                OleDbCommand .Parameters.AddWithValue("@dustReport", bd.dustReport);
                OleDbCommand .Parameters.AddWithValue("@projectName", bd.projectName);
               
                OleDbCommand .Parameters.AddWithValue("@ContractCode", bd.ContractCode);

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
        //public bool Update(ProjectReports bd)
        //{
        //    bool isSuccess = false;
        //    OleDbConnection conn = new OleDbConnection(myconnecting);
        //    //try
        //    //{
        //    string sql = "Update ProjectReports SET ContractCode=IsNull(@ContractCode,ContractCode),dustReport=IsNull(@dustReport,dustReport), receiptOfTheSite=IsNull(@receiptOfTheSite,receiptOfTheSite), projectName=IsNull(@projectName,projectName) where projectIndexation=@projectIndexation";
        //    OleDbCommand OleDbCommand = new OleDbCommand (sql, conn);
        //    //OleDbCommand .Parameters.AddWithValue("@implementerCompany", bd.implementerCompany);
        //    //OleDbCommand .Parameters.AddWithValue("@BuildViewUri", bd.BuildViewUri);
        //    OleDbCommand .Parameters.AddWithValue("@ContractCode", bd.ContractCode);

        //    OleDbCommand .Parameters.AddWithValue("@dustReport", bd.dustReport);
        //    //OleDbCommand .Parameters.AddWithValue("@contractualDate", bd.contractualDate);
        //    OleDbCommand .Parameters.AddWithValue("@projectName", bd.projectName);
            
        //    //OleDbCommand .Parameters.AddWithValue("@Image", bd.Image);
        //    conn.Open();
        //    int rows = OleDbCommand .ExecuteNonQuery();
        //    if (rows > 0)
        //    {
        //        isSuccess = true;
        //    }
        //    else
        //    {
        //        isSuccess = false;
        //    }
        //    //}
        //    //catch (Exception ex)
        //    //{ }
        //    //finally
        //    //{
        //    //  conn.Close();
        //    //}
        //    return isSuccess;
        //}
        public bool Delete(ProjectReports bd)
        {
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(myconnecting);
            try
            {
                string sql = "DELETE FROM ProjectReports where recordingdateOnDB=@recordingdateOnDB";
                OleDbCommand OleDbCommand = new OleDbCommand (sql, conn);
                OleDbCommand .Parameters.AddWithValue("@recordingdateOnDB", bd.recordingdateOnDB);

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
            { }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
    }
}
