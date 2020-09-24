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
            Chrome.Idi("https://www.birackispisak.gov.rs/Birac/AdvancedSearch/0");
            Chrome.PopuniElement(jmbg, "filterMenu_FilterBox_0");
            Chrome.ElementSelect("BrzaPretragaFilterType").SelectByValue("1");
            Chrome.Element("filterMenu_submitfilter").Click();
        }

        public static void Zahtevi(string jmbg)
        {
            Chrome.JbsTab();
            Chrome.Idi("https://www.birackispisak.gov.rs/Nalog/ListaNaloga/-1");
            Chrome.PopuniElement(jmbg, "filterMenu_FilterBox_0");
            Chrome.ElementSelect("NalogFilterType").SelectByValue("0");
            Chrome.ElementSelect("VrstaPromene").SelectByValue("-1");
            Chrome.Element("filterMenu_submitfilter").Click();
        }
    }
}
