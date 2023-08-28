using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace Base_Temlate.Helpers
{
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
