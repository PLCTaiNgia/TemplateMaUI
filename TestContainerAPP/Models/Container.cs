using System.Text.Json.Serialization;

namespace TestContainerAPP.Models
{
    public class Container
    {
        [JsonPropertyName("CntrNo")]
        public string CntrNo { get; set; }

        [JsonPropertyName("CntrSize")]
        public string CntrSize { get; set; }

        [JsonPropertyName("OprId")]
        public string OprId { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }

        [JsonPropertyName("CMStatus")]
        public string CMStatus { get; set; }

        [JsonPropertyName("Thumbnail")]
        public object Thumbnail { get; set; }
    }
}
