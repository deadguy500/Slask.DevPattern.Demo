using AutoMapper;
using Slask.Domain.Contract.Models;
using Slask.Web.Models;

namespace Slask.Web
{
    public class AutoMapperWebProfile : Profile
    {
        public AutoMapperWebProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ForSourceMember(
                source => source.Id,
                options => options.DoNotValidate());
        }
    }
}