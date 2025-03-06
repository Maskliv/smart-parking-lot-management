using Newtonsoft.Json;
using SmartParkingLot.Api.Domain.Enums;
using System.Text.Json.Serialization;

namespace SmartParkingLot.Api.Domain.Dto
{
    public class SpotDto
    {
        [JsonProperty("status")]
        [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
        public SpotStatus Status { get; set; }

        [JsonProperty("spotId")]
        public long SpotId { get; set; }

        [JsonProperty("zone")]
        public required string Zone { get; set; }

        [JsonProperty("positionId")]
        public required string PositionId { get; set; }
    }
}
