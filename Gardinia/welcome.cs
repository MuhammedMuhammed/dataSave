using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gardinia
{
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();
        }
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private void welcome_Load(object sender, EventArgs e)
        {

            timer.Interval = 3000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler(timer_Tick), sender, e);

            }
            else {
                lock (timer) {
                    if (this.timer.Enabled)
                    {
                        this.timer.Stop();
                        this.doMyDelayedWork();
                        //this.timer.Start();
                            }
                        }
            }
        }

        private void doMyDelayedWork()
        {
            this.Hide();
            loginForm lf = new loginForm();
            lf.Show();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
