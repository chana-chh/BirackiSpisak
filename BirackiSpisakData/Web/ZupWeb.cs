using BirackiSpisakDataManager.Helpers;
using BirackiSpisakDataManager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using static BirackiSpisakData.Enums;

namespace BirackiSpisakDataManager.Web
{
    public static class ZupWeb
    {
        public static void TrenutnoPrebivaliste(string jmbg, string ime, string prezime)
        {
            Chrome.EzupTab();
            Chrome.Idi("https://ezup.euprava.gov.rs/GeneratedService/ExecutedServiceCreate/123");
            Chrome.Element("next").Click();
            Chrome.Cekaj("CaseNumber");
            Chrome.PopuniElement(ConfigurationManager.AppSettings["ZupBrojZaTP"] + DateTime.Now.Year, "CaseNumber");
            Chrome.PopuniElement(DateTime.Now.ToShortDateString(), "CaseDate");
            Chrome.PopuniElement(Converter.LatToCyr(ime), "OnBelhalfOfFirstName");
            Chrome.PopuniElement(Converter.LatToCyr(prezime), "OnBelhalfOfLastName");
            Chrome.Element("consent").Click();
            Chrome.Element("#div_AdministrativeProcedureCode > div > a.btn-info", Selector.Css).Click();
            Chrome.Cekaj("mupGetResidenceJmbgEntry1");
            Chrome.PopuniElement(jmbg, "mupGetResidenceJmbgEntry1");
            Chrome.Element("MupGetResidenceButton1").Click();
        }

        public static void Mkr(string jmbg, string ime, string prezime)
        {
            Chrome.EzupTab();
            Chrome.Idi("https://ezup.euprava.gov.rs/GeneratedService/ExecutedServiceCreate/121");
            Chrome.Element("next").Click();
            Chrome.Cekaj("CaseNumber");
            Chrome.PopuniElement(ConfigurationManager.AppSettings["ZupBrojZaMKR"] + DateTime.Now.Year, "CaseNumber");
            Chrome.PopuniElement(DateTime.Now.ToShortDateString(), "CaseDate");
            Chrome.PopuniElement(Converter.LatToCyr(ime), "OnBelhalfOfFirstName");
            Chrome.PopuniElement(Converter.LatToCyr(prezime), "OnBelhalfOfLastName");
            Chrome.Element("consent").Click();
            Chrome.Element("#div_AdministrativeProcedureCode > div > a.btn-info", Selector.Css).Click();
            Chrome.Cekaj("upmkrJMBG1");
            Chrome.PopuniElement(jmbg, "upmkrJMBG1");
            Chrome.Element("upmkrButton1").Click();
        }

        public static void Mku(string jmbg, string ime, string prezime)
        {
            Chrome.EzupTab();
            Chrome.Idi("https://ezup.euprava.gov.rs/GeneratedService/ExecutedServiceCreate/120");
            Chrome.Element("next").Click();
            Chrome.Cekaj("CaseNumber");
            Chrome.PopuniElement(ConfigurationManager.AppSettings["ZupBrojZaMKR"] + DateTime.Now.Year, "CaseNumber");
            Chrome.PopuniElement(DateTime.Now.ToShortDateString(), "CaseDate");
            Chrome.PopuniElement(Converter.LatToCyr(ime), "OnBelhalfOfFirstName");
            Chrome.PopuniElement(Converter.LatToCyr(prezime), "OnBelhalfOfLastName");
            Chrome.Element("consent").Click();
            Chrome.Element("#div_AdministrativeProcedureCode > div > a.btn-info", Selector.Css).Click();
            Chrome.Cekaj("upmkuJMBG");
            Chrome.PopuniElement(jmbg, "upmkuJMBG");
            Chrome.Element("upmkuButton").Click();
        }

        public static void Mkv(string jmbg, string ime, string prezime)
        {
            Chrome.EzupTab();
            Chrome.Idi("https://ezup.euprava.gov.rs/GeneratedService/ExecutedServiceCreate/122");
            Chrome.Element("next").Click();
            Chrome.Cekaj("CaseNumber");
            Chrome.PopuniElement(ConfigurationManager.AppSettings["ZupBrojZaMKR"] + DateTime.Now.Year, "CaseNumber");
            Chrome.PopuniElement(DateTime.Now.ToShortDateString(), "CaseDate");
            Chrome.PopuniElement(Converter.LatToCyr(ime), "OnBelhalfOfFirstName");
            Chrome.PopuniElement(Converter.LatToCyr(prezime), "OnBelhalfOfLastName");
            Chrome.Element("consent").Click();
            Chrome.Element("#div_AdministrativeProcedureCode > div > a.btn-info", Selector.Css).Click();
            Chrome.Cekaj("upmkvJMBG");
            Chrome.PopuniElement(jmbg, "upmkvJMBG");
            Chrome.Element("upmkvButton").Click();
        }

        public static bool UpisiMkrZaPunoletne(Mup promena)
        {
            Chrome.EzupTab();
            var jmbg = Chrome.Element("upmkrJMBG1").GetAttribute("value");
            if (jmbg.Equals(promena.Jmbg))
            {
                var opstina = Chrome.Element("upmkrMunicipality").GetAttribute("value").ToUpper();
                var maticnoPodrucje = Chrome.Element("upmkrParentArea").GetAttribute("value").ToUpper();
                var tekuciBroj = Chrome.Element("upmkrCurrentNumber").GetAttribute("value");
                var godinaUpisa = Chrome.Element("upmkrEnrollmentYear").GetAttribute("value");
                Chrome.JbsTab();
                Chrome.PopuniElement(opstina, "Resenje_ObrazlozenjeGradOpstina");
                Chrome.PopuniElement(maticnoPodrucje, "Resenje_ObrazlozenjeMaticnoPodrucje");
                Chrome.PopuniElement(tekuciBroj, "Resenje_ObrazlozenjeTekuciBroj");
                Chrome.PopuniElement(godinaUpisa, "Resenje_ObrazlozenjeGodina");
            }
            return false;
        }
    }
}
