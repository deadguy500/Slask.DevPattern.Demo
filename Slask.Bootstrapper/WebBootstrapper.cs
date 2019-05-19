using AutoMapper;
using SimpleInjector;
using Slask.Data.Contract;
using Slask.Data.Contract.Entities;
using Slask.Data.Implementation;
using Slask.Database;
using Slask.Domain.Contract;
using Slask.Domain.Contract.Models;
using Slask.Domain.Implementation;

namespace Slask.Bootstrapper
{
    public class WebBootstrapper
    {
        public static void Register(Container container, Profile profile)
        {
            container.Register<DbContext>(Lifestyle.Singleton);

            container.Register<IUserRepository, UserRepository>();
            container.Register<IProductRepository, ProductRepository>();

            container.Register<IUserService, UserService>();
            container.Register<IProductService, ProductService>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(profile);
                cfg.CreateMap<DbUser, UserEntity>().ReverseMap();
                cfg.CreateMap<ProductEntity, Product>().ReverseMap();

                cfg.CreateMap<User, UserEntity>();

                cfg.CreateMap<UserEntity, User>().ForMember(
                    destination => destination.FullName,
                    options => options.MapFrom(source => $"{source.FirstName} {source.LastName}")
                );
            });

            container.RegisterInstance(config);
            container.Register(() => config.CreateMapper(container.GetInstance));
        }
    }
}
