using Microsoft.AspNetCore.Mvc;
using System.Collections;
using SzkolkaRoslin_API.Controllers.Data;
using SzkolkaRoslin_API.Models;
using Microsoft.EntityFrameworkCore;
using SzkolkaRoslin_API.Models.DTO;

namespace SzkolkaRoslin_API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await _db.Product.ToListAsync()) ;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Product ID must be greater than 0");
                }
                var product = await _db.Product.FirstOrDefaultAsync(u => u.Id == id);
                if (product == null)
                    {
                        return NotFound($"Product with ID {id} was not found");
                    }
                    return Ok(product);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error occured while retrieving product with ID {id}: {ex.Message}");
            }

        }
        [HttpPost()]
        public async Task<ActionResult<Product>> CreateProduct(ProductCreateDTO productDTO)
        {
            try
            {
                if (productDTO == null)
                {
                    return BadRequest("Product data is required");
                }
                Product product = new Product()
                {
                    Name = productDTO.Name,
                    Description = productDTO.Description,
                    ImageUrl = productDTO.ImageUrl,
                    Price = productDTO.Price,
                    CreateDate = DateTime.Now
                };
                
                await _db.Product.AddAsync(product);
                await _db.SaveChangesAsync();
                return Ok(productDTO);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error occured while creating product: {ex.Message}");
            }

        }

    }
}
