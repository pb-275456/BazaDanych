using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaDanych
{
    class City
    {
        public int Id { get; set; }
        public required string name { get; set; }
        public double? lon { get; set; }
        public double? lat { get; set; }
        public required List<WeatherEntry> WeatherEntries { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, City: {name}\nCoordinates - lon: {lon}, lat: {lat}";
        }
    }
}
