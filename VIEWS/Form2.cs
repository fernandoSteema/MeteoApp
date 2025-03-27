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
        private string _diaSeleccionado;
        private DateTime _fechaSeleccionada;
        private TimeSpan _horaSeleccionada;
        private MeteoController _meteoController;
        private string _city;
        private bool _btnDay = false;


        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Forecast allTemperatures, string diaSeleccionado, DateTime fechaSeleccionada, TimeSpan horaSeleccionada, MeteoController meteoController, string city, bool btnDay)
        {
            InitializeComponent();
            _allTemperatures = allTemperatures;
            _diaSeleccionado = diaSeleccionado;
            _fechaSeleccionada = fechaSeleccionada;
            _horaSeleccionada = horaSeleccionada;
            _meteoController = meteoController;
            _city = city;
            _btnDay = btnDay;
        }

        public async Task CargarDatos()
        {
            _allTemperatures = await _meteoController.GetEvolutionOfWeatherByCity(_city);

            if (_allTemperatures != null && !_btnDay)
            {
                lblFecha.Text = $"{_fechaSeleccionada:yyyy-MM-dd}";
                lblHora.Text = $"Today at {_horaSeleccionada}";

                foreach (var dia in _allTemperatures.forecastday)
                {
                    foreach (var hora in dia.hour)
                    {
                        if (hora.time.TimeOfDay.ToString() == _horaSeleccionada.ToString())
                        {
                            lblWind.Text = $"🡢 {hora.wind_kph} km/h";
                            lblCloud.Text = $"☁︎ {hora.cloud}%";
                            lblSnow.Text = $"❄️ {hora.snow_cm} cm";
                            lblRain.Text = $"☂️ {hora.precip_mm} mm";
                            lblPrecip.Text = $"☂️ {dia.day.daily_chance_of_rain}%";
                            lblHumity.Text = $"💧 {hora.humidity}%";
                            lblPressure.Text = $"🕛 {hora.pressure_mb} hPa";
                        }
                    }
                }
            }
            else if (_btnDay)
            {
                _allTemperatures = await _meteoController.GetPrevisionBy10Days(_city);
                if (_allTemperatures != null)
                {
                    foreach (var dia in _allTemperatures.forecastday)
                    {
                        DateTime fecha = DateTime.Parse(dia.date);
                        string diaSemana = fecha.ToString("dddd");

                        if (diaSemana == _diaSeleccionado)
                        {
                            lblFecha.Text = $"{dia.date}";
                            lblHora.Text = $"{_diaSeleccionado}";

                            lblWind.Text = $"🡢 {dia.day.maxwind_kph} km/h";
                            lblSnow.Text = $"❄️ {dia.day.daily_chance_of_snow} %";
                            lblRain.Text = $"☂️ {dia.day.totalprecip_mm} mm";
                            lblPrecip.Text = $"☂️ {dia.day.daily_chance_of_rain}%";
                            lblHumity.Text = $"💧 {dia.day.avghumidity}%";
                            lblPressure.Text = $"🕛 {dia.day.maxtemp_c} ºC";
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
