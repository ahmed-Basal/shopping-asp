using inftastructer.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace inftastructer.Repository
{
    internal class ProductRepository : GenericRepositories<core.Entities.product>, core.interfaces.IProductRepository
    {
        public ProductRepository(AppDbcontext context) : base(context)
        {
        }
    }
}
