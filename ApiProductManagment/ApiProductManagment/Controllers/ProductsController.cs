using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagment.Contracts.Interfaces;
using ProductManagment.Dto.RequestDto;
using ProductManagment.Dto.ResponseDto;

namespace ApiProductManagment.Controllers
{
    [Route("api/products")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("get-all-products")]
        [ProducesResponseType(typeof(ProductsResponseDto), 200)]
        [ProducesResponseType(typeof(ProductsResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> GetAllProducts() 
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet(("get-product-by/{id}"))]
        [ProducesResponseType(typeof(ProductsResponseDto), 200)]
        [ProducesResponseType(typeof(ProductsResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public Task<ProductsResponseDto> GetProduct(Guid id)
        {
            return _productService.GetProduct(id);
        }

        [HttpPost("product")]
        [ProducesResponseType(typeof(ProductsResponseDto), 200)]
        [ProducesResponseType(typeof(ProductsResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> AddProduct(ProductsRequestDto product) 
        {
            var resultproduct = await _productService.CreateProduct(product);
            return Ok(resultproduct);
        }

        [HttpPut("delete-product-by/{id}")]
        [ProducesResponseType(typeof(ProductsResponseDto), 200)]
        [ProducesResponseType(typeof(ProductsResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateProduct(Guid id, ProductsRequestDto product) 
        {
            var productresult = await _productService.UploadProduct(id, product);
            return Ok(productresult);
        }

        [HttpPut("assign-category-product")]
        [ProducesResponseType(typeof(CategoryXProductsResponseDto), 200)]
        [ProducesResponseType(typeof(CategoryXProductsResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateCategoryProduct(Guid IdCategory, Guid idProduct)
        {
            var result = await _productService.UploadCategoryXProduct(IdCategory, idProduct);
            return Ok(result);
        }

        [HttpDelete("delete-product-by/{id}")]
        [ProducesResponseType(typeof(ProductsResponseDto), 200)]
        [ProducesResponseType(typeof(ProductsResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> DeleteProduct(Guid id) 
        {
            var response = await _productService.DeleteProduct(id);
            return Ok(response);
        }
    }
}
