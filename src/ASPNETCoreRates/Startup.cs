using DataAccess;
using DataAccess.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Repository;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore;
using SimpleInjector.Integration.AspNetCore.Mvc;

namespace ASPNETCoreRC2Angular2Demo
{
    public class Startup
    {
        private Container container = new Container();
        //private CrossCuttingConcerns.Bootstrap bootstrapper;
        
        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //bootstrapper = new CrossCuttingConcerns.Bootstrap(services, container);
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(container));
            //var connection = @"Server=(localdb)\mssqllocaldb;Database=RatesDb;Trusted_Connection=True;";
            //services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));
            //var databaseInitializer = new DatabaseInitializer();
            //databaseInitializer.Initialize(services);
        }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseSimpleInjectorAspNetRequestScoping(container);

            container.Options.DefaultScopedLifestyle = new AspNetRequestLifestyle();

            InitializeContainer(app);

            container.Verify();

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            // Add application presentation components:
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

            // Add application services. For instance:
            //container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);

            //Register Database
            //var connection = @"Server=(localdb)\mssqllocaldb;Database=RatesDb;Trusted_Connection=True;";
            //var options = new DbContextOptionsBuilder<DataContext>().UseSqlServer(connection).Options;
            //container.Register<DbContextOptions<DataContext>>(() => new DbContextOptionsBuilder<DataContext>().UseSqlServer(connection).Options, Lifestyle.Scoped);
            //container.Register<IDataContext>(() => new DataContext(new DbContextOptionsBuilder<DataContext>().UseSqlServer(connection).Options), Lifestyle.Scoped);
            //container.RegisterSingleton<DbContextOptionsBuilder<DataContext>>( new DbContextOptionsBuilder<DataContext>().UseSqlServer(connection));
            //Register repositories
            container.Register<IDataContextFactory, DataContextFactory>(Lifestyle.Scoped);
            container.Register<IRatesRepository, RatesRepository>(Lifestyle.Scoped);
            //container.Register<IDatabaseInitializer, DatabaseInitializer>();
            //container.Register<IDataContext, DataContext>();

            // Cross-wire ASP.NET services (if any). For instance:
            //container.RegisterSingleton(app.ApplicationServices.GetService<ILoggerFactory>());
            // NOTE: Prevent cross-wired instances as much as possible.
            // See: https://simpleinjector.org/blog/2016/07/
        }
    }
}
