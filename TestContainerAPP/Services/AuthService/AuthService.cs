using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TestContainerAPP.Constants;
using TestContainerAPP.Dto;
using TestContainerAPP.Models;

namespace TestContainerAPP.Services.AuthService
{
    public class AuthService : IAuthService
    {
        public async Task<bool> IsAuthenticatedAsync()
        {
            var userString = await SecureStorage.Default.GetAsync(AppConstants.AUTH_STORAGE_KEY);

            return !string.IsNullOrWhiteSpace(userString);
        }

        public async Task<bool> LoginAsync(LoginRequestDto loginRequestDto)
        {
            using (HttpClient httpClient = new())
            {
                var response = await httpClient.PostAsJsonAsync<LoginRequestDto>($"{AppConstants.BASE_URL}/auth/login", loginRequestDto);

                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    var res = JsonConvert.DeserializeObject<ResponseAPI<AuthResponse>>(content);

                    if (res.Success)
                    {
                        var auth = res.Data.User;
                        var serializedData = JsonConvert.SerializeObject(auth);
                        await SecureStorage.Default.SetAsync(AppConstants.AUTH_STORAGE_KEY, serializedData);
                        await SecureStorage.Default.SetAsync(AppConstants.ACCESS_TOKEN, res.Data.Token.AccessToken);
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
            return true;
        }

        public void LogoutAsync()
        {
            SecureStorage.Default.Remove(AppConstants.AUTH_STORAGE_KEY);
            SecureStorage.Default.Remove(AppConstants.ACCESS_TOKEN);
        }

        public async Task<bool> RegisterAsync(RegisterRequestDto registerRequestDto)
        {
            using (HttpClient httpClient = new())
            {
                var response = await httpClient.PostAsJsonAsync<RegisterRequestDto>($"{AppConstants.BASE_URL}/auth/register", registerRequestDto);
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    var res = JsonConvert.DeserializeObject<ResponseAPI<dynamic>>(content);

                    if (res.Success)
                    {
                        var isRegister = res.Data;

                        return isRegister;
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

        public async Task<bool> ChangePassword(ChangePasswordRequestDto changePasswordRequestDto)
        {
            using (HttpClient httpClient = new())
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", await SecureStorage.Default.GetAsync(AppConstants.ACCESS_TOKEN));

                var response = await httpClient.PostAsJsonAsync<ChangePasswordRequestDto>($"{AppConstants.BASE_URL}/auth/ChangePassword", changePasswordRequestDto);
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
}
