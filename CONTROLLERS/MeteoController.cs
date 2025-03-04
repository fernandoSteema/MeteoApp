using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MeteoApp.MODELS;
using Newtonsoft.Json;

namespace MeteoApp.CONTROLLERS
{
    public class MeteoController
    {
        private HttpClient client;

        public MeteoController()
        {
            client = new HttpClient();
        }

        public async Task<WeatherResponse> GetCurrentTemperatura(string city)
        {
            try
            {
                string url = $"http://api.weatherapi.com/v1/current.json?key=c23a2b4ddd284dfcbb891155252802&q={city}&aqi=no";

              
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();
                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseJson);


                return weatherResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la temperatura: {ex.Message}");
            }
        }

        public async Task<Forecast> GetEvolutionOfWeatherByCity(string city)
        {
            try
            {
                string url = $"http://api.weatherapi.com/v1/forecast.json?key=c23a2b4ddd284dfcbb891155252802&q={city}&days=3";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();
                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseJson);

                return weatherResponse.Forecast;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las temperaturas diarias: {ex.Message}");
            }
        }
        public async Task<Forecast> GetEvolutionOfHumidityAndTemperatureByCity(string city)
        {
            try
            {
                string url = $"http://api.weatherapi.com/v1/forecast.json?key=c23a2b4ddd284dfcbb891155252802&q={city}&days=1";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();
                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseJson);

                return weatherResponse.Forecast;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las temperaturas diarias: {ex.Message}");
            }
        }
        public async Task<Forecast> GetPrevisionBy10Days(string city)
        {
            try
            {
                string url = $"http://api.weatherapi.com/v1/forecast.json?key=c23a2b4ddd284dfcbb891155252802&q={city}&days=10";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();
                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseJson);

                return weatherResponse.Forecast;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las temperaturas diarias: {ex.Message}");
            }
        }


    }
}
