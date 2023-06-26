using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace juegocochesSO
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form jugador1 = new Form1();
            jugador1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form jugador2 = new Form2();
            jugador2.Show();
        }
    }
}
