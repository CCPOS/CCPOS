using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _Till_.Panels.Till.Convenience
{
    public partial class TillMain : UserControl
    {
        public TillMain()
        {
            InitializeComponent();
            timeUpdateer.WorkerReportsProgress = true;
            timeUpdateer.WorkerSupportsCancellation = true;
            if (timeUpdateer.IsBusy != true)
            {
                timeUpdateer.RunWorkerAsync();
            }
            
        }

        private void timeUpdateer_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (true)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(1);
                    worker.ReportProgress(1);
                }
            }
        }

        private void timeUpdateer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label1.Text = string.Format("{0} - {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
        }

        private void timeUpdateer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                label1.Text = "GoodBye :)";
            }
            else if (e.Error != null)
            {
                label1.Text = "Error: " + e.Error.Message;
            }
            else
            {
                label1.Text = "GoodBye :)";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "00";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 1)
            {
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void TillMain_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            this.label1.Location = new Point(panel1.Width + 4, this.Height - this.label1.Height);
            this.Update();
        }
    }
}