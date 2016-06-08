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
    public partial class Form3 : Form
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
                ReadOnly = !value;
                buttonLend.Visible = !value;
                buttonEdit.Visible = !value;
                textBoxNumber.ReadOnly = !value;

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
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(Car car)
        {
            InitializeComponent();
            ReadOnly = true;
            this.car = car;

            setCarData();

        }
        private void setCarData()
        {
            textBoxModel.Text = car.model;
        }
        private void buttonEnd_Click(object sender, EventArgs e)
        {
            clearMessage();
            if (!newCar && edition)
            {
                resetViewAfterEdition();
                setCarData();
            }
            else if (!newCar && transaction)
            {
                resetViewAfterTransaction();
            }
            else
                Close();
        }
        private void resetViewAfterTransaction()
        {
            buttonLend.Visible = true;
            buttonEdit.Visible = true;
            labelUseId.Visible = false;
            textBoxUserId.Visible = false;
            transaction = false;
        }
        private void resetViewAfterEdition()
        {
            ReadOnly = true;
                buttonLend.Visible = true;
                buttonEdit.Visible = true;
                labelUseId.Visible = false;
                textBoxUserId.Visible = false;
                edition = false;
            }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
           
            ReadOnly = false;
            buttonLend.Visible = false;
            buttonEdit.Visible = false;
            edition = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!newCar&&edition)
            {
                //edycja
                if (!CheckIfNotEmpty())
                {
                    labelMessage.Text = "Nie podano wszystkich danych";
                    return;
                }

                resetViewAfterEdition();
            }
            if (!newCar && transaction)
            {
                resetViewAfterTransaction();
            }
            if (newCar)
            {
                Dictionary<string, string> d=new Dictionary<string, string>();
                d.Add("model", textBoxModel.Text);
                Car car = new Car(d);
                Rental.addCar(car);
            }
        }

        private void buttonLend_Click(object sender, EventArgs e)
        {
            buttonEdit.Visible = false;
            labelUseId.Visible = true;
            textBoxUserId.Visible = true;
            transaction = true;
        }

        private void ValidateNumber(object sender, EventArgs e)
        {
            //do poprawy, jeszcze mogą być ułamki
            //trzeba rozdzielic walidację liczb i nru użytkownika (w drugim tylko calkowite)
            string text = ((TextBox)sender).Text;
            if (ReadOnly||text == "")
                return;
            if (text[text.Length - 1] < '0' || text[text.Length - 1] > '9')
                ((TextBox)sender).Text = ((TextBox)sender).Text.Substring(0, text.Length - 1);
        }
        private bool CheckIfNotEmpty()
        {
            return textBoxBrand.Text != "" && textBoxYear.Text != "" && textBoxModel.Text != "" && textBoxPojemnosc.Text != "" && textBoxNumber.Text != "" && textBoxPrice.Text != "" && textBoxColor.Text != "" &&comboBoxClima.SelectedIndex>=0&&comboBoxFuel.SelectedIndex>=0;
        }
        private void clearMessage()
        {
            labelMessage.Text = "";
        }

        private void textBoxBrand_Enter(object sender, EventArgs e)
        {
            clearMessage();
        }
    }
}
