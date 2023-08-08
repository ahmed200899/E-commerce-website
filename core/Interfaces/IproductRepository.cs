using System.Collections.Generic;
using System.Threading.Tasks;
using core.Enities;

namespace core.Interfaces
{
    public interface IproductRepository
    {
        Task<Product> GetProductByIdAsnc(int id);
        Task<IReadOnlyList<Product>> GetProductsAsnc(string orderby, string AscOrDesc,int? Typeid,int? brandid,int pagenumber,string search);
        Task<IReadOnlyList<ProductBrand>> GetProductsBrandsAsnc();
        Task<IReadOnlyList<ProductType>> GetProductsTypesAsnc();

    }
}