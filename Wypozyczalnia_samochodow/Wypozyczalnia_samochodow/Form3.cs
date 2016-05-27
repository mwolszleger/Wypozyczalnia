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
        public bool newCar
        {
            get
            {
                return _newCar;
            }
            set
            {
                _newCar = value;
                readOnly = !value;
                button1.Visible = !value;
                button2.Visible = !value;
                textBox10.ReadOnly = !value;

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
                textBox1.ReadOnly = value;
                textBox3.ReadOnly = value;
                textBox5.ReadOnly = value;
                
                textBox8.ReadOnly = value;
                textBox2.ReadOnly = value;
                textBox6.ReadOnly = value;
                label12.Visible = value;
                textBox11.Visible =value;
                comboBox1.Enabled = !value;
                comboBox2.Enabled = !value;


            }
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            readOnly = false;
            button1.Visible = false;
            button2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!newCar)
            {
                readOnly = true;
                button1.Visible = true;
                button2.Visible = true;
                label10.Visible = false;
                textBox9.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            label10.Visible = true;
            textBox9.Visible = true;
        }
    }
}
