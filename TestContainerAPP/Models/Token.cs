using System.Text.Json.Serialization;

namespace TestContainerAPP.Models
{
    public class Token
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
    }
}
