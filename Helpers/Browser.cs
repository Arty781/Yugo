using Microsoft.Playwright;

namespace Base_Temlate.Helpers
{

    public class Browser
    {
        public static IPage page { get; set; }
        private static IBrowserContext browserContext { get; set; }

        public static async Task Initialize()
        {
            var pl = await Playwright.CreateAsync();
            var browser = await pl.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false

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
