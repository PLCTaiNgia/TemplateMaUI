using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TestContainerAPP.Constants;
using TestContainerAPP.Dto;
using TestContainerAPP.Models;

namespace TestContainerAPP.Services.ContainerService
{
    public class ContainerService : IContainerService
    {
        public async Task<Container> GetContainerById(string id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var responseString = await httpClient.GetStringAsync($"{AppConstants.BASE_URL}/container/{id}");

                var responseObj = JsonConvert.DeserializeObject<ResponseAPI<Container>>(responseString);

                if (responseObj.Success)
                {
                    return responseObj.Data;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<Container>> GetContainers()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var responseString = await httpClient.GetStringAsync($"{AppConstants.BASE_URL}/container");

                var responseObj = JsonConvert.DeserializeObject<ResponseAPI<List<Container>>>(responseString);

                if (responseObj.Success)
                {
                    return responseObj.Data;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<bool> UpdateContainerAsync(string id, UpdateContainerRequestDto updateContainerRequestDto)
        {
            using HttpClient httpClient = new();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await SecureStorage.Default.GetAsync(AppConstants.ACCESS_TOKEN));

            var response = await httpClient.PutAsJsonAsync<UpdateContainerRequestDto>($"{AppConstants.BASE_URL}/container/{id}", updateContainerRequestDto);
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                var res = JsonConvert.DeserializeObject<ResponseAPI<dynamic>>(content);

                if (res.Success)
                {
                    var isChanged = res.Data;

                    return isChanged;
                }
                else
                {
                    return res.Success;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
