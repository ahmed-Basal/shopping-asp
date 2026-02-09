using core.interfaces;
using inftastructer.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace inftastructer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }

        public IPhotoRepository PhotoRepository { get;  }

        public IProductRepository productRepository { get; }
        public UnitOfWork(AppDbcontext context)
        {
            CategoryRepository = new CategoryRepository(context);
            PhotoRepository = new Photprepository(context);
            productRepository = new ProductRepository(context);
        }
    }
}
