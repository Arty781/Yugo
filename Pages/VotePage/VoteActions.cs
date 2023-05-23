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
            for(int i=0; i<8; i++)
            {
                GoToVotePage();
                Button.Click(btnVote[i]);
                WaitHelpers.WaitSomeInterval(5000);
            }

            return this;
        }
    }
}
