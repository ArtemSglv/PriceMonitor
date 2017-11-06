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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(796, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // настройкаToolStripMenuItem
            // 
            this.настройкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.параметрыToolStripMenuItem});
            this.настройкаToolStripMenuItem.Name = "настройкаToolStripMenuItem";
            this.настройкаToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.настройкаToolStripMenuItem.Text = "Настройка";
            // 
            // параметрыToolStripMenuItem
            // 
            this.параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.параметрыToolStripMenuItem.Text = "Параметры";
            this.параметрыToolStripMenuItem.Click += new System.EventHandler(this.параметрыToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Монета / Биржа";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelWhite
            // 
            this.panelWhite.AutoScroll = true;
            this.panelWhite.AutoSize = true;
            this.panelWhite.BackColor = System.Drawing.Color.White;
            this.panelWhite.Controls.Add(this.labelBitfinex);
            this.panelWhite.Controls.Add(this.labelKraken);
            this.panelWhite.Controls.Add(this.labelLiqui);
            this.panelWhite.Controls.Add(this.labelBittrex);
            this.panelWhite.Controls.Add(this.label1);
            this.panelWhite.Controls.Add(this.labelPoloniex);
            this.panelWhite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWhite.Location = new System.Drawing.Point(0, 0);
            this.panelWhite.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelWhite.Name = "panelWhite";
            this.panelWhite.Size = new System.Drawing.Size(796, 356);
            this.panelWhite.TabIndex = 3;
            // 
            // labelBitfinex
            // 
            this.labelBitfinex.BackColor = System.Drawing.Color.White;
            this.labelBitfinex.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBitfinex.Location = new System.Drawing.Point(681, 29);
            this.labelBitfinex.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBitfinex.Name = "labelBitfinex";
            this.labelBitfinex.Size = new System.Drawing.Size(94, 14);
            this.labelBitfinex.TabIndex = 8;
            this.labelBitfinex.Text = "Bitfinex.com";
            this.labelBitfinex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelKraken
            // 
            this.labelKraken.BackColor = System.Drawing.Color.White;
            this.labelKraken.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKraken.Location = new System.Drawing.Point(547, 29);
            this.labelKraken.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelKraken.Name = "labelKraken";
            this.labelKraken.Size = new System.Drawing.Size(94, 14);
            this.labelKraken.TabIndex = 7;
            this.labelKraken.Text = "Kraken.com";
            this.labelKraken.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLiqui
            // 
            this.labelLiqui.BackColor = System.Drawing.Color.White;
            this.labelLiqui.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLiqui.Location = new System.Drawing.Point(414, 29);
            this.labelLiqui.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLiqui.Name = "labelLiqui";
            this.labelLiqui.Size = new System.Drawing.Size(94, 14);
            this.labelLiqui.TabIndex = 6;
            this.labelLiqui.Text = "Liqui.io";
            this.labelLiqui.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBittrex
            // 
            this.labelBittrex.BackColor = System.Drawing.Color.White;
            this.labelBittrex.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBittrex.Location = new System.Drawing.Point(279, 29);
            this.labelBittrex.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBittrex.Name = "labelBittrex";
            this.labelBittrex.Size = new System.Drawing.Size(94, 14);
            this.labelBittrex.TabIndex = 5;
            this.labelBittrex.Text = "Bittrex.com";
            this.labelBittrex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPoloniex
            // 
            this.labelPoloniex.BackColor = System.Drawing.Color.White;
            this.labelPoloniex.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPoloniex.Location = new System.Drawing.Point(147, 29);
            this.labelPoloniex.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPoloniex.Name = "labelPoloniex";
            this.labelPoloniex.Size = new System.Drawing.Size(94, 14);
            this.labelPoloniex.TabIndex = 4;
            this.labelPoloniex.Text = "Poloniex.com";
            this.labelPoloniex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelStatus
            // 
            this.panelStatus.BackColor = System.Drawing.Color.Gray;
            this.panelStatus.Controls.Add(this.labelTimeRefresh);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatus.Location = new System.Drawing.Point(0, 356);
            this.panelStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(796, 23);
            this.panelStatus.TabIndex = 3;
            // 
            // labelTimeRefresh
            // 
            this.labelTimeRefresh.AutoSize = true;
            this.labelTimeRefresh.BackColor = System.Drawing.Color.Transparent;
            this.labelTimeRefresh.ForeColor = System.Drawing.Color.Snow;
            this.labelTimeRefresh.Location = new System.Drawing.Point(8, 4);
            this.labelTimeRefresh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTimeRefresh.Name = "labelTimeRefresh";
            this.labelTimeRefresh.Size = new System.Drawing.Size(0, 13);
            this.labelTimeRefresh.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 379);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelWhite);
            this.Controls.Add(this.panelStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
    }
}

