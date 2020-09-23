using BirackiSpisakDataManager.Helpers;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirackiSpisakDataManager.Web
{
    public static class JbsMup
    {
        public static void OtvoriChrome()
        {
            Chrome.OtvoriJBSiZUP();
        }

        public static bool PripremiChrome()
        {
            if (Chrome.ImaDvaTaba())
            {
                Chrome.OdrediEZupHandle();
                return true;
            }
            return false;
        }

        public static void ZatvoriChrome()
        {
            Chrome.Zatvori();
        }

        public static void Zup()
        {
            Chrome.EzupTab();
        }

        public static void Jbs()
        {
            Chrome.JbsTab();
        }

        public static void Jmbg(string jmbg)
        {
            Chrome.JbsTab();
            Chrome.Idi("https://www.birackispisak.gov.rs/Birac/ListaBiraca");
            var el = Chrome.Element("filterMenu_FilterBox_0");
            el.Clear();
            el.SendKeys(jmbg);
            Chrome.ElementSelect("BrzaPretragaFilterType").SelectByValue("1");
            Chrome.Element("filterMenu_submitfilter").Click();
        }
    }
}
