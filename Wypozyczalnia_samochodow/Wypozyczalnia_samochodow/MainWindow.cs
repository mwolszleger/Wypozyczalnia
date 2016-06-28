using System;
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
    public partial class MainWindow : Form
    {
        public MainWindow(string login)
        {
            InitializeComponent();
            menuItems = new Control[] { buttonCars, buttonCustomers, buttonLogOut, label1 };
            search.Closing += BackToMenu;

            Rental.ClearEverything();
            try
            {
                Rental.SaveToBase();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
            try
            {
                Rental.LoadFromDataBase();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            Rental.LoggedEmplyee = Rental.FindEmployee(login);
            if (Rental.LoggedEmplyee != null)
                label1.Text = Rental.LoggedEmplyee.ToString();
            else
                label1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
        private Control[] menuItems;


        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            search.CloseWindows();
            try
            {
                Rental.SaveToBase();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

            }


        }
        private void SetMenuVisibility(bool val)
        {
            foreach (var it in menuItems)
                it.Visible = val;
        }
        void BackToMenu(object sender, EventArgs e)
        {
            SetMenuVisibility(true);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetMenuVisibility(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            search.SearchingCars = true;
            search.Visible = true;
            SetMenuVisibility(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            search.SearchingCars = false;
            search.Visible = true;
            SetMenuVisibility(false);
        }
    }
}
