namespace DataAccess.Database
{
    public interface IDataContextFactory
    {
        DataContext Create();
    }
}