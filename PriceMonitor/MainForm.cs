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
        public static System.Threading.Timer timer;
        static object locker = new object();

        

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
                cb.IntegralHeight = false;
                cb.MaxDropDownItems = 10;
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
                    but.Tag = engine.exchanges[i].Url;
                    but.Click += (s, e) => {
                        if (((Button)s).Text != "")
                            System.Diagnostics.Process.Start(
                                engine.exchanges.Find(x=>x.Url== ((Button)s).Tag.ToString()).GetUrl(cb.SelectedItem.ToString())
                                ); }; //переход в браузер на эту биржу
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
        // в потоке таймера
        void AutoUpdate(object obj)
        {
            
                //timer.Change(0, int.Parse(ConfigurationManager.AppSettings.Get("frequencyUpdate")));
                engine.exchanges.ForEach
                    (
                        x =>
                        {
                            x.Price.Keys.ToList().ForEach
                         (
                             k =>
                             {
                                 engine.GetPrice(k);
                             }
                          );
                        });
                // InvalidOperationException
                try
                {
                    rows.ForEach(x =>
                    {
                        x.cb.BeginInvoke(new Action(() =>
                        {
                            x.FillData();                            
                        }));
                    });
                }
                catch(InvalidOperationException)
                {

                }           
            
            labelTimeRefresh.Invoke(new Action(()=> 
            { labelTimeRefresh.Text = string.Format("Время обновления {0:HH:mm:ss} ", DateTime.Now); }));

        }
        void TimerInThread()
        {
            TimerCallback tm = new TimerCallback(AutoUpdate);
            // создаем таймер
            timer = new System.Threading.Timer(tm, null, 0, int.Parse(ConfigurationManager.AppSettings.Get("frequencyUpdate")));
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
        void GetPriceInThread(object sender, EventArgs e)
        {
            var n=Thread.CurrentThread.Name;
            engine.exchanges.ForEach
                (
                    x => {
                        x.Price.Keys.ToList().ForEach
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
                    labelTimeRefresh.Text = string.Format("Время обновления {0:HH:mm:ss} ", DateTime.Now);
                }));
            });
            //MessageBox.Show(Thread.CurrentThread.Name);
        }
        void StartTimerInThread() //for all coin in all combobox ОЧЕНЬ ПЛОХОЙ МЕТОД КАК БЫ ЕГО ПЕРЕДЕЛАТЬ?
        {
            tmr = new System.Timers.Timer();
            tmr.Elapsed += GetPriceInThread;
            Thread trd = new Thread(delegate ()
            {                
                tmr.Interval = double.Parse(ConfigurationManager.AppSettings.Get("frequencyUpdate"));
                tmr.Start();
                
            });
            trd.IsBackground = true;
            trd.Name = "my Timer thread";
            trd.Start();
            //trd.Join();
        }
        void GetPriceInThread(string sel_coin)
        {
            Thread trd = new Thread(delegate () { engine.GetPrice(sel_coin); });
            trd.Start();
            trd.Join();
        }
        public void comboBoxEventSelIndexChanged(object sender, EventArgs e) // тут можно поиграться с порядком, для лучшего отображения
        {
            ComboBox cb = (ComboBox)sender;

            // отрисовка кнопок при выборе монеты
            rows.Find(x => (x.cb.Equals(cb))).ShowButtons();                      

            // Создание новой строки            
            if (rows.Last().cb.Equals(cb))
            {
                CreateRow();
                //UpdateData(rows.Last().cb);
            }

            // запрос цен в отдельном потоке
            GetPriceInThread(cb.SelectedItem.ToString());

            // заполнение кнопок для определенного комбобокса
            UpdateData(sender);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            Init();
            //StartTimerInThread();
            TimerInThread();

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
