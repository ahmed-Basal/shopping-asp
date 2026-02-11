using core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace core.interfaces
{
    public  interface  IProductRepository:IGenricRepo<core.Entities.product>
    {
        Task<bool> add(AddproductDto productDto);
        Task<bool> update(updateproductDto updateproductDto);
    }
}
