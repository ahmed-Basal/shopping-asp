using api.halper;
using AutoMapper;
using core.Dto;
using core.Entities;
using core.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace api.Controllers
{

    public class ProductController : BaseController
    {

        public ProductController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> get()
        {
            try
            {
                var Product = await work.productRepository
                    .GetAllAsync(x => x.category, x => x.photos);

                var result = mapper.Map<List<ProductDto>>(Product);

                if (Product is null)
                {
                    return BadRequest(new ResponseAPI(400));
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> getById(int id)
        {
            try
            {


                var product = await work.productRepository.GetByIdAsync(
    id,
    x => x.category,
    x => x.photos
);


                if (product is null)
                    return BadRequest(new ResponseAPI(statusCode: 400));

                var result = mapper.Map<ProductDto>(product);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost("Add-Product")]
        public async Task<IActionResult> add(AddproductDto productDTO)
        {
            try
            {
                await work.productRepository.add(productDTO);
                return Ok(new ResponseAPI(200, "item add"));
            }
            catch (Exception ex)
            {
                return BadRequest(error: new ResponseAPI(statusCode: 400, message: ex.Message));
            }
        }
        [HttpPut("update-product")]
        public async Task<IActionResult> update(updateproductDto productDTO)
        {
            try
            {
                await work.productRepository.update(mapper.Map<updateproductDto>(productDTO));
                return Ok(new ResponseAPI(200, "item update"));
            }
            catch (Exception ex)
            {
                return BadRequest(error: new ResponseAPI(statusCode: 400, message: ex.Message));
            }

        }
    }
}