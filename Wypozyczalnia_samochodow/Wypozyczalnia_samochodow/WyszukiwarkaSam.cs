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
    public partial class WyszukiwarkaSam : UserControl
    {
        public WyszukiwarkaSam()
        {
            InitializeComponent();
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

        private void button4_Click(object sender, EventArgs e)
        {
            OnClosing(new EventArgs());
            Visible = false;
        }
    }
}
