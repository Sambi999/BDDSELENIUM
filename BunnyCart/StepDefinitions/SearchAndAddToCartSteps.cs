using BunnyCart.Utilities;
using System;
using TechTalk.SpecFlow;

namespace BunnyCart.StepDefinitions
{
    [Binding]
    public class SearchAndAddToCartSteps : CoreCodes
    {
        [Given(@"User will be on the Homepage")]
        public void GivenUserWillBeOnTheHomepage()
        {
            throw new PendingStepException();
        }

        [When(@"User will type the searchtext in the searchbox")]
        public void WhenUserWillTypeTheSearchtextInTheSearchbox()
        {
            throw new PendingStepException();
        }

        [Then(@"Search results are loaded in the same page with searchtext")]
        public void ThenSearchResultsAreLoadedInTheSamePageWithSearchtext()
        {
            throw new PendingStepException();
        }
    }
}
