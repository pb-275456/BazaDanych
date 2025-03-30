using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaDanych
{
    internal class WeatherData
    {
        public Main main { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }

        public override string ToString()
        {
            return $"City: {name}\n{main}\n{coord}";
        }
    }

    internal class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double pressure { get; set; }
        public double humidity { get; set; }

        public override string ToString()
        {
            return $"temp: {temp}, feels like: {feels_like}, pressure: {pressure}, humidity: {humidity}";
        }
    }

    internal class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }

        public override string ToString()
        {
            return $"coordinates - lon: {lon}, lat: {lat}";
        }
    }

   
}
