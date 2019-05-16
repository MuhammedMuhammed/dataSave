using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardinia.GardModels
{
    class SandReport
    {
        //SandReportCode,avoirdupois,SandType,reportDate,SandreportContent,Image

        //@SandReportCode, @avoirdupois, @SandType, @reportDate, @SandreportContent, @Image
        public int SandReportCode
        {
            get;
            set;


        }
        public string SandType { get; set; }
        //        public string BuildViewUri { set; get; }
        public Decimal avoirdupois { get; set; }
        public DateTime reportDate { get; set; }
        public string SandreportContent { get; set; }
        public byte[] Image { get; set; }

        static string myconnecting = "Provider=Microsoft.ACE.OleDb.12.0;Data Source="+Directory.GetCurrentDirectory()+"\\ArchDB.accdb;Persist Security Info=false";

        public DataTable Select()
        {
            OleDbConnection conn = new OleDbConnection(myconnecting);
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * From SandReport";
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
        public bool Insert(SandReport sr)
        {
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(myconnecting);
            try
            {   
                string sql = "INSERT INTO SandReport(SandReportCode,avoirdupois,SandType,reportDate,SandreportContent,Image) VALUES (@SandReportCode, @avoirdupois, @SandType, @reportDate, @SandreportContent, @Image)";
                OleDbCommand OleDbCommand = new OleDbCommand (sql, conn);
                OleDbCommand .Parameters.AddWithValue("@SandReportCode", sr.SandReportCode);
                //OleDbCommand .Parameters.AddWithValue("@[BuildViewUri ]", sr.BuildViewUri);
                OleDbCommand .Parameters.AddWithValue("@avoirdupois", sr.avoirdupois);
                OleDbCommand .Parameters.AddWithValue("@SandType", sr.SandType);
                OleDbCommand .Parameters.AddWithValue("@reportDate", sr.reportDate);
                OleDbCommand .Parameters.AddWithValue("@SandreportContent", sr.SandreportContent);
                OleDbCommand .Parameters.AddWithValue("@Image", sr.Image);
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
        public bool Update(SandReport sr)
        {
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(myconnecting);
            //try
            //{
            string sql = "Update SandReport SET avoirdupois=@avoirdupois,SandType=@SandType,reportDate=@reportDate,SandreportContent=@SandreportContent,Image=@Image where SandReportCode=@SandReportCode";
            OleDbCommand OleDbCommand = new OleDbCommand (sql, conn);
            OleDbCommand .Parameters.AddWithValue("@avoirdupois", sr.avoirdupois);
            //OleDbCommand .Parameters.AddWithValue("@BuildViewUri", sr.BuildViewUri);
            OleDbCommand .Parameters.AddWithValue("@SandType", sr.SandType);
            OleDbCommand .Parameters.AddWithValue("@reportDate", sr.reportDate);
            OleDbCommand .Parameters.AddWithValue("@SandreportContent", sr.SandreportContent);
            OleDbCommand .Parameters.AddWithValue("@SandReportCode", sr.SandReportCode);
            OleDbCommand .Parameters.AddWithValue("@Image", sr.Image);
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
            //}
            //catch (Exception ex)
            //{ }
            //finally
            //{
            //  conn.Close();
            //}
            return isSuccess;
        }
        public bool Delete(SandReport sr)
        {
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(myconnecting);
            try
            {
                string sql = "DELETE FROM SandReport where SandReportCode=@SandReportCode";
                OleDbCommand OleDbCommand = new OleDbCommand (sql, conn);
                OleDbCommand .Parameters.AddWithValue("@SandReportCode", sr.SandReportCode);

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
