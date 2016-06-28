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
    public partial class LogInWindow : Form
    {
        private MainWindow f;
        public LogInWindow()
        {
            InitializeComponent();
        }
        private void NewUser(object sender, EventArgs e)
        {
            Show();

        }
        private void buttonLog_Click(object sender, EventArgs e)
        {
            bool d = Rental.TryToLogIn(textBoxLogin.Text, textBoxPassword.Text);

            if (d)
            {
                f = new MainWindow(textBoxLogin.Text);
                f.FormClosed += NewUser;
                f.Show();
                Hide();
            }
            Clear();
        }
        private void Clear()
        {
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
        }

    }
}
