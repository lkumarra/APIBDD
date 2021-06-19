using BestBuy.API.BDD.API;
using BestBuy.API.BDD.Wrapper;
using TechTalk.SpecFlow;

namespace BestBuy.API.BDD.Steps
{
    [Binding]
    public class CommanSteps
    {
        private BaseAPI baseAPI = new BaseAPI();

        [Given(@"I am a valid user")]
        public void GivenIAmAValidUser()
        {

        }

        [Then(@".* should be .* with status code '(.*)'")]
        [Then(@".* list returned with status code '(.*)'")]
        public void ThenIGetTheResponseCode(int statuscode)
        {
            this.baseAPI.VerifyResponse(new ResponseModalWrapper() { code = statuscode });
        }

        [Then(@".* should not be .* with name as '(.*)',message as '(.*)', status code '(.*)' and errors as '(.*)'")]
        public void ThenProductsShouldNotBeUpdatedNameAsMessageAs(string errorName, string message, int statuscode, string errors)
        {
            this.baseAPI.VerifyResponse(new ResponseModalWrapper() { code = statuscode, name = errorName, message = message, errors = errors });
        }
    }
}
