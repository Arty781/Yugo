using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yugo.Pages.VotePage
{
    public partial class Vote
    {
        [FindsBy(How = How.XPath, Using = "//button[text()=' Vote']")]
        public IList<IWebElement> btnVote;

        [FindsBy(How = How.XPath, Using = "//h4[text()='Vote']]")]
        public IWebElement titleVote;

        [FindsBy(How=How.XPath, Using = "//a[text()=' Vote Panel']")]
        public IWebElement linkVoteSidebar;

        [FindsBy(How=How.XPath, Using = "//div[@class='uk-navbar-item']//li[2]")]
        public IWebElement textVotePoints;

        [FindsBy(How=How.XPath,Using = "//div[@uk-countdown]")]
        public IList<IWebElement> countdownTimer;

    }
}
