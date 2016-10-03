using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace ASPNETCoreRates.Models
{
    public class RateViewModel
    {
        public int Id { get; set; }

        public int Rate { get; set; }

        public string Description { get; set; }

        public static RateViewModel FromRateDto(RatesDto dto)
        {
            return new RateViewModel
            {
                Id = dto.RateId,
                Rate = dto.Value,
                Description = dto.Decription
            };
        }
    }
}
