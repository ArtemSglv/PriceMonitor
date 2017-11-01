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
                for (int i = 0; i < Engine.exchanges.Count; i++)
                {
                    but = new Button();
                    but.Name = Engine.exchanges[i].Name;
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
            public void FillData() // print price into buttons
            {
                if (cb.SelectedItem != null)
                {
                    Engine.GetPrice(cb.SelectedItem.ToString());
                    for (int i = 0; i < buttons.Count; i++)
                        buttons[i].Text = Engine.exchanges[i].Price.ToString();
                }
            }
        }

        List<Row> rows = new List<Row>();

        //object[] ListAssets;
        //public static List<StockExchange> Exchange;

        public MainForm()
        {
            InitializeComponent();
            Init();            
           // DataUpdater();
        }
        void Init()
        {
           // Exchange = new List<StockExchange>();
            //Exchange.Add(new Poloniex());
            Engine.ScanAssets();
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
            rows.Last().CreateRow();
            rows.Last().cb.Items.AddRange(Engine.listAssets.ToArray<object>());
            rows.Last().cb.DropDown += comboBoxEventDropDown;
            rows.Last().cb.SelectedIndexChanged += comboBoxEventSelIndexChanged;
            panelWhite.Controls.Add(rows.Last().cb);
            panelWhite.Controls.AddRange(rows.Last().buttons.ToArray());
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
            Thread trd =new Thread(delegate() { Engine.ScanAssets(); MessageBox.Show("Найдено монет:\r\n"); });
        }
        void FillComboBox(ComboBox cb)
        {
            if (cb.Items.Count == 0)
                cb.Items.AddRange(Engine.listAssets.ToArray<object>());
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
            rows.ForEach(x => { x.FillData(); });
            //foreach (Row row in rows)
            //{
            //   // FillComboBox(row.cb);
            //    row.FillData();
            //}
        }
        public void comboBoxEventDropDown(object sender, EventArgs e)
        {
            

        }
        public void comboBoxEventSelIndexChanged(object sender, EventArgs e)
        {

            // условие для создания новой строки
            ComboBox cb = (ComboBox)sender;
            if (rows.Last().cb.Equals(cb) /*&& cb.SelectedIndex == -1*/)
            {
                CreateRow();
                UpdateData(rows.Last().cb);
            }
            // показ кнопок
            rows.Find(x => (x.cb.Equals(cb))).ShowButtons();

            UpdateData(sender);
        }
    }
}
