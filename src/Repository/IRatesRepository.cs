using DTO;

namespace Repository
{
    public interface IRatesRepository
    {
        RatesDto[] GetRates();
        int Test();
    }
}