using BestBuy.API.BDD.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [Then(@"I get the response code '(.*)'")]
        public void ThenIGetTheResponseCode(int statuscode)
        {
            this.baseAPI.VerifyResponse(statuscode);
        }
    }
}
