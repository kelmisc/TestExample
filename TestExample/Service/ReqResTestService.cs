using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TestExample.Models;

namespace TestExample.Service
{
    public class ReqResTestService : IReqResTestService
    {
        private HttpClient _httpClient;

        public ReqResTestService(HttpClient httpClient) => this._httpClient = httpClient;

        public async Task<User> GetUserAsync(string id)
        {
            var response = await this._httpClient.GetAsync($"users/{id}");
            if (!response.IsSuccessStatusCode)
            {
                if(response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw new HttpResponseException(response);
                }
            }

            var userDataContainer = await response.Content.ReadAsAsync<UserDataContainer>();
            return userDataContainer.User;
        }
    }
}
