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
            textBoxBrand.Text = car.brand;
            textBoxPrice.Text = car.price.ToString();
            textBoxYear.Text = car.year.ToString();
            if(car.climatisation)
                comboBoxClima.SelectedIndex = 0;
            else
                comboBoxClima.SelectedIndex = 1;
            textBoxColor.Text = car.color;
            textBoxPojemnosc.Text = car.engine.ToString();
            textBoxNumber.Text = car.registration;
            if (Rental.isCarAvailaible(car))
                textBoxAvailaible.Text = "tak";
            else
                textBoxAvailaible.Text = "nie";
            if(car.fuel==Fuels.Petrol)
                comboBoxFuel.SelectedIndex = 0;
            if (car.fuel == Fuels.Diesel)
                comboBoxFuel.SelectedIndex = 1;
            if (car.fuel == Fuels.Lpg)
                comboBoxFuel.SelectedIndex = 2;

        }
        private Dictionary<string, string> getCarData()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("model", textBoxModel.Text);
            d.Add("brand", textBoxBrand.Text);
            d.Add("color", textBoxColor.Text);
            d.Add("registration", textBoxNumber.Text);
            d.Add("price",textBoxPrice.Text);
            d.Add("year", textBoxYear.Text);
            if(comboBoxClima.SelectedIndex == 0)
                d.Add("climatisation","true");
            if (comboBoxClima.SelectedIndex == 1)
                d.Add("climatisation", "false");
            d.Add("engine", textBoxPojemnosc.Text);
            if (comboBoxClima.SelectedIndex == 0)
                d.Add("fuel","petrol");
            if (comboBoxClima.SelectedIndex == 1)
                d.Add("fuel","diesel");
            if (comboBoxClima.SelectedIndex == 2)
                d.Add("fuel","lpg");
            //d.Add("availability","true");
            return d;
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
                setCarData();
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

            if(!Rental.isCarAvailaible(car))
            {
                labelMessage.Text = "Nie można edytować samochodu wypożyczonego";
                return;
            }
            ReadOnly = false;
            buttonLend.Visible = false;
            buttonEdit.Visible = false;
            edition = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            clearMessage();
            if (!newCar && edition)
            {
                //edycja
                if (!CheckIfNotEmpty())
                {
                    labelMessage.Text = "Nie podano wszystkich danych";
                    return;
                }
                car.setCarData(getCarData());
                Rental.updateCar(car);
                resetViewAfterEdition();
                
            }
            if (!newCar && transaction)
            {
                Customer customer;
                try
                {
                    customer = Rental.findCustomer(Convert.ToUInt32(textBoxUserId.Text));
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
                Rental.addTransaction(Transaction);
                
                resetViewAfterTransaction();
            }
            if (newCar)
            {
                if (!CheckIfNotEmpty())
                {
                    labelMessage.Text = "Nie podano wszystkich danych";
                    return;
                }

                Car car = new Car(getCarData());
                Rental.addCar(car);
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
            if (!Rental.isCarAvailaible(car))
                return;
            buttonEdit.Visible = false;
            buttonLend.Visible = false;
            labelUseId.Visible = true;
            textBoxUserId.Visible = true;
            transaction = true;
        }

        private void numberValidation(object sender, EventArgs e)
        {
            if (ReadOnly|| ((TextBox)sender).Text=="")
                return;
            for (int i = 0; i < ((TextBox)sender).Text.Length; i++)
            {
                
                char z = ((TextBox)sender).Text[i];
                if (z >= '0' && z <= '9')
                    continue;
                else
                {
                    ((TextBox)sender).Text = ((TextBox)sender).Text.Remove(i--, 1);

                }
            }
            //ustawia kursor na koncu
           ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }
        private bool CheckIfNotEmpty()
        {
            return textBoxBrand.Text != "" && textBoxYear.Text != "" && textBoxModel.Text != "" && textBoxPojemnosc.Text != "" && textBoxNumber.Text != "" && textBoxPrice.Text != "" && textBoxColor.Text != "" && comboBoxClima.SelectedIndex >= 0 && comboBoxFuel.SelectedIndex >= 0;
        }
        private void clearMessage()
        {
            labelMessage.Text = "";
        }

        private void textBoxBrand_Enter(object sender, EventArgs e)
        {
            clearMessage();
        }

        private void stringValidation(object sender, EventArgs e)
        {
            //na pewno nie moze byc sredników i cudzysłowów, bo popsuje się w bazie, pewnie jakieś jeszcze ograniczenia tez powinny być
           
            if (ReadOnly)
                return;
            for (int i = 0; i < ((TextBox)sender).Text.Length; i++)
            {
                char z = ((TextBox)sender).Text[i];
                if (z == '\"' || z == ';')
                    ((TextBox)sender).Text = ((TextBox)sender).Text.Remove(i--,1);
            }
           //ustawia kursor na koncu
           ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);

        }

        private void registryNumberValidation(object sender, EventArgs e)
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
            if (Rental.isCarAvailaible(car))
            {
                labelMessage.Text="Auto nie jest wypożyczone";

            }
            else
            {
                var tr = Rental.findTransaction(car);
                tr.finish();
                Rental.updateTransaction(tr);
                labelMessage.Text = "Do zapłaty "+tr.price;
            }
        }
    }
    }
