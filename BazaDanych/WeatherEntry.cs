using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaDanych
{
    class WeatherEntry
    {
        public int Id { get; set; }
        public required DateTime date { get; set; }
        public required double temp { get; set; }
        public double feels_like { get; set; }
        public double pressure { get; set; }
        public double humidity { get; set; }
        public required int CityId { get; set; } //id miasta
        public required City City { get; set; } //relacja z powrotem do miasta

        public override string ToString()
        {
            return $"Date: {date.Date}, temperature: {temp}, feels like: {feels_like}, pressure: {pressure}, humidity: {humidity}";
        }
    }
}
