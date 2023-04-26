using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinemaProje
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        OleDbConnection Aconnection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source =|DataDirectory|\\Database.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
            Aconnection.Open();
            OleDbCommand AccessCommand = new OleDbCommand();
            AccessCommand.Connection = Aconnection;
            string sqlText = "SELECT * FROM Users WHERE id=1";
            AccessCommand.CommandText = (sqlText);
            OleDbDataReader read = AccessCommand.ExecuteReader();
            read.Read();
            var username = read["user_name"].ToString();
            var password = read["password"].ToString();
            if (this.textBox1.Text == username && this.textBox2.Text == password)
            {
                AnaMenu main=new AnaMenu();
                main.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("Username or Password is incorrect !");
            }
            Aconnection.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
