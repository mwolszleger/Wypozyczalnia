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
    public partial class Form2 : Form
    {
        public Form2(string login)
        {
            InitializeComponent();
            menuItems = new Control[] { button1, button2, button4, label1 };
            wyszukiwarkaSam1.Closing += backToMenu;
          
            Rental.clearEverything();
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
            Rental.LoggedEmplyee = Rental.findEmployee(login);
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
            wyszukiwarkaSam1.closeWindows();
            Rental.SaveToBase();
            
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
            setMenuVisibility(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wyszukiwarkaSam1.searchingCars = true;
            wyszukiwarkaSam1.Visible = true;
            setMenuVisibility(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wyszukiwarkaSam1.searchingCars = false;
            wyszukiwarkaSam1.Visible = true;
            setMenuVisibility(false);
        }
    }
}
