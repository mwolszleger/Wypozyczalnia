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
    public partial class Form4 : Form
    {
        private bool _newCustomer;
        private bool _readOnly;
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
                button1.Visible = !value;
                button2.Visible = !value;

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
                textBox7.ReadOnly = value;
                textBox4.ReadOnly = value;
            }
        }

        public Form4()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
