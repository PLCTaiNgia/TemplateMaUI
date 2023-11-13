using System.Text.Json.Serialization;

namespace TestContainerAPP.Models
{
    public class AuthResponse
    {
        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("token")]
        public Token Token { get; set; }
    }
}
