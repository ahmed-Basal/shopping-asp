using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace core.Entities
{
    public  class ReviewReply
    {
        public int ReviewId { get; set; }
        [ForeignKey("ReviewId")]
        public virtual Review Review { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }

        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
