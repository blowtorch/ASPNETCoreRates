using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Database
{
    public class DataContext: DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        public DbSet<Rate> Rates { get; set; }
    }

    public class Rate
    {
        public int RateId { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
    }
}
