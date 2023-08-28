using Base_Temlate.Helpers;
using Microsoft.Playwright;

namespace Yugo.Helpers
{
    public class Button
    {
        public static async Task Click(string element)
        {
            await WaitHelpers.WaitSomeInterval(300);
            await WaitHelpers.CustomElementIsVisible(element);
            PageQuerySelectorOptions options = new() { Strict = true };
            await Browser.Driver.QuerySelectorAsync(element, options).Result.ClickAsync();

        }




    }
    public class InputBox
    {
        public static async Task Element(string element, string data, int milliSeconds = 10000)
        {
            await WaitHelpers.WaitSomeInterval(250);
            await WaitHelpers.CustomElementIsVisible(element, milliSeconds);
            await Browser.Driver.FocusAsync(element);
            await Browser.Driver.Keyboard.PressAsync("Control+A");
            await Browser.Driver.Keyboard.PressAsync("Backspace");
            await Browser.Driver.QuerySelectorAsync(element).Result.FillAsync(data);
        }



    }

    public class TextBox
    {
        public static async Task<string> GetText(string element)
        {
            await WaitHelpers.CustomElementIsVisible(element);
            return (await Browser.Driver.QuerySelectorAsync(element)).TextContentAsync().Result;
        }

        public static async Task<string> GetAttribute(string element, string attribute)
        {
            await WaitHelpers.CustomElementIsVisible(element);
            return (await Browser.Driver.QuerySelectorAsync(element)).GetAttributeAsync(attribute).Result;

        }
    }

}
