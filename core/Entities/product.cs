using System;
using System.Collections.Generic;
using System.Text;

namespace core.Entities
{
    public  class product: BaseEntities<int>
    {
        public string name { get; set; }
        public string description { get; set; }
        public decimal NewPrice { get; set; }
        public decimal oldPrice { get; set; }
        public  virtual List<photo> photos { get; set; }=new List<photo>();
        public int  CategoryId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("CategoryId")]
        public virtual category category { get; set; }


    }
}
