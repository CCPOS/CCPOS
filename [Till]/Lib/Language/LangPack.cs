using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _Till_.Lib.Language
{
    public class LangPack
    {
        public string PackName = "";
        public List<Entry> Definitions = new List<Entry>();
        public bool Loaded = false;
    }

    public class LangFuncs
    {
        public static bool LoadLanguagePack(string Name) {
            LangPack x = new LangPack();

            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/langs/" + Name + ".lang"))
            {
                x.PackName = Name;
                x.Definitions = GetLangPack(AppDomain.CurrentDomain.BaseDirectory + "/langs/" + Name + ".lang");
                x.Loaded = true;
                _Till_.Program.LanguagePack = x;
                x = null;
                return true;
            }
            return false;
        }
        public static List<Entry> GetLangPack(string Path)
        {
            if (System.IO.File.Exists(Path))
            {
                List<Entry> defs = new List<Entry>();

                string[] Entrys = System.IO.File.ReadAllLines(Path);

                foreach (string x in Entrys)
                {
                    if (!x.StartsWith("#"))
                    {
                        Entry buf = new Entry();
                        string[] y = x.Split(':');

                        buf.Name = y[0];
                        if (y[1].Substring(0, 1) == " ")
                        {
                            buf.Text = y[1].Substring(1, y[1].Length - 1);
                        }
                        else
                        {
                            buf.Text = y[1];
                        }

                        defs.Add(buf);
                        buf = null;
                    }
                }

                Entrys = null;
                return defs;
            }

            return new List<Entry>();
        }
        public static string GetLangDef(string DefName)
        {
            if (_Till_.Program.LanguagePack.Definitions.Count > 0)
            {
                foreach (Entry x in _Till_.Program.LanguagePack.Definitions)
                {
                    if (x.Name == DefName)
                    {
                        return x.Text;
                    }
                }
            }
            return "Undefined";
        }
    }
}
