using Microsoft.EntityFrameworkCore;

namespace DataAccess.Database
{
    public interface IDataContext
    {
        DbSet<Rate> Rates { get; set; }
    }
}