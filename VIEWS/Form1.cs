using System.Net;
using MeteoApp.CONTROLLERS;
using MeteoApp.MODELS;
using MeteoApp.VIEWS;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;
using Steema.TeeChart;
using MeteoApp.LANGUAGES;
using PdfSharp.Pdf.Annotations;
using Steema.TeeChart.Editors.Tools;
using Steema.TeeChart.Languages;
using System;
using System.Globalization;

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
        public bool btnDay = false;
        bool eventAdded = false;
        Form2 form = new Form2();

        public Form1()
        {
            InitializeComponent();
            metoController = new MeteoController();
            temperaturaActual = new WeatherResponse();
            Update();
            Language.UpdateMenuStrip(menuStrip1);
            cmbBoxDays.Visible = false;
        }

        public void Update()
        {
            Language.Controllers(this);
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

        private double? firstBarXNextDay = null;
        public void UpdateAnnotations()
        {
            // Remove previous annotations to avoid duplicates
            for (int i = tChart1.Tools.Count - 1; i >= 0; i--)
            {
                if (tChart1.Tools[i] is Annotation)
                {
                    tChart1.Tools.RemoveAt(i);
                }
            }

            foreach (var verticalLineX in verticalLinePositions)
            {
                // Draw the vertical line
                int pixelX = tChart1.Axes.Bottom.CalcXPosValue(verticalLineX);

                // Convert the value of OADate to DateTime
                DateTime dateFrom = DateTime.FromOADate(verticalLineX);
                DateTime dateTo = dateFrom.AddDays(1);

                // Get the name of the days from the dictionary "diasConFechas"
                string day1 = diasConFechas.FirstOrDefault(d => d.Key.Date == dateFrom.Date).Value;
                string day2 = diasConFechas.FirstOrDefault(d => d.Key.Date == dateTo.Date).Value;

                day1 = day1?.Trim();
                day2 = day2?.Trim();

                if (day2 != null)
                {
                    // If the condition is met, then it translates the translation of its respective attribute+
                    day1 = Language.info.ContainsKey(day1) ? Language.info[day1] : day1;
                    day2 = Language.info.ContainsKey(day2) ? Language.info[day2] : day2;
                }

                // Annotation of the first day 
                Annotation annotationLeft = new Annotation(tChart1.Chart);
                annotationLeft.Text = day1;
                annotationLeft.Left = pixelX - 95 - 40;
                annotationLeft.Top = tChart1.Axes.Left.IStartPos + 10;
                annotationLeft.Shape.Transparent = true;
                tChart1.Tools.Add(annotationLeft);

                // Create second day annotation only if `day2` is not null
                if (day2 != null)
                {
                    Annotation annotationRight = new Annotation(tChart1.Chart);
                    annotationRight.Text = day2;
                    annotationRight.Left = pixelX + 24;
                    annotationRight.Top = tChart1.Axes.Left.IStartPos + 10;
                    annotationRight.Shape.Transparent = true;
                    tChart1.Tools.Add(annotationRight);
                }
            }
        }

        public void UpdateForecastDays()
        {
            if (allTemperatures == null || allTemperatures.forecastday.Count < 3)
            {
                return;
            }

            int selectedIndex = cmbBoxDays.SelectedIndex; // Guardar selección actual
            string selectedDay = (cmbBoxDays.SelectedItem != null) ? cmbBoxDays.SelectedItem.ToString() : "";

            cmbBoxDays.Items.Clear();

            for (int i = 0; i < 3; i++)
            {
                DateTime fecha = DateTime.Parse(allTemperatures.forecastday[i].date);
                string diaSemana = fecha.ToString("dddd");

                // Traducir si existe en el diccionario de idiomas
                if (Language.info.ContainsKey(diaSemana))
                {
                    diaSemana = Language.info[diaSemana];
                }

                string diaFormateado = $"{diaSemana} ({fecha:dd/MM})";
                string dateKey = fecha.ToString("yyyy-MM-dd");

                diasConFechas[fecha] = diaFormateado;
                cmbBoxDays.Items.Add(diaFormateado);
            }

            // Restaurar la selección previa si sigue existiendo
            if (!string.IsNullOrEmpty(selectedDay) && cmbBoxDays.Items.Contains(selectedDay))
            {
                cmbBoxDays.SelectedItem = selectedDay;
            }
            else if (cmbBoxDays.Items.Count > 0)
            {
                cmbBoxDays.SelectedIndex = 0;
            }
        }


        /// <summary>
        /// Retrieves the hourly weather evolution for the specified city and displays it in a bar chart.
        /// </summary>
        /// <param name="city">The name of the city to fetch the weather evolution for.</param>
        private List<double> verticalLinePositions = new List<double>();
        private double? lastBarX;
        public string currentCity;
        private Dictionary<string, Tuple<double, double>> rangoDias = new Dictionary<string, Tuple<double, double>>();

        public async void GetAllTemperatures(string city)
        {
            cmbBoxDays.Visible = true;

            Bar barSeries = (Bar)tChart1.Series[0];
            barSeries.Transparency = 85;
            tChart1.Panning.Allow = ScrollModes.None;
            hScrollBar1.Visible = true;
            btnDay = false;
            currentCity = city;

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
                double? firstBarX = null;
                DateTime? lastBarTime = null;
                lastBarX = null;
                firstBarXNextDay = null;

                foreach (var dia in allTemperatures.forecastday)
                {
                    DateTime fecha = DateTime.Parse(dia.date);
                    string dateKey = fecha.ToString("yyyy-MM-dd");
                    diasConFechas[fecha] = fecha.ToString("dddd");

                    List<string> tempIcons = new List<string>();

                    // Reiniciar el primer valor del día actual
                    firstBarX = null;

                    foreach (var hora in dia.hour)
                    {
                        DateTime fechaHora = DateTime.Parse(hora.time.ToString());

                        if (fechaHora < DateTime.Now)
                            continue;

                        double horaValor = fechaHora.ToOADate();
                        barSeries.Add(horaValor, hora.temp_c, fechaHora.ToString("HH:mm"));
                        horasConFechas[horaValor] = dateKey;
                        tempIcons.Add($"https:{hora.condition.Icon}");

                        // Guardar el primer valor X del día
                        if (firstBarX == null)
                            firstBarX = horaValor;

                        // Guardar la última barra del día actual
                        lastBarTime = fechaHora;
                        lastBarX = horaValor; 
                        
                        rangoDias[dateKey] = new Tuple<double, double>(firstBarX ?? 0, lastBarX ?? 0);
                    }

                    if (tempIcons.Count > 0)
                    {
                        iconosPorDia[dateKey] = tempIcons;
                    }

                    // Asignamos el primer valor del día siguiente al primer valor de X
                    if (firstBarX != null)
                        firstBarXNextDay = firstBarX;

                    if (lastBarTime != null && firstBarXNextDay != null)
                    {
                        DateTime date23 = fecha.AddHours(23);
                        DateTime date00 = fecha.AddDays(1).AddHours(0);

                        // Usamos los valores de `ToOADate` para convertir las fechas a valores flotantes
                        double x23 = date23.ToOADate();
                        double x00 = date00.ToOADate();

                        // Calculamos las posiciones medias
                        double verticalLineX = (x23 + x00) / 2;
                        verticalLinePositions.Add(verticalLineX); // Guardamos la posición de la línea
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
                hScrollBar1.Maximum = 990; // Provisional
                hScrollBar1.Value = 0;
                hScrollBar1.LargeChange = 10;

                double initialMax = minX + visibleRange;
                tChart1.Axes.Bottom.SetMinMax(minX, initialMax);
            }
            else
            {
                MessageBox.Show("No se encontraron datos para mostrar en el gráfico.");
            }

            tChart1.Refresh();
            UpdateAnnotations();
            LoadForecastDays();
        }
        private void LoadForecastDays()
        {
            if (allTemperatures == null || allTemperatures.forecastday.Count < 3)
            {
                MessageBox.Show("No hay suficientes datos de pronóstico.");
                return;
            }

            cmbBoxDays.Items.Clear();

            for (int i = 0; i < 3; i++)
            {
                DateTime fecha = DateTime.Parse(allTemperatures.forecastday[i].date);
                string diaSemana = fecha.ToString("dddd");

                // Traducir si existe en el diccionario de idiomas
                if (Language.info.ContainsKey(diaSemana))
                {
                    diaSemana = Language.info[diaSemana];
                }

                string diaFormateado = $"{diaSemana} ({fecha:dd/MM})";

                string dateKey = fecha.ToString("yyyy-MM-dd");

                diasConFechas[fecha] = diaFormateado;

                cmbBoxDays.Items.Add(diaFormateado);
            }

            // Seleccionar el primer día por defecto si hay elementos en el ComboBox
            if (cmbBoxDays.Items.Count > 0)
            {
                cmbBoxDays.SelectedIndex = 0;
            }
        }


        /// <summary>
        /// Retrieves the 10-day weather forecast for the specified city and displays it in a bar chart.
        /// </summary>
        /// <param name="city">The name of the city to fetch the weather forecast for.</param>
        /// 
        public async void GetAllTemperaturesByDays(string city)
        {
            cmbBoxDays.Visible = false;

            Bar barSeries = (tChart1.Series.Count == 0) ? new Bar() : (Bar)tChart1.Series[0];

            if (tChart1.Series.Count == 0)
            {
                barSeries.Transparency = 70;
                barSeries.ColorEach = true;
                tChart1.Series.Add(barSeries);
            }

            hScrollBar1.Visible = false;
            btnDay = true;
            currentCity = city;

            // Limpiar datos previos
            barSeries.Clear();
            iconosPorDia.Clear();
            diasConFechas.Clear();

            // Eliminar anotaciones previas
            for (int i = tChart1.Tools.Count - 1; i >= 0; i--)
            {
                if (tChart1.Tools[i] is Annotation)
                {
                    tChart1.Tools.RemoveAt(i);
                }
            }

            allTemperatures = await metoController.GetPrevisionBy10Days(city);

            if (allTemperatures != null && allTemperatures.forecastday.Count > 0)
            {
                // Traducir título del gráfico
                tChart1.Header.Text = Language.info.ContainsKey("FORECAST_10_DAYS")
                    ? Language.info["FORECAST_10_DAYS"]
                    : "FORECAST (10 days)";

                foreach (var dia in allTemperatures.forecastday)
                {
                    DateTime fecha = DateTime.Parse(dia.date);
                    string diaSemana = fecha.ToString("dddd");

                    // Traducir el nombre del día si existe en el diccionario de idiomas
                    if (Language.info.ContainsKey(diaSemana))
                    {
                        diaSemana = Language.info[diaSemana];
                    }

                    string dateKey = fecha.ToString("yyyy-MM-dd");

                    // Almacenar relación fecha-nombre del día
                    diasConFechas[fecha] = diaSemana;

                    // Agregar datos al gráfico
                    barSeries.Add(dia.day.maxtemp_c, diaSemana);

                    // Guardar icono del clima
                    string urlIcon = $"https:{dia.day.condition.Icon}";
                    iconosPorDia[dateKey] = new List<string> { urlIcon };
                }

                // Configurar paginación para 10 días
                tChart1.Page.MaxPointsPerPage = 10;
                tChart1.Page.Current = 1;
            }

            // Forzar actualización del gráfico
            tChart1.Axes.Bottom.Automatic = true;
            tChart1.Invalidate();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string city = txtBoxCity.Text;
            GetTemperaturaActual(city);

            // Suscribir el evento solo una vez para evitar múltiples dibujos
            if (!eventAdded)
            {
                tChart1.AfterDraw += TChart1_AfterDraw; ; ;
                eventAdded = true;
            }
            GetAllTemperatures(city);
            GetTemperatureAndHumidity(city);
        }

        /// <summary>
        /// Draws vertical lines on the chart at specified X-axis positions after the chart is rendered.
        /// </summary>
        private void TChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.IGraphics3D g)
        {
            int offsetX = 34;
            foreach (var verticalLineX in verticalLinePositions)
            {
                int pixelX = tChart1.Axes.Bottom.CalcXPosValue(verticalLineX);
                g.Line(pixelX, tChart1.Axes.Left.IStartPos, pixelX, tChart1.Axes.Left.IEndPos);
            }
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
                    string evolutionText = Language.info.ContainsKey("EVOLUTION_OF_DAY") ? Language.info["EVOLUTION_OF_DAY"] : "EVOLUCIÓ DEL DIA";
                    string tempHumText = Language.info.ContainsKey("TEMP_HUMIDITY") ? Language.info["TEMP_HUMIDITY"] : "Temperatura / Humitat relativa";

                    tChart2.Header.Text = $"{evolutionText}: {dia.date}";
                    tChart2.SubHeader.Text = tempHumText;

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

        public void UpdateChartLanguage()
        {
            if (allTemperatures != null && allTemperatures.forecastday.Count > 0)
            {
                // Obtener traducciones
                string evolutionText = Language.info.ContainsKey("EVOLUTION_OF_DAY") ? Language.info["EVOLUTION_OF_DAY"] : "EVOLUCIÓ DEL DIA";
                string tempHumText = Language.info.ContainsKey("TEMP_HUMIDITY") ? Language.info["TEMP_HUMIDITY"] : "Temperatura / Humitat relativa";

                // Actualizar encabezados del gráfico sin modificar los datos
                tChart2.Header.Text = $"{evolutionText}: {allTemperatures.forecastday[0].date}";
                tChart2.SubHeader.Text = tempHumText;

                tChart2.Refresh();
            }

            if (tChart2.Series.Count >= 2)
            {
                string tempText = Language.info.ContainsKey("TemperatureTchart2") ? Language.info["TemperatureTchart2"] : "Temperatura";
                string humText = Language.info.ContainsKey("HumidityTchart2") ? Language.info["HumidityTchart2"] : "Humitat";

                tChart2.Series[0].Title = tempText;
                tChart2.Series[1].Title = humText;

                tChart2.Refresh();
            }
        }

        private void ToolNPHumidity_Change(object? sender, EventArgs e)
        {
            Line graficoLiniaTemperature = (Line)tChart2.Series[0];
            Line graficoLiniaHumidity = (Line)tChart2.Series[1];

            string tempText = Language.info.ContainsKey("Temperature") ? Language.info["Temperature"] : "Temperature";
            string humText = Language.info.ContainsKey("Humidity") ? Language.info["Humidity"] : "Humidity";

            annotation.Text = $"{tempText}: {graficoLiniaTemperature.YValues[toolNPTemp.Point]}ºC \n " +
                              $" {humText}: {graficoLiniaHumidity.YValues[toolNPHumidity.Point]}%";

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
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.WindowState = FormWindowState.Maximized;
            this.AcceptButton = btnSearch;
        }

        private void btnDays_Click(object sender, EventArgs e)
        {
            btnDay = true;
            string city = txtBoxCity.Text;
            GetAllTemperaturesByDays(city);
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

                // Crear y mostrar Form2
                Form2 form = new Form2(allTemperatures, valor, fechaSeleccionada, horaSeleccionada, metoController, city, btnDay);
                form.Show();  // Show en vez de ShowDialog para poder usar await

                // Esperar a que los datos se carguen correctamente
                _ = form.CargarDatos();
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // Si btnDay está activo, el scroll no debe funcionar
            if (btnDay) return;

            tChart1.Axes.Bottom.Automatic = false;

            if (tChart1.Series.Count == 0 || tChart1.Series[0].Count == 0)
                return;

            // Obtener el valor mínimo y máximo del eje X según la posición del ScrollBar
            Bar barSeries = (Bar)tChart1.Series[0];
            double minX = barSeries.MinXValue();
            double maxX = barSeries.MaxXValue();
            double visibleRange = (maxX - minX) / 7;

            // Calcular el nuevo rango de visualización en el gráfico
            double newMin = minX + e.NewValue * (maxX - minX - visibleRange) / hScrollBar1.Maximum;
            double newMax = newMin + visibleRange;

            // Evitar que el rango se salga de los límites
            if (newMax > maxX)
            {
                newMax = maxX;
                newMin = newMax - visibleRange;
            }

            // Evitar valores fuera de rango
            if (newMin < minX)
            {
                newMin = minX;
                newMax = newMin + visibleRange;
            }

            // Actualizar el eje X con los nuevos valores
            tChart1.Axes.Bottom.SetMinMax(newMin, newMax);
            UpdateAnnotations();

            //PARTE DEL CMBOX:
            foreach(var kvp in rangoDias)
            {
                double minDay = kvp.Value.Item1;
                double maxDay = kvp.Value.Item2;

                if (newMin >= minDay && newMin <= maxDay)
                {
                    string formattedDay = diasConFechas[DateTime.Parse(kvp.Key)];
                    int index = cmbBoxDays.Items.IndexOf(formattedDay);
                    if (index != -1 && cmbBoxDays.SelectedIndex != index)
                    {
                        cmbBoxDays.SelectedIndex = index;
                    }
                    break;
                }
            }
        }

        private void tChart1_Scroll(object sender, EventArgs e)
        {
            // Sincronizar el ScrollBar con la página actual
            if (tChart1.Page.Current >= hScrollBar1.Minimum && tChart1.Page.Current <= hScrollBar1.Maximum)
                hScrollBar1.Value = tChart1.Page.Current - 1;
        }

        private void englishToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Language.ChangeLenguage("en.txt");
            Update();
            Language.UpdateMenuStrip(menuStrip1);

        }

        private void catalanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Language.ChangeLenguage("ca.txt");
            Update();
            Language.UpdateMenuStrip(menuStrip1);

        }

        private void spanishToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Language.ChangeLenguage("es.txt");
            Update();
            Language.UpdateMenuStrip(menuStrip1);
        }

        private void btnHours_Click(object sender, EventArgs e)
        {
            string city = txtBoxCity.Text;
            GetTemperaturaActual(city);
            GetAllTemperatures(city);
            GetTemperatureAndHumidity(city);
        }

        private void cmbBoxDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxDays.SelectedItem == null) return;

            string selectedDay = cmbBoxDays.SelectedItem.ToString(); 
            string fechaStr = selectedDay.Split('(')[1].Split(')')[0];


            if (DateTime.TryParseExact(fechaStr, "dd/MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                string dateKey = parsedDate.ToString("yyyy-MM-dd");

                if (rangoDias.ContainsKey(dateKey))
                {
                    double minX = rangoDias[dateKey].Item1;
                    double maxX = rangoDias[dateKey].Item2;

                    tChart1.Axes.Bottom.SetMinMax(minX, maxX);

                    double globalMinX = tChart1.Series[0].MinXValue();
                    double globalMaxX = tChart1.Series[0].MaxXValue();
                    double totalRange = globalMaxX - globalMinX;

                    double selectedRange = minX - globalMinX;
                    int sliderValue = (int) ((selectedRange / totalRange) * hScrollBar1.Maximum);

                    if (sliderValue >= hScrollBar1.Minimum && sliderValue <= hScrollBar1.Maximum)
                    {
                        hScrollBar1.Value = sliderValue;
                    }

                    // FORZAR REDIBUJADO Y ACTUALIZAR ANOTACIONES
                    tChart1.Refresh();
                    UpdateAnnotations();
                }
            }
            else
            {
                MessageBox.Show("Error al convertir la fecha seleccionada.");
            }
        }
    }
}
