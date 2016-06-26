using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Wypozyczalnia_samochodow
{
    public partial class CustomerView : Form
    {
        private bool _newCustomer;
        private bool _readOnly;
        private bool edition;
        private bool transaction;
        private Customer customer;

        public bool newCustomer
        {
            get
            {
                return _newCustomer;
            }
            set
            {
                _newCustomer = value;
                readOnly = !value;
                button.Visible = !value;
                button2.Visible = !value;
                label9.Visible = !value;
                textBox_ID.Visible = !value;
            }
        }
        public bool readOnly
        {
            get
            {
                return _readOnly;
            }
            set
            {
                _readOnly = value;
                textName.ReadOnly = value;
                textHouseNumber.ReadOnly = value;
                textPlace.ReadOnly = value;
                textCodeCity.ReadOnly = value;
                textLastName.ReadOnly = value;
                textFlatNumber.ReadOnly = value;
                textPhoneNumber.ReadOnly = value;
                textStreet.ReadOnly = value;
            }
        }

        public CustomerView()
        {
            InitializeComponent();
        }

        public CustomerView(Customer customer)
        {
            InitializeComponent();
            readOnly = true;
            this.customer = customer;
            SetCustomerData();
            textBox_ID.Text = customer.Id.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearMessage();
            if (!newCustomer && edition)
            {
                ResetViewAfterEdition();
                SetCustomerData();
            }
            else if (!newCustomer && transaction)
            {
                ResetViewAfterTransaction();
            }
            else
                Close();
        }

        private void ClearMessage()
        {
            label_text.Text = "";
        }

        private void SetCustomerData()
        {
            textName.Text = customer.Name;
            textLastName.Text = customer.Last_name;
            textStreet.Text = customer.Street;
            textHouseNumber.Text = customer.House_number.ToString();
            if (textFlatNumber.Text != "")
            {
                textFlatNumber.Text = customer.Flat_number.ToString();
            }
            textCodeCity.Text = customer.Code_town.ToString();
            textPlace.Text = customer.Place;
            textPhoneNumber.Text = customer.Phone_number.ToString();

        }

        private Dictionary<string, string> GetCustomerData()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("name", textName.Text);
            d.Add("last_name", textLastName.Text);
            d.Add("house_number", textHouseNumber.Text);
            if (textFlatNumber.Text != "")
            {
                d.Add("flat_number", textFlatNumber.Text);
            }
            d.Add("street", textStreet.Text);
            d.Add("code_town", textCodeCity.Text);
            d.Add("place", textPlace.Text);
            d.Add("phone_number", textPhoneNumber.Text);
            return d;
        }

        private bool CheckIfNotEmpty()
        {
            return textName.Text != "" && textLastName.Text != "" && textHouseNumber.Text != "" && textCodeCity.Text != "" && textPhoneNumber.Text != "" && textStreet.Text != "" && textPlace.Text != "";
        }

        private void ResetViewAfterEdition()
        {
            readOnly = true;
            button.Visible = true;
            button2.Visible = true;
            edition = false;
        }

        private void ResetViewAfterTransaction()
        {
            button.Visible = true;
            button2.Visible = true;
            transaction = false;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ClearMessage();

            if (!newCustomer && edition)
            {
                if (protect_code_city() && protect_phone_number() && Protect_name() && Protect_last_name() && Protect_place() && Protect_flat_number())
                {
                  
                    if (!CheckIfNotEmpty())
                    {
                        label_text.Text = "Nie podano wszystkich danych";
                        return;
                    }
                    Rental.UpdateCustomer(customer);
                    customer.SetCustomerData(GetCustomerData());
                    ResetViewAfterEdition();
                }
            }
            if (!newCustomer && transaction)
            {
                Car car;
                try
                {
                    car = Rental.FindCar(Convert.ToString(textBox_nr.Text));
                }
                catch (Exception ee)
                {
                    label_text.Text = "Brak auta o podanym numerze rejestracyjnym";
                    return;
                }
                if (car == null || !car.Availability)
                {
                    label_text.Text = "Brak auta o podanym numerze rejestracyjnym";
                    return;
                }
                if (!Rental.IsCarAvailaible(car))
                {
                    label_text.Text = "Auto jest już wypożyczone";
                    return;
                }
                var Transaction = new Transaction(car, customer);
                Rental.AddTransaction(Transaction);
                textBox_nr.ReadOnly = true;
                ResetViewAfterTransaction();
            }


            if (newCustomer)
            {
                if (protect_code_city() && protect_phone_number() && Protect_name() && Protect_last_name() && Protect_place() && Protect_flat_number())
                {
                    buttonOK.Visible = true;
                    if (!CheckIfNotEmpty())
                    {
                        label_text.Text = "Nie podano wszystkich danych";
                        return;
                    }

                    Customer customer = new Customer(GetCustomerData());
                    Rental.AddCustomer(customer);
                    readOnly = true;
                    label_text.Text = "Dodano";
                    buttonOK.Visible = false;
                }
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            edition = true;
            readOnly = false;
            button.Visible = false;
            button2.Visible = false;
            textBox_ID.Visible = false;
            label9.Visible = false;
        }

        private bool protect_phone_number()
        {
            string text = "^[0-9]{9}$";
            string input = textPhoneNumber.Text;

            if (!Regex.IsMatch(input, text))
            {
                MessageBox.Show("Nieprawidłowy numer telefonu", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool protect_code_city()
        {
            string text = "^[0-9]{2}-[0-9]{3}$";
            string input = textCodeCity.Text;
            if (!Regex.IsMatch(input, text))
            {
                MessageBox.Show("Nieprawidłowy kod miasta", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }
        private bool Protect_name()
        {
            string text = @"^[a-zA-ZżźćńółęąśŻŹĆĄŚĘŁÓŃ\s\-]+$";
            string input = textName.Text;
            if (!Regex.IsMatch(input, text))
            {
                MessageBox.Show("Nieprawidłowe imię", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool Protect_last_name()
        {
            string text = @"^[a-zA-ZżźćńółęąśŻŹĆĄŚĘŁÓŃ\s\-]+$";
            string input = textLastName.Text;
            if (!Regex.IsMatch(input, text))
            {
                MessageBox.Show("Nieprawidłowe nazwisko", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool Protect_place()
        {
            string text = @"^[a-zA-ZżźćńółęąśŻŹĆĄŚĘŁÓŃ\s\-]+$";
            string input = textPlace.Text;
            if (!Regex.IsMatch(input, text))
            {
                MessageBox.Show("Nieprawidłowe miasto", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool Protect_flat_number()
        {
            string text = "^[0-9]$";
            string input = textFlatNumber.Text;
            if (!Regex.IsMatch(input, text) && input != "")
            {
                MessageBox.Show("Nieprawidłowy numer mieszkania", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }
        private bool Protect_number()
        {
            string text = "^[0-9]$";
            string input = textBox_nr.Text;
            if (!Regex.IsMatch(input, text) && input != "")
            {
                MessageBox.Show("Nieprawidłowy numer domu", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }
        private void button_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button.Visible = false;
            transaction = true;
            label10.Visible = true;
            textBox_nr.Visible = true;
        }

    }
}
