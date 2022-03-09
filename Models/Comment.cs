using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace COMP1640_TEAM4.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
     
        public int IdeaId { get; set; }
        public Idea Idea { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }
    }
}