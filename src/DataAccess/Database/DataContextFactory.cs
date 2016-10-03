using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

namespace DataAccess.Database
{
    public class DataContextFactory : IDataContextFactory, IDbContextFactory<DataContext>
    {
        public DataContext Create()
        {
            var optionsBuilder = CreateOptionsBuilder();
            return new DataContext(optionsBuilder.Options);
        }

        private static DbContextOptionsBuilder<DataContext> CreateOptionsBuilder()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RatesDb;Trusted_Connection=True;");
            return optionsBuilder;
        }

        public DataContext Create(DbContextFactoryOptions options)
        {
            var optionsBuilder = CreateOptionsBuilder();
            return new DataContext(optionsBuilder.Options);
        }
    }
}