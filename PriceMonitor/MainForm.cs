using System;
using System.Collections.Generic;
using System.Threading;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace PriceMonitor
{
    public partial class MainForm : Form
    {
        List<Row> rows = new List<Row>();
        static Engine engine = new Engine();
        public static System.Threading.Timer timer;
        static object locker = new object();

        //int counter = 0;
        

        class Row
        {
            private static int Index = -1;

            public bool visibleButtons = false;
            public int index;
            public ComboBox cb;
            public List<Button> buttons;

            public void CreateRow(int scroll)
            {
                //x=11 y=48
                int cbStartX = 0, cbStartY = 10;
                int stepY = 30;

                //Row row = new Row();
                index = ++Index;
                cb = new ComboBox();
                cb.Size = new Size(96, 21);
                cb.IntegralHeight = false;
                cb.MaxDropDownItems = 10;
                cb.Location = new Point(cbStartX, cbStartY + (cb.Size.Height + stepY) * index);
                buttons = new List<Button>();
                CreateButtons(scroll);
                //return row;
            }

            void CreateButtons(int scroll)
            {
                //x=130 y=38
                int bStartX = 119, bStartY = 0;
                int stepX = 5, stepY = 10;

                Button but;
                for (int i = 0; i < engine.exchanges.Count; i++)
                {
                    but = new Button();
                    but.Name = engine.exchanges[i].Name;
                    but.Size = new Size(128, 41);
                    but.BackColor = Color.Transparent;
                    but.Visible = false;
                    but.Tag = engine.exchanges[i].Url;
                    but.Click += (s, e) =>
                    {
                        if (((Button)s).Text != "")
                            System.Diagnostics.Process.Start(
                                engine.exchanges.Find(x => x.Url == ((Button)s).Tag.ToString()).GetUrl(cb.SelectedItem.ToString())
                                );
                    }; //переход в браузер на эту биржу
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
            //ScanAssets();
        }

        void CreateRow()
        {
            rows.Add(new Row());
            rows.Last().CreateRow(panelWhite.VerticalScroll.Value);
            rows.Last().cb.Items.AddRange(engine.listAssets.ToArray<object>());
            rows.Last().cb.SelectedIndexChanged += comboBoxEventSelIndexChanged;
            panelForControl.AutoSize = true;
            //panelForControl.Size = new Size(panelForControl.Size.Width, panelForControl.Size.Width+80);
            panelForControl.Controls.Add(rows.Last().cb);
            panelForControl.Controls.AddRange(rows.Last().buttons.ToArray());
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
            MessageBox.Show("Найдено монет:\r\n" + engine.ScanAssets());
        }

        // в потоке таймера
        void AutoUpdate(object obj)
        {

            // InvalidOperationException
            try
            {
                engine.GetPrice();
                //counter++;

                labelTimeRefresh.Invoke(new Action(() =>
                { labelTimeRefresh.Text = string.Format("Время обновления {0:HH:mm:ss} ", DateTime.Now); }));

                rows.ForEach(x =>
                    {
                        x.cb.BeginInvoke(new Action(() =>
                        {
                            x.FillData();
                        }));
                    });               

            }
            catch (InvalidOperationException)
            {

            }

        }
        void TimerInThread()
        {
            TimerCallback tm = new TimerCallback(AutoUpdate);
            // создаем таймер
            timer = new System.Threading.Timer(tm, null, 3000, int.Parse(ConfigurationManager.AppSettings.Get("frequencyUpdate")));
           
        }
        void UpdateData(object sender) // заполнение кнопки данными
        {
            //for once
            if ((ComboBox)sender != null)
            {
                rows.Find(x => (x.cb.Equals((ComboBox)sender))).FillData();
            }
        }

        void GetPriceInThread(ComboBox cb)
        {
            Thread trd = new Thread(delegate () { engine.GetPrice(); cb.Invoke(new Action(() => UpdateData(cb))); });
            trd.Start();
            //trd.Join();
        }
        public void comboBoxEventSelIndexChanged(object sender, EventArgs e) // тут можно поиграться с порядком, для лучшего отображения
        {
            ComboBox cb = (ComboBox)sender;
            engine.exchanges.ForEach(x => { if (!x.Price.Keys.Contains(cb.SelectedItem.ToString())) x.Price.Add(cb.SelectedItem.ToString(), new StockExchange.CurrentPrice()); });
            // запрос цен в отдельном потоке
            //GetPriceInThread(cb);
            timer.Change(0, int.Parse(ConfigurationManager.AppSettings.Get("frequencyUpdate")));
            // отрисовка кнопок при выборе монеты
            rows.Find(x => (x.cb.Equals(cb))).ShowButtons();


            // Создание новой строки            
            if (rows.Last().cb.Equals(cb))
            {
                CreateRow();
                //UpdateData(rows.Last().cb);
            }

            // заполнение кнопок для определенного комбобокса
            //UpdateData(sender);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            try
            {
                Init();
                //StartTimerInThread();
                TimerInThread();
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Message.Contains("Невозможно разрешить удаленное имя"))
                {
                    MessageBox.Show("Проверьте подключение к Интернету!");
                    Application.Exit();
                }
                else
                    MessageBox.Show(ex.Message + "\r\n" + ex.Response.ResponseUri);

            }

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
