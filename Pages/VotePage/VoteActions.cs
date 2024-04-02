using Base_Temlate.Helpers;
using Microsoft.Playwright;
using System.Diagnostics;
using System.Xml.Linq;
using Yugo.Helpers;

namespace Yugo.Pages.VotePage
{
    public partial class Vote
    {
        public static async Task GoToVotePage()
        {
            await Browser.Driver.GotoAsync(Endpoints.VOTE_PAGE);
            await WaitHelpers.CustomElementIsVisible(linkVoteSidebar);
        }

        public static async Task Voting()
        {
            int votePointsBefore = await GetVotePoints();
            await WaitHelpers.CustomElementIsVisible(cardVote);
            await WaitUntilTimerIsZero();
            for (int i = 0; i < 8; i++)
            {
                await GoToVotePage();
                await WaitHelpers.WaitSomeInterval(2000);
                await BtnVote(i).Result.ClickAsync();
                await WaitHelpers.WaitSomeInterval(2000);
            }
            await GoToVotePage();
            int votePointsAfter = await GetVotePoints();
            Console.WriteLine($"Total votepoints: {votePointsAfter} \r\n added points: +{votePointsAfter - votePointsBefore}");
        }

        public static async Task<int> GetVotePoints()
        {
            await WaitHelpers.CustomElementIsVisible(textVotePoints);
            int votePoints = int.Parse(await TextBox.GetText(textVotePoints));
            await GoToVotePage();
            return votePoints;
        }

        private static async Task WaitUntilTimerIsZero(int seconds = 1800)
        {
            await WaitHelpers.CustomElementIsVisible(lastCardCounter);
            var waitTimeout = TimeSpan.FromSeconds(seconds);
            var pollingInterval = TimeSpan.FromMilliseconds(50);
            var stopwatch = Stopwatch.StartNew();

            bool IsExpectedTimeSpan(string countdown)
            {
                if (TimeSpan.TryParse(countdown.Replace("\n\n", ""), out var timeSpan) && timeSpan == TimeSpan.Zero)
                {
                    return true;
                }
                return false;
            }

            while (stopwatch.Elapsed < waitTimeout)
            {
                try
                {
                    var time = (await Browser.Driver.QuerySelectorAsync(lastCardCounter)).TextContentAsync().Result;
                    if (IsExpectedTimeSpan(time))
                    {
                        // Condition met, break the loop
                        break;
                    }
                    await Task.Delay(pollingInterval);
                }
                catch (TimeoutException)
                {
                    throw new TimeoutException();
                }
                catch (PlaywrightException ex) when (ex.Message.Contains("No node found for selector"))
                {
                    throw new PlaywrightException("Element not found");
                }
                catch (PlaywrightException ex) when (ex.Message.Contains("execution context was destroyed"))
                {
                    throw new PlaywrightException("Element reference is stale");
                }

                // Sleep for pollingInterval before the next attempt
                await Task.Delay(pollingInterval);
            }

            stopwatch.Stop();

            if (!IsExpectedTimeSpan(await (await Browser.Driver.QuerySelectorAsync(lastCardCounter)).TextContentAsync()))
            {
                throw new TimeoutException("Expected time span not reached within the specified duration.");
            }
        }

        private static async Task<IElementHandle> BtnVote(int num)
        {
            return (await Browser.Driver.QuerySelectorAllAsync(btnVote))[num];
        }

        private static async Task<IElementHandle> VoteCounter(int num)
        {
            var card = (await Browser.Driver.QuerySelectorAllAsync(cardVote))[num];
            return await card.QuerySelectorAsync(".//div[@uk-countdown]");
        }

    }
}
