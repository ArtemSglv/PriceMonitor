using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                ConfigurationManager.AppSettings.Set("frequencyUpdate", textBoxFreq.Text);
            if (textBoxCountDigit.Text != "")
                ConfigurationManager.AppSettings.Set("countDigitAfterComma", textBoxCountDigit.Text);
            Close();
        }
    }
}
