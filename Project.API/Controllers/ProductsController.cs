using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.API.Dtos;
using Project.Core.DbModels;
using Project.Core.Interfaces;
using Project.Core.Specification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.API.Controllers
{
    public class ProductsController : BaseApiController
    {
        //private readonly IProductRepository _repository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepository, IGenericRepository<ProductBrand> productBrandRepository, IGenericRepository<ProductType> productTypeRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        [HttpGet("products")]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts(string sort)
        {
            var spec = new ProductsWithProductTypeAndBrandsSpecification(sort);
            var data = await _productRepository.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductDto>>(data));
        }


        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
        {
            return Ok(await _productBrandRepository.ListAllAsync());
        }


        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductType()
        {
            return Ok(await _productTypeRepository.ListAllAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var spec = new ProductsWithProductTypeAndBrandsSpecification(id);
            var data = await _productRepository.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductDto>(data);
        }
    }
}
