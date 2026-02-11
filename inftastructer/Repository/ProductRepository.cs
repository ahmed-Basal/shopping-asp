using AutoMapper;
using core.Dto;
using core.Entities;
using core.Services;
using inftastructer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace inftastructer.Repository
{
    internal class ProductRepository : GenericRepositories<core.Entities.product>, core.interfaces.IProductRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IIamgeServices iamgeServices;

        public ProductRepository(AppDbContext context, IMapper mapper, IIamgeServices iamgeServices) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.iamgeServices = iamgeServices;
        }

        public async Task<bool> add(AddproductDto productDTO)
        {
            if (productDTO == null) return false;

            var product = mapper.Map<product>(productDTO);

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            var ImagePath = await iamgeServices.AddImageAsync(productDTO.Photo, productDTO.Name);

            var photo = ImagePath.Select(path => new photo
            {
                iamgename = path,
                productId = product.Id,
            }).ToList();

            await context.Photos.AddRangeAsync(photo);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> update(updateproductDto updateproductDto)
        {
            if (updateproductDto is null)
            {
                return false;
            }

            var FindProduct = await context.Products.Include(m => m.category)
                .Include(m => m.photos)
                .FirstOrDefaultAsync(m => m.Id == updateproductDto.id);

            if (FindProduct is null)
            {
                return false;
            }
            mapper.Map(updateproductDto, FindProduct);
            var findimage = await context.Photos.Where(m => m.productId == updateproductDto.id).ToListAsync();
            foreach (var item in findimage)
            {
                context.Photos.Remove(item);
            }
            context.Photos.RemoveRange(findimage);
            var imagepath = await iamgeServices.AddImageAsync(updateproductDto.Photo, updateproductDto.Name);
            var photo = imagepath.Select(path => new photo
            {
                iamgename = path,
                productId = FindProduct.Id,
            }).ToList();
            await context.Photos.AddRangeAsync(photo);
            await context.SaveChangesAsync();
            return true;
        }

     


    }
    }

