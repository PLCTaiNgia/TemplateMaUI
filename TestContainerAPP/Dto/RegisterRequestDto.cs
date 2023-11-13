using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestContainerAPP.Dto
{
    public class RegisterRequestDto
    {
        [Required]
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [Required]
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [JsonPropertyName("confirmPassword")]
        public string ConfirmPassword { get; set; }
    }
}
