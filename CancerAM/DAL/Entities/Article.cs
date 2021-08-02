using System;

namespace CancerAM.DAL.Entities
{
    public partial class Article
    {
        public Article()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Body { get; set; }

        public int CategoryId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int AuthorId { get; set; }

        public string? ImgPath { get; set; }

        public string? SecondTitle { get; set; }
        
        public int? Position { get; set; }

        #endregion

        #region Generated Relationships
        #endregion

    }
}
