using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace core.Entities
{
    public  class Review
    {
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual product Product { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string? Comment { get; set; }

        public virtual List<ReviewReply> Replies { get; set; } = new List<ReviewReply>();
    }
}
