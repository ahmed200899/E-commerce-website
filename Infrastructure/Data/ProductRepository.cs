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
        public async Task<IReadOnlyList<Product>> GetProductsAsync(string orderBy, string ascOrDesc, int? typeId, int? brandId, int pageNumber, string search)
        {
            var products = _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .AsQueryable();

            if (typeId.HasValue || brandId.HasValue || !string.IsNullOrEmpty(search))
            {
                products = products.Where(p =>
                    (!typeId.HasValue || p.ProductTypeId == typeId) &&
                    (!brandId.HasValue || p.ProductBrandId == brandId) &&
                    (string.IsNullOrEmpty(search) || p.Name.ToLower().Contains(search))
                );
            }

            return string.IsNullOrEmpty(orderBy) && string.IsNullOrEmpty(ascOrDesc) && orderBy != "price"

                ? await products.OrderBy(p => p.Name)
                    .Skip(pageNumber * PageSize)
                    .Take(PageSize)
                    .ToListAsync()

                : ascOrDesc.Equals("asc", StringComparison.OrdinalIgnoreCase)
                
                    ? await products.OrderBy(p => p.Price)
                        .Skip(pageNumber * PageSize)
                        .Take(PageSize)
                        .ToListAsync()

                    : await products.OrderByDescending(p => p.Price)
                        .Skip(pageNumber * PageSize)
                        .Take(PageSize)
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