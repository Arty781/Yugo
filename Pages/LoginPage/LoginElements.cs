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
        [FindsBy(How = How.Id, Using = "login_username")]
        public IWebElement inputUsername;

        [FindsBy(How = How.Id, Using = "login_password")]
        public IWebElement inputPassword;

        [FindsBy(How = How.Id, Using = "button_login")]
        public IWebElement btnLogin;

        [FindsBy(How=How.XPath,Using = "//img[@alt='Avatar']")]
        public IWebElement iconAvatar;
    }
}
