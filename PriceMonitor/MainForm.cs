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
        static public  List<Row> rows = new List<Row>();

        object[] ListAssets;
        int bLenght = 128, stepX = 5, startX = 130, countComboBox = 1;
        public static List<StockExchange> Exchange;

        public MainForm()
        {
            InitializeComponent();
            Init();

            //rows.Add(Row.CreateRow());

            

            //ScanAssets();
            //dict = Engine.Request("https://poloniex.com/public?command=returnCurrencies");
        }
        void Init()
        {
            
            rows.Add(new Row());
            rows[rows.Count - 1].CreateRow();
            AddToPanelWhiteControls();
            //SetCoord();

            Exchange = new List<StockExchange>();
            Exchange.Add(new Poloniex());

            ScanAssets();            
            FillComboBox();
        }
        void AddToPanelWhiteControls()
        {
            //panelWhite.Controls.Add(comboBox1);
            foreach (Row row in rows)
            {
                panelWhite.Controls.Add(row.cb);
                panelWhite.Controls.AddRange(row.buttons.ToArray());
            }
        }
        void SetCoord()
        {
            this.Load += (s, ea) =>
            {
                var wa = Screen.PrimaryScreen.WorkingArea;
                this.Location = new Point(wa.Right - this.Width, wa.Bottom - this.Height);
            };
        }

        void ScanAssets()
        {
            ListAssets = Exchange[0].GetAssets();
        }
        void FillComboBox()
        {
            foreach (Row row in rows)
                if (row.cb.Items.Count==0)
                    row.cb.Items.AddRange(ListAssets);
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            //NewLine((ComboBox)sender);
        }

        //void NewLine(ComboBox upComboBox)
        //{
        //    ComboBox cb = new ComboBox();
        //    cb.Size = upComboBox.Size;
        //    cb.Location = new Point(upComboBox.Location.X, upComboBox.Location.Y + 70);
        //    cb.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
        //    panelWhite.Controls.Add(cb);
        //    FillComboBox();
        //}

        //void ShowButtons(ComboBox cb)
        //{
        //    Button but;
        //    for (int i = 0; i < 5; i++)
        //    {
        //        but = new Button();
        //        if (i < Exchange.Count) // delete!!!
        //            but.Text = Exchange[i].GetPrice(cb.SelectedItem.ToString());
        //        but.Size = new Size(128, 41);
        //        but.BackColor = Color.Transparent;
        //        //but.Click += (s, e) => { MessageBox.Show(((Button)s).Location.ToString() + "\r\n" + ((Button)s).Size.ToString()); };
        //        but.Location = new Point(startX + (bLenght + stepX) * i, cb.Location.Y);
        //        panelWhite.Controls.Add(but);
        //    }

        //}

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ShowButtons((ComboBox)sender);
        //    //NewLine((ComboBox)sender);
        //}
        public void comboBoxEventDropDown(object sender, EventArgs e)
        {
            //if (((ComboBox)sender).SelectedIndex > -1)
            //{
            //    rows.Add(new Row());
            //    rows[rows.Count - 1].CreateRow();
            //    AddToPanelWhiteControls();
            //}
            //foreach (Row row in rows)
            //    if (row.cb.Equals((ComboBox)sender))
            //        row.ShowButtons();

        }
    }
}
