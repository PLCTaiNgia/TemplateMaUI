using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestContainerAPP.Dto
{
    public class UpdateContainerRequestDto
    {
        [Required]
        [JsonPropertyName("CntrSize")]
        public string CntrSize { get; set; }

        [Required]
        [JsonPropertyName("OprId")]
        public string OprId { get; set; }

        [Required]
        [JsonPropertyName("Status")]
        public string Status { get; set; }

        [Required]
        [JsonPropertyName("CMStatus")]
        public string CMStatus { get; set; }

        [Required]
        [JsonPropertyName("Thumbnail")]
        public object Thumbnail { get; set; }
    }
}
