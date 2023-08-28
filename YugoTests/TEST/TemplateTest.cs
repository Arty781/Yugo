using Base_Temlate.Helpers;
using Base_Temlate.PageObjects;
using NUnit.Framework;
using Yugo.Pages.VotePage;

namespace Template_Test
{

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
