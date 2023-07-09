﻿using Allure.Commons;
using Base_Temlate.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Yugo.Helpers;

namespace Yugo.Pages.VotePage
{
    public partial class Vote
    {
        public Vote GoToVotePage()
        {
            Browser._Driver.Navigate().GoToUrl(Endpoints.VOTE_PAGE);
            WaitHelpers.CustomElementIsVisible(linkVoteSidebar);

            return this;
        }

        public Vote Voting()
        {
            GetVotePoints(out int votePointsBefore);
            for (int i=0; i<8; i++)
            {
                GoToVotePage();
                WaitUntilTimerIsZero(countdownTimer[i]);
                WaitHelpers.WaitSomeInterval(1000);
                Button.Click(btnVote[i]);
                WaitHelpers.CustomElementIsInvisible(btnVote[i]);
                WaitHelpers.WaitSomeInterval(1000);
            }
            GoToVotePage();
            GetVotePoints(out int votePointsAfter);
            Console.WriteLine($"Total votepoints: {votePointsAfter} \r\n added points: +{votePointsAfter - votePointsBefore}");
            return this;
        }

        public Vote GetVotePoints(out int votePoints)
        {
            WaitHelpers.CustomElementIsVisible(textVotePoints);
            votePoints = int.Parse(textVotePoints.Text);
            return this;
        }


        private static void WaitUntilTimerIsZero(IWebElement element, int seconds = 600)
        {
            WebDriverWait wait = new(Browser._Driver, TimeSpan.FromSeconds(seconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
                Message = $"Element is not visible after {seconds} sec"
            };
            try
            {
                wait.Until(e =>
                {
                    try
                    {
                        if (element.Text.Replace("\r\n", "") == "00:00:00:00")
                        {
                            return true;
                        }
                        return false;
                    }
                    catch (Exception) { return false; }

                });
            }
            catch (NoSuchElementException) { throw new NoSuchElementException(); }
            catch (StaleElementReferenceException) { throw new StaleElementReferenceException(); }
        }
    }
}
