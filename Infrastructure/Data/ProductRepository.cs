using System.Collections.Generic;
using System.Threading.Tasks;
using core.Enities;
using core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IproductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;

        }
        public async Task<Product> GetProductByIdAsnc(int id)
        {
            return await _context.Products                                
                                .Include(p=>p.ProductType)
                                .Include(p=>p.ProductBrand)
                                .FirstOrDefaultAsync(p=>p.Id == id);
        }
        public async Task<IReadOnlyList<Product>> GetProductsAsnc()
        {
            return await _context.Products
                                .Include(p=>p.ProductType)
                                .Include(p=>p.ProductBrand)
                                .ToListAsync();
        }
        public async Task<IReadOnlyList<ProductBrand>> GetProductsBrandsAsnc()
        {
            return await _context.ProductBrands.ToListAsync() ;
        }

        public async Task<IReadOnlyList<ProductType>>GetProductsTypesAsnc()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}