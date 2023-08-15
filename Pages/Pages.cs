using Base_Temlate.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yugo.Pages.VotePage;

namespace Base_Temlate.PageObjects
{
    public class Pages
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            IWebDriver driver = Browser.Driver;
            PageFactory.InitElements(driver, page);
            return page;
        }

        public static Login Login => GetPage<Login>();
        public static Vote Vote => GetPage<Vote>();

    }
}
