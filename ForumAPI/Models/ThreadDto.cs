using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Models
{
    public class ThreadDto
    {
        //public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Subject { get; set; }
        
        public DateTime AddDate { get; set; }
        
        public DateTime UpdateDate { get; set; }

        [Required]
        public string Author { get; set; }
        
        public string Content { get; set; }
    }
}
