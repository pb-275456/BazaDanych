using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
[assembly: InternalsVisibleTo("Aplikacja")]

namespace BazaDanych
{
    class Controller
    {
        public HttpClient client;
        private WeatherContext database;
        public WeatherData data { get; set; }
        public Api api { get; set; }

        public Controller()
        {
            database = new WeatherContext();
            data = new WeatherData();
        }
        public async Task GetData(string city)
        {
            client = new HttpClient();
            string apikey = "c4bef0bdf1833ada4944cd1a8c720578";
            //string city = "London";
            string call = @$"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apikey}&units=metric";
            string response = await client.GetStringAsync(call);
            data = JsonSerializer.Deserialize<WeatherData>(response);
            //Console.WriteLine(response);

            Console.WriteLine(data);
            //return data;
        }

        public List<WeatherEntry> getWeatherByCity(string cityName) //pobieranie pogody z danego miasta
        {
            var city = database.Cities.Include(c => c.WeatherEntries).FirstOrDefault(c => c.name == cityName);
            if(city!=null)
            {
                return city.WeatherEntries.ToList();
            }
            return new List<WeatherEntry>();
        }

        public List<WeatherEntry> getWeatherForCityDate(string cityName, DateTime date)
        {
            var weather = database.WeatherEntries.Where(w => w.City.name == cityName && w.date == date).ToList();

            return weather;
        }

        public void addEntry()
        {
            //sprawdenie czy miasto juz isntnieje w bazie
            var city = database.Cities.FirstOrDefault(c => c.name == data.name);
            if (city == null) //jesli nie ma miasta tworzymy nowe
            {
                city = new City { name = data.name, lat = data.coord.lat, lon = data.coord.lon };
                database.Cities.Add(city);
                database.SaveChanges();
            }

            var weather = new WeatherEntry
            {
                CityId = city.Id,
                date = DateTime.Now.Date,
                temp = data.main.temp,
                feels_like = data.main.feels_like,
                humidity = data.main.humidity,
                pressure = data.main.pressure,
                City = city
            };
            database.WeatherEntries.Add(weather);
            database.SaveChanges();
        }

        public bool CheckEntryInDatabase(string cityName, DateTime date)
        {
            return database.WeatherEntries.Any(w => w.City.name == cityName && w.date.Date == date.Date);
        }

    }
}
