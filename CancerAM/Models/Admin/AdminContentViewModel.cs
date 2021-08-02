using System.Collections.Generic;

namespace CancerAM.Models.Admin
{
    public class AdminContentViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        
        public string? CurrentCategoryName { get; set; }
        
        public int? CurrentCategoryId { get; set; }
        
        public int? CurrentArticleId { get; set; }
        
        
        public int? CurrentSubArticleId { get; set; }
        
        public ArticleViewModel? CurrentArticle { get; set; }
        
        public SubArticleViewModel? CurrentSubArticle { get; set; }
    }
}