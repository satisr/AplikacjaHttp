using System.Text.Json;
using WebApplication1;

namespace AplikacjaHttp
{
    public class Aplikacja
    {
        private const string Route = "https://catfact.ninja/fact";
        private readonly HttpClient _client;

        public Aplikacja(HttpClient client)
        {
            _client = client;
        }

        public async Task WriteTextAsync()
        {
            var results = await _client.GetAsync(Route);

            var tekst = JsonSerializer.Deserialize<Dto>(await results.Content.ReadAsStringAsync());

            if (tekst is null)
            {
                throw new KeyNotFoundException("Niepoprawny tekst");
            }

            WriteFile(tekst.fact);
        }

        public void WriteFile(string tekst)
        {
            StreamWriter file = File.AppendText("C:\\plik.txt");
            file.WriteLine(tekst);
            file.Close();
        }
    }
}