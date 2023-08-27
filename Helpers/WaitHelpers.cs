using Base_Temlate.Helpers;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Yugo.Helpers
{
    public class WaitHelpers
    {
        public static async Task WaitSomeInterval(int ms = 2000)
        {
            await Browser.Driver.WaitForTimeoutAsync(ms);
        }

        public static async Task CustomElementIsVisible(string element, int milliSeconds = 10000)
        {
            await Browser.Driver.WaitForTimeoutAsync(250);
            PageWaitForSelectorOptions waitOptions = new()
            {
                Timeout = milliSeconds,
                State = WaitForSelectorState.Attached
            };
            await Browser.Driver.WaitForSelectorAsync(element, waitOptions);
        }

        public static async Task CustomElementIsInvisible(string element, int milliSeconds = 10000)
        {
            await Browser.Driver.WaitForTimeoutAsync(250);
            PageWaitForSelectorOptions waitOptions = new()
            {
                Timeout = milliSeconds,
                State = WaitForSelectorState.Detached
            };
            await Browser.Driver.WaitForSelectorAsync(element, waitOptions);

        }
    }
}
