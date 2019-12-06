using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }

        public virtual Thread Thread { get; set; }
        public int ThreadId { get; set; }
    }
}
