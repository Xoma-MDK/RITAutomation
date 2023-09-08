namespace RITAutomation
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.GMCMap = new GMap.NET.WindowsForms.GMapControl();
            this.SuspendLayout();
            // 
            // GMCMap
            // 
            this.GMCMap.AllowDrop = true;
            this.GMCMap.Bearing = 0F;
            this.GMCMap.CanDragMap = true;
            this.GMCMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.GMCMap.GrayScaleMode = false;
            this.GMCMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.GMCMap.LevelsKeepInMemmory = 5;
            this.GMCMap.Location = new System.Drawing.Point(12, 12);
            this.GMCMap.MarkersEnabled = true;
            this.GMCMap.MaxZoom = 2;
            this.GMCMap.MinZoom = 2;
            this.GMCMap.MouseWheelZoomEnabled = true;
            this.GMCMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.GMCMap.Name = "GMCMap";
            this.GMCMap.NegativeMode = false;
            this.GMCMap.PolygonsEnabled = true;
            this.GMCMap.RetryLoadTile = 0;
            this.GMCMap.RoutesEnabled = true;
            this.GMCMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.GMCMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.GMCMap.ShowTileGridLines = false;
            this.GMCMap.Size = new System.Drawing.Size(776, 426);
            this.GMCMap.TabIndex = 0;
            this.GMCMap.Zoom = 0D;
            this.GMCMap.OnMarkerEnter += new GMap.NET.WindowsForms.MarkerEnter(this.GMCMap_OnMarkerEnter);
            this.GMCMap.OnMarkerLeave += new GMap.NET.WindowsForms.MarkerLeave(this.GMCMap_OnMarkerLeave);
            this.GMCMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GMCMap_MouseDown);
            this.GMCMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GMCMap_MouseMove);
            this.GMCMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GMCMap_MouseUp);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GMCMap);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main window";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl GMCMap;
    }
}

