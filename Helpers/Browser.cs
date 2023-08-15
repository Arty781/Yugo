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
        private static IWebDriver InitDriver { get; set; }
        public static void Initialize()
        {
            AllureHelper.CreateJsonConfigFile();
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--window-size=1920,1020");
            new DriverManager().SetUpDriver(new ChromeConfig());
            InitDriver = new ChromeDriver(options);
            InitDriver.Manage().Cookies.DeleteAllCookies();
            Assert.That(InitDriver, Is.Not.Null);
        }

        public static string RootPath()
        {
            return Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\"));
        }

        public static IWebDriver Driver => InitDriver;
    }
}
