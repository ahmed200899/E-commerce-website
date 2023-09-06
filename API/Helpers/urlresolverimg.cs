using API.Dto;
using AutoMapper;
using core.Enities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class urlresolverimg : IValueResolver<Product, ProductstoreturnDto, string>
    {
        private readonly IConfiguration _config;
        public urlresolverimg(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductstoreturnDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}
