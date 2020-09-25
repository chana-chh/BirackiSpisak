using BirackiSpisakDataManager.Helpers;
using BirackiSpisakDataManager.Models;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        public static void PromeniPrebivaliste(Mup promena)
        {
            Chrome.Idi("https://www.birackispisak.gov.rs/Nalog/UnosNalogaPretragaBiraca/7");
            var el = Chrome.Element("validation-summary-errors", Selector.Class);
            if (el == null)
            {
                Chrome.Cekaj("Nalog_JMBG");
                Chrome.PopuniElement(promena.Jmbg, "JmbgIliRedniBroj");
                Chrome.Element("button_search", Selector.Class).Click();
            }
            UpisiAdresu(promena, true);
        }

        public static void UpisiAdresu(Mup promena, bool podvrsta = false)
        {
            Chrome.Cekaj("Nalog_JMBG");

            var jmbg = Chrome.Element("Nalog_JMBG");

            if (jmbg != null)
            {
                if (podvrsta)
                {
                    Chrome.ElementSelect("Nalog_PodVrstaPromeneID").SelectByValue("1"); // podvrsta promene "izmena"
                }

                Chrome.PopuniElement(Converter.LatToCyr(promena.MestoLk), "Nalog_PrebivalisteNaselje");
                Chrome.PopuniElement(Converter.LatToCyr(promena.UlicaLk), "Nalog_PrebivalisteUlica");

                if (promena.BrojLk.Equals("BB") || promena.BrojLk.Equals("ББ"))
                {
                    promena.BrojLk = "0";
                }

                Chrome.PopuniElement((promena.BrojLk.Equals("0")) ? "0" : promena.BrojLk.TrimStart('0'), "Nalog_PrebivalisteKucniBrojBrojcaniDeo");
                Chrome.PopuniElement(Converter.LatToCyr(promena.DodatakBrojuLk), "Nalog_PrebivalisteKucniBrojZnakovniDeo");
                Chrome.PopuniElement("", "Nalog_PrebivalisteUlaz");
                Chrome.PopuniElement("", "Nalog_PrebivalisteSprat");
                Chrome.PopuniElement("", "Nalog_PrebivalisteStan");
            }
        }

        public static void PopuniOvlascenje()
        {
            Chrome.PopuniElement(ConfigurationManager.AppSettings["BrojOvlascenja"], "Resenje_OvlascenjeBroj");
            Chrome.PopuniElement(ConfigurationManager.AppSettings["DanOvlascenja"], "Resenje_OvlascenjeDatum_Day");
            Chrome.PopuniElement(ConfigurationManager.AppSettings["MesecOvlascenja"], "Resenje_OvlascenjeDatum_Month");
            Chrome.PopuniElement(ConfigurationManager.AppSettings["GodinaOvlascenja"], "Resenje_OvlascenjeDatum_Year");
        }

        public static void PopuniResenje(Mup promena)
        {
            string datum = promena.DatumFajla.Value.ToShortDateString();
            string d = datum.Substring(0, 2);
            string m = datum.Substring(3, 2);
            string g = datum.Substring(6, 4);

            Chrome.PopuniElement("МУП СРБИЈЕ", "Resenje_ObrazlozenjeMUP");
            Chrome.PopuniElement("/", "Resenje_ObrazlozenjeBrojAktaMUP");
            Chrome.PopuniElement(d, "Resenje_ObrazlozenjeDatumAktaMUP_Day");
            Chrome.PopuniElement(m, "Resenje_ObrazlozenjeDatumAktaMUP_Month");
            Chrome.PopuniElement(g, "Resenje_ObrazlozenjeDatumAktaMUP_Year");
        }

        public static void UpisiPrebivaliste(Mup promena)
        {
            Chrome.Idi("https://www.birackispisak.gov.rs/Nalog/UnosNalogaPretragaBiraca/2");
            var el = Chrome.Element("validation-summary-errors", Selector.Class);
            if (el == null)
            {
                Chrome.Cekaj("Nalog_JMBG");
                Chrome.PopuniElement(promena.Jmbg, "JmbgIliRedniBroj");
                Chrome.Element("button_search", Selector.Class).Click();
            }
            UpisiAdresu(promena);
        }
    }
}
