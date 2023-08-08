using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Enities;
using core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IproductRepository
    {
        private readonly StoreContext _context;
        private readonly int PageSize;

        public ProductRepository(StoreContext context)
        {
            _context = context;
            PageSize = 5;

        }
        public async Task<Product> GetProductByIdAsnc(int id)
        {
            return await _context.Products                                
                                .Include(p=>p.ProductType)
                                .Include(p=>p.ProductBrand)
                                .FirstOrDefaultAsync(p=>p.Id == id);
        }
        public async Task<IReadOnlyList<Product>> GetProductsAsnc(string order_by, string AscOrDesc,int? Typeid,int? brandid,int pagenumber,string search)
        {
            var products= _context.Products
                            .Include(p=>p.ProductType)
                            .Include(p=>p.ProductBrand)
                            .AsQueryable();
                            
            if (Typeid.HasValue||brandid.HasValue ||!string.IsNullOrEmpty(search))
            {
                products = products
                            .Where(p =>(!Typeid.HasValue ||p.ProductTypeId == Typeid)
                                &&(!brandid.HasValue || p.ProductBrandId == brandid)
                                &&(string.IsNullOrEmpty(search))|| p.Name.ToLower().Contains(search))
                            .AsQueryable();
            }
            return (string.IsNullOrEmpty(order_by)&&string.IsNullOrEmpty(AscOrDesc)&&order_by!="price")
             ? await products
                    .OrderBy(p =>p.Name)
                    .Skip(pagenumber*PageSize).Take(PageSize)
                    .ToListAsync() 
            :(AscOrDesc.Equals("asc",StringComparison.OrdinalIgnoreCase)) 
                            ? await products
                                        .OrderBy(p =>p.Price)
                                        .Skip(pagenumber*PageSize).Take(PageSize)
                                        .ToListAsync()
                            : await products
                                        .OrderByDescending(p =>p.Price)
                                        .Skip(pagenumber*PageSize).Take(PageSize)
                                        .ToListAsync();                          
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductsBrandsAsnc()
        {
            return await _context.ProductBrands.ToListAsync() ;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductsTypesAsnc()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    
        

    }
}