using Base_Temlate.PageObjects;
using NUnit.Allure.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template_Test.BASE_Test;

namespace Template_Test.TEST
{
    [AllureNUnit]
    [TestFixture]
    public class Yugo : BASE
    {
        [Test]
        public void Login()
        {
            Pages.Login
                .SignIn();
            Pages.Vote
                .Voting();

        }

    }
}
