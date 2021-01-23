using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace _Till_
{
    static class Program
    {
        public static List<Lib.Products.Entry> ProductsDB;
        public static Lib.TillMode ModeOfOp;
        public static List<Lib.Config.Entry> Config;
        public static Lib.Language.LangPack LanguagePack;

        public static int Height;
        public static int Width;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Config = Lib.Config.Read.GetCfg(AppDomain.CurrentDomain.BaseDirectory + "/config.data");

            Lib.Language.LangFuncs.LoadLanguagePack(CultureInfo.CurrentCulture.Name);

            if (!LanguagePack.Loaded)
            {
                Lib.Language.LangFuncs.LoadLanguagePack("en-GB");
                if (!LanguagePack.Loaded)
                {
                    MessageBox.Show("Could not Load Language Pack " + CultureInfo.CurrentCulture.Name + " then I tryed to default to en-GB, couldent so exiting, langauge package missing.", "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    goto RunTill;
                }
            }
            else
            {
                goto RunTill;
            }
            Application.Exit();

        RunTill:
            {
                if (Config.Count == 0)
                {

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainWindow());
                }
                else
                {
                    if (!SetupConfig())
                    {
                        MessageBox.Show("Could not setup configuration, maybe permissions or you didnt close the setup correctly!, Im gunna close, I suggest you restart configuration to use this software!", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Application.Exit();
                }
            }
        }

        static bool SetupConfig()
        {
            Setup setup = new Setup();
            bool done = false;
            DialogResult x = setup.ShowDialog();
            if (x == DialogResult.None || x == DialogResult.Cancel)
            {
                done = false;
            }
            else if (x == DialogResult.OK)
            {
                done = true;
            }
            setup = null;
            return done;
        }
    }
}
