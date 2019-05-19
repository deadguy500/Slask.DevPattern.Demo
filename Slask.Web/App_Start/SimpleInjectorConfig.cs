using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using Slask.Bootstrapper;
using System.Reflection;
using System.Web.Mvc;

namespace Slask.Web
{
    public class SimpleInjectorConfig
    {
        public static void Register()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            WebBootstrapper.Register(container, new AutoMapperWebProfile());
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}