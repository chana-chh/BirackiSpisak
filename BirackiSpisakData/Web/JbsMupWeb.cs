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
    public static class JbsMupWeb
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

        public static void UpisiAdresu(Mup promena, bool podvrsta = false)
        {
            Chrome.JbsTab();
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

        public static void UpisiLicnePodatke(Mup promena, bool podvrsta = false, bool upisiJmbg = false)
        {
            Chrome.JbsTab();
            Chrome.Cekaj("Nalog_JMBG");
            var jmbg = Chrome.Element("Nalog_JMBG");
            if (jmbg != null)
            {
                var muski = Chrome.Element("Nalog.Pol_True");
                var zenski = Chrome.Element("Nalog.Pol_False");
                string datumRodjenja = promena.DatumRodjenja.Value.ToShortDateString();
                string d = datumRodjenja.Substring(0, 2);
                string m = datumRodjenja.Substring(3, 2);
                string g = datumRodjenja.Substring(6, 4);
                bool pol = promena.Pol.Equals("M") ? true : false;
                string mr = (String.IsNullOrEmpty(promena.MestoRodjenja))
                            ? $"{Converter.LatToCyr(promena.DrzavaRodjenja)}, {Converter.LatToCyr(promena.StranoMestoRodjenja)}"
                            : Converter.LatToCyr(promena.MestoRodjenja);
                if (podvrsta)
                {
                    Chrome.ElementSelect("Nalog_PodVrstaPromeneID").SelectByValue("1"); // podvrsta promene "izmena"
                }
                if (upisiJmbg)
                {
                    Chrome.PopuniElement(promena.Jmbg, "Nalog_JMBG");
                }
                Chrome.PopuniElement(Converter.LatToCyr(promena.Prezime), "Nalog_Prezime");
                Chrome.PopuniElement(Converter.LatToCyr(promena.Ime), "Nalog_Ime");
                Chrome.PopuniElement(Converter.LatToCyr(promena.ImeRoditelja), "Nalog_ImeRoditelja");
                Chrome.PopuniElement(d, "Nalog_DatumRodjenja_Day");
                Chrome.PopuniElement(m, "Nalog_DatumRodjenja_Month");
                Chrome.PopuniElement(g, "Nalog_DatumRodjenja_Year");
                Chrome.PopuniElement(mr, "Nalog_MestoRodjenja");
                if (pol)
                {
                    muski.Click();
                }
                else
                {
                    zenski.Click();
                }
            }
        }

        public static void PopuniOvlascenje()
        {
            Chrome.JbsTab();
            Chrome.PopuniElement(ConfigurationManager.AppSettings["BrojOvlascenja"], "Resenje_OvlascenjeBroj");
            Chrome.PopuniElement(ConfigurationManager.AppSettings["DanOvlascenja"], "Resenje_OvlascenjeDatum_Day");
            Chrome.PopuniElement(ConfigurationManager.AppSettings["MesecOvlascenja"], "Resenje_OvlascenjeDatum_Month");
            Chrome.PopuniElement(ConfigurationManager.AppSettings["GodinaOvlascenja"], "Resenje_OvlascenjeDatum_Year");
        }

        public static void PopuniResenje(Mup promena)
        {
            Chrome.JbsTab();
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

        private static void PopuniJmbg(Mup promena)
        {
            Chrome.JbsTab();
            var el = Chrome.Element("validation-summary-errors", Selector.Class);
            if (el == null)
            {
                Chrome.Cekaj("Nalog_JMBG");
                Chrome.PopuniElement(promena.Jmbg, "JmbgIliRedniBroj");
                Chrome.Element("button_search", Selector.Class).Click();
            }
        }

        public static void UpisiPrebivaliste(Mup promena)
        {
            Chrome.JbsTab();
            Chrome.Idi("https://www.birackispisak.gov.rs/Nalog/UnosNalogaPretragaBiraca/2");
            PopuniJmbg(promena);
            var prezime = Chrome.Element("Nalog_Prezime");
            if (prezime.GetAttribute("value").Trim().Equals(""))
            {
                UpisiLicnePodatke(promena);
            }
            UpisiAdresu(promena);
        }

        public static void PromeniPrebivaliste(Mup promena)
        {
            Chrome.JbsTab();
            Chrome.Idi("https://www.birackispisak.gov.rs/Nalog/UnosNalogaPretragaBiraca/7");
            PopuniJmbg(promena);
            UpisiAdresu(promena, true);
        }

        public static void UpisiPunoletnoLice(Mup promena)
        {
            Chrome.JbsTab();
            Chrome.Idi("https://www.birackispisak.gov.rs/Nalog/UnosNaloga/1");
            UpisiLicnePodatke(promena, false, true);
            UpisiAdresu(promena, true);
        }

        public static void PromeniLicnePodatke(Mup promena)
        {
            Chrome.JbsTab();
            Chrome.Idi("https://www.birackispisak.gov.rs/Nalog/UnosNalogaPretragaBiraca/6");
            PopuniJmbg(promena);
            UpisiLicnePodatke(promena, true);
        }

        public static void OdjaviPrebivaliste(Mup promena)
        {
            Chrome.JbsTab();
            Chrome.Idi("https://www.birackispisak.gov.rs/Nalog/UnosNalogaPretragaBiraca/13");
            PopuniJmbg(promena);
        }

        public static void OdjaviPrebivalisteSluzbeno(Mup promena)
        {
            Chrome.JbsTab();
            Chrome.Idi("https://www.birackispisak.gov.rs/Nalog/UnosNalogaPretragaBiraca/32");
            PopuniJmbg(promena);
        }
    }
}
