using net_core_EF_Redis_Cache.Data;
using net_core_EF_Redis_Cache.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_EF_Redis_Cache.Business
{
    public class WeatherService
    {
        private ApplicationDbContext _context;
        public WeatherService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Weather> GetInformations() => _context.Weather.ToList();
    }
}
