using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace hello_dotnet5
{
    class Program
    {
        private static readonly Random random = new Random();
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            int randomCharacterId = GetRandomCharacterId();
            await SendRequest(randomCharacterId);
        }

        private static async Task SendRequest(int randomCharacterId)
        {
            const string url = "https://swapi.dev/api/people";
            var response = await client.GetStringAsync($"{url}/{randomCharacterId}/");
            Console.WriteLine("Your random Star Wars character today:");
            Console.WriteLine(response);
        }

        private static int GetRandomCharacterId()
        {
            int id;

            do
            {
                id = random.Next(1, 84);
            }
            while (id == 17);

            return id;
        }
    }
}
