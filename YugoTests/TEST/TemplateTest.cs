﻿using Base_Temlate.PageObjects;
using NUnit.Allure.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Test
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
