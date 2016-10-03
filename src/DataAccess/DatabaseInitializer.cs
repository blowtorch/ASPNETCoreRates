using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace DataAccess
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        public DatabaseInitializer()
        {
        }

        public void Initialize(IServiceCollection services)
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=RatesDb;Trusted_Connection=True;";
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));
        }
    }
}
