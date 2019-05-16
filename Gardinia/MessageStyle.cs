using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gardinia
{
    public partial class MessageStyle : UserControl
    {
        string messagetxt;
        Bitmap resourcefile;
        private DialogResult DialogResult;
       public string[] YesNo(string yes, string no) {
            no = "no";
            yes = "yes";
            string[] array = { yes, no };
             
            return array;
        }
       
        public MessageStyle(string messageTxt,Bitmap resourcefile)
        {
            InitializeComponent();
            this.messagetxt = messageTxt;
            this.resourcefile = resourcefile;
            
        }

        private void MessageStyle_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
