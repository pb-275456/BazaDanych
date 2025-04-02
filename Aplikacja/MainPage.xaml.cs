using BazaDanych;

namespace Aplikacja
{
    public partial class MainPage : ContentPage
    {
        private Controller controller;

        public MainPage()
        {
            InitializeComponent();
            controller = new Controller();
        }


        private bool validateCityInput(string cityName)
        {
            if(!string.IsNullOrWhiteSpace(cityName))
            {
                CityInput.BackgroundColor = Color.FromArgb("6ACF65");
                CityInput.TextColor = Color.FromArgb("FFFFFF");
                return true;
            }
            CityInput.BackgroundColor = Color.FromArgb("FF0000");
            CityInput.TextColor = Color.FromArgb("FFFFFF");
            return false;
        }

        private async void OnGetWeatherClicked(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now.Date;
            var cityName = CityInput.Text;
            if (!validateCityInput(cityName))
            {
                return;
            }
            
            //jak nie ma danych to pobieramy i dodajemy
            if (!controller.CheckEntryInDatabase(cityName, date))
            {
                try
                {
                    await controller.GetData(cityName);
                    controller.addEntry();
                }
                catch (HttpRequestException ex)
                {
                    //lapiemy blad, np nie ma takiego miasta
                    await DisplayAlert("Error", $"Failed to fetch weather data: {ex.Message}", "OK");
                    return;
                }
            }
            
            //jak sa dane/pobierzemy to wyswietlamy
            var entries = controller.getWeatherForCityDate(cityName, date);
            if (entries.Any())
            {
                await controller.GetData(cityName);
                WeatherListView.ItemsSource = entries;
                WeatherListView.IsVisible = true;
            }
            else
            {
                WeatherListView.IsVisible = false;
                await DisplayAlert("No Data", "No weather data available for the selected city.", "OK");
            }
        }

        private async void OnGetAllWeatherClicked(object sender, EventArgs e)
        {
            var cityName = CityInput.Text;
            if (!validateCityInput(cityName))
            {
                return;
            }

            //jak nie ma danych to pobieramy i dodajemy
            
            var entries = controller.getWeatherByCity(cityName);

            if (entries.Any())
            {
                await controller.GetData(cityName);
                WeatherListView.ItemsSource = entries;
                WeatherListView.IsVisible = true;
            }
            else
            {
                WeatherListView.IsVisible = false;
                await DisplayAlert("No Data", "No weather data available for the selected city.", "OK");
            }
        }

    }

}
