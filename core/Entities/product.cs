using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Text;

namespace core.Entities
{
    public  class product: BaseEntities<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal NewPrice { get; set; }
        public decimal oldPrice { get; set; }
      
        public  virtual List<photo> ? photos { get; set; }=new List<photo>();
        public int  CategoryId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("CategoryId")]
        public virtual category category { get; set; }

        public virtual List<Review> Reviews { get; set; } = new List<Review>();
        public virtual List<Favorite> Favorites { get; set; } = new List<Favorite>();
    }
}
