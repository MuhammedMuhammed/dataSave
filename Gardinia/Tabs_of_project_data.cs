using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;
namespace Gardinia
{
    public partial class Tabs_of_project_data : TitleBarTabs
    {
        public Tabs_of_project_data()
        {
            InitializeComponent();
            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
        }

        public override TitleBarTab CreateTab()
        {
            return new TitleBarTab(this)
            {
                Content = new ImageMap
                (
                    Text = "NewTab"
                )
            };
}

        private void Tabs_of_project_data_Load(object sender, EventArgs e)
        {

        }
    }
}
