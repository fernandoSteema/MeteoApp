namespace MeteoApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Steema.TeeChart.Margins margins1 = new Steema.TeeChart.Margins();
            Steema.TeeChart.Drawing.Cursor cursor1 = new Steema.TeeChart.Drawing.Cursor();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Steema.TeeChart.Margins margins2 = new Steema.TeeChart.Margins();
            Steema.TeeChart.Drawing.Cursor cursor2 = new Steema.TeeChart.Drawing.Cursor();
            btnSearch = new Steema.TeeChart.ButtonPen();
            label1 = new Label();
            txtBoxCity = new TextBox();
            label2 = new Label();
            lblCity = new Label();
            lblProvincia = new Label();
            lblTemp = new Label();
            imgIcon = new PictureBox();
            lblMinMax = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            hScrollBar1 = new HScrollBar();
            tChart1 = new Steema.TeeChart.TChart();
            bar1 = new Steema.TeeChart.Styles.Bar();
            tabPage2 = new TabPage();
            tChart2 = new Steema.TeeChart.TChart();
            line2 = new Steema.TeeChart.Styles.Line();
            line1 = new Steema.TeeChart.Styles.Line();
            nearestPoint1 = new Steema.TeeChart.Tools.NearestPoint();
            nearestPoint2 = new Steema.TeeChart.Tools.NearestPoint();
            chartController1 = new Steema.TeeChart.ChartController();
            contextMenuStrip1 = new ContextMenuStrip(components);
            btnDays = new Button();
            btnHours = new Button();
            btnWeekend = new Button();
            listBox1 = new ListBox();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)imgIcon).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Location = new Point(847, 29);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(35, 32);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "🔍";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(534, 33);
            label1.Name = "label1";
            label1.Size = new Size(155, 31);
            label1.TabIndex = 1;
            label1.Text = "The weather in...";
            // 
            // txtBoxCity
            // 
            txtBoxCity.Font = new Font("Segoe UI", 14F);
            txtBoxCity.Location = new Point(658, 29);
            txtBoxCity.Name = "txtBoxCity";
            txtBoxCity.Size = new Size(174, 32);
            txtBoxCity.TabIndex = 2;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(680, 100);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 3;
            label2.Text = "The weather in";
            // 
            // lblCity
            // 
            lblCity.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCity.Location = new Point(680, 122);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(110, 27);
            lblCity.TabIndex = 4;
            lblCity.Text = "Girona";
            // 
            // lblProvincia
            // 
            lblProvincia.Font = new Font("Segoe UI", 9F);
            lblProvincia.Location = new Point(680, 146);
            lblProvincia.Name = "lblProvincia";
            lblProvincia.Size = new Size(152, 25);
            lblProvincia.TabIndex = 5;
            lblProvincia.Text = "Girona province";
            // 
            // lblTemp
            // 
            lblTemp.AutoSize = true;
            lblTemp.Font = new Font("Segoe UI", 40F);
            lblTemp.Location = new Point(633, 171);
            lblTemp.Name = "lblTemp";
            lblTemp.Size = new Size(111, 72);
            lblTemp.TabIndex = 6;
            lblTemp.Text = "12º";
            // 
            // imgIcon
            // 
            imgIcon.Location = new Point(765, 180);
            imgIcon.Name = "imgIcon";
            imgIcon.Size = new Size(81, 63);
            imgIcon.TabIndex = 7;
            imgIcon.TabStop = false;
            // 
            // lblMinMax
            // 
            lblMinMax.AutoSize = true;
            lblMinMax.Location = new Point(650, 243);
            lblMinMax.Name = "lblMinMax";
            lblMinMax.Size = new Size(94, 15);
            lblMinMax.TabIndex = 10;
            lblMinMax.Text = "Máx. 15º Mín.5º ";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(194, 302);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1157, 428);
            tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(hScrollBar1);
            tabPage1.Controls.Add(tChart1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1149, 400);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // hScrollBar1
            // 
            hScrollBar1.Location = new Point(-8, 385);
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(1157, 17);
            hScrollBar1.TabIndex = 14;
            hScrollBar1.Scroll += hScrollBar1_Scroll;
            // 
            // tChart1
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Bottom.Labels.Brush.Color = Color.White;
            tChart1.Axes.Bottom.Labels.Brush.Solid = true;
            tChart1.Axes.Bottom.Labels.Brush.Visible = true;
            // 
            // 
            // 
            tChart1.Axes.Bottom.Labels.Font.Bold = false;
            // 
            // 
            // 
            tChart1.Axes.Bottom.Labels.Font.Brush.Color = Color.FromArgb(128, 128, 128);
            tChart1.Axes.Bottom.Labels.Font.Brush.Solid = true;
            tChart1.Axes.Bottom.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Bottom.Labels.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.Bottom.Labels.Font.Shadow.Brush.Solid = true;
            tChart1.Axes.Bottom.Labels.Font.Shadow.Brush.Visible = true;
            tChart1.Axes.Bottom.Labels.Font.Size = 9;
            tChart1.Axes.Bottom.Labels.Font.SizeFloat = 9F;
            tChart1.Axes.Bottom.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Bottom.Labels.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Axes.Bottom.Labels.ImageBevel.Brush.Solid = true;
            tChart1.Axes.Bottom.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Bottom.Labels.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.Bottom.Labels.Shadow.Brush.Solid = true;
            tChart1.Axes.Bottom.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            tChart1.Axes.Bottom.TicksInner.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Bottom.Title.Brush.Color = Color.Silver;
            tChart1.Axes.Bottom.Title.Brush.Solid = true;
            tChart1.Axes.Bottom.Title.Brush.Visible = true;
            tChart1.Axes.Bottom.Title.Distance = 0;
            // 
            // 
            // 
            tChart1.Axes.Bottom.Title.Font.Bold = false;
            // 
            // 
            // 
            tChart1.Axes.Bottom.Title.Font.Brush.Color = Color.FromArgb(64, 64, 64);
            tChart1.Axes.Bottom.Title.Font.Brush.Solid = true;
            tChart1.Axes.Bottom.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Bottom.Title.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.Bottom.Title.Font.Shadow.Brush.Solid = true;
            tChart1.Axes.Bottom.Title.Font.Shadow.Brush.Visible = true;
            tChart1.Axes.Bottom.Title.Font.Size = 11;
            tChart1.Axes.Bottom.Title.Font.SizeFloat = 11F;
            tChart1.Axes.Bottom.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Bottom.Title.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Axes.Bottom.Title.ImageBevel.Brush.Solid = true;
            tChart1.Axes.Bottom.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Bottom.Title.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.Bottom.Title.Shadow.Brush.Solid = true;
            tChart1.Axes.Bottom.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Depth.Labels.Brush.Color = Color.White;
            tChart1.Axes.Depth.Labels.Brush.Solid = true;
            tChart1.Axes.Depth.Labels.Brush.Visible = true;
            // 
            // 
            // 
            tChart1.Axes.Depth.Labels.Font.Bold = false;
            // 
            // 
            // 
            tChart1.Axes.Depth.Labels.Font.Brush.Color = Color.FromArgb(128, 128, 128);
            tChart1.Axes.Depth.Labels.Font.Brush.Solid = true;
            tChart1.Axes.Depth.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Depth.Labels.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.Depth.Labels.Font.Shadow.Brush.Solid = true;
            tChart1.Axes.Depth.Labels.Font.Shadow.Brush.Visible = true;
            tChart1.Axes.Depth.Labels.Font.Size = 9;
            tChart1.Axes.Depth.Labels.Font.SizeFloat = 9F;
            tChart1.Axes.Depth.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Depth.Labels.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Axes.Depth.Labels.ImageBevel.Brush.Solid = true;
            tChart1.Axes.Depth.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Depth.Labels.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.Depth.Labels.Shadow.Brush.Solid = true;
            tChart1.Axes.Depth.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            tChart1.Axes.Depth.TicksInner.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Depth.Title.Brush.Color = Color.Silver;
            tChart1.Axes.Depth.Title.Brush.Solid = true;
            tChart1.Axes.Depth.Title.Brush.Visible = true;
            tChart1.Axes.Depth.Title.Distance = 0;
            // 
            // 
            // 
            tChart1.Axes.Depth.Title.Font.Bold = false;
            // 
            // 
            // 
            tChart1.Axes.Depth.Title.Font.Brush.Color = Color.FromArgb(64, 64, 64);
            tChart1.Axes.Depth.Title.Font.Brush.Solid = true;
            tChart1.Axes.Depth.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Depth.Title.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.Depth.Title.Font.Shadow.Brush.Solid = true;
            tChart1.Axes.Depth.Title.Font.Shadow.Brush.Visible = true;
            tChart1.Axes.Depth.Title.Font.Size = 11;
            tChart1.Axes.Depth.Title.Font.SizeFloat = 11F;
            tChart1.Axes.Depth.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Depth.Title.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Axes.Depth.Title.ImageBevel.Brush.Solid = true;
            tChart1.Axes.Depth.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Depth.Title.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.Depth.Title.Shadow.Brush.Solid = true;
            tChart1.Axes.Depth.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.DepthTop.Labels.Brush.Color = Color.White;
            tChart1.Axes.DepthTop.Labels.Brush.Solid = true;
            tChart1.Axes.DepthTop.Labels.Brush.Visible = true;
            // 
            // 
            // 
            tChart1.Axes.DepthTop.Labels.Font.Bold = false;
            // 
            // 
            // 
            tChart1.Axes.DepthTop.Labels.Font.Brush.Color = Color.FromArgb(128, 128, 128);
            tChart1.Axes.DepthTop.Labels.Font.Brush.Solid = true;
            tChart1.Axes.DepthTop.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.DepthTop.Labels.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.DepthTop.Labels.Font.Shadow.Brush.Solid = true;
            tChart1.Axes.DepthTop.Labels.Font.Shadow.Brush.Visible = true;
            tChart1.Axes.DepthTop.Labels.Font.Size = 9;
            tChart1.Axes.DepthTop.Labels.Font.SizeFloat = 9F;
            tChart1.Axes.DepthTop.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.DepthTop.Labels.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Axes.DepthTop.Labels.ImageBevel.Brush.Solid = true;
            tChart1.Axes.DepthTop.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.DepthTop.Labels.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.DepthTop.Labels.Shadow.Brush.Solid = true;
            tChart1.Axes.DepthTop.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            tChart1.Axes.DepthTop.TicksInner.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.DepthTop.Title.Brush.Color = Color.Silver;
            tChart1.Axes.DepthTop.Title.Brush.Solid = true;
            tChart1.Axes.DepthTop.Title.Brush.Visible = true;
            tChart1.Axes.DepthTop.Title.Distance = 0;
            // 
            // 
            // 
            tChart1.Axes.DepthTop.Title.Font.Bold = false;
            // 
            // 
            // 
            tChart1.Axes.DepthTop.Title.Font.Brush.Color = Color.FromArgb(64, 64, 64);
            tChart1.Axes.DepthTop.Title.Font.Brush.Solid = true;
            tChart1.Axes.DepthTop.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.DepthTop.Title.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.DepthTop.Title.Font.Shadow.Brush.Solid = true;
            tChart1.Axes.DepthTop.Title.Font.Shadow.Brush.Visible = true;
            tChart1.Axes.DepthTop.Title.Font.Size = 11;
            tChart1.Axes.DepthTop.Title.Font.SizeFloat = 11F;
            tChart1.Axes.DepthTop.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.DepthTop.Title.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Axes.DepthTop.Title.ImageBevel.Brush.Solid = true;
            tChart1.Axes.DepthTop.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.DepthTop.Title.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.DepthTop.Title.Shadow.Brush.Solid = true;
            tChart1.Axes.DepthTop.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Left.Labels.Brush.Color = Color.White;
            tChart1.Axes.Left.Labels.Brush.Solid = true;
            tChart1.Axes.Left.Labels.Brush.Visible = true;
            // 
            // 
            // 
            tChart1.Axes.Left.Labels.Font.Bold = false;
            // 
            // 
            // 
            tChart1.Axes.Left.Labels.Font.Brush.Color = Color.FromArgb(128, 128, 128);
            tChart1.Axes.Left.Labels.Font.Brush.Solid = true;
            tChart1.Axes.Left.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Left.Labels.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.Left.Labels.Font.Shadow.Brush.Solid = true;
            tChart1.Axes.Left.Labels.Font.Shadow.Brush.Visible = true;
            tChart1.Axes.Left.Labels.Font.Size = 9;
            tChart1.Axes.Left.Labels.Font.SizeFloat = 9F;
            tChart1.Axes.Left.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Left.Labels.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Axes.Left.Labels.ImageBevel.Brush.Solid = true;
            tChart1.Axes.Left.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Left.Labels.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.Left.Labels.Shadow.Brush.Solid = true;
            tChart1.Axes.Left.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            tChart1.Axes.Left.TicksInner.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Left.Title.Brush.Color = Color.Silver;
            tChart1.Axes.Left.Title.Brush.Solid = true;
            tChart1.Axes.Left.Title.Brush.Visible = true;
            tChart1.Axes.Left.Title.Distance = 0;
            // 
            // 
            // 
            tChart1.Axes.Left.Title.Font.Bold = false;
            // 
            // 
            // 
            tChart1.Axes.Left.Title.Font.Brush.Color = Color.FromArgb(64, 64, 64);
            tChart1.Axes.Left.Title.Font.Brush.Solid = true;
            tChart1.Axes.Left.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Left.Title.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.Left.Title.Font.Shadow.Brush.Solid = true;
            tChart1.Axes.Left.Title.Font.Shadow.Brush.Visible = true;
            tChart1.Axes.Left.Title.Font.Size = 11;
            tChart1.Axes.Left.Title.Font.SizeFloat = 11F;
            tChart1.Axes.Left.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Left.Title.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Axes.Left.Title.ImageBevel.Brush.Solid = true;
            tChart1.Axes.Left.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Left.Title.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.Left.Title.Shadow.Brush.Solid = true;
            tChart1.Axes.Left.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Right.Labels.Brush.Color = Color.White;
            tChart1.Axes.Right.Labels.Brush.Solid = true;
            tChart1.Axes.Right.Labels.Brush.Visible = true;
            // 
            // 
            // 
            tChart1.Axes.Right.Labels.Font.Bold = false;
            // 
            // 
            // 
            tChart1.Axes.Right.Labels.Font.Brush.Color = Color.FromArgb(128, 128, 128);
            tChart1.Axes.Right.Labels.Font.Brush.Solid = true;
            tChart1.Axes.Right.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Right.Labels.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.Right.Labels.Font.Shadow.Brush.Solid = true;
            tChart1.Axes.Right.Labels.Font.Shadow.Brush.Visible = true;
            tChart1.Axes.Right.Labels.Font.Size = 9;
            tChart1.Axes.Right.Labels.Font.SizeFloat = 9F;
            tChart1.Axes.Right.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Right.Labels.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Axes.Right.Labels.ImageBevel.Brush.Solid = true;
            tChart1.Axes.Right.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Right.Labels.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.Right.Labels.Shadow.Brush.Solid = true;
            tChart1.Axes.Right.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            tChart1.Axes.Right.TicksInner.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Right.Title.Brush.Color = Color.Silver;
            tChart1.Axes.Right.Title.Brush.Solid = true;
            tChart1.Axes.Right.Title.Brush.Visible = true;
            tChart1.Axes.Right.Title.Distance = 0;
            // 
            // 
            // 
            tChart1.Axes.Right.Title.Font.Bold = false;
            // 
            // 
            // 
            tChart1.Axes.Right.Title.Font.Brush.Color = Color.FromArgb(64, 64, 64);
            tChart1.Axes.Right.Title.Font.Brush.Solid = true;
            tChart1.Axes.Right.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Right.Title.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.Right.Title.Font.Shadow.Brush.Solid = true;
            tChart1.Axes.Right.Title.Font.Shadow.Brush.Visible = true;
            tChart1.Axes.Right.Title.Font.Size = 11;
            tChart1.Axes.Right.Title.Font.SizeFloat = 11F;
            tChart1.Axes.Right.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Right.Title.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Axes.Right.Title.ImageBevel.Brush.Solid = true;
            tChart1.Axes.Right.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Right.Title.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.Right.Title.Shadow.Brush.Solid = true;
            tChart1.Axes.Right.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Top.Labels.Brush.Color = Color.White;
            tChart1.Axes.Top.Labels.Brush.Solid = true;
            tChart1.Axes.Top.Labels.Brush.Visible = true;
            // 
            // 
            // 
            tChart1.Axes.Top.Labels.Font.Bold = false;
            // 
            // 
            // 
            tChart1.Axes.Top.Labels.Font.Brush.Color = Color.FromArgb(128, 128, 128);
            tChart1.Axes.Top.Labels.Font.Brush.Solid = true;
            tChart1.Axes.Top.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Top.Labels.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.Top.Labels.Font.Shadow.Brush.Solid = true;
            tChart1.Axes.Top.Labels.Font.Shadow.Brush.Visible = true;
            tChart1.Axes.Top.Labels.Font.Size = 9;
            tChart1.Axes.Top.Labels.Font.SizeFloat = 9F;
            tChart1.Axes.Top.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Top.Labels.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Axes.Top.Labels.ImageBevel.Brush.Solid = true;
            tChart1.Axes.Top.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Top.Labels.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.Top.Labels.Shadow.Brush.Solid = true;
            tChart1.Axes.Top.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            tChart1.Axes.Top.TicksInner.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Top.Title.Brush.Color = Color.Silver;
            tChart1.Axes.Top.Title.Brush.Solid = true;
            tChart1.Axes.Top.Title.Brush.Visible = true;
            tChart1.Axes.Top.Title.Distance = 0;
            // 
            // 
            // 
            tChart1.Axes.Top.Title.Font.Bold = false;
            // 
            // 
            // 
            tChart1.Axes.Top.Title.Font.Brush.Color = Color.FromArgb(64, 64, 64);
            tChart1.Axes.Top.Title.Font.Brush.Solid = true;
            tChart1.Axes.Top.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Top.Title.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.Top.Title.Font.Shadow.Brush.Solid = true;
            tChart1.Axes.Top.Title.Font.Shadow.Brush.Visible = true;
            tChart1.Axes.Top.Title.Font.Size = 11;
            tChart1.Axes.Top.Title.Font.SizeFloat = 11F;
            tChart1.Axes.Top.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Top.Title.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Axes.Top.Title.ImageBevel.Brush.Solid = true;
            tChart1.Axes.Top.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Axes.Top.Title.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Axes.Top.Title.Shadow.Brush.Solid = true;
            tChart1.Axes.Top.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Footer.Brush.Color = Color.Silver;
            tChart1.Footer.Brush.Solid = true;
            tChart1.Footer.Brush.Visible = true;
            // 
            // 
            // 
            tChart1.Footer.Font.Bold = false;
            // 
            // 
            // 
            tChart1.Footer.Font.Brush.Color = Color.Red;
            tChart1.Footer.Font.Brush.Solid = true;
            tChart1.Footer.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Footer.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Footer.Font.Shadow.Brush.Solid = true;
            tChart1.Footer.Font.Shadow.Brush.Visible = true;
            tChart1.Footer.Font.Size = 8;
            tChart1.Footer.Font.SizeFloat = 8F;
            tChart1.Footer.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Footer.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Footer.ImageBevel.Brush.Solid = true;
            tChart1.Footer.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Footer.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Footer.Shadow.Brush.Solid = true;
            tChart1.Footer.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Header.Brush.Color = Color.FromArgb(192, 192, 192);
            tChart1.Header.Brush.Solid = true;
            tChart1.Header.Brush.Visible = true;
            // 
            // 
            // 
            tChart1.Header.Font.Bold = false;
            // 
            // 
            // 
            tChart1.Header.Font.Brush.Color = Color.FromArgb(128, 128, 128);
            tChart1.Header.Font.Brush.Solid = true;
            tChart1.Header.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Header.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Header.Font.Shadow.Brush.Solid = true;
            tChart1.Header.Font.Shadow.Brush.Visible = true;
            tChart1.Header.Font.Size = 12;
            tChart1.Header.Font.SizeFloat = 12F;
            tChart1.Header.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Header.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Header.ImageBevel.Brush.Solid = true;
            tChart1.Header.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Header.Shadow.Brush.Color = Color.FromArgb(169, 169, 169);
            tChart1.Header.Shadow.Brush.Solid = true;
            tChart1.Header.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Legend.Brush.Color = Color.White;
            tChart1.Legend.Brush.Solid = true;
            tChart1.Legend.Brush.Visible = true;
            tChart1.Legend.CheckBoxes = false;
            tChart1.Legend.ClipText = false;
            // 
            // 
            // 
            tChart1.Legend.Font.Bold = false;
            // 
            // 
            // 
            tChart1.Legend.Font.Brush.Color = Color.FromArgb(64, 64, 64);
            tChart1.Legend.Font.Brush.Solid = true;
            tChart1.Legend.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Legend.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Legend.Font.Shadow.Brush.Solid = true;
            tChart1.Legend.Font.Shadow.Brush.Visible = true;
            tChart1.Legend.Font.Size = 9;
            tChart1.Legend.Font.SizeFloat = 9F;
            tChart1.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Legend.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Legend.ImageBevel.Brush.Solid = true;
            tChart1.Legend.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Legend.Shadow.Brush.Color = Color.FromArgb(0, 0, 0);
            tChart1.Legend.Shadow.Brush.Solid = true;
            tChart1.Legend.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Legend.Symbol.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Legend.Symbol.Shadow.Brush.Solid = true;
            tChart1.Legend.Symbol.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Legend.Title.Brush.Color = Color.White;
            tChart1.Legend.Title.Brush.Solid = true;
            tChart1.Legend.Title.Brush.Visible = true;
            // 
            // 
            // 
            tChart1.Legend.Title.Font.Bold = true;
            // 
            // 
            // 
            tChart1.Legend.Title.Font.Brush.Color = Color.Black;
            tChart1.Legend.Title.Font.Brush.Solid = true;
            tChart1.Legend.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Legend.Title.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Legend.Title.Font.Shadow.Brush.Solid = true;
            tChart1.Legend.Title.Font.Shadow.Brush.Visible = true;
            tChart1.Legend.Title.Font.Size = 8;
            tChart1.Legend.Title.Font.SizeFloat = 8F;
            tChart1.Legend.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Bold;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Legend.Title.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Legend.Title.ImageBevel.Brush.Solid = true;
            tChart1.Legend.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Legend.Title.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Legend.Title.Shadow.Brush.Solid = true;
            tChart1.Legend.Title.Shadow.Brush.Visible = true;
            tChart1.Legend.Visible = false;
            tChart1.Location = new Point(-4, 0);
            tChart1.Name = "tChart1";
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Panel.Brush.Color = Color.FromArgb(255, 255, 255);
            tChart1.Panel.Brush.Solid = true;
            tChart1.Panel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Panel.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Panel.ImageBevel.Brush.Solid = true;
            tChart1.Panel.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Panel.Shadow.Brush.Color = Color.FromArgb(165, 165, 165);
            tChart1.Panel.Shadow.Brush.Solid = true;
            tChart1.Panel.Shadow.Brush.Visible = true;
            tChart1.Panel.Shadow.Height = 0;
            tChart1.Panel.Shadow.Width = 0;
            // 
            // 
            // 
            margins1.Bottom = 100;
            margins1.Left = 100;
            margins1.Right = 100;
            margins1.Top = 100;
            tChart1.Printer.Margins = margins1;
            tChart1.Series.Add(bar1);
            tChart1.Size = new Size(1157, 402);
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.SubFooter.Brush.Color = Color.Silver;
            tChart1.SubFooter.Brush.Solid = true;
            tChart1.SubFooter.Brush.Visible = true;
            // 
            // 
            // 
            tChart1.SubFooter.Font.Bold = false;
            // 
            // 
            // 
            tChart1.SubFooter.Font.Brush.Color = Color.Red;
            tChart1.SubFooter.Font.Brush.Solid = true;
            tChart1.SubFooter.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.SubFooter.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart1.SubFooter.Font.Shadow.Brush.Solid = true;
            tChart1.SubFooter.Font.Shadow.Brush.Visible = true;
            tChart1.SubFooter.Font.Size = 8;
            tChart1.SubFooter.Font.SizeFloat = 8F;
            tChart1.SubFooter.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.SubFooter.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.SubFooter.ImageBevel.Brush.Solid = true;
            tChart1.SubFooter.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.SubFooter.Shadow.Brush.Color = Color.DarkGray;
            tChart1.SubFooter.Shadow.Brush.Solid = true;
            tChart1.SubFooter.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.SubHeader.Brush.Color = Color.FromArgb(192, 192, 192);
            tChart1.SubHeader.Brush.Solid = true;
            tChart1.SubHeader.Brush.Visible = true;
            // 
            // 
            // 
            tChart1.SubHeader.Font.Bold = false;
            // 
            // 
            // 
            tChart1.SubHeader.Font.Brush.Color = Color.FromArgb(128, 128, 128);
            tChart1.SubHeader.Font.Brush.Solid = true;
            tChart1.SubHeader.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.SubHeader.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart1.SubHeader.Font.Shadow.Brush.Solid = true;
            tChart1.SubHeader.Font.Shadow.Brush.Visible = true;
            tChart1.SubHeader.Font.Size = 12;
            tChart1.SubHeader.Font.SizeFloat = 12F;
            tChart1.SubHeader.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.SubHeader.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.SubHeader.ImageBevel.Brush.Solid = true;
            tChart1.SubHeader.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.SubHeader.Shadow.Brush.Color = Color.FromArgb(169, 169, 169);
            tChart1.SubHeader.Shadow.Brush.Solid = true;
            tChart1.SubHeader.Shadow.Brush.Visible = true;
            tChart1.TabIndex = 13;
            tChart1.Text = "tChart1";
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Walls.Back.Brush.Color = Color.Silver;
            tChart1.Walls.Back.Brush.Solid = true;
            tChart1.Walls.Back.Brush.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Walls.Back.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Walls.Back.ImageBevel.Brush.Solid = true;
            tChart1.Walls.Back.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Walls.Back.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Walls.Back.Shadow.Brush.Solid = true;
            tChart1.Walls.Back.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Walls.Bottom.Brush.Color = Color.White;
            tChart1.Walls.Bottom.Brush.Solid = true;
            tChart1.Walls.Bottom.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Walls.Bottom.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Walls.Bottom.ImageBevel.Brush.Solid = true;
            tChart1.Walls.Bottom.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Walls.Bottom.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Walls.Bottom.Shadow.Brush.Solid = true;
            tChart1.Walls.Bottom.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Walls.Left.Brush.Color = Color.LightYellow;
            tChart1.Walls.Left.Brush.Solid = true;
            tChart1.Walls.Left.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Walls.Left.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Walls.Left.ImageBevel.Brush.Solid = true;
            tChart1.Walls.Left.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Walls.Left.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Walls.Left.Shadow.Brush.Solid = true;
            tChart1.Walls.Left.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Walls.Right.Brush.Color = Color.LightYellow;
            tChart1.Walls.Right.Brush.Solid = true;
            tChart1.Walls.Right.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Walls.Right.ImageBevel.Brush.Color = Color.LightGray;
            tChart1.Walls.Right.ImageBevel.Brush.Solid = true;
            tChart1.Walls.Right.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Walls.Right.Shadow.Brush.Color = Color.DarkGray;
            tChart1.Walls.Right.Shadow.Brush.Solid = true;
            tChart1.Walls.Right.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart1.Zoom.Brush.Color = Color.FromArgb(150, 173, 216, 230);
            tChart1.Zoom.Brush.Solid = true;
            tChart1.Zoom.Brush.Visible = true;
            tChart1.Scroll += tChart1_Scroll;
            tChart1.AfterDraw += tChart1_AfterDraw;
            tChart1.ClickSeries += tChart1_ClickSeries;
            // 
            // bar1
            // 
            bar1.BarRound = Steema.TeeChart.Styles.BarRounding.AtValue;
            // 
            // 
            // 
            bar1.Brush.Color = Color.FromArgb(119, 153, 214);
            bar1.Brush.Solid = true;
            bar1.Brush.Visible = true;
            bar1.Color = Color.FromArgb(119, 153, 214);
            bar1.Cursor = cursor1;
            // 
            // 
            // 
            // 
            // 
            // 
            bar1.Legend.Brush.Color = Color.White;
            bar1.Legend.Brush.Solid = true;
            bar1.Legend.Brush.Visible = true;
            // 
            // 
            // 
            bar1.Legend.Font.Bold = false;
            // 
            // 
            // 
            bar1.Legend.Font.Brush.Color = Color.Black;
            bar1.Legend.Font.Brush.Solid = true;
            bar1.Legend.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            bar1.Legend.Font.Shadow.Brush.Color = Color.DarkGray;
            bar1.Legend.Font.Shadow.Brush.Solid = true;
            bar1.Legend.Font.Shadow.Brush.Visible = true;
            bar1.Legend.Font.Size = 8;
            bar1.Legend.Font.SizeFloat = 8F;
            bar1.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            bar1.Legend.ImageBevel.Brush.Color = Color.LightGray;
            bar1.Legend.ImageBevel.Brush.Solid = true;
            bar1.Legend.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            bar1.Legend.Shadow.Brush.Color = Color.DarkGray;
            bar1.Legend.Shadow.Brush.Solid = true;
            bar1.Legend.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            bar1.Marks.Brush.Color = Color.FromArgb(255, 255, 255);
            bar1.Marks.Brush.Solid = true;
            bar1.Marks.Brush.Visible = true;
            // 
            // 
            // 
            bar1.Marks.Font.Bold = false;
            // 
            // 
            // 
            bar1.Marks.Font.Brush.Color = Color.Black;
            bar1.Marks.Font.Brush.Solid = true;
            bar1.Marks.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            bar1.Marks.Font.Shadow.Brush.Color = Color.DarkGray;
            bar1.Marks.Font.Shadow.Brush.Solid = true;
            bar1.Marks.Font.Shadow.Brush.Visible = true;
            bar1.Marks.Font.Size = 8;
            bar1.Marks.Font.SizeFloat = 8F;
            bar1.Marks.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            bar1.Marks.ImageBevel.Brush.Color = Color.LightGray;
            bar1.Marks.ImageBevel.Brush.Solid = true;
            bar1.Marks.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            bar1.Marks.Shadow.Brush.Color = Color.Gray;
            bar1.Marks.Shadow.Brush.Solid = true;
            bar1.Marks.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            bar1.Marks.Symbol.Brush.Color = Color.White;
            bar1.Marks.Symbol.Brush.Solid = true;
            bar1.Marks.Symbol.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            bar1.Marks.Symbol.ImageBevel.Brush.Color = Color.LightGray;
            bar1.Marks.Symbol.ImageBevel.Brush.Solid = true;
            bar1.Marks.Symbol.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            bar1.Marks.Symbol.Shadow.Brush.Color = Color.DarkGray;
            bar1.Marks.Symbol.Shadow.Brush.Solid = true;
            bar1.Marks.Symbol.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            bar1.Shadow.Brush.Color = Color.DarkGray;
            bar1.Shadow.Brush.Solid = true;
            bar1.Shadow.Brush.Visible = true;
            bar1.Title = "bar1";
            // 
            // 
            // 
            bar1.XValues.DataMember = "X";
            bar1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            bar1.XValues.Value = new double[]
    {
    0D,
    1D,
    2D,
    3D,
    4D,
    5D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D
    };
            // 
            // 
            // 
            bar1.YValues.DataMember = "Bar";
            bar1.YValues.Value = new double[]
    {
    403D,
    475D,
    482D,
    560D,
    675D,
    650D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D
    };
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tChart2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1149, 400);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tChart2
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Bottom.Labels.Brush.Color = Color.White;
            tChart2.Axes.Bottom.Labels.Brush.Solid = true;
            tChart2.Axes.Bottom.Labels.Brush.Visible = true;
            // 
            // 
            // 
            tChart2.Axes.Bottom.Labels.Font.Bold = false;
            // 
            // 
            // 
            tChart2.Axes.Bottom.Labels.Font.Brush.Color = Color.FromArgb(128, 128, 128);
            tChart2.Axes.Bottom.Labels.Font.Brush.Solid = true;
            tChart2.Axes.Bottom.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Bottom.Labels.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.Bottom.Labels.Font.Shadow.Brush.Solid = true;
            tChart2.Axes.Bottom.Labels.Font.Shadow.Brush.Visible = true;
            tChart2.Axes.Bottom.Labels.Font.Size = 9;
            tChart2.Axes.Bottom.Labels.Font.SizeFloat = 9F;
            tChart2.Axes.Bottom.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Bottom.Labels.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Axes.Bottom.Labels.ImageBevel.Brush.Solid = true;
            tChart2.Axes.Bottom.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Bottom.Labels.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.Bottom.Labels.Shadow.Brush.Solid = true;
            tChart2.Axes.Bottom.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Bottom.Title.Brush.Color = Color.Silver;
            tChart2.Axes.Bottom.Title.Brush.Solid = true;
            tChart2.Axes.Bottom.Title.Brush.Visible = true;
            tChart2.Axes.Bottom.Title.Distance = 0;
            // 
            // 
            // 
            tChart2.Axes.Bottom.Title.Font.Bold = false;
            // 
            // 
            // 
            tChart2.Axes.Bottom.Title.Font.Brush.Color = Color.FromArgb(64, 64, 64);
            tChart2.Axes.Bottom.Title.Font.Brush.Solid = true;
            tChart2.Axes.Bottom.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Bottom.Title.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.Bottom.Title.Font.Shadow.Brush.Solid = true;
            tChart2.Axes.Bottom.Title.Font.Shadow.Brush.Visible = true;
            tChart2.Axes.Bottom.Title.Font.Size = 11;
            tChart2.Axes.Bottom.Title.Font.SizeFloat = 11F;
            tChart2.Axes.Bottom.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Bottom.Title.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Axes.Bottom.Title.ImageBevel.Brush.Solid = true;
            tChart2.Axes.Bottom.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Bottom.Title.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.Bottom.Title.Shadow.Brush.Solid = true;
            tChart2.Axes.Bottom.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Depth.Labels.Brush.Color = Color.White;
            tChart2.Axes.Depth.Labels.Brush.Solid = true;
            tChart2.Axes.Depth.Labels.Brush.Visible = true;
            // 
            // 
            // 
            tChart2.Axes.Depth.Labels.Font.Bold = false;
            // 
            // 
            // 
            tChart2.Axes.Depth.Labels.Font.Brush.Color = Color.FromArgb(128, 128, 128);
            tChart2.Axes.Depth.Labels.Font.Brush.Solid = true;
            tChart2.Axes.Depth.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Depth.Labels.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.Depth.Labels.Font.Shadow.Brush.Solid = true;
            tChart2.Axes.Depth.Labels.Font.Shadow.Brush.Visible = true;
            tChart2.Axes.Depth.Labels.Font.Size = 9;
            tChart2.Axes.Depth.Labels.Font.SizeFloat = 9F;
            tChart2.Axes.Depth.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Depth.Labels.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Axes.Depth.Labels.ImageBevel.Brush.Solid = true;
            tChart2.Axes.Depth.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Depth.Labels.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.Depth.Labels.Shadow.Brush.Solid = true;
            tChart2.Axes.Depth.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Depth.Title.Brush.Color = Color.Silver;
            tChart2.Axes.Depth.Title.Brush.Solid = true;
            tChart2.Axes.Depth.Title.Brush.Visible = true;
            tChart2.Axes.Depth.Title.Distance = 0;
            // 
            // 
            // 
            tChart2.Axes.Depth.Title.Font.Bold = false;
            // 
            // 
            // 
            tChart2.Axes.Depth.Title.Font.Brush.Color = Color.FromArgb(64, 64, 64);
            tChart2.Axes.Depth.Title.Font.Brush.Solid = true;
            tChart2.Axes.Depth.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Depth.Title.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.Depth.Title.Font.Shadow.Brush.Solid = true;
            tChart2.Axes.Depth.Title.Font.Shadow.Brush.Visible = true;
            tChart2.Axes.Depth.Title.Font.Size = 11;
            tChart2.Axes.Depth.Title.Font.SizeFloat = 11F;
            tChart2.Axes.Depth.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Depth.Title.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Axes.Depth.Title.ImageBevel.Brush.Solid = true;
            tChart2.Axes.Depth.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Depth.Title.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.Depth.Title.Shadow.Brush.Solid = true;
            tChart2.Axes.Depth.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.DepthTop.Labels.Brush.Color = Color.White;
            tChart2.Axes.DepthTop.Labels.Brush.Solid = true;
            tChart2.Axes.DepthTop.Labels.Brush.Visible = true;
            // 
            // 
            // 
            tChart2.Axes.DepthTop.Labels.Font.Bold = false;
            // 
            // 
            // 
            tChart2.Axes.DepthTop.Labels.Font.Brush.Color = Color.FromArgb(128, 128, 128);
            tChart2.Axes.DepthTop.Labels.Font.Brush.Solid = true;
            tChart2.Axes.DepthTop.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.DepthTop.Labels.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.DepthTop.Labels.Font.Shadow.Brush.Solid = true;
            tChart2.Axes.DepthTop.Labels.Font.Shadow.Brush.Visible = true;
            tChart2.Axes.DepthTop.Labels.Font.Size = 9;
            tChart2.Axes.DepthTop.Labels.Font.SizeFloat = 9F;
            tChart2.Axes.DepthTop.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.DepthTop.Labels.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Axes.DepthTop.Labels.ImageBevel.Brush.Solid = true;
            tChart2.Axes.DepthTop.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.DepthTop.Labels.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.DepthTop.Labels.Shadow.Brush.Solid = true;
            tChart2.Axes.DepthTop.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.DepthTop.Title.Brush.Color = Color.Silver;
            tChart2.Axes.DepthTop.Title.Brush.Solid = true;
            tChart2.Axes.DepthTop.Title.Brush.Visible = true;
            tChart2.Axes.DepthTop.Title.Distance = 0;
            // 
            // 
            // 
            tChart2.Axes.DepthTop.Title.Font.Bold = false;
            // 
            // 
            // 
            tChart2.Axes.DepthTop.Title.Font.Brush.Color = Color.FromArgb(64, 64, 64);
            tChart2.Axes.DepthTop.Title.Font.Brush.Solid = true;
            tChart2.Axes.DepthTop.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.DepthTop.Title.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.DepthTop.Title.Font.Shadow.Brush.Solid = true;
            tChart2.Axes.DepthTop.Title.Font.Shadow.Brush.Visible = true;
            tChart2.Axes.DepthTop.Title.Font.Size = 11;
            tChart2.Axes.DepthTop.Title.Font.SizeFloat = 11F;
            tChart2.Axes.DepthTop.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.DepthTop.Title.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Axes.DepthTop.Title.ImageBevel.Brush.Solid = true;
            tChart2.Axes.DepthTop.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.DepthTop.Title.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.DepthTop.Title.Shadow.Brush.Solid = true;
            tChart2.Axes.DepthTop.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Left.Labels.Brush.Color = Color.White;
            tChart2.Axes.Left.Labels.Brush.Solid = true;
            tChart2.Axes.Left.Labels.Brush.Visible = true;
            // 
            // 
            // 
            tChart2.Axes.Left.Labels.Font.Bold = false;
            // 
            // 
            // 
            tChart2.Axes.Left.Labels.Font.Brush.Color = Color.FromArgb(128, 128, 128);
            tChart2.Axes.Left.Labels.Font.Brush.Solid = true;
            tChart2.Axes.Left.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Left.Labels.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.Left.Labels.Font.Shadow.Brush.Solid = true;
            tChart2.Axes.Left.Labels.Font.Shadow.Brush.Visible = true;
            tChart2.Axes.Left.Labels.Font.Size = 9;
            tChart2.Axes.Left.Labels.Font.SizeFloat = 9F;
            tChart2.Axes.Left.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Left.Labels.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Axes.Left.Labels.ImageBevel.Brush.Solid = true;
            tChart2.Axes.Left.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Left.Labels.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.Left.Labels.Shadow.Brush.Solid = true;
            tChart2.Axes.Left.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Left.Title.Brush.Color = Color.Silver;
            tChart2.Axes.Left.Title.Brush.Solid = true;
            tChart2.Axes.Left.Title.Brush.Visible = true;
            tChart2.Axes.Left.Title.Distance = 0;
            // 
            // 
            // 
            tChart2.Axes.Left.Title.Font.Bold = false;
            // 
            // 
            // 
            tChart2.Axes.Left.Title.Font.Brush.Color = Color.FromArgb(64, 64, 64);
            tChart2.Axes.Left.Title.Font.Brush.Solid = true;
            tChart2.Axes.Left.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Left.Title.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.Left.Title.Font.Shadow.Brush.Solid = true;
            tChart2.Axes.Left.Title.Font.Shadow.Brush.Visible = true;
            tChart2.Axes.Left.Title.Font.Size = 11;
            tChart2.Axes.Left.Title.Font.SizeFloat = 11F;
            tChart2.Axes.Left.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Left.Title.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Axes.Left.Title.ImageBevel.Brush.Solid = true;
            tChart2.Axes.Left.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Left.Title.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.Left.Title.Shadow.Brush.Solid = true;
            tChart2.Axes.Left.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Right.Labels.Brush.Color = Color.White;
            tChart2.Axes.Right.Labels.Brush.Solid = true;
            tChart2.Axes.Right.Labels.Brush.Visible = true;
            // 
            // 
            // 
            tChart2.Axes.Right.Labels.Font.Bold = false;
            // 
            // 
            // 
            tChart2.Axes.Right.Labels.Font.Brush.Color = Color.FromArgb(128, 128, 128);
            tChart2.Axes.Right.Labels.Font.Brush.Solid = true;
            tChart2.Axes.Right.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Right.Labels.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.Right.Labels.Font.Shadow.Brush.Solid = true;
            tChart2.Axes.Right.Labels.Font.Shadow.Brush.Visible = true;
            tChart2.Axes.Right.Labels.Font.Size = 9;
            tChart2.Axes.Right.Labels.Font.SizeFloat = 9F;
            tChart2.Axes.Right.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Right.Labels.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Axes.Right.Labels.ImageBevel.Brush.Solid = true;
            tChart2.Axes.Right.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Right.Labels.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.Right.Labels.Shadow.Brush.Solid = true;
            tChart2.Axes.Right.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Right.Title.Brush.Color = Color.Silver;
            tChart2.Axes.Right.Title.Brush.Solid = true;
            tChart2.Axes.Right.Title.Brush.Visible = true;
            tChart2.Axes.Right.Title.Distance = 0;
            // 
            // 
            // 
            tChart2.Axes.Right.Title.Font.Bold = false;
            // 
            // 
            // 
            tChart2.Axes.Right.Title.Font.Brush.Color = Color.FromArgb(64, 64, 64);
            tChart2.Axes.Right.Title.Font.Brush.Solid = true;
            tChart2.Axes.Right.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Right.Title.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.Right.Title.Font.Shadow.Brush.Solid = true;
            tChart2.Axes.Right.Title.Font.Shadow.Brush.Visible = true;
            tChart2.Axes.Right.Title.Font.Size = 11;
            tChart2.Axes.Right.Title.Font.SizeFloat = 11F;
            tChart2.Axes.Right.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Right.Title.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Axes.Right.Title.ImageBevel.Brush.Solid = true;
            tChart2.Axes.Right.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Right.Title.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.Right.Title.Shadow.Brush.Solid = true;
            tChart2.Axes.Right.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Top.Labels.Brush.Color = Color.White;
            tChart2.Axes.Top.Labels.Brush.Solid = true;
            tChart2.Axes.Top.Labels.Brush.Visible = true;
            // 
            // 
            // 
            tChart2.Axes.Top.Labels.Font.Bold = false;
            // 
            // 
            // 
            tChart2.Axes.Top.Labels.Font.Brush.Color = Color.FromArgb(128, 128, 128);
            tChart2.Axes.Top.Labels.Font.Brush.Solid = true;
            tChart2.Axes.Top.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Top.Labels.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.Top.Labels.Font.Shadow.Brush.Solid = true;
            tChart2.Axes.Top.Labels.Font.Shadow.Brush.Visible = true;
            tChart2.Axes.Top.Labels.Font.Size = 9;
            tChart2.Axes.Top.Labels.Font.SizeFloat = 9F;
            tChart2.Axes.Top.Labels.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Top.Labels.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Axes.Top.Labels.ImageBevel.Brush.Solid = true;
            tChart2.Axes.Top.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Top.Labels.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.Top.Labels.Shadow.Brush.Solid = true;
            tChart2.Axes.Top.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Top.Title.Brush.Color = Color.Silver;
            tChart2.Axes.Top.Title.Brush.Solid = true;
            tChart2.Axes.Top.Title.Brush.Visible = true;
            tChart2.Axes.Top.Title.Distance = 0;
            // 
            // 
            // 
            tChart2.Axes.Top.Title.Font.Bold = false;
            // 
            // 
            // 
            tChart2.Axes.Top.Title.Font.Brush.Color = Color.FromArgb(64, 64, 64);
            tChart2.Axes.Top.Title.Font.Brush.Solid = true;
            tChart2.Axes.Top.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Top.Title.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.Top.Title.Font.Shadow.Brush.Solid = true;
            tChart2.Axes.Top.Title.Font.Shadow.Brush.Visible = true;
            tChart2.Axes.Top.Title.Font.Size = 11;
            tChart2.Axes.Top.Title.Font.SizeFloat = 11F;
            tChart2.Axes.Top.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Top.Title.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Axes.Top.Title.ImageBevel.Brush.Solid = true;
            tChart2.Axes.Top.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Axes.Top.Title.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Axes.Top.Title.Shadow.Brush.Solid = true;
            tChart2.Axes.Top.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Footer.Brush.Color = Color.Silver;
            tChart2.Footer.Brush.Solid = true;
            tChart2.Footer.Brush.Visible = true;
            // 
            // 
            // 
            tChart2.Footer.Font.Bold = false;
            // 
            // 
            // 
            tChart2.Footer.Font.Brush.Color = Color.Red;
            tChart2.Footer.Font.Brush.Solid = true;
            tChart2.Footer.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Footer.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Footer.Font.Shadow.Brush.Solid = true;
            tChart2.Footer.Font.Shadow.Brush.Visible = true;
            tChart2.Footer.Font.Size = 8;
            tChart2.Footer.Font.SizeFloat = 8F;
            tChart2.Footer.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Footer.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Footer.ImageBevel.Brush.Solid = true;
            tChart2.Footer.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Footer.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Footer.Shadow.Brush.Solid = true;
            tChart2.Footer.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Header.Brush.Color = Color.FromArgb(192, 192, 192);
            tChart2.Header.Brush.Solid = true;
            tChart2.Header.Brush.Visible = true;
            // 
            // 
            // 
            tChart2.Header.Font.Bold = false;
            // 
            // 
            // 
            tChart2.Header.Font.Brush.Color = Color.FromArgb(128, 128, 128);
            tChart2.Header.Font.Brush.Solid = true;
            tChart2.Header.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Header.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Header.Font.Shadow.Brush.Solid = true;
            tChart2.Header.Font.Shadow.Brush.Visible = true;
            tChart2.Header.Font.Size = 12;
            tChart2.Header.Font.SizeFloat = 12F;
            tChart2.Header.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Header.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Header.ImageBevel.Brush.Solid = true;
            tChart2.Header.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Header.Shadow.Brush.Color = Color.FromArgb(169, 169, 169);
            tChart2.Header.Shadow.Brush.Solid = true;
            tChart2.Header.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            tChart2.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom;
            // 
            // 
            // 
            tChart2.Legend.Brush.Color = Color.White;
            tChart2.Legend.Brush.Solid = true;
            tChart2.Legend.Brush.Visible = true;
            tChart2.Legend.CheckBoxes = false;
            tChart2.Legend.ClipText = false;
            // 
            // 
            // 
            tChart2.Legend.Font.Bold = false;
            // 
            // 
            // 
            tChart2.Legend.Font.Brush.Color = Color.FromArgb(64, 64, 64);
            tChart2.Legend.Font.Brush.Solid = true;
            tChart2.Legend.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Legend.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Legend.Font.Shadow.Brush.Solid = true;
            tChart2.Legend.Font.Shadow.Brush.Visible = true;
            tChart2.Legend.Font.Size = 9;
            tChart2.Legend.Font.SizeFloat = 9F;
            tChart2.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Legend.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Legend.ImageBevel.Brush.Solid = true;
            tChart2.Legend.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Legend.Shadow.Brush.Color = Color.FromArgb(0, 0, 0);
            tChart2.Legend.Shadow.Brush.Solid = true;
            tChart2.Legend.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Legend.Symbol.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Legend.Symbol.Shadow.Brush.Solid = true;
            tChart2.Legend.Symbol.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Legend.Title.Brush.Color = Color.White;
            tChart2.Legend.Title.Brush.Solid = true;
            tChart2.Legend.Title.Brush.Visible = true;
            // 
            // 
            // 
            tChart2.Legend.Title.Font.Bold = true;
            // 
            // 
            // 
            tChart2.Legend.Title.Font.Brush.Color = Color.Black;
            tChart2.Legend.Title.Font.Brush.Solid = true;
            tChart2.Legend.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Legend.Title.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Legend.Title.Font.Shadow.Brush.Solid = true;
            tChart2.Legend.Title.Font.Shadow.Brush.Visible = true;
            tChart2.Legend.Title.Font.Size = 8;
            tChart2.Legend.Title.Font.SizeFloat = 8F;
            tChart2.Legend.Title.Font.Style = Steema.TeeChart.Drawing.FontStyle.Bold;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Legend.Title.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Legend.Title.ImageBevel.Brush.Solid = true;
            tChart2.Legend.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Legend.Title.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Legend.Title.Shadow.Brush.Solid = true;
            tChart2.Legend.Title.Shadow.Brush.Visible = true;
            tChart2.Location = new Point(3, 3);
            tChart2.Name = "tChart2";
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Panel.Brush.Color = Color.FromArgb(255, 255, 255);
            tChart2.Panel.Brush.Solid = true;
            tChart2.Panel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Panel.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Panel.ImageBevel.Brush.Solid = true;
            tChart2.Panel.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Panel.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Panel.Shadow.Brush.Solid = true;
            tChart2.Panel.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            margins2.Bottom = 100;
            margins2.Left = 100;
            margins2.Right = 100;
            margins2.Top = 100;
            tChart2.Printer.Margins = margins2;
            tChart2.Series.Add(line2);
            tChart2.Series.Add(line1);
            tChart2.Size = new Size(1146, 395);
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.SubFooter.Brush.Color = Color.Silver;
            tChart2.SubFooter.Brush.Solid = true;
            tChart2.SubFooter.Brush.Visible = true;
            // 
            // 
            // 
            tChart2.SubFooter.Font.Bold = false;
            // 
            // 
            // 
            tChart2.SubFooter.Font.Brush.Color = Color.Red;
            tChart2.SubFooter.Font.Brush.Solid = true;
            tChart2.SubFooter.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.SubFooter.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart2.SubFooter.Font.Shadow.Brush.Solid = true;
            tChart2.SubFooter.Font.Shadow.Brush.Visible = true;
            tChart2.SubFooter.Font.Size = 8;
            tChart2.SubFooter.Font.SizeFloat = 8F;
            tChart2.SubFooter.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.SubFooter.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.SubFooter.ImageBevel.Brush.Solid = true;
            tChart2.SubFooter.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.SubFooter.Shadow.Brush.Color = Color.DarkGray;
            tChart2.SubFooter.Shadow.Brush.Solid = true;
            tChart2.SubFooter.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.SubHeader.Brush.Color = Color.FromArgb(192, 192, 192);
            tChart2.SubHeader.Brush.Solid = true;
            tChart2.SubHeader.Brush.Visible = true;
            // 
            // 
            // 
            tChart2.SubHeader.Font.Bold = false;
            // 
            // 
            // 
            tChart2.SubHeader.Font.Brush.Color = Color.FromArgb(128, 128, 128);
            tChart2.SubHeader.Font.Brush.Solid = true;
            tChart2.SubHeader.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.SubHeader.Font.Shadow.Brush.Color = Color.DarkGray;
            tChart2.SubHeader.Font.Shadow.Brush.Solid = true;
            tChart2.SubHeader.Font.Shadow.Brush.Visible = true;
            tChart2.SubHeader.Font.Size = 12;
            tChart2.SubHeader.Font.SizeFloat = 12F;
            tChart2.SubHeader.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.SubHeader.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.SubHeader.ImageBevel.Brush.Solid = true;
            tChart2.SubHeader.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.SubHeader.Shadow.Brush.Color = Color.FromArgb(169, 169, 169);
            tChart2.SubHeader.Shadow.Brush.Solid = true;
            tChart2.SubHeader.Shadow.Brush.Visible = true;
            tChart2.TabIndex = 0;
            tChart2.Text = "tChart2";
            tChart2.Tools.Add(nearestPoint1);
            tChart2.Tools.Add(nearestPoint2);
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Walls.Back.Brush.Color = Color.Silver;
            tChart2.Walls.Back.Brush.Solid = true;
            tChart2.Walls.Back.Brush.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Walls.Back.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Walls.Back.ImageBevel.Brush.Solid = true;
            tChart2.Walls.Back.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Walls.Back.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Walls.Back.Shadow.Brush.Solid = true;
            tChart2.Walls.Back.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Walls.Bottom.Brush.Color = Color.White;
            tChart2.Walls.Bottom.Brush.Solid = true;
            tChart2.Walls.Bottom.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Walls.Bottom.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Walls.Bottom.ImageBevel.Brush.Solid = true;
            tChart2.Walls.Bottom.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Walls.Bottom.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Walls.Bottom.Shadow.Brush.Solid = true;
            tChart2.Walls.Bottom.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Walls.Left.Brush.Color = Color.LightYellow;
            tChart2.Walls.Left.Brush.Solid = true;
            tChart2.Walls.Left.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Walls.Left.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Walls.Left.ImageBevel.Brush.Solid = true;
            tChart2.Walls.Left.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Walls.Left.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Walls.Left.Shadow.Brush.Solid = true;
            tChart2.Walls.Left.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Walls.Right.Brush.Color = Color.LightYellow;
            tChart2.Walls.Right.Brush.Solid = true;
            tChart2.Walls.Right.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Walls.Right.ImageBevel.Brush.Color = Color.LightGray;
            tChart2.Walls.Right.ImageBevel.Brush.Solid = true;
            tChart2.Walls.Right.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Walls.Right.Shadow.Brush.Color = Color.DarkGray;
            tChart2.Walls.Right.Shadow.Brush.Solid = true;
            tChart2.Walls.Right.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            tChart2.Zoom.Brush.Color = Color.FromArgb(150, 173, 216, 230);
            tChart2.Zoom.Brush.Solid = true;
            tChart2.Zoom.Brush.Visible = true;
            // 
            // line2
            // 
            // 
            // 
            // 
            line2.AreaBrush.Color = Color.White;
            line2.AreaBrush.Solid = true;
            line2.AreaBrush.Visible = false;
            // 
            // 
            // 
            line2.Brush.Color = Color.FromArgb(255, 207, 104);
            line2.Brush.Solid = true;
            line2.Brush.Visible = true;
            line2.Color = Color.FromArgb(255, 207, 104);
            line2.Cursor = cursor2;
            // 
            // 
            // 
            // 
            // 
            // 
            line2.Legend.Brush.Color = Color.White;
            line2.Legend.Brush.Solid = true;
            line2.Legend.Brush.Visible = true;
            // 
            // 
            // 
            line2.Legend.Font.Bold = false;
            // 
            // 
            // 
            line2.Legend.Font.Brush.Color = Color.Black;
            line2.Legend.Font.Brush.Solid = true;
            line2.Legend.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            line2.Legend.Font.Shadow.Brush.Color = Color.DarkGray;
            line2.Legend.Font.Shadow.Brush.Solid = true;
            line2.Legend.Font.Shadow.Brush.Visible = true;
            line2.Legend.Font.Size = 8;
            line2.Legend.Font.SizeFloat = 8F;
            line2.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            line2.Legend.ImageBevel.Brush.Color = Color.LightGray;
            line2.Legend.ImageBevel.Brush.Solid = true;
            line2.Legend.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            line2.Legend.Shadow.Brush.Color = Color.DarkGray;
            line2.Legend.Shadow.Brush.Solid = true;
            line2.Legend.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            line2.LinePen.Width = 3;
            // 
            // 
            // 
            // 
            // 
            // 
            line2.Marks.Brush.Color = Color.FromArgb(255, 255, 255);
            line2.Marks.Brush.Solid = true;
            line2.Marks.Brush.Visible = true;
            // 
            // 
            // 
            line2.Marks.Font.Bold = false;
            // 
            // 
            // 
            line2.Marks.Font.Brush.Color = Color.Black;
            line2.Marks.Font.Brush.Solid = true;
            line2.Marks.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            line2.Marks.Font.Shadow.Brush.Color = Color.DarkGray;
            line2.Marks.Font.Shadow.Brush.Solid = true;
            line2.Marks.Font.Shadow.Brush.Visible = true;
            line2.Marks.Font.Size = 8;
            line2.Marks.Font.SizeFloat = 8F;
            line2.Marks.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            line2.Marks.ImageBevel.Brush.Color = Color.LightGray;
            line2.Marks.ImageBevel.Brush.Solid = true;
            line2.Marks.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            line2.Marks.Shadow.Brush.Color = Color.Gray;
            line2.Marks.Shadow.Brush.Solid = true;
            line2.Marks.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            line2.Marks.Symbol.Brush.Color = Color.White;
            line2.Marks.Symbol.Brush.Solid = true;
            line2.Marks.Symbol.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            line2.Marks.Symbol.ImageBevel.Brush.Color = Color.LightGray;
            line2.Marks.Symbol.ImageBevel.Brush.Solid = true;
            line2.Marks.Symbol.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            line2.Marks.Symbol.Shadow.Brush.Color = Color.DarkGray;
            line2.Marks.Symbol.Shadow.Brush.Solid = true;
            line2.Marks.Symbol.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            line2.Pointer.Brush.Color = Color.FromArgb(255, 207, 104);
            line2.Pointer.Brush.Solid = true;
            line2.Pointer.Brush.Visible = true;
            line2.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Circle;
            line2.Pointer.Visible = true;
            line2.Title = "Temperatura (ºC)";
            // 
            // 
            // 
            line2.XValues.DataMember = "X";
            line2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            line2.XValues.Value = new double[]
    {
    0D,
    1D,
    2D,
    3D,
    4D,
    5D,
    6D,
    7D,
    8D,
    9D,
    10D,
    11D,
    12D,
    13D,
    14D,
    15D,
    16D,
    17D,
    18D,
    19D,
    20D,
    21D,
    22D,
    23D,
    24D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D
    };
            // 
            // 
            // 
            line2.YValues.DataMember = "Y";
            line2.YValues.Value = new double[]
    {
    82D,
    37D,
    62D,
    127D,
    5D,
    73D,
    176D,
    172D,
    258D,
    341D,
    386D,
    352D,
    264D,
    198D,
    146D,
    214D,
    107D,
    176D,
    99D,
    140D,
    119D,
    98D,
    218D,
    148D,
    198D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D
    };
            // 
            // line1
            // 
            // 
            // 
            // 
            line1.AreaBrush.Color = Color.White;
            line1.AreaBrush.Solid = true;
            line1.AreaBrush.Visible = false;
            // 
            // 
            // 
            line1.Brush.Color = Color.FromArgb(119, 153, 214);
            line1.Brush.Solid = true;
            line1.Brush.Visible = true;
            line1.Color = Color.FromArgb(119, 153, 214);
            line1.Cursor = cursor2;
            // 
            // 
            // 
            // 
            // 
            // 
            line1.Legend.Brush.Color = Color.White;
            line1.Legend.Brush.Solid = true;
            line1.Legend.Brush.Visible = true;
            // 
            // 
            // 
            line1.Legend.Font.Bold = false;
            // 
            // 
            // 
            line1.Legend.Font.Brush.Color = Color.Black;
            line1.Legend.Font.Brush.Solid = true;
            line1.Legend.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            line1.Legend.Font.Shadow.Brush.Color = Color.DarkGray;
            line1.Legend.Font.Shadow.Brush.Solid = true;
            line1.Legend.Font.Shadow.Brush.Visible = true;
            line1.Legend.Font.Size = 8;
            line1.Legend.Font.SizeFloat = 8F;
            line1.Legend.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            line1.Legend.ImageBevel.Brush.Color = Color.LightGray;
            line1.Legend.ImageBevel.Brush.Solid = true;
            line1.Legend.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            line1.Legend.Shadow.Brush.Color = Color.DarkGray;
            line1.Legend.Shadow.Brush.Solid = true;
            line1.Legend.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            line1.LinePen.Width = 3;
            // 
            // 
            // 
            // 
            // 
            // 
            line1.Marks.Brush.Color = Color.FromArgb(255, 255, 255);
            line1.Marks.Brush.Solid = true;
            line1.Marks.Brush.Visible = true;
            // 
            // 
            // 
            line1.Marks.Font.Bold = false;
            // 
            // 
            // 
            line1.Marks.Font.Brush.Color = Color.Black;
            line1.Marks.Font.Brush.Solid = true;
            line1.Marks.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            line1.Marks.Font.Shadow.Brush.Color = Color.DarkGray;
            line1.Marks.Font.Shadow.Brush.Solid = true;
            line1.Marks.Font.Shadow.Brush.Visible = true;
            line1.Marks.Font.Size = 8;
            line1.Marks.Font.SizeFloat = 8F;
            line1.Marks.Font.Style = Steema.TeeChart.Drawing.FontStyle.Regular;
            // 
            // 
            // 
            // 
            // 
            // 
            line1.Marks.ImageBevel.Brush.Color = Color.LightGray;
            line1.Marks.ImageBevel.Brush.Solid = true;
            line1.Marks.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            line1.Marks.Shadow.Brush.Color = Color.Gray;
            line1.Marks.Shadow.Brush.Solid = true;
            line1.Marks.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            line1.Marks.Symbol.Brush.Color = Color.White;
            line1.Marks.Symbol.Brush.Solid = true;
            line1.Marks.Symbol.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            line1.Marks.Symbol.ImageBevel.Brush.Color = Color.LightGray;
            line1.Marks.Symbol.ImageBevel.Brush.Solid = true;
            line1.Marks.Symbol.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            line1.Marks.Symbol.Shadow.Brush.Color = Color.DarkGray;
            line1.Marks.Symbol.Shadow.Brush.Solid = true;
            line1.Marks.Symbol.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            line1.Pointer.Brush.Color = Color.FromArgb(119, 153, 214);
            line1.Pointer.Brush.Solid = true;
            line1.Pointer.Brush.Visible = true;
            line1.Pointer.Visible = true;
            line1.Title = "Humitat relativa (%)";
            // 
            // 
            // 
            line1.XValues.DataMember = "X";
            line1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            line1.XValues.Value = new double[]
    {
    0D,
    1D,
    2D,
    3D,
    4D,
    5D,
    6D,
    7D,
    8D,
    9D,
    10D,
    11D,
    12D,
    13D,
    14D,
    15D,
    16D,
    17D,
    18D,
    19D,
    20D,
    21D,
    22D,
    23D,
    24D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D
    };
            // 
            // 
            // 
            line1.YValues.DataMember = "Y";
            line1.YValues.Value = new double[]
    {
    326D,
    298D,
    304D,
    326D,
    349D,
    364D,
    362D,
    369D,
    345D,
    305D,
    269D,
    286D,
    289D,
    291D,
    291D,
    310D,
    302D,
    342D,
    328D,
    289D,
    298D,
    298D,
    297D,
    340D,
    310D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D,
    0D
    };
            // 
            // nearestPoint1
            // 
            // 
            // 
            // 
            nearestPoint1.Brush.Color = Color.FromArgb(247, 189, 125);
            nearestPoint1.Brush.Solid = true;
            nearestPoint1.Brush.Visible = true;
            // 
            // 
            // 
            nearestPoint1.Pen.Color = Color.White;
            nearestPoint1.Pen.Width = 2;
            nearestPoint1.Series = line2;
            nearestPoint1.SeriesIndex = 0;
            nearestPoint1.Size = 10;
            // 
            // nearestPoint2
            // 
            // 
            // 
            // 
            nearestPoint2.Brush.Color = Color.FromArgb(112, 135, 245);
            nearestPoint2.Brush.Solid = true;
            nearestPoint2.Brush.Visible = true;
            // 
            // 
            // 
            nearestPoint2.Pen.Color = Color.White;
            nearestPoint2.Pen.Width = 2;
            nearestPoint2.Series = line1;
            nearestPoint2.SeriesIndex = 1;
            nearestPoint2.Size = 10;
            nearestPoint2.Style = Steema.TeeChart.Tools.NearestPointStyles.Rectangle;
            // 
            // chartController1
            // 
            chartController1.ButtonSize = Steema.TeeChart.ControllerButtonSize.x16;
            chartController1.Chart = tChart1;
            chartController1.LabelValues = true;
            chartController1.Location = new Point(0, 0);
            chartController1.Name = "chartController1";
            chartController1.Size = new Size(1501, 25);
            chartController1.TabIndex = 12;
            chartController1.Text = "chartController1";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // btnDays
            // 
            btnDays.Location = new Point(195, 258);
            btnDays.Name = "btnDays";
            btnDays.Size = new Size(75, 36);
            btnDays.TabIndex = 13;
            btnDays.Text = "Days";
            btnDays.UseVisualStyleBackColor = true;
            btnDays.Click += btnDays_Click;
            // 
            // btnHours
            // 
            btnHours.Location = new Point(276, 258);
            btnHours.Name = "btnHours";
            btnHours.Size = new Size(75, 36);
            btnHours.TabIndex = 14;
            btnHours.Text = "Hours";
            btnHours.UseVisualStyleBackColor = true;
            // 
            // btnWeekend
            // 
            btnWeekend.Location = new Point(357, 258);
            btnWeekend.Name = "btnWeekend";
            btnWeekend.Size = new Size(75, 36);
            btnWeekend.TabIndex = 15;
            btnWeekend.Text = "Weekend";
            btnWeekend.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Items.AddRange(new object[] { "Girona", "Barcelona", "Banyoles", "Birmingham" });
            listBox1.Location = new Point(902, 29);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(81, 64);
            listBox1.TabIndex = 16;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(276, 736);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 17;
            button1.Text = "NEXT";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(194, 734);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 18;
            button2.Text = "PREVIOUS";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1501, 796);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Controls.Add(btnWeekend);
            Controls.Add(btnHours);
            Controls.Add(btnDays);
            Controls.Add(chartController1);
            Controls.Add(tabControl1);
            Controls.Add(lblMinMax);
            Controls.Add(imgIcon);
            Controls.Add(lblTemp);
            Controls.Add(lblProvincia);
            Controls.Add(lblCity);
            Controls.Add(label2);
            Controls.Add(txtBoxCity);
            Controls.Add(label1);
            Controls.Add(btnSearch);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)imgIcon).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Steema.TeeChart.ButtonPen btnSearch;
        private Label label1;
        private TextBox txtBoxCity;
        private Label label2;
        private Label lblCity;
        private Label lblProvincia;
        private Label lblTemp;
        private PictureBox imgIcon;
        private Label lblMinMax;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Steema.TeeChart.TChart tChart1;
        private TabPage tabPage2;
        private Steema.TeeChart.TChart tChart2;
        private Steema.TeeChart.Styles.Line line1;
        private Steema.TeeChart.Styles.Line line2;
        private Steema.TeeChart.ChartController chartController1;
        private Steema.TeeChart.Tools.NearestPoint nearestPoint1;
        private ContextMenuStrip contextMenuStrip1;
        private Button btnDays;
        private Button btnHours;
        private Button btnWeekend;
        private ListBox listBox1;
        private Steema.TeeChart.Tools.NearestPoint nearestPoint2;
        private Button button1;
        private Button button2;
        private Steema.TeeChart.Styles.Bar bar1;
        private HScrollBar hScrollBar1;
    }
}
