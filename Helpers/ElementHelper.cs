using Base_Temlate.Helpers;
using Base_Temlate.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yugo.Helpers
{
    public class Button
    {
        public static void Click(IWebElement element)
        {
            WaitHelpers.WaitSomeInterval(300);
            WebDriverWait wait = new WebDriverWait(Browser._Driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50)
            };
            try
            {
                wait.Until(e =>
                {
                    try
                    {
                        if (element != null && element.Enabled)
                        {
                            return true;
                        }
                        return false;
                    }
                    catch (Exception) { return false; }

                });
                element.Click();
                WaitHelpers.WaitSomeInterval(350);
            }
            catch (Exception) { }

        }

        public static void ClickJS(IWebElement element)
        {
            WaitHelpers.WaitSomeInterval();
            IJavaScriptExecutor ex = (IJavaScriptExecutor)Browser._Driver;
            ex.ExecuteScript("arguments[0].click();", element);
        }



    }
    public class InputBox
    {
        public static IWebElement Element(IWebElement element, int seconds, string data)
        {
            WaitHelpers.WaitSomeInterval(250);
            WaitHelpers.CustomElementIsVisible(element, seconds);
            element.SendKeys(Keyss.Control() + "A" + Keys.Delete);
            WaitHelpers.WaitSomeInterval(250);
            element.SendKeys(data);

            return element;
        }

        public static IWebElement ElementImage(IWebElement element, int seconds, string data)
        {
            WaitHelpers.CustomElementIsVisible(element, seconds);
            WaitHelpers.WaitSomeInterval(250);
            element.SendKeys(data);

            return element;
        }

        public static IWebElement CbbxElement(IWebElement element, int seconds, string data)
        {

            WaitHelpers.CustomElementIsVisible(element, seconds);
            element.SendKeys(data + Keys.Enter);

            return element;
        }


    }

    public class TextBox
    {
        public static string GetText(IWebElement element)
        {
            WaitHelpers.CustomElementIsVisible(element);
            return element.Text;
        }

        public static string GetAttribute(IWebElement element, string attribute)
        {
            WaitHelpers.CustomElementIsVisible(element);
            return element.GetAttribute(attribute);

        }
    }

    public class Element
    {
       
        public static void Action(string key)
        {
            Actions actions = new(Browser._Driver);
            actions.SendKeys(key);
            actions.Perform();
            WaitHelpers.WaitSomeInterval(700);
        }
    }

    public class Keyss
    {
        public static string Control()
        {
            string control = String.Empty;
            if (OperatingSystem.IsWindows())
            {
                control = Keys.Control;
            }
            else if (OperatingSystem.IsMacOS() || OperatingSystem.IsLinux())
            {
                control = Keys.Command;
            }
            return control;
        }
    }
}
