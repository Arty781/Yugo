using Base_Temlate.Helpers;
using Yugo.Helpers;

namespace Base_Temlate.PageObjects
{
    public partial class Login
    {
        public static async Task SignIn()
        {
            await Browser.Driver.GotoAsync("https://yugowow.com/en/login");
            await WaitHelpers.CustomElementIsVisible(btnLogin);
            await InputBox.Element(inputUsername, "lordecses");
            await InputBox.Element(inputPassword, "Qwerty123");
            await Button.Click(btnLogin);
            await WaitHelpers.CustomElementIsVisible(iconAvatar);
        }
    }
}
