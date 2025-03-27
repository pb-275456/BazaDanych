using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaDanych
{
    internal class CharacterData
    {
        public int _id {get; set;}
        public string films { get; set; }
        public string name { get; set; }

        public CharacterData()
        {
            //this.films = new List<string>();
        }

        public override string ToString()
        {
            return $"{_id}, name: {name}, films: {films}";
        }
    }

    internal class ApiResponse
    {
        public Info info { get; set; }
        public List<CharacterData> data { get; set; }

        public ApiResponse()
        {
            this.data = new List<CharacterData>();
        }
    }

    internal class Info
    {
        public int count { get; set; }
    }
}
