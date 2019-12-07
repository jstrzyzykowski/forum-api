using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Models
{
    public class CommentDto
    {
        
        public DateTime AddDate { get; set; }
        
        public DateTime UpdateDate { get; set; }
        
        [Required]
        [MinLength(3)]
        public string Author { get; set; }
        
        [Required]
        [MinLength(3)]
        public string Content { get; set; }
    }
}
