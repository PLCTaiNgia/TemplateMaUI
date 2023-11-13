using System.Text.Json.Serialization;

namespace TestContainerAPP.Dto
{
    public class ChangePasswordRequestDto
    {
        [JsonPropertyName("oldPassword")]
        public string OldPassword { get; set; }

        [JsonPropertyName("newPassword")]
        public string NewPassword { get; set; }

        [JsonPropertyName("confirmNewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}
