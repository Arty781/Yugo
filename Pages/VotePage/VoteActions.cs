using Base_Temlate.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Button.Click(btnVote[i]);
                WaitHelpers.WaitSomeInterval(5000);
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

        private static void WaitUntilTimerIsZero(IWebElement element)
        {
            var desiredTime = element.Text.Replace("\r\n", "");
            if (desiredTime != "00:00:00:00")
            {
                TimeSpan desiredTimeSpan = TimeSpan.Parse(desiredTime);
                DateTime startTime = DateTime.Now;
                TimeSpan timeLimit = TimeSpan.FromMinutes(10); // Example time limit of 5 minutes

                while (desiredTimeSpan != TimeSpan.Zero)
                {
                    if (DateTime.Now - startTime > timeLimit)
                    {
                        throw new ArgumentException("Time limit exceeded");
                    }

                    TimeSpan currentTimeSpan = TimeSpan.FromTicks(DateTime.Now.Ticks - startTime.Ticks);
                    if (currentTimeSpan >= desiredTimeSpan)
                    {
                        // Desired time reached, exit the loop
                        break;
                    }
                    
                    Thread.Sleep(TimeSpan.FromMinutes(1));
                    desiredTime = element.Text.Replace("\r\n", "");
                    desiredTimeSpan = TimeSpan.Parse(desiredTime);
                }
            }
        }
    }
}
