using System;
using System.Windows.Forms;
using System.Configuration;

namespace PriceMonitor
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void butAccept_Click(object sender, EventArgs e)
        {
            if (textBoxFreq.Text != "")
            {
                ConfigurationManager.AppSettings.Set("frequencyUpdate", textBoxFreq.Text+"000");
                MainForm.timer.Change(0, int.Parse(ConfigurationManager.AppSettings.Get("frequencyUpdate")));
            }
            if (textBoxCountDigit.Text != "")
                ConfigurationManager.AppSettings.Set("countDigitAfterComma", textBoxCountDigit.Text);
            Close();
        }
    }
}
