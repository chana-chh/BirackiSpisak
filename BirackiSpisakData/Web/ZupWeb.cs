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
        public static void TrenutnoPrebivaliste(Mup promena)
        {
            Chrome.EzupTab();
            Chrome.Idi("https://ezup.euprava.gov.rs/GeneratedService/ExecutedServiceCreate/123");
            Chrome.Element("next").Click();
            Chrome.Cekaj("CaseNumber");
            Chrome.PopuniElement(ConfigurationManager.AppSettings["ZupBrojZaTP"] + DateTime.Now.Year, "CaseNumber");
            Chrome.PopuniElement(DateTime.Now.ToShortDateString(), "CaseDate");
            Chrome.PopuniElement(promena.ImeLk, "OnBelhalfOfFirstName");
            Chrome.PopuniElement(promena.PrezimeLk, "OnBelhalfOfLastName");
            Chrome.Element("consent").Click();
            Chrome.Element("#div_AdministrativeProcedureCode > div > a.btn-info", Selector.Css).Click();
            Chrome.Cekaj("mupGetResidenceJmbgEntry1");
            Chrome.PopuniElement(promena.Jmbg, "mupGetResidenceJmbgEntry1");
            Chrome.Element("MupGetResidenceButton1").Click();
        }

        public static void Mkr(Mup promena)
        {
            Chrome.EzupTab();
            Chrome.Idi("https://ezup.euprava.gov.rs/GeneratedService/ExecutedServiceCreate/121");
            Chrome.Element("next").Click();
            Chrome.Cekaj("CaseNumber");
            Chrome.PopuniElement(ConfigurationManager.AppSettings["ZupBrojZaMKR"] + DateTime.Now.Year, "CaseNumber");
            Chrome.PopuniElement(DateTime.Now.ToShortDateString(), "CaseDate");
            Chrome.PopuniElement(promena.ImeLk, "OnBelhalfOfFirstName");
            Chrome.PopuniElement(promena.PrezimeLk, "OnBelhalfOfLastName");
            Chrome.Element("consent").Click();
            Chrome.Element("#div_AdministrativeProcedureCode > div > a.btn-info", Selector.Css).Click();
            Chrome.Cekaj("upmkrJMBG1");
            Chrome.PopuniElement(promena.Jmbg, "upmkrJMBG1");
            Chrome.Element("upmkrButton1").Click();
        }

        public static void Mku(Mup promena)
        {
            Chrome.EzupTab();
            Chrome.Idi("https://ezup.euprava.gov.rs/GeneratedService/ExecutedServiceCreate/120");
            Chrome.Element("next").Click();
            Chrome.Cekaj("CaseNumber");
            Chrome.PopuniElement(ConfigurationManager.AppSettings["ZupBrojZaMKR"] + DateTime.Now.Year, "CaseNumber");
            Chrome.PopuniElement(DateTime.Now.ToShortDateString(), "CaseDate");
            Chrome.PopuniElement(promena.ImeLk, "OnBelhalfOfFirstName");
            Chrome.PopuniElement(promena.PrezimeLk, "OnBelhalfOfLastName");
            Chrome.Element("consent").Click();
            Chrome.Element("#div_AdministrativeProcedureCode > div > a.btn-info", Selector.Css).Click();
            Chrome.Cekaj("upmkuJMBG1");
            Chrome.PopuniElement(promena.Jmbg, "upmkuJMBG1");
            Chrome.Element("upmkuButton1").Click();
        }

        public static void Mkv(Mup promena)
        {
            Chrome.EzupTab();
            Chrome.Idi("https://ezup.euprava.gov.rs/GeneratedService/ExecutedServiceCreate/122");
            Chrome.Element("next").Click();
            Chrome.Cekaj("CaseNumber");
            Chrome.PopuniElement(ConfigurationManager.AppSettings["ZupBrojZaMKR"] + DateTime.Now.Year, "CaseNumber");
            Chrome.PopuniElement(DateTime.Now.ToShortDateString(), "CaseDate");
            Chrome.PopuniElement(promena.ImeLk, "OnBelhalfOfFirstName");
            Chrome.PopuniElement(promena.PrezimeLk, "OnBelhalfOfLastName");
            Chrome.Element("consent").Click();
            Chrome.Element("#div_AdministrativeProcedureCode > div > a.btn-info", Selector.Css).Click();
            Chrome.Cekaj("upmkvJMBG1");
            Chrome.PopuniElement(promena.Jmbg, "upmkvJMBG1");
            Chrome.Element("upmkvButton1").Click();
        }
    }
}
