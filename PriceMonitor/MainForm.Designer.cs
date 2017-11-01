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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panelWhite = new System.Windows.Forms.Panel();
            this.labelBittrex = new System.Windows.Forms.Label();
            this.labelPoloniex = new System.Windows.Forms.Label();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panelWhite.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(1061, 28);
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
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(15, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Монета / Биржа";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelWhite
            // 
            this.panelWhite.AutoScroll = true;
            this.panelWhite.BackColor = System.Drawing.Color.White;
            this.panelWhite.Controls.Add(this.labelBittrex);
            this.panelWhite.Controls.Add(this.label1);
            this.panelWhite.Controls.Add(this.labelPoloniex);
            this.panelWhite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWhite.Location = new System.Drawing.Point(0, 0);
            this.panelWhite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelWhite.Name = "panelWhite";
            this.panelWhite.Size = new System.Drawing.Size(1061, 438);
            this.panelWhite.TabIndex = 3;
            // 
            // labelBittrex
            // 
            this.labelBittrex.BackColor = System.Drawing.Color.White;
            this.labelBittrex.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBittrex.Location = new System.Drawing.Point(372, 36);
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
            this.labelPoloniex.Location = new System.Drawing.Point(196, 36);
            this.labelPoloniex.Name = "labelPoloniex";
            this.labelPoloniex.Size = new System.Drawing.Size(125, 17);
            this.labelPoloniex.TabIndex = 4;
            this.labelPoloniex.Text = "Poloniex.com";
            this.labelPoloniex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelStatus
            // 
            this.panelStatus.BackColor = System.Drawing.Color.Black;
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatus.Location = new System.Drawing.Point(0, 438);
            this.panelStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(1061, 28);
            this.panelStatus.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 466);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelWhite);
            this.Controls.Add(this.panelStatus);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "PriceMonitor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelWhite.ResumeLayout(false);
            this.panelWhite.PerformLayout();
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
    }
}

