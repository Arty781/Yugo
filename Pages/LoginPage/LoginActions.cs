using Base_Temlate.Helpers;
using OpenQA.Selenium.DevTools.V109.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Yugo.Helpers;

namespace Base_Temlate.PageObjects
{
    public partial class Login
    {
        public Login SignIn()
        {
            Browser._Driver.Navigate().GoToUrl("https://yugowow.com/en/login");
            WaitHelpers.CustomElementIsVisible(btnLogin);
            InputBox.Element(inputUsername, 10, "lordecses");
            InputBox.Element(inputPassword, 10, "Qwerty123");
            Button.Click(btnLogin);
            WaitHelpers.CustomElementIsVisible(iconAvatar);

            return this;
        }
    }
}
