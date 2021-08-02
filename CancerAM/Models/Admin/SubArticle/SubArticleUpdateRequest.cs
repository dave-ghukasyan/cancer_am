using Newtonsoft.Json;

namespace CancerAM.Models.Admin.SubArticle
{
    public class SubArticleUpdateRequest
    {
        [JsonProperty("body")]
        public string? Body { get; set; }
        
        [JsonProperty("title")]
        public string? Title { get; set; }
    }
}