using System.Text.Json;
using Microsoft.EntityFrameworkCore;

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

        public void getWeatherByCity(string cityName) //pobieranie pogody z danego miasta
        {
            var city = database.Cities.Include(c => c.WeatherEntries).FirstOrDefault(c => c.name == cityName);
            if(city != null)
            {
                foreach (var weatherEntry in city.WeatherEntries)
                {
                    Console.WriteLine($"Date: {weatherEntry.Date}, Temperature: {weatherEntry.temp}°C");
                }
            }
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
                Date = DateTime.Now.Date,
                temp = data.main.temp,
                feels_like = data.main.feels_like,
                humidity = data.main.humidity,
                pressure = data.main.pressure,
                City = city
            };
            database.WeatherEntries.Add(weather);
            database.SaveChanges();
        }
    }
}
