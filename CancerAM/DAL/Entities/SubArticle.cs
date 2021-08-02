namespace CancerAM.DAL.Entities
{
    public partial class SubArticle
    {
        public SubArticle()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
        
        public int? Position { get; set; }

        #endregion

        #region Generated Relationships
        #endregion

    }
}
