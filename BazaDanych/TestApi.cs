using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BazaDanych
{
    class TestApi
    {
        public HttpClient client;
        public async Task GetData()
        {
            client = new HttpClient();
            string call = @"https://api.disneyapi.dev/character/308";
            string response = await client.GetStringAsync(call);
            Console.WriteLine(response);
            //List<CharacterData> data = JsonSerializer.Deserialize<List<CharacterData>>(response);
            ApiResponse x = JsonSerializer.Deserialize<ApiResponse>(response);
            foreach (var character in x.data)
            {
                Console.WriteLine(character);
            }
        }

    }
}
