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
        private List<Car> foundCars = new List<Car>();
        private List<Customer> foundCustomers = new List<Customer>();
        private bool _searchingCars;
        public bool SearchingCars
        {
            set
            {
                _searchingCars = value;
                labelBrand.Visible = value;
                label2.Visible = value;
                labelName.Visible = !value;
                labelLastName.Visible = !value;
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
            Clear();
            Visible = false;
        }
        private void Clear()
        {
            textBoxNameBrnd.Text = "";
            textBoxLastNameModel.Text = "";
            listBox.Items.Clear();
            foundCars.Clear();
            foundCustomers.Clear();
        }
        private List<CarView> CarWindows = new List<CarView>();
        private List<CustomerView> CustomerWindows = new List<CustomerView>();
        private void button2_Click(object sender, EventArgs e)
        {
            if (SearchingCars == true)
            {
                var temp = new CarView();
                temp.newCar = true;
                temp.Show();
                CarWindows.Add(temp);
            }
            else
            {
                var temp = new CustomerView();
                temp.newCustomer = true;
                temp.Show();
                CustomerWindows.Add(temp);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex < 0 || (SearchingCars && !foundCars[listBox.SelectedIndex].Availability))
                return;
            if (SearchingCars == true)
            {

                var temp = new CarView(foundCars[listBox.SelectedIndex]);
                temp.newCar = false;
                temp.Show();
                temp.FormClosing += ClosedCarWindow;
                CarWindows.Add(temp);
            }
            else
            {
                var temp = new CustomerView(foundCustomers[listBox.SelectedIndex]);
                temp.newCustomer = false;
                temp.Show();
                temp.FormClosing += ClosedCustomerWindows;
                CustomerWindows.Add(temp);
            }
        }
        public void CloseWindows()
        {
            for (int i = CarWindows.Count - 1; i >= 0; i--)
                CarWindows[i].Close();
            for (int i = CustomerWindows.Count - 1; i >= 0; i--)
                CustomerWindows[i].Close();
        }
        private void ClosedCarWindow(object sender, EventArgs e)
        {
            CarWindows.Remove((CarView)sender);
        }

        private void ClosedCustomerWindows(object sender, EventArgs e)
        {
            CustomerWindows.Remove((CustomerView)sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SearchingCars == true)
            {
                listBox.Items.Clear();
                foundCars = Rental.FindCars(textBoxNameBrnd.Text, textBoxLastNameModel.Text);
                foreach (var it in foundCars)
                {
                    listBox.Items.Add(it.ToString());
                }
            }
            else
            {
                listBox.Items.Clear();
                foundCustomers = Rental.FindCustomer(textBoxNameBrnd.Text, textBoxLastNameModel.Text);
                foreach (var it in foundCustomers)
                {
                    listBox.Items.Add(it.ToString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
