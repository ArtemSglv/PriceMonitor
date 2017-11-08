namespace PriceMonitor
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panelWhite = new System.Windows.Forms.Panel();
            this.labelBitfinex = new System.Windows.Forms.Label();
            this.labelKraken = new System.Windows.Forms.Label();
            this.labelLiqui = new System.Windows.Forms.Label();
            this.labelBittrex = new System.Windows.Forms.Label();
            this.labelPoloniex = new System.Windows.Forms.Label();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.labelTimeRefresh = new System.Windows.Forms.Label();
            this.panelForControl = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panelWhite.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.настройкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1091, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // настройкаToolStripMenuItem
            // 
            this.настройкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.параметрыToolStripMenuItem});
            this.настройкаToolStripMenuItem.Name = "настройкаToolStripMenuItem";
            this.настройкаToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.настройкаToolStripMenuItem.Text = "Настройка";
            // 
            // параметрыToolStripMenuItem
            // 
            this.параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.параметрыToolStripMenuItem.Text = "Параметры";
            this.параметрыToolStripMenuItem.Click += new System.EventHandler(this.параметрыToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Монета / Биржа";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelWhite
            // 
            this.panelWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelWhite.AutoScroll = true;
            this.panelWhite.BackColor = System.Drawing.Color.White;
            this.panelWhite.Controls.Add(this.panelForControl);
            this.panelWhite.Controls.Add(this.labelBitfinex);
            this.panelWhite.Controls.Add(this.labelKraken);
            this.panelWhite.Controls.Add(this.labelLiqui);
            this.panelWhite.Controls.Add(this.labelBittrex);
            this.panelWhite.Controls.Add(this.label1);
            this.panelWhite.Controls.Add(this.labelPoloniex);
            this.panelWhite.Location = new System.Drawing.Point(0, 30);
            this.panelWhite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelWhite.Name = "panelWhite";
            this.panelWhite.Size = new System.Drawing.Size(1091, 408);
            this.panelWhite.TabIndex = 3;
            // 
            // labelBitfinex
            // 
            this.labelBitfinex.BackColor = System.Drawing.Color.White;
            this.labelBitfinex.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBitfinex.Location = new System.Drawing.Point(908, 11);
            this.labelBitfinex.Name = "labelBitfinex";
            this.labelBitfinex.Size = new System.Drawing.Size(125, 17);
            this.labelBitfinex.TabIndex = 8;
            this.labelBitfinex.Text = "Bitfinex.com";
            this.labelBitfinex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelKraken
            // 
            this.labelKraken.BackColor = System.Drawing.Color.White;
            this.labelKraken.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKraken.Location = new System.Drawing.Point(729, 11);
            this.labelKraken.Name = "labelKraken";
            this.labelKraken.Size = new System.Drawing.Size(125, 17);
            this.labelKraken.TabIndex = 7;
            this.labelKraken.Text = "Kraken.com";
            this.labelKraken.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLiqui
            // 
            this.labelLiqui.BackColor = System.Drawing.Color.White;
            this.labelLiqui.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLiqui.Location = new System.Drawing.Point(552, 11);
            this.labelLiqui.Name = "labelLiqui";
            this.labelLiqui.Size = new System.Drawing.Size(125, 17);
            this.labelLiqui.TabIndex = 6;
            this.labelLiqui.Text = "Liqui.io";
            this.labelLiqui.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBittrex
            // 
            this.labelBittrex.BackColor = System.Drawing.Color.White;
            this.labelBittrex.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBittrex.Location = new System.Drawing.Point(372, 11);
            this.labelBittrex.Name = "labelBittrex";
            this.labelBittrex.Size = new System.Drawing.Size(125, 17);
            this.labelBittrex.TabIndex = 5;
            this.labelBittrex.Text = "Bittrex.com";
            this.labelBittrex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPoloniex
            // 
            this.labelPoloniex.BackColor = System.Drawing.Color.White;
            this.labelPoloniex.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPoloniex.Location = new System.Drawing.Point(196, 11);
            this.labelPoloniex.Name = "labelPoloniex";
            this.labelPoloniex.Size = new System.Drawing.Size(125, 17);
            this.labelPoloniex.TabIndex = 4;
            this.labelPoloniex.Text = "Poloniex.com";
            this.labelPoloniex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelStatus
            // 
            this.panelStatus.BackColor = System.Drawing.Color.Gray;
            this.panelStatus.Controls.Add(this.labelTimeRefresh);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatus.Location = new System.Drawing.Point(0, 438);
            this.panelStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(1091, 28);
            this.panelStatus.TabIndex = 3;
            // 
            // labelTimeRefresh
            // 
            this.labelTimeRefresh.AutoSize = true;
            this.labelTimeRefresh.BackColor = System.Drawing.Color.Transparent;
            this.labelTimeRefresh.ForeColor = System.Drawing.Color.Snow;
            this.labelTimeRefresh.Location = new System.Drawing.Point(11, 5);
            this.labelTimeRefresh.Name = "labelTimeRefresh";
            this.labelTimeRefresh.Size = new System.Drawing.Size(0, 17);
            this.labelTimeRefresh.TabIndex = 0;
            // 
            // panelForControl
            // 
            this.panelForControl.Location = new System.Drawing.Point(22, 49);
            this.panelForControl.Name = "panelForControl";
            this.panelForControl.Size = new System.Drawing.Size(1039, 252);
            this.panelForControl.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 466);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelWhite);
            this.Controls.Add(this.panelStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "PriceMonitor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelWhite.ResumeLayout(false);
            this.panelWhite.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelWhite;
        private System.Windows.Forms.Label labelPoloniex;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label labelBittrex;
        private System.Windows.Forms.Label labelTimeRefresh;
        private System.Windows.Forms.Label labelLiqui;
        private System.Windows.Forms.Label labelKraken;
        private System.Windows.Forms.Label labelBitfinex;
        private System.Windows.Forms.Panel panelForControl;
    }
}

