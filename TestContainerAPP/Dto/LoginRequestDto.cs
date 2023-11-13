using System.Text.Json.Serialization;

namespace TestContainerAPP.Dto
{
    public class LoginRequestDto
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
