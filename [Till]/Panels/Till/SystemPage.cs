using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _Till_.Panels.Till
{
    public partial class SystemPage : UserControl
    {
        private MainWindow windata;
        public SystemPage(MainWindow window)
        {
            InitializeComponent();
            windata = window;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            windata.CloseDown();
        }
    }
}
