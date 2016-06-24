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
    public partial class Form4 : Form
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

        public Form4()
        {
            InitializeComponent();
        }

        public Form4(Customer customer)
        {
            InitializeComponent();
            readOnly = true;
            this.customer = customer;
            setCustomerData();
            textBox_ID.Text = customer.id.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clearMessage();
            if (!newCustomer && edition)
            {
                resetViewAfterEdition();
                setCustomerData();
            }
            else if (!newCustomer && transaction)
            {
                resetViewAfterTransaction();
            }
            else
                Close();
        }

        private void clearMessage()
        {
            label_text.Text = "";
        }

        private void setCustomerData()
        {
            textName.Text = customer.name;
            textLastName.Text = customer.last_name;
            textStreet.Text = customer.street;
            textHouseNumber.Text = customer.house_number.ToString();
            if (textFlatNumber.Text != "")
            {
                textFlatNumber.Text = customer.flat_number.ToString();
            }
            textCodeCity.Text = customer.code_town.ToString();
            textPlace.Text = customer.place;
            textPhoneNumber.Text = customer.phone_number.ToString();

        }

        private Dictionary<string, string> getCustomerData()
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

        private void resetViewAfterEdition()
        {
            readOnly = true;
            button.Visible = true;
            button2.Visible = true;
            edition = false;
        }

        private void resetViewAfterTransaction()
        {
            button.Visible = true;
            button2.Visible = true;
            transaction = false;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            clearMessage();
            
                if (!newCustomer && edition)
                {
                    if (protect_code_city() && protect_phone_number() && protect_name() && protect_last_name() && protect_place()&& protect_flat_number())
                    {
                    //edycja
                    if (!CheckIfNotEmpty())
                    {
                        label_text.Text = "Nie podano wszystkich danych";
                        return;
                    }
                    Rental.updateCustomer(customer);
                    customer.setCustomerData(getCustomerData());

                    resetViewAfterEdition();
                }
                if (!newCustomer && transaction)
                {
                    resetViewAfterTransaction();
                }
            }
         
                if (newCustomer)
                {
                    if (protect_code_city()&& protect_phone_number()&& protect_name()&&protect_last_name() && protect_place()&& protect_flat_number())
                    {
                    buttonOK.Visible = true;
                    if (!CheckIfNotEmpty())
                    {
                        label_text.Text = "Nie podano wszystkich danych";
                        return;
                    }

                    Customer customer = new Customer(getCustomerData());
                    Rental.addCustomer(customer);
                    readOnly = true;
                    label_text.Text = "Dodano";
                    buttonOK.Visible = false;
                }
            }

        }
        private void stringValidation(object sender, EventArgs e)
        {
            //na pewno nie moze byc sredników i cudzysłowów, bo popsuje się w bazie, pewnie jakieś jeszcze ograniczenia tez powinny być

            if (_readOnly)
                return;
            for (int i = 0; i < ((TextBox)sender).Text.Length; i++)
            {
                char z = ((TextBox)sender).Text[i];
                if (z == '\"' || z == ';')
                    ((TextBox)sender).Text = ((TextBox)sender).Text.Remove(i--, 1);
            }
            //ustawia kursor na koncu
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);

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
           if(! Regex.IsMatch(input, text))
           {
                MessageBox.Show("Nieprawidłowy kod miasta", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
           }
           return true;

        }
        private bool protect_name()
        {
            string text = @"^[a-zA-Z]+$";
            string input = textName.Text;
          if(!Regex.IsMatch(input, text ))
          {
              MessageBox.Show("Nieprawidłowe imie", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
              return false;
          }
          return true;
        }
        private bool protect_last_name()
        {
            string text = @"^[a-zA-Z]+$";
            string input = textName.Text;
            if (!Regex.IsMatch(input, text))
            {
                MessageBox.Show("Nieprawidłowe nazwisko", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool protect_place()
        {
            string text = @"^[a-zA-Z]+$";
            string input = textName.Text;
            if (!Regex.IsMatch(input, text))
            {
                MessageBox.Show("Nieprawidłowe miasto", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool protect_flat_number()
        {
          string text = "^[0-9]$";
            string input = textFlatNumber.Text;
           if(! Regex.IsMatch(input, text) && input!="")
           {
                MessageBox.Show("Nieprawidłowy numer mieszkania", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
           }
           return true;

        }

    }
}
