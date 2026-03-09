using System;
using System.Collections.Generic;
using System.Text;

namespace core.Dto
{
    public  class ReviewDto
    {
        public int ProductId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
