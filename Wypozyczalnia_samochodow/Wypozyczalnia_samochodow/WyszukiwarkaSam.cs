using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wypozyczalnia_samochodow
{
    public partial class WyszukiwarkaSam : UserControl
    {
        public WyszukiwarkaSam()
        {
            InitializeComponent();
            
        }
 
        public event EventHandler Closing;
        private List<Car> foundCars=new List<Car>();
        private List<Customer> foundCustomer=new List<Customer>();
        private bool _searchingCars;
        public bool searchingCars
        {
            set
            {
                _searchingCars = value;
                label1.Visible = value;
                label2.Visible = value;
                label3.Visible = !value;
                label4.Visible = !value;
            }

            get
            {
                return _searchingCars;
            }
        }
       
        protected virtual void OnClosing(EventArgs e)
        {
            EventHandler handler = Closing;
            if (handler != null)
            {
                handler(this, e);
            }
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            OnClosing(new EventArgs());
            clear();
            Visible = false;
        }
        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            listBox1.Items.Clear();
            foundCars.Clear();
            foundCustomer.Clear();
        }
        private List<Form3> CarWindows = new List<Form3>();
        private List<Form4> CustomerWindows = new List<Form4>();
        private void button2_Click(object sender, EventArgs e)
        {
            if (searchingCars == true)
            {
                var temp = new Form3();
                temp.newCar = true;
                temp.Show();
                CarWindows.Add(temp);
            }
            else
            {
                var temp = new Form4();
                temp.newCustomer = true;
                temp.Show();
                CustomerWindows.Add(temp);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
                return;
            if (searchingCars == true)
            {
                
                var temp = new Form3(foundCars[listBox1.SelectedIndex]);
                temp.newCar = false;
                temp.Show();
                temp.FormClosing += ClosedCarWindow;
                CarWindows.Add(temp);
            }
            else
            {
                var temp = new Form4();
                temp.newCustomer = false;
                temp.Show();
                temp.FormClosing += ClosedCustomerWindows;
                CustomerWindows.Add(temp);
            }
        }
        public void closeWindows()
        {
            for (int i = CarWindows.Count - 1; i >= 0; i--)
                CarWindows[i].Close();
            for (int i = CustomerWindows.Count - 1; i >= 0; i--)
                CustomerWindows[i].Close();
        }
        private void ClosedCarWindow(object sender, EventArgs e)
        {
            CarWindows.Remove((Form3)sender);
        }

        private void ClosedCustomerWindows(object sender, EventArgs e)
        {
            CustomerWindows.Remove((Form4)sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (searchingCars==true)
            {
                listBox1.Items.Clear();
                foundCars = Rental.findCars(textBox1.Text, textBox2.Text);
                foreach (var it in foundCars)
                {
                    listBox1.Items.Add(it.ToString());
                }
            }
            else
            {
                listBox1.Items.Clear();
                foundCustomer = Rental.findCustomers(textBox1.Text, textBox2.Text);
                foreach (var it in foundCustomer)
                {
                    listBox1.Items.Add(it);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox1.Text = " ";
            textBox2.Text = " ";
        }
    }
}
