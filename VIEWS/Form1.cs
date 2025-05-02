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
        #region PRIVATE FIELDS
        // Controllerss
        private WeatherController weatherController;

        // Weather Respones
        private WeatherResponse currentTemperature;
        private Forecast allTemperatures;

        // Lists
        List<string> lstIconUrls = new List<string>();
        private List<double> verticalLinePositions = new List<double>();

        // Chart Tools
        NearestPoint toolNPTemp = null;
        NearestPoint toolNPHumidity = null;
        Annotation annotation;
        Axis vertAxis, horizAxis;

        // Dictionaries
        private Dictionary<DateTime, string> daysWithDates = new Dictionary<DateTime, string>();
        private Dictionary<double, string> hoursWithDates = new Dictionary<double, string>();
        private Dictionary<string, List<string>> iconsForDay = new Dictionary<string, List<string>>();
        private Dictionary<string, Bitmap> imageCache = new Dictionary<string, Bitmap>();
        private Dictionary<string, Tuple<double, double>> rankDays = new Dictionary<string, Tuple<double, double>>();

        // Other  Variables
        private bool eventAdded = false;
        private double? firstBarXNextDay = null;
        private double? lastBarX;
        public string currentCity;
        public bool btnDay = false;
        #endregion


        public Form1()
        {
            InitializeComponent();
            weatherController = new WeatherController();
            currentTemperature = new WeatherResponse();
            Update();
            Language.UpdateMenuStrip(menuStrip1);
            cmbBoxDays.Visible = false;
            tChart1[0].Marks.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.WindowState = FormWindowState.Maximized;
            this.AcceptButton = btnSearch;
        }


        #region UPDATE METHODS
        /// <summary>
        /// Updates the controllers and the UI elements such as the menu.
        /// </summary>
        public void Update()
        {
            Language.Controllers(this);
        }


        /// <summary>
        /// Updates the annotations on the chart, adding labels for each vertical line.
        /// </summary>
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

                DateTime dateFrom = DateTime.FromOADate(verticalLineX);
                DateTime dateTo = dateFrom.AddDays(1);

             
                string day1 = daysWithDates.FirstOrDefault(d => d.Key.Date == dateFrom.Date).Value;
                string day2 = daysWithDates.FirstOrDefault(d => d.Key.Date == dateTo.Date).Value;

                day1 = day1?.Trim();
                day2 = day2?.Trim();

                if (day2 != null)
                {
                   
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


        /// <summary>
        /// Adds the days of the week in a cmbBox and updates depending on the chosen language.
        /// </summary>
        public void UpdateAndLoadForecastDays()
        {
            if (allTemperatures == null || allTemperatures.forecastday.Count < 3)
            {
                return;
            }

            int selectedIndex = cmbBoxDays.SelectedIndex; // Save current selection
            string selectedDay = (cmbBoxDays.SelectedItem != null) ? cmbBoxDays.SelectedItem.ToString() : "";

            cmbBoxDays.Items.Clear();

            for (int i = 0; i < 3; i++)
            {
                DateTime date = DateTime.Parse(allTemperatures.forecastday[i].date);
                string dayOfTheWeek = date.ToString("dddd");

                
                if (Language.info.ContainsKey(dayOfTheWeek))
                {
                    dayOfTheWeek = Language.info[dayOfTheWeek];
                }

                string dayFormatted = $"{dayOfTheWeek} ({date:dd/MM})";
                string dateKey = date.ToString("yyyy-MM-dd");

                daysWithDates[date] = dayFormatted;
                cmbBoxDays.Items.Add(dayFormatted);
            }

            // Restore previous selection if it still exists
            if (!string.IsNullOrEmpty(selectedDay) && cmbBoxDays.Items.Contains(selectedDay))
            {
                cmbBoxDays.SelectedItem = selectedDay;
            }
            else if (cmbBoxDays.Items.Count > 0)
            {
                cmbBoxDays.SelectedIndex = selectedIndex >= 0 && selectedIndex < cmbBoxDays.Items.Count ? selectedIndex : 0;
            }
        }


        /// <summary>
        /// Updates the language of the chart headers and series titles in the `tChart2` chart.
        /// It translates the evolution of the day, temperature, and humidity texts based on the selected language.
        /// If translations are not available, it uses default values.
        /// </summary>
        public void UpdateChartLanguage()
        {
            if (allTemperatures != null && allTemperatures.forecastday.Count > 0)
            {
                string headerTxt = Language.info.ContainsKey("Forecast_by_hour") ? Language.info["Forecast_by_hour"] : "Previsió per hores";
                tChart1.Header.Text = headerTxt;

                // Get translations
                string evolutionText = Language.info.ContainsKey("EVOLUTION_OF_DAY") ? Language.info["EVOLUTION_OF_DAY"] : "EVOLUCIÓ DEL DIA";
                string tempHumText = Language.info.ContainsKey("TEMP_HUMIDITY") ? Language.info["TEMP_HUMIDITY"] : "Temperatura / Humitat relativa";

                // Update chart headers without modifying the data
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
        #endregion


        #region TEMPERATURE METHODS
        /// <summary>
        ///  Gets the current temperature of the specified city and updates the UI elements.
        /// </summary>
        /// <param name="city">The city for which to get the temperature</param>
        private async void GetCurrentTemperature(string city)
        {
            currentTemperature = await weatherController.GetCurrentTemperatura(city);

            if (currentTemperature != null)
            {
                lblTemp.Text = Math.Truncate(currentTemperature.Current.temp_c).ToString() + "ºC";
                lblCity.Text = currentTemperature.Location.Name;
                lblProvince.Text = $"{currentTemperature.Location.Region} region";
                imgIcon.Load($"https:{currentTemperature.Current.condition.Icon}");

            }
        }


        /// <summary>
        /// Retrieves the hourly weather evolution for the specified city and displays it in a bar chart.
        /// </summary>
        /// <param name="city">The name of the city to fetch the weather evolution for.</param>
        public async void GetAllTemperatures(string city)
        {
            cmbBoxDays.Visible = true;

            Bar barSeries = (Bar)tChart1.Series[0];
            barSeries.Transparency = 85;

            tChart1.Panning.Allow = ScrollModes.None;
            hScrollBar1.Visible = true;
            tChart1.Zoom.Allow = false;

            btnDay = false;
            currentCity = city;

            if (tChart1.Series.Count > 0)
            {
                tChart1.Series[0].Clear();
                iconsForDay.Clear();
                daysWithDates.Clear();
                hoursWithDates.Clear();
            }

            tChart1.Axes.Bottom.Labels.Separation = 50;

            string headerTxt = Language.info.ContainsKey("Forecast_by_hour") ? Language.info["Forecast_by_hour"] : "Previsió per hores";
            tChart1.Header.Text = headerTxt;

            allTemperatures = await weatherController.GetEvolutionOfWeatherByCity(city);

            if (allTemperatures != null && allTemperatures.forecastday.Count > 0)
            {
                double? firstBarX = null;
                DateTime? lastBarTime = null;
                lastBarX = null;
                firstBarXNextDay = null;

                foreach (Forecastday dia in allTemperatures.forecastday)
                {
                    DateTime date = DateTime.Parse(dia.date);
                    string dateKey = date.ToString("yyyy-MM-dd");
                    daysWithDates[date] = date.ToString("dddd");

                    List<string> tempIcons = new List<string>();

                    // Reset the first value of the current day
                    firstBarX = null;

                    foreach (var hora in dia.hour)
                    {
                        DateTime fechaHora = DateTime.Parse(hora.time.ToString());

                        if (fechaHora < DateTime.Now)
                            continue;

                        double hourValue = fechaHora.ToOADate();
                        barSeries.Add(hourValue, hora.temp_c, fechaHora.ToString("HH:mm"));
                        hoursWithDates[hourValue] = dateKey;
                        tempIcons.Add($"https:{hora.condition.Icon}");

                       
                        if (firstBarX == null)
                            firstBarX = hourValue;

                        // Save the last bar of the current day
                        lastBarTime = fechaHora;
                        lastBarX = hourValue;

                        rankDays[dateKey] = new Tuple<double, double>(firstBarX ?? 0, lastBarX ?? 0);
                    }

                    if (tempIcons.Count > 0)
                    {
                        iconsForDay[dateKey] = tempIcons;
                    }

                    // We assign the first value of the next day to the first value of X
                    if (firstBarX != null)
                        firstBarXNextDay = firstBarX;

                    if (lastBarTime != null && firstBarXNextDay != null)
                    {
                        DateTime date23 = date.AddHours(23);
                        DateTime date00 = date.AddDays(1).AddHours(0);

                        double x23 = date23.ToOADate();
                        double x00 = date00.ToOADate();

                        // Calculate the average positions
                        double verticalLineX = (x23 + x00) / 2;
                        verticalLinePositions.Add(verticalLineX); 
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
                double initialMax = minX + visibleRange;
                tChart1.Axes.Bottom.SetMinMax(minX, initialMax);

                double minY = barSeries.MinYValue();
                double maxY = barSeries.MaxYValue();

                double margenY = (maxY - minY) * 0.15;
                if (minY > 0 && minY < 5)
                {
                    minY = 0;
                }
                else minY = minY -margenY;

                tChart1.Axes.Left.SetMinMax(minY, maxY + margenY);

                if (minY < 0 && maxY > 0)
                    tChart1.Axes.Left.Grid.Centered = true;

                //hScrollBar1.Minimum = 0;
                //hScrollBar1.Maximum = 990; // Provisional
                //hScrollBar1.Value = 0;
                //hScrollBar1.LargeChange = 10;

            }
            else
            {
                MessageBox.Show("No data found!");
            }

            tChart1.Refresh();
            UpdateAnnotations();
            UpdateAndLoadForecastDays();

            tChart1.Invalidate();
        }


        /// <summary>
        /// Retrieves the 7-day weather forecast for the specified city and displays it in a bar chart.
        /// </summary>
        /// <param name="city">The name of the city to fetch the weather forecast for</param>
        /// 
        public async void GetAllTemperaturesByDays(string city)
        {
            cmbBoxDays.Visible = false;

            Bar barSeries = (tChart1.Series.Count == 0) ? new Bar() : (Bar)tChart1.Series[0];

            if (tChart1.Series.Count == 0)
            {
                barSeries.Transparency = 70;
                barSeries.ColorEach = false;
                tChart1.Series.Add(barSeries);
            }

            hScrollBar1.Visible = false;
            btnDay = true;
            currentCity = city;

            barSeries.Clear();
            iconsForDay.Clear();
            daysWithDates.Clear();

            // Delete previous annotations (Only annotation type tools!)
            for (int i = tChart1.Tools.Count - 1; i >= 0; i--)
            {
                if (tChart1.Tools[i] is Annotation)
                {
                    tChart1.Tools.RemoveAt(i);
                }
            }

            allTemperatures = await weatherController.GetPrevisionBy10Days(city);

            if (allTemperatures != null && allTemperatures.forecastday.Count > 0)
            {
                tChart1.Header.Text = Language.info.ContainsKey("FORECAST_7_DAYS")
                                    ? Language.info["FORECAST_7_DAYS"]
                                    : "FORECAST (7 days)";

                foreach (Forecastday day in allTemperatures.forecastday)
                {
                    DateTime date = DateTime.Parse(day.date);
                    string dayOfTheWeek = date.ToString("dddd");

                   
                    if (Language.info.ContainsKey(dayOfTheWeek))
                    {
                        dayOfTheWeek = Language.info[dayOfTheWeek];
                    }

                    string dateKey = date.ToString("yyyy-MM-dd");

                    daysWithDates[date] = dayOfTheWeek;

                    barSeries.Add(day.day.maxtemp_c, dayOfTheWeek);

                    string urlIcon = $"https:{day.day.condition.Icon}";
                    iconsForDay[dateKey] = new List<string> { urlIcon };
                }
            }

            // Force chart update
            tChart1.Axes.Bottom.Automatic = true;
            tChart1.Invalidate();
        }


        /// <summary>
        /// Obtains and displays the evolution of the temperature and relative humidity of a city on a graph.
        /// </summary>
        /// <param name="city">The city for which you wish to obtain temperature and humidity data</param>
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

            tChart2.Zoom.Allow = false;
            tChart2.Panning.Allow = ScrollModes.None;
            tChart2.Axes.Bottom.Labels.Separation = 90;

            lineTemperatura.VertAxis = VerticalAxis.Left;
            lineHumidity.VertAxis = VerticalAxis.Right;


            allTemperatures = await weatherController.GetEvolutionOfHumidityAndTemperatureByCity(city);

            foreach (Tool tool in tChart2.Tools)
            {
                if (tool is NearestPoint np)
                {
                   if(np.Series == lineHumidity)
                        toolNPHumidity = np;
                   else if (np.Series == lineTemperatura)
                        toolNPTemp = np;
                }
            }

            if (toolNPHumidity != null)
            {
                toolNPHumidity.Pen.Visible = true;
                toolNPHumidity.Pen.Color = Color.Black;
                toolNPHumidity.Pen.Width = 2;
                toolNPHumidity.DrawLine = false;
                toolNPHumidity.Pen.Style = Steema.TeeChart.Drawing.DashStyle.Solid;
            }

            if (toolNPTemp != null)
            {
                toolNPTemp.Pen.Visible = true;
                toolNPTemp.Pen.Color = Color.Black;
                toolNPTemp.Pen.Width = 2;
                toolNPTemp.DrawLine = false;
                toolNPTemp.Pen.Style = Steema.TeeChart.Drawing.DashStyle.Solid;
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
                        DateTime dateTime = DateTime.Parse(hora.time.ToString());
                        if (dateTime.Hour >= 0 && dateTime.Hour <= 9 && (dateTime.Minute == 0 || dateTime.Minute == 30))
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

        #endregion


        #region EVENT HANDLERS

        // Search button (executed when the search button is clicked)
        private void btnSearch_Click(object sender, EventArgs e)
        {

            string city = txtBoxCity.Text;
            GetCurrentTemperature(city);

            // Suscribir el evento solo una vez para evitar múltiples dibujos
            if (!eventAdded)
            {
                tChart1.AfterDraw += TChart1_AfterDraw;
                eventAdded = true;
            }

            tChart1.Refresh();
            GetAllTemperatures(city);
            GetTemperatureAndHumidity(city);
        }

        // Button to display temperatures per day (loads the temperature graph for each day of the week)
        private void btnDays_Click(object sender, EventArgs e)
        {
            btnDay = true;
            string city = txtBoxCity.Text;
            GetAllTemperaturesByDays(city);
        }

        // Button for displaying hourly temperatures (loads the 3-day graph but displays each day's temperature by hour)
        private void btnHours_Click(object sender, EventArgs e)
        {
            string city = txtBoxCity.Text;
            if (!eventAdded)
            {
                tChart1.AfterDraw += TChart1_AfterDraw;
                eventAdded = true;
            }

            GetCurrentTemperature(city);
            GetAllTemperatures(city);
            GetTemperatureAndHumidity(city);

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

        #endregion


        #region TChart DRAWING HANDLERS
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

        /// <summary>
        ///  Draw the images on the graph for the temperatures per day, and also for the temperatures per hour.
        /// </summary>
        private void tChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.IGraphics3D g)
        {
            // Removes any previous clipping regions that may have been configured
            tChart1.Graphics3D.ClearClipRegions();

            // Creates a rectangle that respects the horizontal boundaries of the chart (X and Width)
            // but extends from the top of the screen (Y=0) to the bottom of the chart
            Rectangle openTopRect = new Rectangle(
                                    tChart1.Chart.ChartRect.X,
                                    0, tChart1.Chart.ChartRect.Width,
                                    tChart1.Chart.ChartRect.Height +
                                    tChart1.Chart.ChartRect.Y
            );

            // Set this rectangle as the clipping region.
            // Anything drawn outside this region will be clipped (not visible).
            tChart1.Graphics3D.ClipRectangle(openTopRect);

            foreach (Series s in tChart1.Series)
            {
                if (!(s is Bar)) continue;

                Dictionary<string, List<int>> dataGroups = new Dictionary<string, List<int>>();

                for (int i = 0; i < s.Count; i++)
                {
                    string dateKey;

                    // Case 1: Data represents hours (GetAllTemperatures)
                    if (hoursWithDates.ContainsKey(s.XValues[i]))
                    {
                        dateKey = hoursWithDates[s.XValues[i]];
                    }
                    // Case 2: Data represents days (GetAllTemperaturesByDays)
                    else if (daysWithDates.ContainsValue(s.Labels[i]))
                    {
                        dateKey = daysWithDates.FirstOrDefault(x => x.Value == s.Labels[i]).Key.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        continue;
                    }

                    if (!dataGroups.ContainsKey(dateKey))
                        dataGroups[dateKey] = new List<int>();

                    dataGroups[dateKey].Add(i);
                }

                foreach (var group in dataGroups)
                {
                    int p = 0;
                    string dateKey = group.Key;

                    if (!iconsForDay.ContainsKey(dateKey) || iconsForDay[dateKey].Count == 0)
                        continue;

                    foreach (int index in group.Value)
                    {
                        Bitmap objBitmap;
                        if (s.Labels[index].Contains(":"))
                        {
                            int iconIndex = p % iconsForDay[dateKey].Count;
                            objBitmap = LoadBitmapFromUrl(iconsForDay[dateKey][iconIndex]);
                        }
                        else
                        {
                            objBitmap = LoadBitmapFromUrl(iconsForDay[dateKey][0]);
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

            tChart1.Graphics3D.ClearClipRegions();
        }
        #endregion


        private void ToolNPHumidity_Change(object? sender, EventArgs e)
        {
            Line graphLineTemperature = (Line)tChart2.Series[0];
            Line graphLineHumidity = (Line)tChart2.Series[1];

            string tempText = Language.info.ContainsKey("Temperature") ? Language.info["Temperature"] : "Temperature";
            string humText = Language.info.ContainsKey("Humidity") ? Language.info["Humidity"] : "Humidity";

            int tempPoint = toolNPTemp.Point;
            int humPoint = toolNPHumidity.Point;

            // Validar que los índices sean válidos antes de acceder
            if (tempPoint >= 0 && tempPoint < graphLineTemperature.Count &&
                humPoint >= 0 && humPoint < graphLineHumidity.Count)
            {
                annotation.Text = $"{tempText}: {graphLineTemperature.YValues[tempPoint]}ºC \n " +
                                  $"{humText}: {graphLineHumidity.YValues[humPoint]}%";
            }
            else
            {
                annotation.Text = $"{tempText}: - \n {humText}: -";
            }
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

        /// <summary>
        /// Downloads an image from a given URL and returns it as a BitmapImage for use in WPF.
        /// Utilizes a cache to avoid repeated downloads of the same image.
        /// </summary>
        /// <param name="url">The URL of the image to download.</param>
        /// <returns>A BitmapImage loaded from the specified URL.</returns>
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
                    imageCache[url] = bitmap;
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
                string value = bar1.Labels[valueIndex];
                double hourValue = s.XValues[valueIndex];

                DateTime dateSelectedTime = DateTime.FromOADate(hourValue);

                int hours = dateSelectedTime.Hour;
                int minutes = dateSelectedTime.Minute;

                DateTime dateSelected = DateTime.Today.Date;
                TimeSpan hourSelected = new TimeSpan(hours, minutes, 0);

                string city = txtBoxCity.Text;

                Form2 form = new Form2(allTemperatures, value, dateSelected, hourSelected, weatherController, city, btnDay);
                form.Show();

                _ = form.LoadData();
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (btnDay) return;

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

            
            if (newMax > maxX)
            {
                newMax = maxX;
                newMin = newMax - visibleRange;
            }

            if (newMin < minX)
            {
                newMin = minX;
                newMax = newMin + visibleRange;
            }

            tChart1.Axes.Bottom.SetMinMax(newMin, newMax);
            UpdateAnnotations();

            // PART OF THE CMBOX:
            foreach (var kvp in rankDays)
            {
                // Gets the minimum and maximum values for the selected day in the dictionary.
                double minDay = kvp.Value.Item1;
                double maxDay = kvp.Value.Item2;

                if (newMin >= minDay && newMin <= maxDay)
                {
                    
                    string formattedDay = daysWithDates[DateTime.Parse(kvp.Key)];

                  
                    int index = cmbBoxDays.Items.IndexOf(formattedDay);

                    if (index != -1 && cmbBoxDays.SelectedIndex != index)
                    {
                        cmbBoxDays.SelectedIndex = index;
                    }
                    break;
                }
            }
        }

        // Synchronise the ScrollBar with the current page
        private void tChart1_Scroll(object sender, EventArgs e)
        {
            if (tChart1.Page.Current >= hScrollBar1.Minimum && tChart1.Page.Current <= hScrollBar1.Maximum)
                hScrollBar1.Value = tChart1.Page.Current - 1;
        }

        private void cmbBoxDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxDays.SelectedItem == null) return;

            string selectedDay = cmbBoxDays.SelectedItem.ToString();
            string dateStr = selectedDay.Split('(')[1].Split(')')[0];


            if (DateTime.TryParseExact(dateStr, "dd/MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                string dateKey = parsedDate.ToString("yyyy-MM-dd");

                if (rankDays.ContainsKey(dateKey))
                {
                    double minX = rankDays[dateKey].Item1;
                    double maxX = rankDays[dateKey].Item2;

                    tChart1.Axes.Bottom.SetMinMax(minX, maxX);

                    double globalMinX = tChart1.Series[0].MinXValue();
                    double globalMaxX = tChart1.Series[0].MaxXValue();
                    double totalRange = globalMaxX - globalMinX;

                    double selectedRange = minX - globalMinX;
                    int sliderValue = (int)((selectedRange / totalRange) * hScrollBar1.Maximum);

                    if (sliderValue >= hScrollBar1.Minimum && sliderValue <= hScrollBar1.Maximum)
                    {
                        hScrollBar1.Value = sliderValue;
                    }

                    // FORCE REDRAW AND UPDATE ANNOTATIONS
                    tChart1.Refresh();
                    UpdateAnnotations();
                }
            }
            else
            {
                MessageBox.Show("No data found!");
            }
        }

        private void tChart1_BeforeDrawSeries_1(object sender, Steema.TeeChart.Drawing.IGraphics3D g)
        {
            if (tChart1.Series[0] is Bar)
            {
                int visibleBars = tChart1.Series[0].LastVisibleIndex - tChart1.Series[0].FirstVisibleIndex + 1;

                if (visibleBars > 20)
                    ((Bar)(tChart1.Series[0])).CustomBarWidth = 33;
                else if (visibleBars > 10)
                    ((Bar)(tChart1.Series[0])).CustomBarWidth = 44;
                else
                    ((Bar)(tChart1.Series[0])).CustomBarWidth = 50;
            }
        }

        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panelBottomTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tChart2_Click(object sender, EventArgs e)
        {

        }
    }
}
