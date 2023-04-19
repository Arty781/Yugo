using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Base_Temlate.Helpers
{
    public class Browser
    {
        private static IWebDriver _driver { get; set; }
        public static void Initialize()
        {
            AllureHelper.CreateJsonConfigFile();
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _driver.Manage().Cookies.DeleteAllCookies();
            Assert.That(_driver, Is.Not.Null);
        }

        public static string RootPath()
        {
            string rootPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\"));
            return rootPath;
        }

        public static ISearchContext Driver => _driver;
        public static IWebDriver _Driver => _driver;
    }
}
