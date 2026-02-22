using AutoMapper;
using core.Dto;
using core.Entities;
using core.Services;
using core.shareing;
using inftastructer.Data;
using Microsoft.AspNetCore.Mvc;
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

        public async Task  delete(product product)
        {
           var photo= context.Photos.Where(m => m.productId == product.Id).ToList();
            foreach (var item in photo)
            {
                context.Photos.Remove(item);
            }
            context.Photos.RemoveRange(photo);
            context.Products.Remove(product);
            await  context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAll(ProductParameters productparameter)
        {
            var query = context.Products
                .Include(p => p.category)
                .Include(p => p.photos)
                .AsNoTracking()
                .AsQueryable();

            if(!string.IsNullOrEmpty(productparameter.Search))
            {
                var searchWords = productparameter.Search.Split(' ');
                query = query.Where(m => searchWords.All(word =>
                    m.Name.ToLower().Contains(word.ToLower()) ||
                    m.Description.ToLower().Contains(word.ToLower())
                ));
            }


            if (!string.IsNullOrWhiteSpace(productparameter.Sort))
            {
                var sort = productparameter.Sort;

                if (string.Equals(sort, "PriceAsc", StringComparison.OrdinalIgnoreCase))
                    query = query.OrderBy(p => p.NewPrice);

                else if (string.Equals(sort, "PriceDesc", StringComparison.OrdinalIgnoreCase))
                    query = query.OrderByDescending(p => p.NewPrice);

                else
                    query = query.OrderBy(p => p.Name);
            }
            else
            {
                query = query.OrderBy(p => p.Name);
            }

            query = query.Skip((productparameter.PageNumber - 1) * productparameter.PageSize).Take(productparameter.PageSize);

            var products = await query.ToListAsync();

            return mapper.Map<IEnumerable<ProductDto>>(products);
        }



        public async Task<bool> update(int id, updateproductDto dto)
        {
            if (dto == null) return false;

            var product = await context.Products
                .Include(p => p.category)
                .Include(p => p.photos)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return false;

         
            if (!string.IsNullOrEmpty(dto.Name)) product.Name = dto.Name;
            if (!string.IsNullOrEmpty(dto.Description)) product.Description = dto.Description;
            if (dto.NewPrice.HasValue) product.NewPrice = (decimal)dto.NewPrice;
            if (dto.CategoryId.HasValue) product.CategoryId = (int)dto.CategoryId;

           
            if (dto.Photo != null && dto.Photo.Count > 0)
            {
                var imagePaths = await iamgeServices.AddImageAsync(dto.Photo, dto.Name ?? "product");
                var newPhotos = imagePaths.Select(path => new photo
                {
                    iamgename = path,
                    productId = product.Id
                }).ToList();

                await context.Photos.AddRangeAsync(newPhotos);
            }

            await context.SaveChangesAsync();
            return true;
        }


    }
    }

