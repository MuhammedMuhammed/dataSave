using ExcelDataReader;


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gardinia
{
    public partial class Excel : Form
    {
        DataSet result;
        public Excel(string text)
        {
            InitializeComponent();

            FileStream fileStream = File.Open(text, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelDataReader = ExcelReaderFactory.CreateReader(fileStream);
            //excelDataReader.IsFirstRowAsColumnNames = true;
            result = excelDataReader.AsDataSet();
            metroComboBox1.Items.Clear();
            foreach (DataTable dt in result.Tables)
            {
                metroComboBox1.Items.Add(dt.TableName);
                excelDataReader.Close();
            }
        }

        private void Excel_Load(object sender, EventArgs e)
        {

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroGrid1.DataSource = result.Tables[metroComboBox1.SelectedIndex];
        }
    }
}
