using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Infrastructure.DataContext;
using Project.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Core.Interfaces;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("products")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await _repository.GetProductAsync());
        }


        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrand()
        {
            return Ok(await _repository.GetProductBrandAsync());
        }


        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductType()
        {
            return Ok(await _repository.GetProductTypeAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            return Ok(await _repository.GetProductByIdAsync(id));
        }

    }
}
