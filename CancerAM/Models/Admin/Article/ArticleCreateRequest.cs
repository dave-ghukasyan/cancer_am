using Newtonsoft.Json;

namespace CancerAM.Models.Admin.Article
{
    public class ArticleCreateRequest
    {
        [JsonProperty("body")]
        public string? Body { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("img")]
        public string? Image { get; set; }
    }
}