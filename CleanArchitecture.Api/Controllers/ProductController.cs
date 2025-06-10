using CleanArchitecture.Api.Authentification;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    [ServiceFilter(typeof(ApiKeyFilter))]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await _productService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            
            return Ok(await _productService.GetByIdAsync(id));    
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto )
        {
            await _productService.AddAsync(dto);
            return Ok("Produit créé avec succès");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {
            await _productService.UpdateAsync(dto);
            return Ok("Mise à jour avec succès");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteAsync(id);
            return Ok("Suprimé avec succès");
        }

    }
}
