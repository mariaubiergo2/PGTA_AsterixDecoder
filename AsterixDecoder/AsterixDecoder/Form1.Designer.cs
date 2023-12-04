
namespace AsterixDecoder
{
    partial class MainWindow
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.csvGridView = new System.Windows.Forms.DataGridView();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.viewPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.backPictureBox = new System.Windows.Forms.PictureBox();
            this.playPictureBox = new System.Windows.Forms.PictureBox();
            this.fowardPictureBox = new System.Windows.Forms.PictureBox();
            this.speedDecisionBox = new System.Windows.Forms.ComboBox();
            this.hourBox = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressLbl = new System.Windows.Forms.Label();
            this.cSVToolboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importBinaryFileToDecodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizeCSVFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trajectoriesSimulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizeCSVFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTrajectoriesInKMLFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fAQsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.infoLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.csvGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.viewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fowardPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // csvGridView
            // 
            this.csvGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.csvGridView.Location = new System.Drawing.Point(13, 43);
            this.csvGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.csvGridView.Name = "csvGridView";
            this.csvGridView.RowHeadersWidth = 51;
            this.csvGridView.RowTemplate.Height = 24;
            this.csvGridView.Size = new System.Drawing.Size(1181, 416);
            this.csvGridView.TabIndex = 3;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(708, 530);
            this.pictureBoxLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(485, 57);
            this.pictureBoxLogo.TabIndex = 4;
            this.pictureBoxLogo.TabStop = false;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(924, 487);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(44, 16);
            this.title.TabIndex = 5;
            this.title.Text = "label1";
            // 
            // viewPanel
            // 
            this.viewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.viewPanel.Controls.Add(this.backPictureBox);
            this.viewPanel.Controls.Add(this.playPictureBox);
            this.viewPanel.Controls.Add(this.fowardPictureBox);
            this.viewPanel.Controls.Add(this.speedDecisionBox);
            this.viewPanel.Controls.Add(this.hourBox);
            this.viewPanel.Location = new System.Drawing.Point(13, 461);
            this.viewPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(882, 65);
            this.viewPanel.TabIndex = 9;
            // 
            // backPictureBox
            // 
            this.backPictureBox.Location = new System.Drawing.Point(3, 3);
            this.backPictureBox.Name = "backPictureBox";
            this.backPictureBox.Size = new System.Drawing.Size(83, 29);
            this.backPictureBox.TabIndex = 14;
            this.backPictureBox.TabStop = false;
            // 
            // playPictureBox
            // 
            this.playPictureBox.Location = new System.Drawing.Point(92, 3);
            this.playPictureBox.Name = "playPictureBox";
            this.playPictureBox.Size = new System.Drawing.Size(64, 29);
            this.playPictureBox.TabIndex = 12;
            this.playPictureBox.TabStop = false;
            this.playPictureBox.Click += new System.EventHandler(this.playPictureBox_Click);
            // 
            // fowardPictureBox
            // 
            this.fowardPictureBox.Location = new System.Drawing.Point(162, 3);
            this.fowardPictureBox.Name = "fowardPictureBox";
            this.fowardPictureBox.Size = new System.Drawing.Size(38, 29);
            this.fowardPictureBox.TabIndex = 15;
            this.fowardPictureBox.TabStop = false;
            // 
            // speedDecisionBox
            // 
            this.speedDecisionBox.FormattingEnabled = true;
            this.speedDecisionBox.Items.AddRange(new object[] {
            "x 0.5",
            "x 1",
            "x 1.5",
            "x 2",
            "x 3"});
            this.speedDecisionBox.Location = new System.Drawing.Point(206, 3);
            this.speedDecisionBox.Name = "speedDecisionBox";
            this.speedDecisionBox.Size = new System.Drawing.Size(93, 24);
            this.speedDecisionBox.TabIndex = 19;
            this.speedDecisionBox.SelectedIndexChanged += new System.EventHandler(this.speedDecisionBox_SelectedIndexChanged);
            // 
            // hourBox
            // 
            this.hourBox.Location = new System.Drawing.Point(305, 3);
            this.hourBox.Name = "hourBox";
            this.hourBox.Size = new System.Drawing.Size(104, 22);
            this.hourBox.TabIndex = 20;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 592);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1205, 10);
            this.progressBar1.TabIndex = 6;
            // 
            // progressLbl
            // 
            this.progressLbl.AutoSize = true;
            this.progressLbl.Font = new System.Drawing.Font("Cascadia Code", 8F);
            this.progressLbl.Location = new System.Drawing.Point(9, 569);
            this.progressLbl.Name = "progressLbl";
            this.progressLbl.Size = new System.Drawing.Size(88, 18);
            this.progressLbl.TabIndex = 10;
            this.progressLbl.Text = "Loading...";
            // 
            // cSVToolboxToolStripMenuItem
            // 
            this.cSVToolboxToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importBinaryFileToDecodeToolStripMenuItem,
            this.visualizeCSVFileToolStripMenuItem1,
            this.saveAsToolStripMenuItem});
            this.cSVToolboxToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Code", 9F);
            this.cSVToolboxToolStripMenuItem.Name = "cSVToolboxToolStripMenuItem";
            this.cSVToolboxToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.cSVToolboxToolStripMenuItem.Text = "CSV toolbox";
            this.cSVToolboxToolStripMenuItem.Click += new System.EventHandler(this.cSVToolboxToolStripMenuItem_Click);
            // 
            // importBinaryFileToDecodeToolStripMenuItem
            // 
            this.importBinaryFileToDecodeToolStripMenuItem.Name = "importBinaryFileToDecodeToolStripMenuItem";
            this.importBinaryFileToDecodeToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.importBinaryFileToDecodeToolStripMenuItem.Text = "Import binary file to decode";
            this.importBinaryFileToDecodeToolStripMenuItem.Click += new System.EventHandler(this.importBinaryFileToDecodeToolStripMenuItem_Click);
            // 
            // visualizeCSVFileToolStripMenuItem1
            // 
            this.visualizeCSVFileToolStripMenuItem1.Name = "visualizeCSVFileToolStripMenuItem1";
            this.visualizeCSVFileToolStripMenuItem1.Size = new System.Drawing.Size(344, 26);
            this.visualizeCSVFileToolStripMenuItem1.Text = "Visualize CSV file";
            this.visualizeCSVFileToolStripMenuItem1.Click += new System.EventHandler(this.visualizeCSVFileToolStripMenuItem1_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // trajectoriesSimulatorToolStripMenuItem
            // 
            this.trajectoriesSimulatorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualizeCSVFileToolStripMenuItem,
            this.saveTrajectoriesInKMLFormatToolStripMenuItem});
            this.trajectoriesSimulatorToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Code", 9F);
            this.trajectoriesSimulatorToolStripMenuItem.Name = "trajectoriesSimulatorToolStripMenuItem";
            this.trajectoriesSimulatorToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.trajectoriesSimulatorToolStripMenuItem.Text = "Trajectories simulator";
            this.trajectoriesSimulatorToolStripMenuItem.Click += new System.EventHandler(this.trajectoriesSimulatorToolStripMenuItem_Click);
            // 
            // visualizeCSVFileToolStripMenuItem
            // 
            this.visualizeCSVFileToolStripMenuItem.Name = "visualizeCSVFileToolStripMenuItem";
            this.visualizeCSVFileToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.visualizeCSVFileToolStripMenuItem.Text = "Visualize CSV file";
            this.visualizeCSVFileToolStripMenuItem.Click += new System.EventHandler(this.visualizeCSVFileToolStripMenuItem_Click);
            // 
            // saveTrajectoriesInKMLFormatToolStripMenuItem
            // 
            this.saveTrajectoriesInKMLFormatToolStripMenuItem.Name = "saveTrajectoriesInKMLFormatToolStripMenuItem";
            this.saveTrajectoriesInKMLFormatToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.saveTrajectoriesInKMLFormatToolStripMenuItem.Text = "Save trajectories in KML format";
            this.saveTrajectoriesInKMLFormatToolStripMenuItem.Click += new System.EventHandler(this.saveTrajectoriesInKMLFormatToolStripMenuItem_Click);
            // 
            // fAQsToolStripMenuItem
            // 
            this.fAQsToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Code", 9F);
            this.fAQsToolStripMenuItem.Name = "fAQsToolStripMenuItem";
            this.fAQsToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.fAQsToolStripMenuItem.Text = "FAQs";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cSVToolboxToolStripMenuItem,
            this.trajectoriesSimulatorToolStripMenuItem,
            this.fAQsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1205, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gmap
            // 
            this.gmap.AutoSize = true;
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemory = 5;
            this.gmap.Location = new System.Drawing.Point(11, 43);
            this.gmap.Margin = new System.Windows.Forms.Padding(4);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 2;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Fractional;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(1183, 402);
            this.gmap.TabIndex = 11;
            this.gmap.Zoom = 0D;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // infoLbl
            // 
            this.infoLbl.AutoSize = true;
            this.infoLbl.Location = new System.Drawing.Point(13, 541);
            this.infoLbl.Name = "infoLbl";
            this.infoLbl.Size = new System.Drawing.Size(44, 16);
            this.infoLbl.TabIndex = 12;
            this.infoLbl.Text = "label1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 604);
            this.Controls.Add(this.infoLbl);
            this.Controls.Add(this.gmap);
            this.Controls.Add(this.csvGridView);
            this.Controls.Add(this.progressLbl);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.title);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.viewPanel);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindow";
            this.Text = "Asterix Decoder";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.csvGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.viewPanel.ResumeLayout(false);
            this.viewPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fowardPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView csvGridView;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.FlowLayoutPanel viewPanel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label progressLbl;
        private System.Windows.Forms.ToolStripMenuItem cSVToolboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trajectoriesSimulatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fAQsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.ToolStripMenuItem visualizeCSVFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTrajectoriesInKMLFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importBinaryFileToDecodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.PictureBox playPictureBox;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox backPictureBox;
        private System.Windows.Forms.PictureBox fowardPictureBox;
        private System.Windows.Forms.ComboBox speedDecisionBox;
        private System.Windows.Forms.ToolStripMenuItem visualizeCSVFileToolStripMenuItem1;
        private System.Windows.Forms.TextBox hourBox;
        private System.Windows.Forms.Label infoLbl;
    }
}

