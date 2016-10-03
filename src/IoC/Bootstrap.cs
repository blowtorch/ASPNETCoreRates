
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using DataAccess.Database;
using Repository;

namespace IoC
{
    public static class Bootstrap
    {
        public static void Register(Container container)
        {
            container.Register<IDataContextFactory, DataContextFactory>(Lifestyle.Scoped);
            container.Register<IRatesRepository, RatesRepository>(Lifestyle.Scoped);
        }
    }
}
