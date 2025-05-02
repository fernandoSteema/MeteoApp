using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeteoApp.CONTROLLERS;
using MeteoApp.LANGUAGES;
using MeteoApp.MODELS;

namespace MeteoApp.VIEWS
{
    public partial class Form2 : Form
    {
        private Forecast _allTemperatures;
        private string _selectedDay;
        private DateTime _dateSelected;
        private TimeSpan _hourSelected;
        private WeatherController _weatherController;
        private string _city;
        private bool _btnDay = false;


        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Forecast allTemperatures, string selectedDay, DateTime dateSelected, TimeSpan hourSelected, WeatherController weatherController, string city, bool btnDay)
        {
            InitializeComponent();
            _allTemperatures = allTemperatures;
            _selectedDay = selectedDay;
            _dateSelected = dateSelected;
            _hourSelected = hourSelected;
            _weatherController = weatherController;
            _city = city;
            _btnDay = btnDay;
        }

        public async Task LoadData()
        {
            _allTemperatures = await _weatherController.GetEvolutionOfWeatherByCity(_city);

            if (_allTemperatures != null && !_btnDay)
            {
                lblFecha.Text = $"{_dateSelected:yyyy-MM-dd}";
                lblHora.Text = $"Today at {_hourSelected}";

                foreach (var day in _allTemperatures.forecastday)
                {
                    foreach (var hour in day.hour)
                    {
                        if (hour.time.TimeOfDay.ToString() == _hourSelected.ToString())
                        {
                            lblWind.Text = $"🡢 {hour.wind_kph} km/h";
                            lblCloud.Text = $"☁︎ {hour.cloud}%";
                            lblSnow.Text = $"❄️ {hour.snow_cm} cm";
                            lblRain.Text = $"☂️ {hour.precip_mm} mm";
                            lblPrecip.Text = $"☂️ {day.day.daily_chance_of_rain}%";
                            lblHumity.Text = $"💧 {hour.humidity}%";
                            lblPressure.Text = $"🕛 {hour.pressure_mb} hPa";
                        }
                    }
                }
            }
            else if (_btnDay)
            {
                _allTemperatures = await _weatherController.GetPrevisionBy10Days(_city);
                if (_allTemperatures != null)
                {
                    foreach (Forecastday day in _allTemperatures.forecastday)
                    {
                        DateTime date = DateTime.Parse(day.date);
                        string dayOfTheWeek = date.ToString("dddd");

                        if (dayOfTheWeek == _selectedDay)
                        {
                            lblFecha.Text = $"{day.date}";
                            lblHora.Text = $"{_selectedDay}";

                            lblWind.Text = $"🡢 {day.day.maxwind_kph} km/h";
                            lblSnow.Text = $"❄️ {day.day.daily_chance_of_snow} %";
                            lblRain.Text = $"☂️ {day.day.totalprecip_mm} mm";
                            lblPrecip.Text = $"☂️ {day.day.daily_chance_of_rain}%";
                            lblHumity.Text = $"💧 {day.day.avghumidity}%";
                            lblPressure.Text = $"🕛 {day.day.maxtemp_c} ºC";
                        }
                    }
                }
            }

            Language.Controllers(this);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
