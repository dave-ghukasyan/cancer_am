namespace CancerAM.Models.Admin
{
    public class AdminArticleEditViewModel
    {
        public ArticleViewModel Article { get; set; }
        
        public SubArticleViewModel CurrentSubArticle { get; set; }

        public AdminArticleEditViewModel(ArticleViewModel article, SubArticleViewModel subArticle)
        {
            Article = article;
            CurrentSubArticle = subArticle;
        }
    }
}