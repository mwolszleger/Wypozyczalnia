using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wypozyczalnia_samochodow
{
    public partial class CarView : Form
    {
        private bool _newCar;
        private bool _readOnly;
        private bool edition;
        private bool transaction;
        private Car car;
        public bool newCar
        {
            get
            {
                return _newCar;
            }
            set
            {
                _newCar = value;
                buttonOK.Visible = value;
                ReadOnly = !value;
                buttonLend.Visible = !value;
                buttonEdit.Visible = !value;
                textBoxNumber.ReadOnly = !value;
                buttonReturn.Visible = !value;
                buttonRemove.Visible = !value;
            }
        }
        public bool ReadOnly
        {
            get
            {
                return _readOnly;
            }
            set
            {
                _readOnly = value;
                textBoxBrand.ReadOnly = value;
                textBoxYear.ReadOnly = value;
                textBoxPojemnosc.ReadOnly = value;

                textBoxPrice.ReadOnly = value;
                textBoxModel.ReadOnly = value;
                textBoxColor.ReadOnly = value;
                label12.Visible = value;
                textBoxAvailaible.Visible = value;
                comboBoxFuel.Enabled = !value;
                comboBoxClima.Enabled = !value;


            }
        }
        public CarView()
        {
            InitializeComponent();
        }
        public CarView(Car car)
        {
            InitializeComponent();
            ReadOnly = true;
            this.car = car;

            SetCarData();

        }
        private void SetCarData()
        {
            textBoxModel.Text = car.Model;
            textBoxBrand.Text = car.Brand;
            textBoxPrice.Text = car.Price.ToString();
            textBoxYear.Text = car.Year.ToString();
            if (car.Climatisation)
                comboBoxClima.SelectedIndex = 0;
            else
                comboBoxClima.SelectedIndex = 1;
            textBoxColor.Text = car.Color;
            textBoxPojemnosc.Text = car.Engine.ToString();
            textBoxNumber.Text = car.Registration;
            if (Rental.IsCarAvailaible(car))
                textBoxAvailaible.Text = "tak";
            else
                textBoxAvailaible.Text = "nie";
            if (car.Fuel == Fuels.Petrol)
                comboBoxFuel.SelectedIndex = 0;
            if (car.Fuel == Fuels.Diesel)
                comboBoxFuel.SelectedIndex = 1;
            if (car.Fuel == Fuels.Lpg)
                comboBoxFuel.SelectedIndex = 2;

        }
        private Dictionary<string, string> GetCarData()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("model", textBoxModel.Text);
            d.Add("brand", textBoxBrand.Text);
            d.Add("color", textBoxColor.Text);
            d.Add("registration", textBoxNumber.Text);
            d.Add("price", textBoxPrice.Text);
            d.Add("year", textBoxYear.Text);
            if (comboBoxClima.SelectedIndex == 0)
                d.Add("climatisation", "true");
            if (comboBoxClima.SelectedIndex == 1)
                d.Add("climatisation", "false");
            d.Add("engine", textBoxPojemnosc.Text);
            if (comboBoxFuel.SelectedIndex == 0)
                d.Add("fuel", "petrol");
            if (comboBoxFuel.SelectedIndex == 1)
                d.Add("fuel", "diesel");
            if (comboBoxFuel.SelectedIndex == 2)
                d.Add("fuel", "lpg");
            //d.Add("availability","true");
            return d;
        }
        private void buttonEnd_Click(object sender, EventArgs e)
        {
            ClearMessage();
            if (!newCar && edition)
            {
                resetViewAfterEdition();
                SetCarData();
            }
            else if (!newCar && transaction)
            {
                resetViewAfterTransaction();
                SetCarData();
            }
            else
                Close();
        }
        private void resetViewAfterTransaction()
        {
            newCar = false;
            transaction = false;
            labelUseId.Visible = false;
            textBoxUserId.Visible = false;
            buttonRemove.Visible = true;
            SetCarData();
        }
        private void resetViewAfterEdition()
        {
            ReadOnly = true;
            newCar = false;
            SetCarData();
            textBoxUserId.Visible = false;
            edition = false;
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {

            if (!Rental.IsCarAvailaible(car))
            {
                labelMessage.Text = "Nie można edytować samochodu wypożyczonego";
                return;
            }
            ReadOnly = false;
            buttonLend.Visible = false;
            buttonEdit.Visible = false;
            buttonOK.Visible = true;
            buttonRemove.Visible = false;
            buttonReturn.Visible = false;
            edition = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)

        {
            ClearMessage();
            if (!newCar && edition)
            {
                if (!Protect()) return;
                car.setCarData(GetCarData());
                Rental.UpdateCar(car);
                resetViewAfterEdition();

            }
            if (!newCar && transaction)
            {
                Customer customer;
                try
                {
                    customer = Rental.FindCustomer(Convert.ToUInt32(textBoxUserId.Text));
                }
                catch (Exception ee)
                {
                    labelMessage.Text = "Brak użytkownika o podanym identyfikatorze";
                    return;
                }
                if (customer == null)
                {
                    labelMessage.Text = "Brak użytkownika o podanym identyfikatorze";
                    return;
                }
                var Transaction = new Transaction(car, customer);
                Rental.AddTransaction(Transaction);

                resetViewAfterTransaction();
            }
            if (newCar)
            {
                if (!Protect()) return;

                Car car = new Car(GetCarData());
                Rental.AddCar(car);
                ReadOnly = true;
                labelMessage.Text = "Dodano";
                label12.Visible = false;
                textBoxAvailaible.Visible = false;
                textBoxNumber.ReadOnly = true;
                buttonOK.Visible = false;
            }
        }

        private void buttonLend_Click(object sender, EventArgs e)
        {
            if (!Rental.IsCarAvailaible(car))
                return;
            buttonEdit.Visible = false;
            buttonLend.Visible = false;
            labelUseId.Visible = true;
            buttonOK.Visible = true;
            buttonRemove.Visible = false;
            buttonReturn.Visible = false;
            textBoxUserId.Visible = true;
            transaction = true;

        }


        private bool CheckIfNotEmpty()
        {
            bool a = textBoxBrand.Text != "" && textBoxYear.Text != "" && textBoxModel.Text != "" && textBoxPojemnosc.Text != "" && textBoxNumber.Text != "" && textBoxPrice.Text != "" && textBoxColor.Text != "" && comboBoxClima.SelectedIndex >= 0 && comboBoxFuel.SelectedIndex >= 0;
            if (!a)
            {
                MessageBox.Show("Nie podano wszytskich danych", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return a;

        }
        private void ClearMessage()
        {
            labelMessage.Text = "";
        }

        private void textBoxBrand_Enter(object sender, EventArgs e)
        {
            ClearMessage();
        }

        private bool Protect_string(string textToCheck, string message, bool numbersPossible = false)
        {
            string text = @"^[a-zA-ZżźćńółęąśŻŹĆĄŚĘŁÓŃ\s\-]+$";
            if (numbersPossible)
                text = @"^[0-9a-zA-ZżźćńółęąśŻŹĆĄŚĘŁÓŃ\s\-]+$";
            string input = textToCheck;
            if (textToCheck.Length > 30 || !Regex.IsMatch(input, text))
            {
                MessageBox.Show(message, "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool ProtectDecimal(string textToCheck, string message)
        {
            decimal temp;
            if (decimal.TryParse(textToCheck, out temp) && temp >= 0)
            {
                return true;
            }
            MessageBox.Show(message, "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        private bool ProtectYear(string text)
        {

            if (text.Length == 4 && text[0] >= '1' && text[0] <= '2' && text[1] >= '0' && text[1] <= '9' && text[2] >= '0' && text[2] <= '9' && text[3] >= '0' && text[3] <= '9')
                return true;
            MessageBox.Show("Nieprawidłowy rok produkcji", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        private bool ProtectRegistration(string number)
        {

            if (Rental.ExistsRegistryNumber(number) && newCar)
            {
                MessageBox.Show("Numer rejestracyjny już istnieje w bazie", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (number.Length > 30)
            {
                MessageBox.Show("Nieprawidłowy numer rejestracyjny", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool Protect()
        {
            return Protect_string(textBoxBrand.Text, "Nieprawidłowa marka", true) &&
                Protect_string(textBoxModel.Text, "Nieprawidłowy model", true) &&
                Protect_string(textBoxColor.Text, "Nieprawidłowy kolor", true) &&
                ProtectDecimal(textBoxPrice.Text, "Niepraidłowa cena") &&
                ProtectDecimal(textBoxPojemnosc.Text, "Nieprawidłowa pojemność silnika") &&
                ProtectYear(textBoxYear.Text) &&
                ProtectRegistration(textBoxNumber.Text) &&
                CheckIfNotEmpty();
        }
        private void RegistryNumberValidation(object sender, EventArgs e)
        {

            if (ReadOnly)
                return;
            for (int i = 0; i < ((TextBox)sender).Text.Length; i++)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
                char z = ((TextBox)sender).Text[i];
                if (z >= 'A' && z <= 'Z')
                    continue;
                else if (z >= '0' && z <= '9')
                    continue;
                else
                {
                    ((TextBox)sender).Text = ((TextBox)sender).Text = ((TextBox)sender).Text.Remove(i--, 1);
                }


            }
            //ustawia kursor na koncu
           ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            if (Rental.IsCarAvailaible(car))
            {
                labelMessage.Text = "Auto nie jest wypożyczone";

            }
            else
            {
                var tr = Rental.FindTransaction(car);
                tr.Finish();
                Rental.UpdateTransaction(tr);
                labelMessage.Text = "Do zapłaty " + tr.Price;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Rental.IsCarAvailaible(car))
            {
                labelMessage.Text = "Nie można usunąć samochodu wypożyczonego";
                return;
            }

            car.Availability = false;
            Rental.UpdateCar(car);
            buttonLend.Visible = false;
            buttonEdit.Visible = false;
            buttonReturn.Visible = false;
            buttonRemove.Visible = false;
        }


    }
}
