using core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace core.Dto
{
    public  record ProductDto
    {
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public virtual List<PhotoDto> photos { get; set; }
       public int  CategoryId { get; set; }
    }
    public record PhotoDto
    {
        public  string iamgename { get; set; }
        public int productId { get; set; }
    }
    public record AddproductDto {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public int CategoryId { get; set; }
        public IFormFileCollection Photo { get; set; }
    }
    public record updateproductDto:AddproductDto {
    public int id { get; set; }
    }

}
