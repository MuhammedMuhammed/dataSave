using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gardinia
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string CommonDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            //FileInfo file = new FileInfo("script.sql");
            //string SQLscript = file.OpenText().ReadToEnd();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try { 
            Application.Run(new welcome());
            }
            catch (Exception ex) {
            }
        }
        //الثانية
    }
}
