using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Temlate.PageObjects
{
    public partial class Login
    {
        public const string inputUsername = "#login_username";
        public const string inputPassword = "#login_password";
        public const string btnLogin = "#button_login";
        public const string iconAvatar = "//img[@alt='Avatar']";
    }
}
