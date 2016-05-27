﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wypozyczalnia_samochodow
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            menuItems = new Control[] { button1, button2, button3, button4, label1 };
            zmianaHasla1.Closing += backToMenu;
            wyszukiwarkaSam1.Closing += backToMenu;       
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
        private Control[] menuItems;
        public event EventHandler LoggingOut;
        protected virtual void OnLoggingOut(EventArgs e)
        {
            EventHandler handler = LoggingOut;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnLoggingOut(new EventArgs());
            wyszukiwarkaSam1.closeWindows();
        }
        private void setMenuVisibility(bool val)
        {
            foreach (var it in menuItems)
                it.Visible = val;
        }
        void backToMenu(object sender, EventArgs e)
        {
            setMenuVisibility(true);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            zmianaHasla1.Visible = true;
            setMenuVisibility(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wyszukiwarkaSam1.Visible = true;
            setMenuVisibility(false);
        }
    }
}
