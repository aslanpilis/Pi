using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pi.Core.Entity;
using Pi.Core.Services;
using Pi.Store.Api.DTOs;
using Pi.Store.Api.Filters;
using Pi.Store.Api.Mapping;

namespace Pi.Store.Api.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class ProductsController : ControllerBase
        {
            private readonly IMapper _mapper;
            private readonly IProductService _productService;

            public ProductsController(IProductService productService, IMapper mapper)
            {
                _productService = productService;
                _mapper = mapper;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var products = await _productService.Where(x => x.IsDelete == false);

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
            }

           [ServiceFilter(typeof(NotFoundFilter))]
           [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var product = await _productService.GetByIdAsync(id);

                return Ok(_mapper.Map<ProductDto>(product));
            }


            [HttpGet("{id}/category")]
            public async Task<IActionResult> GetWithCategoryById(int id)
            {
                var product = await _productService.GetWithCategoryByIdAsync(id);

                return Ok(_mapper.Map<ProductWithCategoryDto>(product));
            }


            [HttpPost]
            public async Task<IActionResult> Save(ProductDto productDto)
            {
                var newproduct = await _productService.AddAsync(_mapper.Map<Product>(productDto));

                return Created(string.Empty, _mapper.Map<ProductDto>(newproduct));
            }

            [HttpPut]
            public IActionResult Update(ProductDto productDto)
            {
                var product = _productService.Update(_mapper.Map<Product>(productDto));

                return NoContent();
            }

      
            [HttpDelete("{id}")]
            public IActionResult Remove(int id)
            {
                var product = _productService.GetByIdAsync(id).Result;

                _productService.Remove(product);
                return NoContent();
            }
        }
    }

