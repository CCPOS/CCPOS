using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _Till_.Lib.Till
{
    public class PageData
    {
        public System.Windows.Forms.UserControl PageControl;
        public string PageName;
        public bool IsCurrent = false;
    }

    public class PageFuncs
    {
        public static PageData getPageData(System.Windows.Forms.UserControl PageControl, string PageName)
        {
            PageData x = new PageData();
            x.PageControl = PageControl;
            x.PageName = PageName;
            return x;
        }
    }
}
