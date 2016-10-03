
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using DataAccess.Database;
using Repository;

namespace IoC
{
    public class Bootstrap
    {
        public Bootstrap(IServiceCollection services, Container container)
        {
            //Register web
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(container));
            
            //Register Database
            container.Register<IDataContext, DataContext>();

            //Register repositories
            container.Register<IRatesRepository, RatesRepository>();

        }
    }
}
