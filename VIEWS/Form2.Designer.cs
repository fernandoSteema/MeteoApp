namespace MeteoApp.VIEWS
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblFecha = new Label();
            lblHora = new Label();
            lblWiind = new Label();
            lblSnoow = new Label();
            lblHumidity = new Label();
            lblClouds = new Label();
            lblRains = new Label();
            lblPrecipitations = new Label();
            lblWind = new Label();
            lblCloud = new Label();
            lblRain = new Label();
            lblPrecip = new Label();
            lblSnow = new Label();
            lblHumity = new Label();
            lblPressure = new Label();
            lblPresure = new Label();
            SuspendLayout();
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 15F);
            lblFecha.Location = new Point(12, 9);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(98, 28);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "29TH JAN";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHora.ForeColor = SystemColors.ControlText;
            lblHora.Location = new Point(12, 37);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(205, 30);
            lblHora.TabIndex = 1;
            lblHora.Text = "Today at 2:00 p.m.";
            // 
            // lblWiind
            // 
            lblWiind.AutoSize = true;
            lblWiind.Font = new Font("Segoe UI", 12F);
            lblWiind.Location = new Point(12, 96);
            lblWiind.Name = "lblWiind";
            lblWiind.Size = new Size(52, 21);
            lblWiind.TabIndex = 2;
            lblWiind.Text = "WIND";
            // 
            // lblSnoow
            // 
            lblSnoow.AutoSize = true;
            lblSnoow.Font = new Font("Segoe UI", 12F);
            lblSnoow.Location = new Point(12, 195);
            lblSnoow.Name = "lblSnoow";
            lblSnoow.Size = new Size(58, 21);
            lblSnoow.TabIndex = 3;
            lblSnoow.Text = "SNOW";
            // 
            // lblHumidity
            // 
            lblHumidity.AutoSize = true;
            lblHumidity.Font = new Font("Segoe UI", 12F);
            lblHumidity.Location = new Point(203, 195);
            lblHumidity.Name = "lblHumidity";
            lblHumidity.Size = new Size(82, 21);
            lblHumidity.TabIndex = 4;
            lblHumidity.Text = "HUMIDITY";
            // 
            // lblClouds
            // 
            lblClouds.AutoSize = true;
            lblClouds.Font = new Font("Segoe UI", 12F);
            lblClouds.Location = new Point(203, 96);
            lblClouds.Name = "lblClouds";
            lblClouds.Size = new Size(70, 21);
            lblClouds.TabIndex = 5;
            lblClouds.Text = "CLOUDS";
            // 
            // lblRains
            // 
            lblRains.AutoSize = true;
            lblRains.Font = new Font("Segoe UI", 12F);
            lblRains.Location = new Point(384, 96);
            lblRains.Name = "lblRains";
            lblRains.Size = new Size(46, 21);
            lblRains.TabIndex = 6;
            lblRains.Text = "RAIN";
            // 
            // lblPrecipitations
            // 
            lblPrecipitations.AutoSize = true;
            lblPrecipitations.Font = new Font("Segoe UI", 12F);
            lblPrecipitations.Location = new Point(384, 195);
            lblPrecipitations.Name = "lblPrecipitations";
            lblPrecipitations.Size = new Size(187, 21);
            lblPrecipitations.TabIndex = 7;
            lblPrecipitations.Text = "PROB. OF PRECIPITATION";
            // 
            // lblWind
            // 
            lblWind.AutoSize = true;
            lblWind.Font = new Font("Segoe UI", 15F);
            lblWind.Location = new Point(12, 129);
            lblWind.Name = "lblWind";
            lblWind.Size = new Size(98, 28);
            lblWind.TabIndex = 8;
            lblWind.Text = "🡢 5 km/h";
            // 
            // lblCloud
            // 
            lblCloud.AutoSize = true;
            lblCloud.Font = new Font("Segoe UI", 15F);
            lblCloud.Location = new Point(203, 129);
            lblCloud.Name = "lblCloud";
            lblCloud.Size = new Size(71, 28);
            lblCloud.TabIndex = 9;
            lblCloud.Text = "☁︎ 2%";
            // 
            // lblRain
            // 
            lblRain.AutoSize = true;
            lblRain.Font = new Font("Segoe UI", 15F);
            lblRain.Location = new Point(384, 129);
            lblRain.Name = "lblRain";
            lblRain.Size = new Size(89, 28);
            lblRain.TabIndex = 10;
            lblRain.Text = "☂️ 0mm";
            // 
            // lblPrecip
            // 
            lblPrecip.AutoSize = true;
            lblPrecip.Font = new Font("Segoe UI", 15F);
            lblPrecip.Location = new Point(384, 236);
            lblPrecip.Name = "lblPrecip";
            lblPrecip.Size = new Size(71, 28);
            lblPrecip.TabIndex = 11;
            lblPrecip.Text = "☂️ 0%";
            // 
            // lblSnow
            // 
            lblSnow.AutoSize = true;
            lblSnow.Font = new Font("Segoe UI", 15F);
            lblSnow.Location = new Point(12, 236);
            lblSnow.Name = "lblSnow";
            lblSnow.Size = new Size(86, 28);
            lblSnow.TabIndex = 12;
            lblSnow.Text = "❄️ 0 cm";
            // 
            // lblHumity
            // 
            lblHumity.AutoSize = true;
            lblHumity.Font = new Font("Segoe UI", 15F);
            lblHumity.Location = new Point(203, 236);
            lblHumity.Name = "lblHumity";
            lblHumity.Size = new Size(82, 28);
            lblHumity.TabIndex = 13;
            lblHumity.Text = "💧 74%";
            // 
            // lblPressure
            // 
            lblPressure.AutoSize = true;
            lblPressure.Font = new Font("Segoe UI", 15F);
            lblPressure.Location = new Point(12, 342);
            lblPressure.Name = "lblPressure";
            lblPressure.Size = new Size(124, 28);
            lblPressure.TabIndex = 15;
            lblPressure.Text = "🕛 1019 hPa";
            // 
            // lblPresure
            // 
            lblPresure.AutoSize = true;
            lblPresure.Font = new Font("Segoe UI", 12F);
            lblPresure.Location = new Point(12, 301);
            lblPresure.Name = "lblPresure";
            lblPresure.Size = new Size(84, 21);
            lblPresure.TabIndex = 14;
            lblPresure.Text = "PRESSURE";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 396);
            Controls.Add(lblPressure);
            Controls.Add(lblPresure);
            Controls.Add(lblHumity);
            Controls.Add(lblSnow);
            Controls.Add(lblPrecip);
            Controls.Add(lblRain);
            Controls.Add(lblCloud);
            Controls.Add(lblWind);
            Controls.Add(lblPrecipitations);
            Controls.Add(lblRains);
            Controls.Add(lblClouds);
            Controls.Add(lblHumidity);
            Controls.Add(lblSnoow);
            Controls.Add(lblWiind);
            Controls.Add(lblHora);
            Controls.Add(lblFecha);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFecha;
        private Label lblHora;
        private Label lblWiind;
        private Label lblSnoow;
        private Label lblHumidity;
        private Label lblClouds;
        private Label lblRains;
        private Label lblPrecipitations;
        private Label lblWind;
        private Label lblCloud;
        private Label lblRain;
        private Label lblPrecip;
        private Label lblSnow;
        private Label lblHumity;
        private Label lblPressure;
        private Label lblPresure;
    }
}