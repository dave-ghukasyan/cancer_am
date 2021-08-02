using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CancerAM.Models.Admin.SubArticle
{
    public class SubArticleCreateRequest
    {
        [JsonProperty("title")]
        [Required]
        public string? Title { get; set; }

        [JsonProperty("body")]
        [Required]
        public string? Body { get; set; }
    }
}