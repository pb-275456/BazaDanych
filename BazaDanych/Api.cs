using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BazaDanych
{
    internal class Api
    {
        public HttpClient client;
        public async Task GetData(string city)
        {
            client = new HttpClient();
            string apikey = "c4bef0bdf1833ada4944cd1a8c720578";
            //string city = "London";
            string call = @$"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apikey}&units=metric";
            string response = await client.GetStringAsync(call);
            WeatherData data = JsonSerializer.Deserialize<WeatherData>(response); 
            //Console.WriteLine(response);

            Console.WriteLine(data);
        }

    }
}
