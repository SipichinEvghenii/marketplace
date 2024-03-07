using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Marketplace.Application.Interfaces;
using Marketplace.Application.Services;
using Marketplace.Infrastructure.Repositories;

namespace Marketplace.Web
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            // Регистрация контроллеров в MVC
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Регистрация сервисов и репозиториев
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            builder.RegisterType<PasswordHasher>().As<IPasswordHasher>().InstancePerRequest();
            builder.RegisterType<AuthService>().As<IAuthService>().InstancePerRequest();
            builder.RegisterType<MarketplaceContext>().InstancePerRequest();

            // Установка резолвера зависимостей
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}