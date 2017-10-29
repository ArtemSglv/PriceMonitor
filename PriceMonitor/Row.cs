using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PriceMonitor
{
    public class Row
    {
        private static int Index=-1;
        private int cbStartX = 11,cbStartY=58;
        private int bStartX = 130, bStartY = 48;
        private int stepX = 5, stepY = 70;
        //private MainForm mForm = new MainForm();

        public int index;
        public ComboBox cb;
        public List<Button> buttons;

        public  Row()
        {
            //index = Index++;
            //comboBox = cb;
            //buttons = buts;
        }

        public bool CreateRow()
        {
            bool newRow = false;
            index = ++Index;
            cb = new ComboBox();
            cb.Size = new Size(96, 21);
            cb.Location = new Point(cbStartX,cbStartY+(cb.Size.Height+stepY)*index);
            cb.SelectedIndexChanged += (s, e) => { FillData(); };
            cb.DropDown += (s,e)=> {
                if (((ComboBox)s).SelectedIndex > -1)
                {
                    MainForm.rows.Add(new Row());
                    MainForm.rows[MainForm.rows.Count - 1].CreateRow();
                }
                foreach (Row row in MainForm.rows)
                    if (row.cb.Equals((ComboBox)s))
                        row.ShowButtons();
                //надо добавить в контрол панели
            };
            //parent.Controls.Add(cb);
            buttons = new List<Button>();
            CreateButtons();
            return newRow;
        }

        void CreateButtons()
        {
            Button but;
            for (int i = 0; i < 5; i++)
            {
                but = new Button();                
                but.Size = new Size(128, 41);
                but.BackColor = Color.Transparent;
                but.Visible = false;
                //but.Click += (s, e) => { MessageBox.Show(((Button)s).Location.ToString() + "\r\n" + ((Button)s).Size.ToString()); };
                but.Location = new Point(bStartX + (but.Size.Width + stepX) * i, bStartY+(but.Size.Height+stepY)*index);
                //parent.Controls.Add(but);
                buttons.Add(but);
            }
        }
        public void ShowButtons()
        {
            foreach (Button but in buttons)
                but.Visible = true;
        }
        void FillData()
        {
            for (int i = 0; i < buttons.Count; i++)
                if(i<MainForm.Exchange.Count)
                buttons[i].Text = MainForm.Exchange[i].GetPrice(cb.SelectedItem.ToString());
        }
    }
}
