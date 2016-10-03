using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DataAccess.Database;
using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.WebEncoders.Testing;

namespace Repository
{
    public class RatesRepository : IRatesRepository
    {
        private readonly IDataContextFactory datacontextFactory;
        //private readonly IDataContext dataContext;
        public RatesRepository(IDataContextFactory datacontextFactory)
        {
            this.datacontextFactory = datacontextFactory;
        }

        public int Test()
        {
            return 12345;
        }

        public RatesDto[] GetRates()
        {
            using (var dataContext = datacontextFactory.Create())
            {
                var ret = (from rate in dataContext.Rates
                           select new RatesDto { RateId = rate.RateId, Value = rate.Value, Decription = rate.Description }).ToArray();
                return ret;
            }
        }

        public void CreateOrUpdateRate(RatesDto rate)
        {
            using (var dataContext = datacontextFactory.Create())
            {
                var result = (from r in dataContext.Rates
                              where r.RateId == rate.RateId
                              select r).FirstOrDefault();
                if (result == null)
                {
                    dataContext.Rates.Add(new Rate { RateId = rate.RateId, Value = rate.Value, Description = rate.Decription });
                }
                else
                {
                    result.Value = rate.Value;
                    result.Description = rate.Decription;
                }
                dataContext.SaveChanges();
            }
        }
    }
}
