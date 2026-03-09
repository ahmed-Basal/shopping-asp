using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace core.Entities
{
    public  class Favorite
    {
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual product Product { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
