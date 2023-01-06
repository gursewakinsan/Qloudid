namespace Qloudid.Models
{
    public class UpdateChannelPublishRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "channel_id")]
        public int ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "publish_channel")]
        public int PublishChannel { get; set; }

    }
}
