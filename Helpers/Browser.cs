using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
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
    //public class Browser
    //{
    //    private static IWebDriver InitDriver { get; set; }
    //    public static void Initialize()
    //    {
    //        AllureHelper.CreateJsonConfigFile();
    //        var options = new ChromeOptions();
    //        options.AddArgument("--headless");
    //        options.AddArgument("--window-size=1920,1020");
    //        new DriverManager().SetUpDriver(new ChromeConfig());
    //        InitDriver = new ChromeDriver(options);
    //        InitDriver.Manage().Cookies.DeleteAllCookies();
    //        Assert.That(InitDriver, Is.Not.Null);
    //    }

    //    public static string RootPath()
    //    {
    //        return Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\"));
    //    }

    //    public static IWebDriver Driver => InitDriver;
    //}

    public class Browser
    {
        public static IPage page { get; set; }
        private static IBrowserContext browserContext { get; set; }

        public static async Task Initialize()
        {
            var pl = await Playwright.CreateAsync();
            var browser = await pl.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true

            });
            browserContext = await browser.NewContextAsync();
            page = await browserContext.NewPageAsync();
            await Driver.SetViewportSizeAsync(width: 1920, height: 1020);
        }

        public static IPage Driver => page;
        public static IBrowserContext BrowserContext => browserContext;

        public static string RootPath()
        {
            return Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\"));
        }
    }

}
