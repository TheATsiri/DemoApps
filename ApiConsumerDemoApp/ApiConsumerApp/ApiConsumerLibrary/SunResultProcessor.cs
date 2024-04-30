using ApiConsumerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumerLibrary
{
    public class SunResultProcessor
    {
        public static async Task<SunModel> LoadSunInformation()
        {
            //Latitude and longtitude for Reutlingen 
            string url = "https://api.sunrise-sunset.org/json?lat=48.49144000&lng=9.20427000&date=today";

            // call the client
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    SunResultModel sunResult = await response.Content.ReadAsAsync<SunResultModel>();

                    return sunResult.Results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
