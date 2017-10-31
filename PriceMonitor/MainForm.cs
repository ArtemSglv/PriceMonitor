using System;
using System.Collections.Generic;
using System.Threading;
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
            private static int countExchange = 5; //кол-во бирж

            public bool visibleButtons = false;
            public int index;
            public ComboBox cb;
            public List<Button> buttons;

            public void CreateRow()
            {
                int cbStartX = 11, cbStartY = 58;
                int stepY = 30;

                //Row row = new Row();
                index = ++Index;
                cb = new ComboBox();
                cb.Size = new Size(96, 21);
                cb.Location = new Point(cbStartX, cbStartY + (cb.Size.Height + stepY) * index);
                buttons = new List<Button>();
                CreateButtons();
                //return row;
            }

            void CreateButtons()
            {
                int bStartX = 130, bStartY = 48;
                int stepX = 5, stepY = 10;

                Button but;
                for (int i = 0; i < countExchange; i++)
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
                if (!visibleButtons)
                {
                    foreach (Button but in buttons)
                        but.Visible = true;
                    visibleButtons = true;
                }
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
        public static List<StockExchange> Exchange;

        public MainForm()
        {
            InitializeComponent();
            Init();
            DataUpdater();
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
        void DataUpdater()
        {
            TimerCallback tcb = new TimerCallback(UpdateData);
            System.Threading.Timer tm = new System.Threading.Timer(tcb,null,0,5000);
            //Thread trd = new Thread(delegate() { UpdateData(); Thread.Sleep(3000); });
            //trd.Start();
        }
        void CreateRow()
        {
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
        void FillComboBox(ComboBox cb)
        {
            if (cb.Items.Count == 0)
                cb.Items.AddRange(ListAssets);
        }

        void UpdateData(object sender = null) // заполнение кнопок и комбобоксов данными
        {
            ComboBox cb = (ComboBox)sender;
            //for once
            if (cb != null)
            {
                rows.Find(x => (x.cb.Equals(cb))).FillData();
                return;
            }
            //for all
            foreach (Row row in rows)
            {
                FillComboBox(row.cb);
                row.FillData();
            }
        }
        public void comboBoxEventDropDown(object sender, EventArgs e)
        {
            // условие для создания новой строки
            ComboBox cb = (ComboBox)sender;
            if (rows.Last().cb.Equals(cb) && cb.SelectedIndex == -1)
            {
                CreateRow();
                UpdateData();
            }

            // показ кнопок
            rows.Find(x => (x.cb.Equals(cb))).ShowButtons();

        }
        public void comboBoxEventSelIndexChanged(object sender, EventArgs e)
        {
            UpdateData(sender);
        }
    }
}
