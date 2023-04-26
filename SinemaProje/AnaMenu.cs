using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinemaProje
{
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }
        private void AnaMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Giris f1 = new Giris();
            this.Hide();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Filmler f1 = new Filmler();
            this.Hide();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BiletAl f1 = new BiletAl();
            this.Hide();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Giris f1 = new Giris();
            this.Hide();
            f1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Seanslar f1 = new Seanslar();
            this.Hide();
            f1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Salonlar f1 = new Salonlar();
            this.Hide();
            f1.Show();
        }
    }
}
