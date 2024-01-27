using AutoMapper;
using JustNowBackend.Data.Models;
using JustNowBackend.DTOs;
using JustNowBackend.Interfaces;
using JustNowBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace JustNowBackend.Controllers
{
    [ApiController]
    public class ProductController:ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        //vraca meni restorana koji ima dati ID
        [HttpGet("/GetAllProductsOfRestaurant/{id}")]
        public async Task<IActionResult> GetAllProducts([FromRoute]int id)
        {
           // if(productService.GetAllProductsOfRestaurant(id) == null) return NotFound();
            return Ok(await productService.GetAllProductsOfRestaurant(id));

        }
        [HttpGet("/GetProductById/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute]int id)
        {
            var obj = await productService.GetProductById(id);
            if (obj == null) return NotFound("Proizvod nije pronadjen u bazi.");
            return Ok(obj);
        }
        [HttpPost("/AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody]ProductRequestDTO product)
        {
            var obj = mapper.Map<Product>(product);
            await productService.AddProduct(obj);
            return Ok("Uspesno dodavanje proizvoda u bazu.");
        }
        [HttpDelete("/DeleteProductWithId/{id}")]
        public async Task<IActionResult> DeleteProductWithId([FromRoute] int id)
        {
            var obj = await  productService.GetProductById(id);
            if (obj == null) return NotFound("Nije moguce brisanje nepostojeceg objekta.");
            await productService.DeleteProduct(id);
            return NoContent();
        }

        [HttpPut("/UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProductInfo([FromRoute]int id,ProductUpdateRequestDTO p)
        {
            var obj = await productService.UpdateProduct(id, mapper.Map<Product>(p));
            if (obj == null)
            {
                return NotFound("Proizvod ne postoji u bazi.");
            }
            return Ok(obj);
        }
    }
}
