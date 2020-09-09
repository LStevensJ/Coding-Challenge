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
            _httpRequestMethods.PostMethod(resource, File.ReadAllText(postBody + @"\PostBodyData.json"));// File path is stored in postBody variable and passed
            // to the post method in the form of an argument. Note post method takes two arguments
        }

        [Then(@"the status code for the request should be '(.*)'")]
        public void ThenTheStatusCodeForTheGETRequestShouldBe(string expectedResult)
        {
            string actualResult = _httpRequestMethods.statusCode.ToString(); //status code property is retrieve and stored here at RT 
            Assert.IsTrue(expectedResult.Equals(actualResult)); //An assertion is performed on actual vs expected result
        }


        [Given(@"the reqres service is running and a GET request is made to the '(.*)' endpoint")]
        public void GivenTheReqresServiceIsRunningAndAGETRequestIsMadeToTheEndpoint(string resource)
        {
            _httpRequestMethods.GetMethod(resource); //Note get method takes one argument i.e. endpoint for the info we wish to retrieve from resource 
        }

        [Then(@"the following user should be present:")]
        public void ThenTheFollowingUserShouldBePresent(Table table)
        {
            var expectedResult = table.CreateInstance<UserModel>(); //Create instance method used to create table with single set of data
            string response = _httpRequestMethods.content; //content from GET response is stored in response var at RT then deserialised to reconstruct the object
            var actualResult = JsonConvert.DeserializeObject<SingleUserModel>(response).data;
            Assert.IsTrue(SerializeObjects(expectedResult, actualResult)); //SerialiserObj method was created to flatten and convert the complex and deserialised
            //object to a string collection which can then be compared using assertion method.
        }

        [Then(@"the following list of users should be present:")]
        public void ThenTheFollowingListOfUsersShouldBePresent(Table table)
        {
            var expectedResult = table.CreateSet<UserModel>(); //expected data is stored in a table object which models 'UserModel' class. 
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

        public bool SerializeObjects(object obj1, object obj2) //Custom method created to serialise a set of deserialised data structures for the purpose comparison
        {                                                       
            bool match = false;

            var object1 = JsonConvert.SerializeObject(obj1);
            var object2 = JsonConvert.SerializeObject(obj2);
            if (object1 == object2) //Block of code in If-statment is executed if serliased objects are identical
            {
                match = true;
            }

            return match; //method returns true if the objects are identical and false if otherwise
        }

    }

}
