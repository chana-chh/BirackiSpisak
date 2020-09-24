using BirackiSpisakDataManager.Helpers;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using static BirackiSpisakData.Enums;

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

        public static void PromeniPrebivaliste(string jmbg)
        {
            // navigam na "https://www.birackispisak.gov.rs/Nalog/UnosNalogaPretragaBiraca/7"
            Chrome.Idi("https://www.birackispisak.gov.rs/Nalog/UnosNalogaPretragaBiraca/7");
            // proverim greske class="validation-summary-errors"
            var el = Chrome.Element("validation-summary-errors", Selector.Class);
            if (el == null)
            {
                // ako nema greske cekam id="Nalog_JMBG"
                // mozda nije potrebno
                Chrome.Cekaj("Nalog_JMBG");
                // upisujem jmbg u id="JmbgIliRedniBroj"
                Chrome.PopuniElement(jmbg, "JmbgIliRedniBroj");
                // kliknem class="doc_button  button_search"
                Chrome.Element("button_search", Selector.Class).Click();
            }
        }
    }
}
