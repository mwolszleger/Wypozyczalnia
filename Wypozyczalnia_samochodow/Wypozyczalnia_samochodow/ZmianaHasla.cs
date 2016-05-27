using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wypozyczalnia_samochodow
{
    public partial class ZmianaHasla : UserControl
    {
      
        public ZmianaHasla()
        {
            InitializeComponent();
            controls = new Control[] { textBox1, textBox2, textBox3, label1, label2, label3, button1, button2 };
        }
        public event EventHandler Closing;
        protected virtual void OnClosing(EventArgs e)
        {
            EventHandler handler = Closing;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        private Control[] controls;
        private void zmianaHasla1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OnClosing(new EventArgs());
            Visible = false;
            clear();
        }
        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
