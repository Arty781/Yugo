using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

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
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            _ = testStatus == TestStatus.Failed ? TelegramHelper.SendMessage() : null;
            await Browser.Driver.CloseAsync();
            await Browser.BrowserContext.CloseAsync();
        }

    }
}
