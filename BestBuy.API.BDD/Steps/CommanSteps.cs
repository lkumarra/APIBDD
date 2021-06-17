using BestBuy.API.BDD.API;
using TechTalk.SpecFlow;

namespace BestBuy.API.BDD.Steps
{
    [Binding]
    public class CommanSteps
    {
        private readonly BaseAPI baseAPI = new BaseAPI();

        [Given(@"I am a valid user")]
        public void GivenIAmAValidUser()
        {

        }

        [Then(@".* list returned with status code '(.*)'")]
        public void ThenIGetTheResponseCode(int statuscode)
        {
            this.baseAPI.VerifyResponse(statuscode);
        }

        [Then(@".* .* be .* with status code '(.*)'")]
        public void ThenProductsShouldBeCreatedWithStatusCode(int statusCode)
        {
            this.baseAPI.VerifyResponse(statusCode);
        }
    }
}
