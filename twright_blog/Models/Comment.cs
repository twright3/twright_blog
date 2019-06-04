using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace twright_blog.Models
{
    public class Comment
    {
        //Primary Key
        public int Id { get; set; }

        //Foreign Key
        public int BlogPostId { get; set; }
        public string AuthorId { get; set; }

        [AllowHtml]
        public string CommentBody { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }

        public string UpdatedReason { get; set; }

        //Navigational properties
        public virtual BlogPost BlogPost { get; set; }
        public virtual ApplicationUser Author { get; set; }



    }
}