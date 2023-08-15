using Base_Temlate.Helpers;
using Yugo.Helpers;

namespace Base_Temlate.PageObjects
{
    public partial class Login
    {
        public Login SignIn()
        {
            Browser.Driver.Navigate().GoToUrl("https://yugowow.com/en/login");
            WaitHelpers.CustomElementIsVisible(btnLogin);
            InputBox.Element(inputUsername, 10, "lordecses");
            InputBox.Element(inputPassword, 10, "Qwerty123");
            Button.Click(btnLogin);
            WaitHelpers.CustomElementIsVisible(iconAvatar);

            return this;
        }
    }
}
