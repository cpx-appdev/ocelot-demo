using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebUI
{
    public class ApiUrls
    {
        //public const string UserService = "http://localhost:52492/";
        //public const string SubscriptionService = "http://localhost:53116/";

        public const string Gateway = "http://localhost:52492/";
    }

    class ApiHelper
    {
        public HttpClient Client { get; set; }

        public ApiHelper(string baseAddress)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(baseAddress);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> Get<T>(string path)
        {
            HttpResponseMessage response = await Client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(result);
            }

            return default(T);
        }

    }
}
