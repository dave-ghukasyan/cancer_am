using Newtonsoft.Json;

namespace CancerAM.Models.Admin.Article
{
    public class ArticleUpdateRequest
    {
        [JsonProperty("title")]
        public string? Title { get; set; }
        
        [JsonProperty("secondTitle")]
        public string? SecondTitle { get; set; }
        
        [JsonProperty("body")]
        public string? Body { get; set; }
        
        [JsonProperty("image")]
        public string? Image { get; set; }
        
        [JsonProperty("position")]
        public int? Position { get; set; }
        
        [JsonProperty("isUp")]
        public bool? IsUp { get; set; }
        
        [JsonProperty("isDown")]
        public bool? IsDown { get; set; }
    }
}