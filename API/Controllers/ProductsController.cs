using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using core.Enities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IproductRepository _Repo;
        public ProductsController(IproductRepository Repo)
        {
            _Repo = Repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _Repo.GetProductsAsnc();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _Repo.GetProductByIdAsnc(id);
        }

        [HttpGet("Brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _Repo.GetProductsBrandsAsnc());
        }

        [HttpGet("Types")]    
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _Repo.GetProductsTypesAsnc());
        }

    }
}