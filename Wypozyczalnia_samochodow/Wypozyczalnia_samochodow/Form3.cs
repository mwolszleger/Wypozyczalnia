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
        public bool newCar
        {
            get
            {
                return _newCar;
            }
            set
            {
                _newCar = value;
                textBox1.ReadOnly = !value;
                textBox3.ReadOnly = !value;
                textBox5.ReadOnly = !value;
                textBox10.ReadOnly = !value;
                textBox8.ReadOnly = !value;
                textBox2.ReadOnly = !value;
                textBox6.ReadOnly = !value;
                label12.Visible = !value;
                textBox11.Visible = !value;
                button1.Visible = !value;
                button2.Visible = !value;
                comboBox1.Enabled = value;
                comboBox2.Enabled = value;
               

            }
        }
        public Form3()
        {
            InitializeComponent();
        }
        
        
    }
}
