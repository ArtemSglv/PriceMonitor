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
        class Row
        {
            private static int Index = -1;

            public int index;
            public ComboBox cb;
            public List<Button> buttons;

            public void CreateRow()
            {
                int cbStartX = 11, cbStartY = 58;
                int stepY = 70;

                //Row row = new Row();
                index = ++Index;
                cb = new ComboBox();
                cb.Size = new Size(96, 21);
                cb.Location = new Point(cbStartX, cbStartY + (cb.Size.Height + stepY) * index);
                //row.cb.SelectedIndexChanged += (s, e) =>
                //{
                //    FillData();
                //};
                //row.cb.DropDown +=  (s, e) =>
                ////{
                ////    if (((ComboBox)s).SelectedIndex > -1)
                ////    {
                ////        rows.Add(new Row());
                ////        rows[rows.Count - 1].CreateRow();
                ////    }
                ////    foreach (Row row in rows)
                ////        if (row.cb.Equals((ComboBox)s))
                ////            row.ShowButtons();
                //    //надо добавить в контрол панели
                //};
                //parent.Controls.Add(cb);
                buttons = new List<Button>();
                CreateButtons();
                //return row;
            }

            void CreateButtons()
            {
                int bStartX = 130, bStartY = 48;
                int stepX = 5, stepY = 70;

                Button but;
                for (int i = 0; i < 5; i++)
                {
                    but = new Button();
                    but.Size = new Size(128, 41);
                    but.BackColor = Color.Transparent;
                    but.Visible = false;
                    //but.Click += (s, e) => { }; //переход в браузер на эту биржу
                    but.Location = new Point(bStartX + (but.Size.Width + stepX) * i, bStartY + (but.Size.Height + stepY) * index);
                    //parent.Controls.Add(but);
                    buttons.Add(but);
                }
            }
            public void ShowButtons()
            {
                foreach (Button but in buttons)
                    but.Visible = true;
            }
            public void FillData()
            {
                for (int i = 0; i < buttons.Count; i++)
                    if (cb.SelectedItem != null && i < Exchange.Count)
                        buttons[i].Text = Exchange[i].GetPrice(cb.SelectedItem.ToString());
            }
        }

        List<Row> rows = new List<Row>();

        object[] ListAssets;
        //int bLenght = 128, startX = 130, countComboBox = 1;
        public static List<StockExchange> Exchange;

        public MainForm()
        {
            InitializeComponent();
            Init();
            //ScanAssets();
            //dict = Engine.Request("https://poloniex.com/public?command=returnCurrencies");
        }
        void Init()
        {
            Exchange = new List<StockExchange>();
            Exchange.Add(new Poloniex());
            ScanAssets();
            //SetCoord();
            CreateRow();
            UpdateData();
        }
        void CreateRow()
        {
            if (rows.Count >= 5) //limit 5 rows
                return;
            rows.Add(new Row());
            rows[rows.Count - 1].CreateRow();
            rows[rows.Count - 1].cb.DropDown += comboBoxEventDropDown;
            rows[rows.Count - 1].cb.SelectedIndexChanged += comboBoxEventSelIndexChanged;
            AddToPanelWhiteControls();
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
                if (row.cb.Items.Count == 0)
                    row.cb.Items.AddRange(ListAssets);
        }

        void UpdateData(ComboBox sender = null)
        {
            //for once
            if (sender != null)
            {
                rows.Find(x => (x.cb.Equals(sender))).FillData();
                return;
            }
            //for all
            foreach (Row row in rows)
            {
                    if (row.cb.Items.Count == 0)
                        row.cb.Items.AddRange(ListAssets);
                row.FillData();
            }
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
            if (((ComboBox)sender).SelectedIndex == -1)
            {
                CreateRow();
            }
            foreach (Row row in rows)
                if (row.cb.Equals((ComboBox)sender))
                    row.ShowButtons();

        }
        public void comboBoxEventSelIndexChanged(object sender, EventArgs e)
        {
            UpdateData((ComboBox)sender);
        }
    }
}
