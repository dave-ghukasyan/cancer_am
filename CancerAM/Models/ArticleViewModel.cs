using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CancerAM.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string SecondTitle { get; set; }

        public string Body { get; set; }

        public CategoryViewModel Category { get; set; }

        public List<SubArticleViewModel> SubArticles { get; set; }

        public AuthorViewModel Author { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string Image { get; set; }
        
        public int? Position { get; set; }
    }
}
