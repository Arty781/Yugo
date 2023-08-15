using Base_Temlate.Helpers;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yugo.Helpers
{
    public class WaitHelpers
    {
        public static void WaitSomeInterval(int ms = 2000)
        {
            Task.Delay(TimeSpan.FromMilliseconds(ms)).Wait();
        }

        public static void CustomElementIsVisible(IWebElement element, int seconds = 10)
        {
            Task.Delay(TimeSpan.FromMilliseconds(250)).Wait();
            WebDriverWait wait = new(Browser.Driver, TimeSpan.FromSeconds(seconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50),
                Message = $"Element is not visible after {seconds} seconds"
            };
            try
            {
                wait.Until(e =>
                {
                    try
                    {
                        if (element != null && element.Displayed)
                        {
                            return true;
                        }
                        return false;
                    }
                    catch (Exception) { return false; }

                });
            }
            catch (Exception) { }
        }

        public static void CustomElementIsInvisible(IWebElement element, int seconds = 10)
        {
            Task.Delay(TimeSpan.FromMilliseconds(150)).Wait();
            WebDriverWait wait = new(Browser.Driver, TimeSpan.FromSeconds(seconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(100)
            };
            try
            {
                wait.Until(e =>
                {
                    try
                    {
                        if (element != null && element.Enabled)
                        {
                            return false;
                        }
                        return true;
                    }
                    catch (Exception) { return true; }

                });
            }
            catch (NoSuchElementException) { throw new NoSuchElementException(); }
            catch (StaleElementReferenceException) { throw new StaleElementReferenceException(); }

        }
    }
}
