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
    class RecordTable
    { 
       
        public int recordNum
        {
            get;
            set;
            
            
        }
        public string recordWriter { get; set;}
//        public string BuildViewUri { set; get; }
        public string recordContent { get; set; }
        public DateTime recordDate { get; set; }
        public byte[] SandReportFile { get; set; }

        //Data Source = MSSQLSERVER; Initial Catalog="+Directory.GetCurrentDirectory()+"/GARDINIATABLES.MDF;Initial Catalog = GardiniaTables; Integrated Security = True"
        static string myconnecting = "Provider=Microsoft.ACE.OleDb.12.0;Data Source="+Directory.GetCurrentDirectory()+"\\ArchDB.accdb;Persist Security Info=false";
            
        public DataTable Select() {
            OleDbConnection conn = new OleDbConnection(myconnecting);
            DataTable dt = new DataTable();
            try
            {
                
                string sql = "select * From RecordTable";
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
        public bool Insert(RecordTable rt) {
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(myconnecting);
            try
            {
                string sql = "INSERT INTO RecordTable(recordWriter, recordContent, recordDate, SandReportFile) VALUES (@recordWriter, @recordContent, @recordDate, @SandReportFile)";
                OleDbCommand OleDbCommand = new OleDbCommand (sql, conn);
                OleDbCommand .Parameters.AddWithValue("@recordWriter", rt.recordWriter);
                //OleDbCommand .Parameters.AddWithValue("@[BuildViewUri ]", rt.BuildViewUri);
                OleDbCommand .Parameters.AddWithValue("@recordContent", rt.recordContent);
                OleDbCommand .Parameters.AddWithValue("@recordDate", rt.recordDate);
                OleDbCommand .Parameters.AddWithValue("@SandReportFile", rt.SandReportFile);
               
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
        public bool Update(RecordTable rt) {
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(myconnecting);
            //try
            //{
                string sql = "Update RecordTable SET recordWriter=@recordWriter, recordContent=@recordContent, recordDate=@recordDate, SandReportFile=@SandReportFile where recordNum=@recordNum";
                OleDbCommand OleDbCommand = new OleDbCommand (sql, conn);
                OleDbCommand .Parameters.AddWithValue("@recordWriter", rt.recordWriter);
                //OleDbCommand .Parameters.AddWithValue("@BuildViewUri", rt.BuildViewUri);
                OleDbCommand .Parameters.AddWithValue("@recordContent", rt.recordContent);
                OleDbCommand .Parameters.AddWithValue("@recordDate", rt.recordDate);
                OleDbCommand .Parameters.AddWithValue("@recordNum", rt.recordNum);
                OleDbCommand .Parameters.AddWithValue("@recordImage", rt.SandReportFile);
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
        public bool Delete(RecordTable rt)
        {
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(myconnecting);
            try
            {
                string sql = "DELETE FROM RecordTable where recordNum=@recordNum";
                OleDbCommand OleDbCommand = new OleDbCommand (sql, conn);
                OleDbCommand .Parameters.AddWithValue("@recordNum", rt.recordNum);

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
