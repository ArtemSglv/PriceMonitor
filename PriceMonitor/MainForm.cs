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
using System.Configuration;

namespace PriceMonitor
{
    public partial class MainForm : Form
    {
        List<Row> rows = new List<Row>();
        static Engine engine = new Engine();
        System.Timers.Timer tmr;

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
                for (int i = 0; i < engine.exchanges.Count; i++)
                {
                    but = new Button();
                    but.Name = engine.exchanges[i].Name;
                    but.Size = new Size(128, 41);
                    but.BackColor = Color.Transparent;
                    but.Visible = false;
                    //but.Click += (s, e) => { }; //переход в браузер на эту биржу
                    but.Location = new Point(bStartX + (but.Size.Width + stepX) * i, bStartY + (but.Size.Height + stepY) * index);
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
                    for (int i = 0; i < buttons.Count; i++)
                        if (engine.exchanges[i].Price.ContainsKey(cb.SelectedItem.ToString()))
                            buttons[i].Text = engine.exchanges[i].Price[cb.SelectedItem.ToString()].ToString();
                        else buttons[i].Text = "";
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }
        void Init()
        {
            ScanAssets();
            CreateRow();
        }
        //void DataUpdater(object sender, EventArgs e)
        //{
        //    GetPriceInThread();
        //}
        void InitAndStartTimer()
        {
            tmr = new System.Timers.Timer();            
            tmr.Elapsed += GetPriceInThread;
            tmr.Interval = double.Parse(ConfigurationManager.AppSettings.Get("frequencyUpdate"));
            tmr.Start();
        }
        void CreateRow()
        {
            rows.Add(new Row());
            rows.Last().CreateRow();
            rows.Last().cb.Items.AddRange(engine.listAssets.ToArray<object>());
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
            string str = "";
            Thread trd = new Thread(delegate ()
            {
                engine.ScanAssets();
                engine.exchanges.ForEach(x => str += x.ToString());
            });
            trd.Start();
            trd.Join();
            MessageBox.Show("Найдено монет:\r\n" + str);
        }
        void FillComboBox(ComboBox cb)
        {
            Thread.Sleep(0);
            if (cb.Items.Count == 0)
                cb.Items.AddRange(engine.listAssets.ToArray<object>());
        }

        void UpdateData(object sender = null) // заполнение кнопок данными
        {
            ComboBox cb = (ComboBox)sender;
            //for once
            if (cb != null)
            {
                rows.Find(x => ( x.cb.Equals(cb))).FillData();
                return;
            }
            //for all
            rows.ForEach(x => { x.FillData(); });

        }

        void GetPriceInThread(object sender, EventArgs e) //for all coin in all combobox ОЧЕНЬ ПЛОХОЙ МЕТОД КАК БЫ ЕГО ПЕРЕДЕЛАТЬ?
        {
            tmr.Interval = double.Parse(ConfigurationManager.AppSettings.Get("frequencyUpdate"));
            Thread trd = new Thread(delegate ()
            {
                engine.exchanges.ForEach
                (
                    x => { x.Price.Keys.ToList().ForEach
                        (
                            k =>
                            {
                                engine.GetPrice(k);
                            }
                         );
                    });
                rows.ForEach(x => {
                    x.cb.BeginInvoke(new Action(() =>
                                                    {
                                                        x.FillData();
                                                        labelTimeRefresh.Text= string.Format("Время обновления {0:HH:mm:ss} ", DateTime.Now);
                                                    }));
                });
            });
            trd.Start();
            trd.Join();
        }
        void GetPriceInThread(string sel_coin)
        {
            Thread trd = new Thread(delegate () { engine.GetPrice(sel_coin); });
            trd.Start();
            trd.Join();
        }
        public void comboBoxEventSelIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            // запрос цен в отдельном потоке
            GetPriceInThread(cb.SelectedItem.ToString());

            // Создание новой строки            
            if (rows.Last().cb.Equals(cb))
            {
                CreateRow();
                //UpdateData(rows.Last().cb);
            }

            // отрисовка кнопок
            rows.Find(x => (x.cb.Equals(cb))).ShowButtons();

            // заполнение кнопок для определенного комбобокса
            UpdateData(sender);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Init();
            InitAndStartTimer();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void параметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.ShowDialog();
        }
    }
}
