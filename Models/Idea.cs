using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP1640_TEAM4.Models
{
    public class Idea
    {
     
        public int Id { get; set; }

        public int? ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Item Item { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }


        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required]
        [DisplayName("Idea Description")]
        public string Description { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public DateTime CreatedAt { get; set; }

        public byte[] File { get; set; }

        public string UrlFile { get; set; }
        public string NameOfFile { get; set; }
    }
}