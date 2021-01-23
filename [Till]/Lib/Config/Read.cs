using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _Till_.Lib.Config
{
    public class Read
    {
        public static List<Entry> GetCfg(string CfgPath)
        {
            if (System.IO.File.Exists(CfgPath))
            {
                List<Entry> cfg = new List<Entry>();

                string[] Entrys = System.IO.File.ReadAllLines(CfgPath);

                foreach (string x in Entrys)
                {
                    if (!x.StartsWith("#"))
                    {
                        Entry buf = new Entry();
                        string[] y = x.Split(':');

                        buf.Name = y[0];
                        buf.Value = y[1];

                        cfg.Add(buf);
                        buf = null;
                    }
                }

                Entrys = null;
                return cfg;
            }

            return new List<Entry>();
        }

        public static void SaveCfg(string CfgPath, List<Entry> Cfg)
        {
            if (System.IO.File.Exists(CfgPath))
            {
                System.IO.File.Delete(CfgPath);
            }

            string outBuf = "# CCPOS Till Config\n";

            foreach (Entry x in Cfg)
            {
                outBuf += string.Format("{0}: {1}\n", x.Name, x.Value);
            }
            outBuf = "# End Of Config";


            System.IO.File.WriteAllText(CfgPath, outBuf);

            outBuf = null;
        }
    }
}
