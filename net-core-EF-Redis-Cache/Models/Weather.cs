using System;

namespace net_core_EF_Redis_Cache.Models
{
    public class Weather
    {
        public int Id { get; set; }
        public decimal Degress { get; set; }
        public Boolean IsRaining { get; set; }
        public int WindSpeed { get; set; }
        public string City { get; set; }
    }
}
