using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Reqres_Automation_Framework.Hooks
{
    public class HttpRequestMethods
    {
        public HttpClient _httpClient;  //httpclient is declared publicly here and can be later instantiated 
        private string baseUrl = "https://reqres.in";

        //Two primary pieces [status code and content ]of data required to validate each scenario are declared at the top and made accessible 
        // to other class files

        public string content = string.Empty;
        public HttpStatusCode statusCode { get; set; }


        public void GetMethod(string resource)
        {
            var handler = new HttpClientHandler() //create new client handler object 
            {
                UseProxy = false
            };

            using (_httpClient = new HttpClient(handler)) //Instatiate new httpclient and pass handler
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, baseUrl + resource); //create variables for request message and response
                var response = _httpClient.SendAsync(requestMessage).Result;
                if (response.IsSuccessStatusCode) //if response is equal to success status code [will be determined at RT] then execute, else, execute the alternative.
                {
                    content = response.Content.ReadAsStringAsync().Result; //response content will be stored in this variable at RT
                    statusCode = response.StatusCode;  //statuscode response will be stored in this variable at RT
                }
                else
                {
                    content = response.Content.ReadAsStringAsync().Result;
                    statusCode = response.StatusCode;
                }
            }
        }


        public void PostMethod(string resource, string body)
        {
            var handler = new HttpClientHandler()
            {
                UseProxy = false
            };

            using (_httpClient = new HttpClient(handler))
            {
                var response = _httpClient.PostAsync(baseUrl + resource, new StringContent(body, Encoding.UTF8, "application/json"));
                if (response.Result.IsSuccessStatusCode)
                {
                    statusCode = response.Result.StatusCode;
                }
                else
                {
                    statusCode = response.Result.StatusCode;
                }
            }
        }


        public void PutMethod(string resource, string body)
        {
            var handler = new HttpClientHandler()
            {
                UseProxy = false
            };

            using (_httpClient = new HttpClient(handler))
            {
                var response = _httpClient.PutAsync(baseUrl + resource, new StringContent(body, Encoding.UTF8, "application/json"));
                if (response.Result.IsSuccessStatusCode)
                {
                    statusCode = response.Result.StatusCode;
                }
                else
                {
                    statusCode = response.Result.StatusCode;
                }
            }
        }


        public void DeleteMethod(string resource)
        {
            var handler = new HttpClientHandler() 
            {
                UseProxy = false
            };

            using (_httpClient = new HttpClient(handler)) 
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Delete, baseUrl + resource); 
                var response = _httpClient.SendAsync(requestMessage).Result;
                if (response.IsSuccessStatusCode) 
                {
                    content = response.Content.ReadAsStringAsync().Result;
                    statusCode = response.StatusCode;
                }
                else
                {
                    content = response.Content.ReadAsStringAsync().Result;
                    statusCode = response.StatusCode;
                }
            }
        }
    }
}
