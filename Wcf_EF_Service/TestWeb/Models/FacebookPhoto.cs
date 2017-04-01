using Newtonsoft.Json;

namespace TestWeb.Models
{
    public class FacebookPhoto
    {
        [JsonProperty("picture")] // 这会将属性重命名为 picture。
        public string ThumbnailUrl { get; set; }

        public string Link { get; set; }
    }
}
