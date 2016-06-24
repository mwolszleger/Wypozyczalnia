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
    public partial class Form1 : Form
    {
        private Form2 f;
        public Form1()
        {
            InitializeComponent();
        }
        private void newUser(object sender, EventArgs e)
        {
            Show();       
            
        }
        private void buttonLog_Click(object sender, EventArgs e)
        {
            bool d = Rental.tryToLogIn(textBoxLogin.Text, textBoxPassword.Text);
            
            if (d)
            {
                f = new Form2(textBoxLogin.Text);
                f.FormClosed += newUser;
                f.Show();
                Hide();
            }
            clear();
        }
        private void clear()
        {
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
        }

    }
}
