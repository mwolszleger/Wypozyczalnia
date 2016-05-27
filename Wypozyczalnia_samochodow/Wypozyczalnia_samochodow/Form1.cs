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
        void newUser(object sender, EventArgs e)
        {
            Show();          
            
        }
        private void buttonLog_Click(object sender, EventArgs e)
        {
            f = new Form2();
            f.LoggingOut += newUser;
            f.Show();
            Hide();
        }

    }
}
