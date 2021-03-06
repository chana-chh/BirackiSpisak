﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.Linq;
using static BirackiSpisakData.Enums;

namespace BirackiSpisakDataManager.Helpers
{
    public static class Chrome
    {
        private static IWebDriver _driver;

        private static int _wait = 10000;

        private static string _eZupHandle;
        private static string _jbsHandle;

        public static void Idi(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public static IWebDriver Drajver() {
            return _driver;
        }

        private static void Init()
        {
            _driver = _driver = new ChromeDriver();
        }

        public static void OtvoriJBSiZUP()
        {
            Init();
            PodesiProzor();
            Idi("https://euprava.gov.rs");
            _eZupHandle = _driver.CurrentWindowHandle;
            _driver.ExecuteJavaScript("window.open('https://www.birackispisak.gov.rs/')");
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            _jbsHandle = _driver.CurrentWindowHandle;
        }

        public static string TrenutnaAdresa()
        {
            return _driver.Url;
        }

        public static void OdrediEZupHandle()
        {
            if (ImaDvaTaba())
            {
                foreach (var h in _driver.WindowHandles)
                {
                    if (!_jbsHandle.Equals(h))
                    {
                        _eZupHandle = h;
                    }
                }
            }
        }

        public static bool ImaDvaTaba()
        {
            if (_driver.WindowHandles.Count == 2)
            {
                return true;
            }
            return false;
        }

        public static void PodesiProzor()
        {
            _driver.Manage().Window.Size = new Size(1270, 1040);
            _driver.Manage().Window.Position = new Point(650, 0);
        }

        public static void EzupTab()
        {
            _driver.SwitchTo().Window(_eZupHandle);
        }

        public static void JbsTab()
        {
            _driver.SwitchTo().Window(_jbsHandle);
        }

        public static void Cekaj(string value, Selector sel = Selector.Id)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(_wait));

            var el = Element(value, sel);

            if (el != null)
            {
                w.Until(d => el.Displayed);
            }
        }

        public static IWebElement Element(string value, Selector sel = Selector.Id)
        {
            IWebElement el;
            try
            {
                switch (sel)
                {
                    case Selector.Id:
                        el = _driver.FindElement(By.Id(value));
                        break;
                    case Selector.Class:
                        el = _driver.FindElement(By.ClassName(value));
                        break;
                    case Selector.Css:
                        el = _driver.FindElement(By.CssSelector(value));
                        break;
                    case Selector.Name:
                        el = _driver.FindElement(By.Name(value));
                        break;
                    default:
                        el = null;
                        break;
                }
            }
            catch (NoSuchElementException)
            {

                el = null;
            }

            return el;
        }

        public static void PopuniElement(string value, string css, Selector sel = Selector.Id)
        {
            IWebElement el = Element(css, sel);
            el.Clear();
            el.SendKeys(value);
        }

        public static SelectElement ElementSelect(string value, Selector sel = Selector.Id)
        {
            var el = Element(value, sel);
            if (el != null)
            {
                return new SelectElement(el);
            }
            return null;
        }


        public static void Zatvori()
        {
            if (_driver != null)
            {
                _driver.Quit();
            }
        }
    }
}
