using System.Net;
using MeteoApp.CONTROLLERS;
using MeteoApp.MODELS;
using MeteoApp.VIEWS;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;
using TeeChart.Xaml.WPF;
using System.Drawing;
using Steema.TeeChart;
using Steema.TeeChart.Editors.Series;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace MeteoApp
{
    public partial class Form1 : Form
    {
        private MeteoController metoController;
        private WeatherResponse temperaturaActual;
        private Forecast allTemperatures;
        List<string> lstIconUrls = new List<string>();
        NearestPoint toolNPTemp = null;
        NearestPoint toolNPHumidity = null;
        Annotation annotation;
        Steema.TeeChart.Axis vertAxis, horizAxis;
        private Dictionary<DateTime, string> diasConFechas = new Dictionary<DateTime, string>();
        private Dictionary<double, string> horasConFechas = new Dictionary<double, string>();
        private Dictionary<string, List<string>> iconosPorDia = new Dictionary<string, List<string>>();
        private Dictionary<string, Bitmap> imageCache = new Dictionary<string, Bitmap>();
        bool btnDay = false;

        public Form1()
        {
            InitializeComponent();
            metoController = new MeteoController();
            temperaturaActual = new WeatherResponse();
        }

        private async void GetTemperaturaActual(string city)
        {
            temperaturaActual = await metoController.GetCurrentTemperatura(city);
            if (temperaturaActual != null)
            {
                lblTemp.Text = Math.Truncate(temperaturaActual.Current.temp_c).ToString() + "ºC";
                lblCity.Text = temperaturaActual.Location.Name;
                lblProvincia.Text = $"{temperaturaActual.Location.Region} region";
                imgIcon.Load($"https:{temperaturaActual.Current.condition.Icon}");

            }
        }

        /// <summary>
        /// Retrieves the hourly weather evolution for the specified city and displays it in a bar chart.
        /// </summary>
        /// <param name="city">The name of the city to fetch the weather evolution for.</param>
        private async void GetAllTemperatures(string city)
        {
            Bar barSeries = (Bar)tChart1.Series[0];
            barSeries.Transparency = 85;
            tChart1.Panning.Allow = ScrollModes.None;


            if (tChart1.Series.Count > 0)
            {
                tChart1.Series[0].Clear();
                iconosPorDia.Clear();
                diasConFechas.Clear();
                horasConFechas.Clear();
            }

            allTemperatures = await metoController.GetEvolutionOfWeatherByCity(city);

            if (allTemperatures != null && allTemperatures.forecastday.Count > 0)
            {
                tChart1.Page.ScaleLastPage = true;

                // Iterate over the list of forecast days in allTemperatures
                foreach (var dia in allTemperatures.forecastday)
                {
                    DateTime fecha = DateTime.Parse(dia.date);
                    string dateKey = fecha.ToString("yyyy-MM-dd");
                    diasConFechas[fecha] = fecha.ToString("dddd");

                    List<string> tempIcons = new List<string>();

                    foreach (var hora in dia.hour)
                    {
                        DateTime fechaHora = DateTime.Parse(hora.time.ToString());

                        // Filter times, only processing those equal to or after the current time.
                        if (fechaHora < DateTime.Now)
                            continue;

                        double horaValor = fechaHora.ToOADate();
                        barSeries.Add(horaValor, hora.temp_c, fechaHora.ToString("HH:mm"));
                        horasConFechas[horaValor] = dateKey;
                        tempIcons.Add($"https:{hora.condition.Icon}");
                    }

                    if (tempIcons.Count > 0)
                    {
                        iconosPorDia[dateKey] = tempIcons;
                    }
                }

                tChart1.Page.MaxPointsPerPage = 11;
                tChart1.Page.Current = 1;

            }

            await Task.Delay(100); 
           
            if (barSeries.Count > 0)
            {
                double minX = barSeries.MinXValue();
                double maxX = barSeries.MaxXValue();

                if (maxX - minX < 10)
                {
                    maxX = minX + 10;
                }

                double visibleRange = (maxX - minX) / 20;

              
                hScrollBar1.Minimum = 0;
                hScrollBar1.Maximum = 990; //Provisional
                hScrollBar1.Value = 0;
                hScrollBar1.LargeChange = 10; 

                double initialMax = minX + visibleRange;
                tChart1.Axes.Bottom.SetMinMax(minX, initialMax);
            }
            else
            {
                MessageBox.Show("No data were found to show in the graph.");
            }

            tChart1.Invalidate();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tChart1.Page.Next();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tChart1.Page.Previous();
        }

        /// <summary>
        /// Retrieves the 10-day weather forecast for the specified city and displays it in a bar chart.
        /// </summary>
        /// <param name="city">The name of the city to fetch the weather forecast for.</param>
        private async void GetAllTemperaturesByDays(string city)
        {
            Bar barSeries;
            if (tChart1.Series.Count == 0)
            {
                barSeries = new Bar();
                barSeries.Transparency = 70;
                barSeries.ColorEach = true;
                tChart1.Series.Add(barSeries);
            }
            else
            {
                barSeries = (Bar)tChart1.Series[0];
            }

            barSeries.Clear();
            iconosPorDia.Clear();

            allTemperatures = await metoController.GetPrevisionBy10Days(city);

            if (allTemperatures != null)
            {
                tChart1.Header.Text = "FORECAST (10 days)";

                // Iterate through each forecast day in the retrieved weather data
                foreach (var dia in allTemperatures.forecastday)
                {
                    DateTime fecha = DateTime.Parse(dia.date);
                    string diaSemana = fecha.ToString("dddd");
                    string dateKey = fecha.ToString("yyyy-MM-dd");

                    // Store the relationship between the date and the weekday name
                    diasConFechas[fecha] = diaSemana;

                    barSeries.Add(dia.day.maxtemp_c, diaSemana);

                    string urlIcon = $"https:{dia.day.condition.Icon}";
                    iconosPorDia[dateKey] = new List<string> { urlIcon };

                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string city = txtBoxCity.Text;
            GetTemperaturaActual(city);
            GetAllTemperatures(city);
            GetTemperatureAndHumidity(city);
        }

        private async void GetTemperatureAndHumidity(string city)
        {

            Line lineTemperatura = (Line)tChart2.Series[0];
            lineTemperatura.Smoothed = false;
            lineTemperatura.Pointer.Visible = true;
            lineTemperatura.Stairs = false;

            Line lineHumidity = (Line)tChart2.Series[1];
            lineHumidity.Smoothed = false;
            lineHumidity.Pointer.Visible = true;
            lineHumidity.Stairs = false;

            if (tChart2.Series.Count > 0)
            {
                tChart2.Series[0].Clear();
                tChart2.Series[1].Clear();
            }


            lineTemperatura.VertAxis = VerticalAxis.Left;
            lineHumidity.VertAxis = VerticalAxis.Right;


            allTemperatures = await metoController.GetEvolutionOfHumidityAndTemperatureByCity(city);

            foreach (Tool tool in tChart2.Tools)
            {
                if (tool is NearestPoint)
                {
                    toolNPHumidity = (NearestPoint)tool;
                    toolNPTemp = (NearestPoint)tool;
                    break;
                }
            }

            annotation = new Annotation(tChart2.Chart);
            vertAxis = tChart2.Axes.Left;
            horizAxis = tChart2.Axes.Bottom;
            tChart2.MouseMove += TChart2_MouseMove;
            toolNPHumidity.Change += ToolNPHumidity_Change;


            if (allTemperatures != null)
            {
                foreach (var dia in allTemperatures.forecastday)
                {
                    tChart2.Header.Text = $"EVOLUCIÓ DEL DIA: {dia.date}";
                    tChart2.SubHeader.Text = "Temperatura / Humitat realitva";

                    foreach (var hora in dia.hour)
                    {
                        DateTime fechaHora = DateTime.Parse(hora.time.ToString());
                        if (fechaHora.Hour >= 0 && fechaHora.Hour <= 9 && (fechaHora.Minute == 0 || fechaHora.Minute == 30))
                        {
                            lineTemperatura.Add(hora.time, hora.temp_c);
                            lineHumidity.Add(hora.time, hora.humidity);

                            string iconUrl = $"https:{hora.condition.Icon}";
                            lstIconUrls.Add(iconUrl);
                        }
                    }
                }
            }

            tChart2.Axes.Left.SetMinMax(0, 20);
            tChart2.Axes.Left.Increment = 10;
            tChart2.Axes.Left.Automatic = false;
            tChart2.Axes.Left.AutomaticMinimum = false;
            tChart2.Axes.Left.AutomaticMaximum = false;

            tChart2.Axes.Right.SetMinMax(0, 100);
            tChart2.Axes.Right.Increment = 50;
            tChart2.Axes.Right.Automatic = false;
            tChart2.Axes.Right.AutomaticMinimum = false;
            tChart2.Axes.Right.AutomaticMaximum = false;


        }

        private void ToolNPHumidity_Change(object? sender, EventArgs e)
        {
            Steema.TeeChart.Styles.Line graficoLiniaTemperature = (Line)tChart2.Series[0];
            Line graficoLiniaHumidity = (Line)tChart2.Series[1];

            annotation.Text = $"Temperature: {graficoLiniaTemperature.YValues[toolNPTemp.Point]}ºC \n " +
                              $"Humidity: {graficoLiniaHumidity.YValues[toolNPHumidity.Point]}%";

        }

        private void TChart2_MouseMove(object? sender, MouseEventArgs e)
        {
            toolNPHumidity.Active = e.X >= horizAxis.IStartPos && e.X <= horizAxis.IEndPos &&
            e.Y >= vertAxis.IStartPos && e.Y <= vertAxis.IEndPos;

            toolNPTemp.Active = e.X >= horizAxis.IStartPos && e.X <= horizAxis.IEndPos &&
            e.Y >= vertAxis.IStartPos && e.Y <= vertAxis.IEndPos;

            // Activate annotation if at least one of the tools is active
            annotation.Active = toolNPHumidity.Active || toolNPTemp.Active;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnSearch;
        }

        private void btnDays_Click(object sender, EventArgs e)
        {
            string city = txtBoxCity.Text;
            GetAllTemperaturesByDays(city);
            btnDay = true;

        }

        private void tChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.IGraphics3D g)
        {
            foreach (Series s in tChart1.Series)
            {
                if (!(s is Bar)) continue;

                Dictionary<string, List<int>> datosAgrupados = new Dictionary<string, List<int>>();

                for (int i = 0; i < s.Count; i++)
                {
                    string dateKey;

                    // Case 1: Data represents hours (GetAllTemperatures)
                    if (horasConFechas.ContainsKey(s.XValues[i]))
                    {
                        dateKey = horasConFechas[s.XValues[i]];
                    }
                    // Case 2: Data represents days (GetAllTemperaturesByDays)
                    else if (diasConFechas.ContainsValue(s.Labels[i]))
                    {
                        dateKey = diasConFechas.FirstOrDefault(x => x.Value == s.Labels[i]).Key.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        continue;
                    }

                    if (!datosAgrupados.ContainsKey(dateKey))
                        datosAgrupados[dateKey] = new List<int>();

                    datosAgrupados[dateKey].Add(i);
                }

                foreach (var grupo in datosAgrupados)
                {
                    int p = 0;
                    string dateKey = grupo.Key;

                    if (!iconosPorDia.ContainsKey(dateKey) || iconosPorDia[dateKey].Count == 0)
                        continue;

                    foreach (int index in grupo.Value)
                    {
                        Bitmap objBitmap;
                        if (s.Labels[index].Contains(":"))
                        {
                            int iconIndex = p % iconosPorDia[dateKey].Count;
                            objBitmap = LoadBitmapFromUrl(iconosPorDia[dateKey][iconIndex]);
                        }
                        else
                        {
                            objBitmap = LoadBitmapFromUrl(iconosPorDia[dateKey][0]);
                        }

                        Steema.TeeChart.Drawing.TImage tChartImage = new Steema.TeeChart.Drawing.TImage(objBitmap);

                        int iconWidth = objBitmap.Width;
                        int iconHeight = objBitmap.Height;
                        int xPos = (int)tChart1.Axes.Bottom.CalcPosValue(s.XValues[index]) - (iconWidth / 2);
                        int yPos = (int)tChart1.Axes.Left.CalcPosValue(s.YValues[index]) - (iconHeight / 2);

                        g.Draw(xPos, yPos, tChartImage);

                        string txt = $"{s.YValues[index]}ºC";
                        int textWidth = (int)(g.TextWidth(txt) / 2);
                        int textYPos = yPos + iconHeight + 5;
                        int textXPos = xPos + (iconWidth / 2) - textWidth;

                        g.TextOut(textXPos, textYPos, txt);

                        p++;
                    }
                }
            }
        }

        private Bitmap LoadBitmapFromUrl(string url)
        {
            if (imageCache.ContainsKey(url))
            {
                return imageCache[url];
            }

            using (WebClient client = new WebClient())
            {
                byte[] imageBytes = client.DownloadData(url);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    Bitmap bitmap = new Bitmap(Image.FromStream(ms));
                    imageCache[url] = bitmap; // Cacheamos la imagen
                    return bitmap;
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                txtBoxCity.Text = listBox1.SelectedItem.ToString();
            }
        }

        private void tChart1_ClickSeries(object sender, Series s, int valueIndex, Steema.TeeChart.Drawing.MouseEventArgs e)
        {
            if (s is Bar && valueIndex >= 0)
            {

                string valor = bar1.Labels[valueIndex];
                double horaValor = s.XValues[valueIndex];

                DateTime fechaHoraSeleccionada = DateTime.FromOADate(horaValor);

                int horas = fechaHoraSeleccionada.Hour;
                int minutos = fechaHoraSeleccionada.Minute;

                DateTime fechaSeleccionada = DateTime.Today.Date;
                TimeSpan horaSeleccionada = new TimeSpan(horas, minutos, 0);

                string city = txtBoxCity.Text;
                Form2 form = new Form2(allTemperatures, valor, fechaSeleccionada, horaSeleccionada, metoController, city, btnDay);
                form.ShowDialog();
            }
        }

        //private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        //{
        //    if (tChart1.Series.Count == 0 || tChart1.Series[0].Count == 0 || tChart1.Page.Count == 0)
        //        return;

        //    int newPage = hScrollBar1.Value + 1;
        //    if(newPage != tChart1.Page.Current)
        //    {
        //        tChart1.Page.Current = newPage;
        //        tChart1.Refresh();
        //    }
        //}

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            tChart1.Axes.Bottom.Automatic = false;

            if (tChart1.Series.Count == 0 || tChart1.Series[0].Count == 0)
                return;

            // Get the minimum and maximum value of the X-axis according to the position of the ScrollBar
            Bar barSeries = (Bar)tChart1.Series[0];
            double minX = barSeries.MinXValue();
            double maxX = barSeries.MaxXValue();
            double visibleRange = (maxX - minX) / 7;

            // Calculate the new display range on the chart
            double newMin = minX + e.NewValue * (maxX - minX - visibleRange) / hScrollBar1.Maximum;
            double newMax = newMin + visibleRange;

            // Prevent the range from being out of bounds
            if (newMax > maxX)
            {
                newMax = maxX;
                newMin = newMax - visibleRange;
            }

            // Avoid out-of-range values
            if (newMin < minX)
            {
                newMin = minX;
                newMax = newMin + visibleRange;
            }

            // Update X-axis with new values
            tChart1.Axes.Bottom.SetMinMax(newMin, newMax);
            tChart1.Invalidate();
        }

        private void tChart1_Scroll(object sender, EventArgs e)
        {
            // Sincronizar el ScrollBar con la página actual
            if (tChart1.Page.Current >= hScrollBar1.Minimum && tChart1.Page.Current <= hScrollBar1.Maximum)
                hScrollBar1.Value = tChart1.Page.Current - 1;
        }
    }
}
