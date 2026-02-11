using AutoMapper;
using core.interfaces;
using core.Services;
using inftastructer.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace inftastructer.Repository
{
    public class UnitOfWork : core.interfaces.IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IIamgeServices _imageManagementService;

        public ICategoryRepository CategoryRepository { get; }
        public IPhotoRepository PhotoRepository { get; }
        public IProductRepository productRepository { get; }

        public UnitOfWork(AppDbContext context, IMapper mapper, IIamgeServices imageManagementService)
        {
            _context = context;
            _mapper = mapper;
            _imageManagementService = imageManagementService;

            CategoryRepository = new CategoryRepository(_context);
            PhotoRepository = new Photprepository(_context);
            productRepository = new ProductRepository(_context, _mapper, _imageManagementService);
        }
    }

}
