using Microsoft.Playwright.NUnit;
using NUnit.Allure.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Temlate.Helpers
{
    [AllureNUnit]
    public class BaseWeb : PlaywrightTest
    {

        [SetUp]
        public async Task SetUp()
        {
            await Browser.Initialize();
            await Browser.Driver.GotoAsync(Endpoints.BASE_URL);
        }

        [TearDown]
        public async Task TearDown()
        {
            await Browser.Driver.CloseAsync();
            await Browser.BrowserContext.CloseAsync();
        }

    }
}
