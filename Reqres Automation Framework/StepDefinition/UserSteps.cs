using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reqres_Automation_Framework.Hooks;
using Reqres_Automation_Framework.Model;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Security.AccessControl;

namespace Reqres_Automation_Framework.StepDefinition
{
    [Binding]
    public class UserSteps
    {
        HttpRequestMethods _httpRequestMethods;

        public UserSteps(HttpRequestMethods httpRequestMethods)
        {
            _httpRequestMethods = httpRequestMethods;
        }

        [Given(@"the reqres service is running and a POST request is made to the '(.*)' endpoint")]
        public void GivenTheReqresServiceIsRunningAndAPOSTRequestIsMadeToTheEndpoint(string resource)
        {
            string postBody = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", ""); // First method of tramsitting data via API 
            _httpRequestMethods.PostMethod(resource, File.ReadAllText(postBody + @"\PostBodyData.json"));
        }

        [Then(@"the status code for the GET request should be '(.*)'")]
        public void ThenTheStatusCodeForTheGETRequestShouldBe(string expectedResult)
        {
            string actualResult = _httpRequestMethods.statusCode.ToString();
            Assert.IsTrue(expectedResult.Equals(actualResult));
        }


        [Given(@"the reqres service is running and a GET request is made to the '(.*)' endpoint")]
        public void GivenTheReqresServiceIsRunningAndAGETRequestIsMadeToTheEndpoint(string resource)
        {
            _httpRequestMethods.GetMethod(resource);
        }

        [Then(@"the following user should be present:")]
        public void ThenTheFollowingUserShouldBePresent(Table table)
        {
            var expectedResult = table.CreateInstance<UserModel>();
            string response = _httpRequestMethods.content;
            var actualResult = JsonConvert.DeserializeObject<UserModel>(response);
            Assert.IsTrue(SerializeObjects(expectedResult, actualResult));
        }

        [Then(@"the following list of users should be present:")]
        public void ThenTheFollowingListOfUsersShouldBePresent(Table table)
        {
            var expectedResult = table.CreateSet<UserModel>();
            var response = _httpRequestMethods.content;
            var actualResult = JsonConvert.DeserializeObject<UserListModel>(response).data;
            Assert.IsTrue(SerializeObjects(expectedResult, actualResult));
        }

        [Given(@"the reqres service is running and a PUT request is made to the '(.*)' endpoint")]
        public void GivenTheReqresServiceIsRunningAndAPUTRequestIsMadeToTheEndpoint(string resource)
        {
            Dictionary<string, string> dataBody = new Dictionary<string, string>(); //Alternative method of tramsitting data 
            dataBody.Add("name", "morpheus"); //Property name and value pairs are stored in Dictionary collection
            dataBody.Add("job", "zion resident");
            string modDataBody = JsonConvert.SerializeObject(dataBody);//dataBody is then serlialized using Json Convert for transmission
            _httpRequestMethods.PutMethod(resource, modDataBody);
        }

        [Then(@"the status code for the PUT request should be '(.*)'")]
        public void ThenTheStatusCodeForThePUTRequestShouldBe(string expectedResult)
        {
            string actualResult = _httpRequestMethods.statusCode.ToString();
            Assert.AreEqual(expectedResult, actualResult); //Alternative assertion method to verify status response. 
        }

        public bool SerializeObjects(object obj1, object obj2)
        {
            bool match = false;

            var object1 = JsonConvert.SerializeObject(obj1);
            var object2 = JsonConvert.SerializeObject(obj2);
            if (object1 == object2)
            {
                match = true;
            }

            return match;
        }

    }

}
