using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _Till_
{
    public partial class MainWindow : Form
    {
        private List<Lib.Till.PageData> Pages;


        public MainWindow()
        {
            InitializeComponent();

            Pages = new List<Lib.Till.PageData>();
            Pages.Add(Lib.Till.PageFuncs.getPageData(new Panels.Till.Convenience.TillMain(), "Till"));
            Pages.Add(Lib.Till.PageFuncs.getPageData(new Panels.Till.Convenience.Reports(), "Reports"));
            Pages.Add(Lib.Till.PageFuncs.getPageData(new Panels.Till.Convenience.StockManager(), "Stock Management"));
            Pages.Add(Lib.Till.PageFuncs.getPageData(new Panels.Till.SystemPage(this), "System"));

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            // Sort out maximised screen labels.
            label1.Location = new Point(8, 8);
            label2.Location = new Point((this.Width - label2.Width) - 8, 8);

            // Sort out panel size;
            panel1.Location = new Point(4, 34);
            panel1.Width = (this.Width - 8);
            panel1.Height = (this.Height - 34);
            this.Update();
            _Till_.Program.Width = this.panel1.Width;
            _Till_.Program.Height = this.panel1.Height;
            Pages[0].IsCurrent = true;
            this.LoadPage(Pages[0].PageControl);
            this.updateMainTitle(Pages[0].PageName);
            label1.Visible = false;
            if (Pages.Count == 1)
            {
                label2.Visible = false;
            }
        }

        public void LoadPage(System.Windows.Forms.UserControl ControlIn)
        {
            ControlIn.Width = _Till_.Program.Width;
            ControlIn.Height = panel1.Height;
            panel1.Controls.Clear();
            panel1.Controls.Add(ControlIn);
            panel1.Update();
        }

        public void updateMainTitle(string Text)
        {
            label3.Text = Text;
            label3.Location = new Point(((this.Width / 2) - (label3.Width / 2)), 8);
        }

        public void CloseDown()
        {
            this.Close();
        }

        private int getCurrentPage()
        {
            for (int i = 0; i < Pages.Count; i++)
            {
                if (Pages[i].IsCurrent)
                {
                    return i;
                }
            }
            return 0;
        }
        private void label2_Click(object sender, EventArgs e)
        {
            int x = this.getCurrentPage();

            if ((x + 1) <= (Pages.Count - 1))
            {
                Pages[x].IsCurrent = false;
                Pages[x + 1].IsCurrent = true;
                this.LoadPage(Pages[x + 1].PageControl);
                this.updateMainTitle(Pages[x + 1].PageName);
                if ((x + 1) >= (Pages.Count - 1))
                {
                    label2.Visible = false;
                }
                else
                {
                    label2.Visible = true;
                }

                label1.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            int x = this.getCurrentPage();

            if ((x - 1) >= 0)
            {
                Pages[x].IsCurrent = false;
                Pages[x - 1].IsCurrent = true;
                this.LoadPage(Pages[x - 1].PageControl);
                this.updateMainTitle(Pages[x - 1].PageName);
                if ((x - 1) <= 0)
                {
                    label1.Visible = false;
                }
                else
                {
                    label1.Visible = true;
                }

                label2.Visible = true;
            }
        }
    }
}
