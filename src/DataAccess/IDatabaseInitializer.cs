using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public interface IDatabaseInitializer
    {
        void Initialize(IServiceCollection services);
    }
}