using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;

namespace PriceMonitor
{
    public partial class MainForm : Form
    {
        Dictionary<string, object> dict;
        object[] ListAssets;
        int bLenght = 115, stepX = 59,startX=200,startY=45;
        List<StockExchange> Exchange;

        public MainForm()
        {
            InitializeComponent();

            panelWhite.Controls.Add(comboBox1);
            panelWhite.Controls.Add(label1);
            panelWhite.Controls.Add(labelPoloniex);

            Exchange = new List<StockExchange>();
            Exchange.Add(new Poloniex());

            ScanAssets();
            //dict = Engine.Request("https://poloniex.com/public?command=returnCurrencies");
        }

        void ScanAssets()
        {
            ListAssets = Exchange[0].GetAssets();
            FillComboBox();
        }
        void FillComboBox()
        {
            foreach (ComboBox cb in panelWhite.Controls.OfType<ComboBox>())
                cb.Items.AddRange(ListAssets);
        }

        void NewLine()
        {
            ComboBox cb=comboBox1;            
            cb.SelectedIndex = 0;
            cb.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            panelWhite.Controls.Add(cb);
        }

        void ShowButtons(Point cbCoord)
        {
            Button but;
            for (int i = 0; i < 5; i++)
            {
                but = new Button();
                if (i < Exchange.Count) // delete!!!
                    but.Text = Exchange[i].GetPrice();
                but.Size = new Size(115, 45);
                Point r=button1.Location;
                but.Location = new Point(startX + (bLenght + stepX)*i, startY);
                panelWhite.Controls.Add(but);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowButtons(((ComboBox)sender).Location);
            NewLine();
        }
    }
}
