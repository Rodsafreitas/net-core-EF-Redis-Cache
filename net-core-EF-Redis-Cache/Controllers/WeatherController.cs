using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using net_core_EF_Redis_Cache.Business;
using net_core_EF_Redis_Cache.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace net_core_EF_Redis_Cache.Controllers
{
    public class WeatherController : Controller
    {
        private WeatherService _service;

        public WeatherController(WeatherService service)
        {
           _service = service;
        }
                
        public ViewResult Index([FromServices]IConfiguration config,[FromServices]IDistributedCache cache)
        {
            string result = cache.GetString("Weather");
            IEnumerable<Weather> weather = null;
            if (result == null)
            {
                weather = _service.GetInformations();
                result = JsonConvert.SerializeObject(weather).ToString();

                DistributedCacheEntryOptions opcoesCache = new DistributedCacheEntryOptions();
                opcoesCache.SetAbsoluteExpiration(TimeSpan.FromSeconds(10));

                cache.SetString("Weather", result, opcoesCache);
            }
            else            
                weather = JsonConvert.DeserializeObject<IEnumerable<Weather>>(result);
            

            return View(weather);            
        }
    }
}