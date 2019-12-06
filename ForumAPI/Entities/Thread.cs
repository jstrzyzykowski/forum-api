using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Entities
{
    public class Thread
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        
        
        public virtual List<Comment> Comments {get; set;}
    }
}
