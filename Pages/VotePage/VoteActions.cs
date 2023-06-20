using Base_Temlate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
