using Base_Temlate.Helpers;
using Base_Temlate.PageObjects;
using NUnit.Allure.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yugo.Pages.VotePage;

namespace Template_Test
{
    [AllureNUnit]
    [TestFixture]
    public class Yugo : BaseWeb
    {
        [Test]
        public async Task Voting()
        {
            await Login.SignIn();
            await Vote.Voting();
        }

    }
}
