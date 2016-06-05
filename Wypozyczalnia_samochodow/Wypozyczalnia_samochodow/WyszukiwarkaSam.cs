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
        private List<Car> foundCars;
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
        private List<Form3> CarWindows = new List<Form3>();
        private void button2_Click(object sender, EventArgs e)
        {
            var temp = new Form3();
            temp.newCar = true;
            temp.Show();
            CarWindows.Add(temp);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            var temp = new Form3();
            temp.newCar = false;
            temp.Show();
            temp.FormClosing +=ClosedWindow;
            CarWindows.Add(temp);
        }
        public void closeWindows()
        {
            for (int i = CarWindows.Count - 1; i >= 0; i--)
                CarWindows[i].Close();
        }
        private void ClosedWindow(object sender, EventArgs e)
        {
            CarWindows.Remove((Form3)sender);
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foundCars = Rental.findCars(textBox1.Text, textBox2.Text);
            foreach (var it in foundCars)
            {
                listBox1.Items.Add(it);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
