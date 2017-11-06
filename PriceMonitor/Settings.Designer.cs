namespace PriceMonitor
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.IntervalLabel = new System.Windows.Forms.Label();
            this.labelSign = new System.Windows.Forms.Label();
            this.textBoxFreq = new System.Windows.Forms.TextBox();
            this.textBoxCountDigit = new System.Windows.Forms.TextBox();
            this.butAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IntervalLabel
            // 
            this.IntervalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IntervalLabel.Location = new System.Drawing.Point(29, 30);
            this.IntervalLabel.Name = "IntervalLabel";
            this.IntervalLabel.Size = new System.Drawing.Size(100, 39);
            this.IntervalLabel.TabIndex = 0;
            this.IntervalLabel.Text = "Интервал обновления";
            this.IntervalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSign
            // 
            this.labelSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSign.Location = new System.Drawing.Point(12, 67);
            this.labelSign.Name = "labelSign";
            this.labelSign.Size = new System.Drawing.Size(117, 75);
            this.labelSign.TabIndex = 1;
            this.labelSign.Text = "Кол-во знаков после запятой";
            this.labelSign.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxFreq
            // 
            this.textBoxFreq.Location = new System.Drawing.Point(135, 38);
            this.textBoxFreq.Name = "textBoxFreq";
            this.textBoxFreq.Size = new System.Drawing.Size(35, 22);
            this.textBoxFreq.TabIndex = 2;
            // 
            // textBoxCountDigit
            // 
            this.textBoxCountDigit.Location = new System.Drawing.Point(135, 94);
            this.textBoxCountDigit.Name = "textBoxCountDigit";
            this.textBoxCountDigit.Size = new System.Drawing.Size(35, 22);
            this.textBoxCountDigit.TabIndex = 3;
            // 
            // butAccept
            // 
            this.butAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAccept.Location = new System.Drawing.Point(43, 134);
            this.butAccept.Name = "butAccept";
            this.butAccept.Size = new System.Drawing.Size(109, 34);
            this.butAccept.TabIndex = 4;
            this.butAccept.Text = "Применить";
            this.butAccept.UseVisualStyleBackColor = true;
            this.butAccept.Click += new System.EventHandler(this.butAccept_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 180);
            this.Controls.Add(this.butAccept);
            this.Controls.Add(this.textBoxCountDigit);
            this.Controls.Add(this.textBoxFreq);
            this.Controls.Add(this.labelSign);
            this.Controls.Add(this.IntervalLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IntervalLabel;
        private System.Windows.Forms.Label labelSign;
        private System.Windows.Forms.TextBox textBoxFreq;
        private System.Windows.Forms.TextBox textBoxCountDigit;
        private System.Windows.Forms.Button butAccept;
    }
}