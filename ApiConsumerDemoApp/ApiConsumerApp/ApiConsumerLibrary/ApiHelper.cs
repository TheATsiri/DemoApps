using System.Net.Http.Headers;

namespace ApiConsumerLibrary
{
    public static class ApiHelper
    {
        /// <summary>
        /// with the ApiClient we can now make calls to the internet, to pull up web pages 
        /// </summary>
        public static HttpClient? ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
