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



namespace Pi.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IShoppingCartService _shoppingCartService;

        public CartsController(IShoppingCartService shoppingCartService, IMapper mapper)
        {
            _shoppingCartService = shoppingCartService;
            _mapper = mapper;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetByappuserId(int id)
        {
            var carts = await _shoppingCartService.GetWithProductByIdAsync(id);

            return Ok(_mapper.Map<IEnumerable<ShoppingCartWithProductDto>>(carts));
        }


        [HttpPost]
        public async Task<IActionResult> Addtocart(ShoppingCartDto shoppingCartDto)
        {
            ErrorDto errorDto = new ErrorDto();
            var usercontrole = await _shoppingCartService.AppuserControl(shoppingCartDto.AppuserId);

            if (!usercontrole.IsOk)
            {
                errorDto.Errors = usercontrole.Errors;
                errorDto.Status = usercontrole.Status;
                return NotFound(errorDto);
            }

            var userproductstokcontrol = await _shoppingCartService.ProductStockControl(shoppingCartDto.ProductId, shoppingCartDto.Count);

            if (!userproductstokcontrol.IsOk)
            {
                errorDto.Errors = usercontrole.Errors;
                errorDto.Status = usercontrole.Status;
                return NotFound(errorDto);
            }

            var shoppingCartControl = await _shoppingCartService.ShoppingCartControl(shoppingCartDto.ProductId, shoppingCartDto.AppuserId);


            if (!shoppingCartControl.IsOk)
            {

                var newshoppingCartDto = await _shoppingCartService.AddAsync(_mapper.Map<ShoppingCart>(shoppingCartDto));

                return Created(string.Empty, _mapper.Map<ShoppingCartDto>(newshoppingCartDto));

            }


            var shoppingCart = shoppingCartControl.Model;

            shoppingCart.Count = shoppingCart.Count + shoppingCartDto.Count;

            if (userproductstokcontrol.Model.Stock < shoppingCart.Count)
            {
                
                errorDto.Status = 400;
                errorDto.Errors.Add("Product is out of stock");
                return NotFound(errorDto);
            }


             var cart = _shoppingCartService.Update(shoppingCart);


            return Ok(cart);

        }


        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var cart = _shoppingCartService.GetByIdAsync(id).Result;
            _shoppingCartService.Remove(cart);

            return NoContent();
        }



    }


}
