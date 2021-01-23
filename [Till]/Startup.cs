using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace _Daemon_
{
    partial class Startup : Form
    {
        public Startup()
        {
            InitializeComponent();
        }

        private void Startup_Load(object sender, EventArgs e)
        {

        }

        public void CloseDialog()
        {
            this.Close();
        }
        public void updateTxt(string Message)
        {
            label1.Text = Message;
            label1.Location = new Point(46, (label1.Width / 2) - (this.Width / 2));
            this.Update();
        }
    }
}
