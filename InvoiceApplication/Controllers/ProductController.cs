using InvoiceApplication.Models;
using InvoiceApplication.Container;
using Microsoft.AspNetCore.Mvc;
using InvoiceApplication.DTOs;

namespace InvoiceApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductContainer _productContainer;

        public ProductController(IProductContainer productContainer)
        {
            _productContainer = productContainer;
        }

        // GET: api/Product/GetAllProducts
        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            try
            {
                var products = await _productContainer.GetProducts();

                return Ok(products);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            try
            {
                var products = await _productContainer.GetProductByProductId(id);

                return Ok(products);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDto product)
        {
            try
            {
                if (id != product.Id)
                {
                    return BadRequest();
                }

                if (_productContainer.IsProductExists(id) &&
                    _productContainer.IsCategoryExists(product.CategoryId))
                {
                    await _productContainer.UpdateProduct(product);
                }
                else
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductDto product)
        {
            try
            {
                if (_productContainer.IsCategoryExists(product.CategoryId))
                {
                    await _productContainer.AddProduct(product);
                    return CreatedAtAction("GetProduct", new { id = product.Id }, product);
                }
                return NotFound("Category does not exists");
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _productContainer.GetProductToDeleteByProductId(id);

                if (product == null)
                {
                    return NotFound();
                }

                await _productContainer.DeleteProduct(product);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}