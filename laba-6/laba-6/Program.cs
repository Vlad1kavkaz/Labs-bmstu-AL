using System.Text.Json;

class lab06
{
    static async Task Main(string[] args)
    {
        for (int j = 0; j < 10; j++)
        {
            Console.WriteLine();

            string apiKey = "78a42a81f9fcfc14fa64cee749e70b59";
            string apiUrl = "https://api.openweathermap.org/data/2.5/weather";

            List<Weather> weatherData = new List<Weather>();
            Random random = new Random();

            for (int i = 0; i < 50; i++)
            {
                Console.Write($"{i} - ");
                double latitude = random.NextDouble() * (90 - (-90)) + (-90);
                double longitude = random.NextDouble() * (180 - (-180)) + (-180);

                Weather weather = await GetWeatherData(apiUrl, apiKey, latitude, longitude);
                if (weather != null)
                {
                    weatherData.Add(weather);
                }
            }

            var maxTempCountry = weatherData.OrderByDescending(w => w.Temp).FirstOrDefault();
            var minTempCountry = weatherData.OrderBy(w => w.Temp).FirstOrDefault();
            var averageTemp = weatherData.Average(w => w.Temp);
            var distinctCountriesCount = weatherData.Select(w => w.Country).Distinct().Count();

            var allCountries = weatherData.Select(w => w.Country).Distinct().ToList();

            var firstClearSky = weatherData.FirstOrDefault(w => w.Description == "clear sky");
            var firstRain = weatherData.FirstOrDefault(w => w.Description == "rain");
            var firstFewClouds = weatherData.FirstOrDefault(w => w.Description == "few clouds");

            Console.WriteLine($"\n\nСтрана с максимальной температурой: {maxTempCountry?.Country}, Температура: {maxTempCountry?.Temp}°C");
            Console.WriteLine($"Страна с минимальной температурой: {minTempCountry?.Country}, Температура: {minTempCountry?.Temp}°C");
            Console.WriteLine($"\nСредняя температура в мире: {averageTemp}°C");
            Console.WriteLine($"Количество стран в коллекции: {distinctCountriesCount}");

            if (firstClearSky != null && firstClearSky.Country != null)
            {
                Console.WriteLine($"\nПервая страна с ясным небом: {firstClearSky.Country}, Местность: {firstClearSky.Name}");
            }
            else
            {
                Console.WriteLine("\nСтран с ясным небом нет");
            }

            if (firstRain != null && firstRain.Country != null)
            {
                Console.WriteLine($"Первая страна с дождем: {firstRain.Country}, Местность: {firstRain.Name}");
            }
            else
            {
                Console.WriteLine("Стран с дождем нет");
            }

            if (firstFewClouds != null && firstFewClouds.Country != null)
            {
                Console.WriteLine($"Первая страна с небольшими облаками: {firstFewClouds.Country}, Местность: {firstFewClouds.Name}");
            }
            else
            {
                Console.WriteLine("Стран с облаками нет");
            }

            Console.WriteLine("\nВсе страны:");
            foreach (var country in allCountries)
            {
                Console.WriteLine(country);
            }
        }
    }

    static async Task<Weather> GetWeatherData(string apiUrl, string apiKey, double latitude, double longitude)
    {
        using (HttpClient client = new HttpClient())
        {
            int maxAttempts = 10;
            int attempt = 0;

            while (attempt < maxAttempts)
            {
                var response = await client.GetStringAsync($"{apiUrl}?lat={latitude}&lon={longitude}&appid={apiKey}&units=metric");
                var weatherInfo = JsonSerializer.Deserialize<WeatherInfo>(response);

                if (weatherInfo != null && !string.IsNullOrEmpty(weatherInfo.sys.country))
                {
                    string country = weatherInfo.sys.country;
                    string name = weatherInfo.name;
                    double temp = weatherInfo.main.temp;
                    string description = weatherInfo.weather[0].description;

                    return new Weather
                    {
                        Country = country,
                        Name = name,
                        Temp = temp,
                        Description = description
                    };
                }

                attempt++;
            }

            return null;
        }
    }
}

class WeatherInfo
{
    public MainInfo main { get; set; }
    public WeatherDescription[] weather { get; set; }
    public string name { get; set; }
    public SysInfo sys { get; set; }
}

class MainInfo
{
    public double temp { get; set; }
}

class WeatherDescription
{
    public string description { get; set; }
}

class SysInfo
{
    public string country { get; set; }
}

class Weather
{
    public string Country { get; set; }
    public string Name { get; set; }
    public double Temp { get; set; }
    public string Description { get; set; }
}