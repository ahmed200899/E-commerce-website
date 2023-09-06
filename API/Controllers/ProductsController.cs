using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using core.Enities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using core.Interfaces;
using API.Dto;
using AutoMapper;
using API.Helpers;

namespace API.Controllers
{

    public class ProductsController : Basecontroller
    {
        private readonly IproductRepository _Repo;
        private readonly IMapper _mapper;
        public ProductsController(IproductRepository Repo, IMapper mapper)
        {
            _mapper = mapper;
            _Repo = Repo;
        }

        [HttpGet]
        public async Task<ActionResult<paggination<ProductstoreturnDto>>> GetProducts(string orderby, string AscOrDesc, int? Typeid, int? brandid, int pagenumber, string search)
        {
            var page_size = 15;
            var page_Number = pagenumber;
            var products = await _Repo.GetProductsAsnc(orderby, AscOrDesc, Typeid, brandid, pagenumber, search);
            var count = products.Count();
            var Data = _mapper
                        .Map<IReadOnlyList<Product>,IReadOnlyList<ProductstoreturnDto>>
                        (products);
            return Ok(new paggination<ProductstoreturnDto>(page_Number,page_size,count,Data));

        } 

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductstoreturnDto>> GetProduct(int id)
        {
            var product = await _Repo.GetProductByIdAsnc(id);

            return _mapper.Map<Product,ProductstoreturnDto>(product);
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