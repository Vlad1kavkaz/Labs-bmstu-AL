using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        private List<City> cities;

        public MainWindow()
        {
            InitializeComponent();

            // Загрузка списка городов из файла
            cities = LoadCities("C:\\Users\\28218\\source\\repos\\WpfApp1\\WpfApp1\\city.txt");

            // Отображение списка городов в ListBox
            foreach (var city in cities)
            {
                cityListBox.Items.Add(city.Name);
            }
        }

        private async void GetWeatherButton_Click(object sender, RoutedEventArgs e)
        {
            // Получение выбранного города из ListBox
            string selectedCityName = cityListBox.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedCityName))
            {
                // Находим координаты выбранного города
                double latitude = cities.First(city => city.Name == selectedCityName).Latitude;
                double longitude = cities.First(city => city.Name == selectedCityName).Longitude;

                // Загрузка текущей погоды
                Weather weather = await GetWeatherData("https://api.openweathermap.org/data/2.5/weather", "78a42a81f9fcfc14fa64cee749e70b59", latitude, longitude);

                if (weather != null)
                {
                    MessageBox.Show($"Текущая погода в городе {selectedCityName}: Температура: {weather.Temp}°C, Описание: {weather.Description}");
                }
                else
                {
                    MessageBox.Show("Не удалось загрузить погоду");
                }
            }
            else
            {
                MessageBox.Show("Выберите город");
            }
        }

        private List<City> LoadCities(string filePath)
        {
            List<City> cities = new List<City>();

            string[] lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                string[] parts = line.Split(',', '\t');
                string name = parts[0];
                double latitude = double.Parse(parts[1].Replace('.', ','));
                double longitude = double.Parse(parts[2].Replace('.', ','));

                cities.Add(new City { Name = name, Latitude = latitude, Longitude = longitude });
            }

            return cities;
        }

        private async Task<Weather> GetWeatherData(string apiUrl, string apiKey, double latitude, double longitude)
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

    public class City
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class Weather
    {
        public string Country { get; set; }
        public string Name { get; set; }
        public double Temp { get; set; }
        public string Description { get; set; }
    }

    public class WeatherInfo
    {
        public SysInfo sys { get; set; }
        public string name { get; set; }
        public MainInfo main { get; set; }
        public List<WeatherDescription> weather { get; set; }
    }

    public class SysInfo
    {
        public string country { get; set; }
    }

    public class MainInfo
    {
        public double temp { get; set; }
    }

    public class WeatherDescription
    {
        public string description { get; set; }
    }
}
